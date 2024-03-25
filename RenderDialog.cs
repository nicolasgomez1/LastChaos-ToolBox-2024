using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using SlimDX;
using SlimDX.Direct3D9;

namespace LastChaos_ToolBox_2024
{
	// SOURCE: Who knows.
	public partial class RenderDialog : Form, IDisposable
	{
		private static Main pMain;
		private tMeshContainer pMeshContainer = new tMeshContainer();
		private static tMeshContainer pMesh;
		private readonly ASCIIEncoding pEnc = new ASCIIEncoding();
		private Direct3D pDirect3D;
		private Device pDevice;
		private List<tMesh> pModel;
		private float fZoom, fUpDown, fRotation;
		//private tTexture pLCTexture;
		private Vector3 vecCameraPosition = new Vector3(0.0f, -2.0f, 4f);
		private Vector3 vecEntityPosition = new Vector3(0f, 0.0f, 0.0f);
		private static string pstrFilePath;

		public RenderDialog(Main mainForm)
		{
			InitializeComponent();
			pMain = mainForm;
		}

		private void RenderDialog_Load(object sender, EventArgs e)
		{
			timerRender.Start();

			this.FormClosing += RenderDialog_FormClosing;
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			panel3DView.MouseWheel += panel3DView_Zoom;

			InitializeDevice();
		}

		private void DisposeModels()
		{
			if (pModel != null)
			{
				foreach (var model in pModel)
					model.Dispose();

				pModel.Clear();
			}

			pDirect3D.Dispose();
		}

		public void SetModel(string strFilePath, string strEntityDistance, int nWearingPosition)
		{
			DisposeModels();

			if (strEntityDistance == "small")
				fUpDown = -0.345f;
			else if (strEntityDistance == "big")
				fUpDown = -1.5f;

			pstrFilePath = strFilePath;

			CameraPositioning();

			MakeLCModels(strFilePath, nWearingPosition);
		}

		private void RenderDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (pModel != null)
			{
				foreach (var model in pModel)
					model?.Dispose();

				pModel = null;
			}

			pDevice?.Dispose();
			pDevice = null;

			pMeshContainer = null;
		}

		private void panel3DView_Zoom(object sender, MouseEventArgs e)
		{
			if (ModifierKeys.HasFlag(Keys.Control))
			{
				fUpDown += Math.Sign(e.Delta) * 0.2f;
				fUpDown = Math.Max(-5, Math.Min(5.0f, fUpDown));
			}
			else if (ModifierKeys.HasFlag(Keys.Shift))
			{
				fRotation += Math.Sign(e.Delta) * 0.1f;
				fRotation = fRotation % 360;
			}
			else
			{
				fZoom += Math.Sign(e.Delta);
				fZoom = Math.Max(-0.1f, Math.Min(17.0f, fZoom));
			}
		}

		public class tMesh : IDisposable
		{
			public Mesh MeshData;
			public Texture TexData;

			public tMesh(Mesh mesh, Texture texture)
			{
				MeshData = mesh;
				TexData = texture;
			}

			public void Dispose()
			{
				Dispose(true);
				GC.SuppressFinalize(this);
			}

			protected virtual void Dispose(bool disposing)
			{
				if (disposing)
				{
					MeshData?.Dispose();
					TexData?.Dispose();
				}
			}
		}

		public enum texFormat
		{
			RGB,
			ARGB,
			DXT1,
			DXT3,
			UNKNOWN
		}

		public class tHeader
		{
			public int AnimOffset { get; set; }

			public uint Bits { get; set; }

			public byte[] DataChunk { get; set; }

			public string Format { get; set; }

			public uint Height { get; set; }

			public uint MipMap { get; set; }

			public uint Shift { get; set; }

			public uint Unknown { get; set; }

			public int Version { get; set; }

			public byte[] VersionChunk { get; set; }

			public uint Width { get; set; }
		}

		public class tTexture
		{
			public tHeader Header { get; set; }

			public byte[][] imageData { get; set; }
		}

		public class Tex
		{
			public static tTexture lcTex;

			public static texFormat GetFormat()
			{
				texFormat texFormat = texFormat.UNKNOWN;

				if (lcTex.Header.Format == "FRMC")
					return (int)lcTex.Header.Bits == 4 || (int)lcTex.Header.Bits == 13 ? texFormat.DXT1 : texFormat.DXT3;

				if (!(lcTex.Header.Format == "FRMS"))
					return texFormat;

				return (int)lcTex.Header.Bits == 0 || (int)lcTex.Header.Bits == 2 ? texFormat.RGB : texFormat.ARGB;
			}

			public static Bitmap makeRGB(byte[] data2, int width, int height)
			{
				List<byte> source = new List<byte>();
				int index = 0;
				while (index < data2.Length)
				{
					source.Add(data2[index + 2]);
					source.Add(data2[index + 1]);
					source.Add(data2[index]);
					source.Add(byte.MaxValue);
					index += 4;
				}

				try
				{
					Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
					BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
					Marshal.Copy(source.ToArray(), 0, bitmapdata.Scan0, source.Count<byte>());
					bitmap.UnlockBits(bitmapdata);
					return bitmap;
				}
				catch
				{
					return new Bitmap(width, height);
				}
			}

			public static Bitmap makeRGB8(byte[] data2, int width, int height)
			{
				List<byte> source = new List<byte>();
				int index = 0;
				while (index < data2.Length)
				{
					source.Add(data2[index + 1]);
					source.Add(data2[index]);
					source.Add(data2[index + 2]);
					index += 3;
				}

				try
				{
					Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
					BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
					Marshal.Copy(source.ToArray(), 0, bitmapdata.Scan0, source.Count<byte>());
					bitmap.UnlockBits(bitmapdata);
					return bitmap;
				}
				catch
				{
					return new Bitmap(width, height);
				}
			}

			public static void ReadFile(string FileName)
			{
				ASCIIEncoding asciiEncoding = new ASCIIEncoding();
				FileStream fileStream = new FileStream(FileName, FileMode.Open);
				BinaryReader b = new BinaryReader((Stream)fileStream);
				lcTex = new tTexture();
				lcTex.Header = new tHeader();
				lcTex.Header.VersionChunk = b.ReadBytes(4);
				lcTex.Header.Version = b.ReadInt32();
				lcTex.Header.DataChunk = b.ReadBytes(4);
				lcTex.Header.Width = b.ReadUInt32() ^ 303316286U;
				lcTex.Header.Shift = b.ReadUInt32() ^ 1431797889U;
				lcTex.Header.Height = b.ReadUInt32() ^ 2560279492U;
				lcTex.Header.MipMap = b.ReadUInt32() ^ 3688695303U;
				lcTex.Header.Bits = b.ReadUInt32() ^ 505432394U;
				lcTex.Header.Unknown = b.ReadUInt32() ^ 1633913997U;
				lcTex.Header.Format = asciiEncoding.GetString(b.ReadBytes(4));
				lcTex.Header.AnimOffset = b.ReadInt32();
				lcTex.Header.Width = Shift(lcTex.Header.Width, lcTex.Header.Shift);
				lcTex.Header.Height = Shift(lcTex.Header.Height, lcTex.Header.Shift);

				if (lcTex.Header.Format == "FRMC")
					ReadFRMC(lcTex, b);
				else if (lcTex.Header.Format == "FRMS")
					ReadFRMS(lcTex, b);

				fileStream.Close();
			}

			/*private static void ReadFRMC(tTexture lcTex, BinaryReader b)
			{
				lcTex.imageData = new byte[(int)lcTex.Header.MipMap][];
				for (int index = 0; (long)index < (long)lcTex.Header.MipMap; ++index)
					lcTex.imageData[index] = b.ReadBytes(b.ReadInt32());
			}*/
			private static void ReadFRMC(tTexture lcTex, BinaryReader b)
			{
				try
				{
					int mipMapCount = (int)lcTex.Header.MipMap;

					if (mipMapCount >= 0)
					{
						lcTex.imageData = new byte[mipMapCount][];

						for (int index = 0; index < mipMapCount; ++index)
						{
							if (b.BaseStream.Length - b.BaseStream.Position >= sizeof(int))
							{
								int mipMapSize = b.ReadInt32();

								if (mipMapSize >= 0 && b.BaseStream.Length - b.BaseStream.Position >= mipMapSize)
								{
									lcTex.imageData[index] = b.ReadBytes(mipMapSize);
								}
								else
								{
									pMain.Logger("Render Dialog > Mipmap size out of range of index: " + index + " (SMC: " + pstrFilePath + ").", Color.Red);
									lcTex.imageData = null;
									break;
								}
							}
							else
							{
								pMain.Logger("Render Dialog > Index of Mipmap out of range (SMC: " + pstrFilePath + ").", Color.Red);
								lcTex.imageData = null;
								break;
							}
						}
					}
					else
					{
						pMain.Logger("Render Dialog > Mipmap number out of range (SMC: " + pstrFilePath + ").", Color.Red);
						lcTex.imageData = null;
					}
				}
				catch (Exception ex)
				{
					pMain.Logger("Render Dialog > " + ex.Message + "(SMC: " + pstrFilePath + ").", Color.Red);
					lcTex.imageData = null;
				}
			}

			private static void ReadFRMS(tTexture lcTex, BinaryReader b)
			{
				int num = (int)lcTex.Header.Width * (int)lcTex.Header.Height;
				int count = (int)lcTex.Header.Bits == 0 || (int)lcTex.Header.Bits == 2 ? num * 3 : num * 4;
				lcTex.imageData = new byte[(int)lcTex.Header.MipMap][];

				for (int index = 0; (long)index < (long)lcTex.Header.MipMap; ++index)
					lcTex.imageData[index] = b.ReadBytes(count);
			}

			private static uint Shift(uint Val, uint Shifter)
			{
				Val >>= (int)Shifter;
				return Val;
			}
		}

		public struct smcObject
		{
			public string Name;
			public string Texture;

			public smcObject(string Name, string Texture)
			{
				this.Name = Name;
				this.Texture = Texture;
			}
		}

		public struct smcMesh
		{
			public string FileName;
			public List<smcObject> Object;

			public smcMesh(string FileName)
			{
				this.FileName = FileName;
				Object = new List<smcObject>();
			}
		}

		public class SMCReader
		{
			public static List<smcMesh> ReadFile(string FileName)
			{
				string[] strArray1 = Path.GetDirectoryName(FileName).Split('\\');
				string str = "";
				bool flag = true;
				for (int index = 0; index < (strArray1).Count<string>(); ++index)
				{
					if (strArray1[index].ToUpper() == "DATA")
						flag = false;
					if (flag)
						str = str + strArray1[index] + "\\";
				}

				List<string> list = (File.ReadAllLines(FileName)).ToList<string>();
				for (int index = list.Count<string>() - 1; index >= 0; --index)
				{
					list[index] = list[index].Trim();
					list[index] = list[index].Replace("TFNM", "");
					if (list[index].Contains("{") || list[index].Contains("}") || (list[index].Contains(",") || list[index].Contains("NAME")) || (list[index].Contains("COLISION") || list[index].Contains("TEXTURES") || (list[index].Contains("ANIM") || list[index].Contains("SKELETON"))) || list[index].Contains("_TAG"))
						list.RemoveAt(index);
				}

				int index1 = -1;
				List<smcMesh> smcMeshList = new List<smcMesh>();
				for (int index2 = 0; index2 < list.Count(); ++index2)
				{
					if (list[index2].Substring(0, 4) == "MESH")
					{
						++index1;
						string[] strArray2 = list[index2].Split('"');
						smcMeshList.Add(new smcMesh(str + strArray2[1]));
					}
					else
					{
						string[] strArray2 = list[index2].Split('"');
						smcMeshList[index1].Object.Add(new smcObject(strArray2[1], str + strArray2[3]));
					}
				}

				return smcMeshList;
			}
		}

		public struct tMeshMorphMap
		{
			public byte[] JIndex;
			public byte[] Influence;

			public tMeshMorphMap(byte[] JIndex, byte[] Influence)
			{
				this.JIndex = JIndex;
				this.Influence = Influence;
			}
		}

		public class tHeaderInfo
		{
			public byte[] Format { get; set; }

			public uint JointCount { get; set; }

			public uint MeshCount { get; set; }

			public int MeshDataSize { get; set; }

			public uint NormalCount { get; set; }

			public uint ObjCount { get; set; }

			public uint TextureMaps { get; set; }

			public uint UnknownCount { get; set; }

			public int Version { get; set; }

			public uint VertexCount { get; set; }
		}

		public struct tVertex3f
		{
			public float X;
			public float Y;
			public float Z;

			public tVertex3f(float X, float Y, float Z)
			{
				this.X = X;
				this.Y = Y;
				this.Z = Z;
			}
		}

		public class tFace
		{
			public short A;
			public short B;
			public short C;

			public tFace(short A, short B, short C)
			{
				this.A = A;
				this.B = B;
				this.C = C;
			}
		}

		public class tMeshShaderData : IDisposable
		{
			public uint cParam0 { get; set; }
			public uint[] Param1 { get; set; }
			public uint[] Param2 { get; set; }
			public float[] ParamFloats { get; set; }
			public byte[] ShaderName { get; set; }

			public void Dispose()
			{
				Param1 = null;
				Param2 = null;
				ParamFloats = null;
				ShaderName = null;
			}
		}

		public class tMeshShaderInfo
		{
			public uint cParam1 { get; set; }
			public uint cParam2 { get; set; }
			public uint cParamFloats { get; set; }
			public uint cTextureUnits { get; set; }
		}

		public struct tMeshTexture
		{
			public byte[] InternalName;
			public int Reserverd;

			public tMeshTexture(byte[] Name)
			{
				InternalName = Name;
				Reserverd = 0;
			}
		}

		public struct tTextCoord
		{
			public float U;
			public float V;

			public tTextCoord(float U, float V)
			{
				this.U = U;
				this.V = V;
			}
		}

		public class tMeshUVMap
		{
			public tTextCoord[] Coords { get; set; }

			public byte[] Name { get; set; }
		}

		/*public class pwTextures
		{
			public byte[] TexFileName { get; set; }
		}*/

		public struct tMeshWeightsMap
		{
			public int Index;
			public float Weight;

			public tMeshWeightsMap(int Index, float Weight)
			{
				this.Index = Index;
				this.Weight = Weight;
			}
		}

		public class tMeshJointWeights
		{
			public uint Count { get; set; }

			public byte[] JointName { get; set; }

			public tMeshWeightsMap[] WeightsMap { get; set; }
		}

		public class tMeshObject : IDisposable
		{
			public uint FaceCount { get; set; }
			public tFace[] Faces { get; set; }
			public uint FromVert { get; set; }
			public byte[] JData { get; set; }
			public uint JValue { get; set; }
			public byte[] MaterialName { get; set; }
			public tMeshShaderData ShaderData { get; set; }
			public uint ShaderFlag { get; set; }
			public tMeshShaderInfo ShaderInfo { get; set; }
			public tMeshTexture[] Textures { get; set; }
			public uint ToVert { get; set; }
			public uint Value1 { get; set; }

			public short[] GetFaces()
			{
				List<short> shortList = new List<short>();
				for (int index = 0; index < Faces.Length; ++index)
				{
					shortList.Add(Faces[index].A);
					shortList.Add(Faces[index].B);
					shortList.Add(Faces[index].C);
				}

				return shortList.ToArray();
			}

			public void Dispose()
			{
				ShaderData?.Dispose();
			}
		}
		public class tMeshContainer
		{
			//private static LCMeshReader pMesh;
			public byte[] FileName { get; set; }
			public string FilePath { get; set; }
			public tHeaderInfo HeaderInfo { get; set; }
			public tMeshMorphMap[] MorphMap { get; set; }
			public tVertex3f[] Normals { get; set; }
			public tMeshObject[] Objects { get; set; }
			//public pwTextures[] PWTextureList { get; set; }
			public float Scale { get; set; }
			public tMeshUVMap[] UVMaps { get; set; }
			public uint Value1 { get; set; }
			public tVertex3f[] Vertices { get; set; }
			public tMeshJointWeights[] Weights { get; set; }
		}

		public class LCMeshReader
		{
			//private static readonly ASCIIEncoding Enc = new ASCIIEncoding();
			public static string OpenedFile = "";

			public static bool ReadFile(string FileName)
			{
				OpenedFile = FileName;
				pMesh = new tMeshContainer();
				BinaryReader b = new BinaryReader(new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read));
				pMesh.HeaderInfo = new tHeaderInfo();
				pMesh.HeaderInfo.Format = b.ReadBytes(4);
				pMesh.HeaderInfo.Version = b.ReadInt32();
				pMesh.HeaderInfo.MeshDataSize = b.ReadInt32();
				pMesh.HeaderInfo.MeshCount = b.ReadUInt32();
				pMesh.HeaderInfo.VertexCount = b.ReadUInt32();
				pMesh.HeaderInfo.JointCount = b.ReadUInt32();
				pMesh.HeaderInfo.TextureMaps = b.ReadUInt32();
				pMesh.HeaderInfo.NormalCount = b.ReadUInt32();
				pMesh.HeaderInfo.ObjCount = b.ReadUInt32();
				pMesh.HeaderInfo.UnknownCount = b.ReadUInt32();
				pMesh.FileName = b.ReadBytes(b.ReadInt32());
				pMesh.Scale = b.ReadSingle();
				pMesh.Value1 = b.ReadUInt32();
				pMesh.FilePath = FileName;
				bool flag = false;

				if (pMesh.HeaderInfo.Version == 16)
				{
					if (ReadV10(b, b.BaseStream.Position))
						flag = true;
				}
				else if (pMesh.HeaderInfo.Version == 17 && ReadV11(b, b.BaseStream.Position))
				{
					flag = true;
				}

				b.Close();

				return flag;
			}

			private static bool ReadV10(BinaryReader b, long Pos)
			{
				tHeaderInfo tHeaderInfo = new tHeaderInfo();
				tHeaderInfo headerInfo = pMesh.HeaderInfo;
				headerInfo.NormalCount = pMesh.HeaderInfo.UnknownCount;
				headerInfo.JointCount = pMesh.HeaderInfo.NormalCount;
				headerInfo.UnknownCount = pMesh.HeaderInfo.TextureMaps;
				headerInfo.ObjCount = pMesh.HeaderInfo.ObjCount;
				headerInfo.TextureMaps = pMesh.HeaderInfo.JointCount;
				pMesh.HeaderInfo = headerInfo;
				pMesh.Vertices = new tVertex3f[(int)pMesh.HeaderInfo.VertexCount];

				for (int index = 0; index < pMesh.HeaderInfo.VertexCount; ++index)
					pMesh.Vertices[index] = new tVertex3f(b.ReadSingle(), b.ReadSingle(), b.ReadSingle());

				pMesh.Normals = new tVertex3f[(int)pMesh.HeaderInfo.VertexCount];

				for (int index = 0; index < pMesh.HeaderInfo.VertexCount; ++index)
					pMesh.Normals[index] = new tVertex3f(b.ReadSingle(), b.ReadSingle(), b.ReadSingle());

				if (pMesh.HeaderInfo.TextureMaps > 0U)
				{
					pMesh.UVMaps = new tMeshUVMap[(int)pMesh.HeaderInfo.TextureMaps];
					for (int index1 = 0; index1 > pMesh.HeaderInfo.TextureMaps; ++index1)
					{
						pMesh.UVMaps[index1] = new tMeshUVMap();
						pMesh.UVMaps[index1].Name = b.ReadBytes(b.ReadInt32());
						pMesh.UVMaps[index1].Coords = new tTextCoord[(int)pMesh.HeaderInfo.VertexCount];
						for (int index2 = 0; index2 < pMesh.HeaderInfo.VertexCount; ++index2)
							pMesh.UVMaps[index1].Coords[index2] = new tTextCoord(b.ReadSingle(), b.ReadSingle());
					}
				}

				pMesh.Objects = new tMeshObject[(int)pMesh.HeaderInfo.ObjCount];

				for (int index1 = 0; index1 < pMesh.HeaderInfo.ObjCount; ++index1)
				{
					tMeshObject tMeshObject = new tMeshObject();
					tMeshObject.MaterialName = b.ReadBytes(b.ReadInt32());
					tMeshObject.Value1 = b.ReadUInt32();
					tMeshObject.FromVert = b.ReadUInt32();
					tMeshObject.ToVert = b.ReadUInt32();
					tMeshObject.FaceCount = b.ReadUInt32();
					tMeshObject.Faces = new tFace[(int)tMeshObject.FaceCount];

					for (int index2 = 0; index2 < tMeshObject.FaceCount; ++index2)
						tMeshObject.Faces[index2] = new tFace(b.ReadInt16(), b.ReadInt16(), b.ReadInt16());

					tMeshObject.JValue = b.ReadUInt32();
					tMeshObject.JData = new byte[(int)tMeshObject.JValue];

					for (int index2 = 0; index2 < tMeshObject.JValue; ++index2)
						tMeshObject.JData[index2] = b.ReadByte();

					tMeshObject.ShaderFlag = b.ReadUInt32();

					if (tMeshObject.ShaderFlag > 0U)
					{
						tMeshObject.ShaderInfo = new tMeshShaderInfo();
						tMeshObject.ShaderInfo.cParam1 = b.ReadUInt32();
						tMeshObject.ShaderInfo.cParamFloats = b.ReadUInt32();
						tMeshObject.ShaderInfo.cTextureUnits = b.ReadUInt32();
						tMeshObject.ShaderInfo.cParam2 = b.ReadUInt32();
						tMeshObject.ShaderInfo = new tMeshShaderInfo()
						{
							cTextureUnits = tMeshObject.ShaderInfo.cParam1,
							cParamFloats = tMeshObject.ShaderInfo.cParamFloats,
							cParam1 = tMeshObject.ShaderInfo.cParam2,
							cParam2 = tMeshObject.ShaderInfo.cTextureUnits
						};

						tMeshObject.ShaderData = new tMeshShaderData();
						tMeshObject.ShaderData.ShaderName = b.ReadBytes(b.ReadInt32());
						tMeshObject.Textures = new tMeshTexture[(int)tMeshObject.ShaderInfo.cTextureUnits];

						for (int index2 = 0; index2 < tMeshObject.ShaderInfo.cTextureUnits; ++index2)
							tMeshObject.Textures[index2] = new tMeshTexture(b.ReadBytes(b.ReadInt32()));

						if (tMeshObject.ShaderInfo.cParam1 > 0U)
							tMeshObject.ShaderData.Param1 = new uint[(int)tMeshObject.ShaderInfo.cParam1];

						if (tMeshObject.ShaderInfo.cParamFloats > 0U)
							tMeshObject.ShaderData.ParamFloats = new float[(int)tMeshObject.ShaderInfo.cParamFloats];

						if (tMeshObject.ShaderInfo.cParam2 > 0U)
							tMeshObject.ShaderData.Param2 = new uint[(int)tMeshObject.ShaderInfo.cParam2];

						tMeshObject.ShaderData.cParam0 = b.ReadUInt32();

						for (int index2 = 0; index2 < tMeshObject.ShaderInfo.cParam2; ++index2)
							tMeshObject.ShaderData.Param2[index2] = b.ReadUInt32();

						for (int index2 = 0; index2 < tMeshObject.ShaderInfo.cParamFloats; ++index2)
							tMeshObject.ShaderData.ParamFloats[index2] = b.ReadSingle();

						for (int index2 = 0; index2 < tMeshObject.ShaderInfo.cParam1; ++index2)
							tMeshObject.ShaderData.Param1[index2] = b.ReadUInt32();

						pMesh.Objects[index1] = tMeshObject;
					}
				}

				pMesh.Weights = new tMeshJointWeights[(int)pMesh.HeaderInfo.JointCount];

				for (int index1 = 0; index1 < pMesh.HeaderInfo.JointCount; ++index1)
				{
					pMesh.Weights[index1] = new tMeshJointWeights();
					pMesh.Weights[index1].JointName = b.ReadBytes(b.ReadInt32());
					pMesh.Weights[index1].Count = b.ReadUInt32();
					pMesh.Weights[index1].WeightsMap = new tMeshWeightsMap[(int)pMesh.Weights[index1].Count];

					for (int index2 = 0; index2 < pMesh.Weights[index1].Count; ++index2)
						pMesh.Weights[index1].WeightsMap[index2] = new tMeshWeightsMap(b.ReadInt32(), b.ReadSingle());
				}

				pMesh.MorphMap = new tMeshMorphMap[(int)pMesh.HeaderInfo.VertexCount];

				for (int index = 0; index < pMesh.HeaderInfo.VertexCount; ++index)
					pMesh.MorphMap[index] = new tMeshMorphMap(b.ReadBytes(4), b.ReadBytes(4));

				return b.BaseStream.Position == (pMesh.HeaderInfo.MeshDataSize + 8);
			}

			public class Decoder
			{
				private static byte[] XorCode;

				public static uint Decode(uint Code)
				{
					byte[] numArray = new byte[4];
					byte[] bytes = BitConverter.GetBytes(Code);

					for (int index = 0; index < 4; ++index)
					{
						bytes[index] = (byte)(bytes[index] ^ XorCode[index]);
						XorCode[index] = (byte)(XorCode[index] + 89U);
					}

					return BitConverter.ToUInt32(bytes, 0);
				}

				public static void Reset() { XorCode = new byte[4] { 101, 72, 53, 30 }; }
			}

			private static bool ReadV11(BinaryReader b, long Pos)
			{
				b.BaseStream.Position = Pos;
				Decoder.Reset();
				pMesh.HeaderInfo.MeshCount = Decoder.Decode(pMesh.HeaderInfo.MeshCount);
				pMesh.HeaderInfo.VertexCount = Decoder.Decode(pMesh.HeaderInfo.VertexCount);
				pMesh.HeaderInfo.JointCount = Decoder.Decode(pMesh.HeaderInfo.JointCount);
				pMesh.HeaderInfo.TextureMaps = Decoder.Decode(pMesh.HeaderInfo.TextureMaps);
				pMesh.HeaderInfo.NormalCount = Decoder.Decode(pMesh.HeaderInfo.NormalCount);
				pMesh.HeaderInfo.ObjCount = Decoder.Decode(pMesh.HeaderInfo.ObjCount);
				pMesh.HeaderInfo.UnknownCount = Decoder.Decode(pMesh.HeaderInfo.UnknownCount);
				pMesh.Value1 = Decoder.Decode(pMesh.Value1);
				pMesh.Vertices = new tVertex3f[(int)pMesh.HeaderInfo.VertexCount];

				for (int index = 0; index < pMesh.HeaderInfo.VertexCount; ++index)
					pMesh.Vertices[index] = new tVertex3f(b.ReadSingle(), b.ReadSingle(), b.ReadSingle());

				pMesh.Normals = new tVertex3f[(int)pMesh.HeaderInfo.NormalCount];

				for (int index = 0; index < pMesh.HeaderInfo.NormalCount; ++index)
					pMesh.Normals[index] = new tVertex3f(b.ReadSingle(), b.ReadSingle(), b.ReadSingle());

				if (pMesh.HeaderInfo.TextureMaps > 0U)
				{
					pMesh.UVMaps = new tMeshUVMap[(int)pMesh.HeaderInfo.TextureMaps];

					for (int index1 = 0; index1 < pMesh.HeaderInfo.TextureMaps; ++index1)
					{
						tMeshUVMap tMeshUvMap = new tMeshUVMap();
						tMeshUvMap.Name = b.ReadBytes(b.ReadInt32());
						tMeshUvMap.Coords = new tTextCoord[(int)pMesh.HeaderInfo.VertexCount];

						for (int index2 = 0; index2 < pMesh.HeaderInfo.VertexCount; ++index2)
							tMeshUvMap.Coords[index2] = new tTextCoord(b.ReadSingle(), b.ReadSingle());

						pMesh.UVMaps[index1] = tMeshUvMap;
					}
				}

				pMesh.Objects = new tMeshObject[(int)pMesh.HeaderInfo.ObjCount];

				for (int index1 = 0;  index1 < pMesh.HeaderInfo.ObjCount; ++index1)
				{
					tMeshObject tMeshObject = new tMeshObject();
					tMeshObject.FromVert = Decoder.Decode(b.ReadUInt32());
					tMeshObject.ToVert = Decoder.Decode(b.ReadUInt32());
					tMeshObject.FaceCount = Decoder.Decode(b.ReadUInt32());
					tMeshObject.Faces = new tFace[(int)tMeshObject.FaceCount];

					for (int index2 = 0; index2 < tMeshObject.FaceCount; ++index2)
						tMeshObject.Faces[index2] = new tFace(b.ReadInt16(), b.ReadInt16(), b.ReadInt16());

					tMeshObject.MaterialName = b.ReadBytes(b.ReadInt32());
					tMeshObject.Value1 = Decoder.Decode(b.ReadUInt32());
					tMeshObject.JValue = Decoder.Decode(b.ReadUInt32());
					tMeshObject.JData = new byte[(int)tMeshObject.JValue];

					for (int index2 = 0; index2 < tMeshObject.JValue; ++index2)
						tMeshObject.JData[index2] = b.ReadByte();

					tMeshObject.ShaderFlag = Decoder.Decode(b.ReadUInt32());

					if (tMeshObject.ShaderFlag > 0U)
					{
						tMeshObject.ShaderInfo = new tMeshShaderInfo();
						tMeshObject.ShaderInfo.cParam1 = Decoder.Decode(b.ReadUInt32());
						tMeshObject.ShaderInfo.cParamFloats = Decoder.Decode(b.ReadUInt32());
						tMeshObject.ShaderInfo.cTextureUnits = Decoder.Decode(b.ReadUInt32());
						tMeshObject.ShaderInfo.cParam2 = Decoder.Decode(b.ReadUInt32());
						tMeshObject.ShaderData = new tMeshShaderData();
						tMeshObject.ShaderData.ShaderName = b.ReadBytes(b.ReadInt32());
						tMeshObject.Textures = new tMeshTexture[(int)tMeshObject.ShaderInfo.cTextureUnits];

						for (int index2 = 0; index2 < tMeshObject.ShaderInfo.cTextureUnits; ++index2)
						{
							tMeshObject.Textures[index2] = new tMeshTexture();
							tMeshObject.Textures[index2].InternalName = b.ReadBytes(b.ReadInt32());
						}

						if (tMeshObject.ShaderInfo.cParam2 > 0U)
							tMeshObject.ShaderData.Param1 = new uint[(int)tMeshObject.ShaderInfo.cParam1];

						if (tMeshObject.ShaderInfo.cParamFloats > 0U)
							tMeshObject.ShaderData.ParamFloats = new float[(int)tMeshObject.ShaderInfo.cParamFloats];

						if (tMeshObject.ShaderInfo.cParam1 > 0U)
							tMeshObject.ShaderData.Param2 = new uint[(int)tMeshObject.ShaderInfo.cParam2];

						tMeshObject.ShaderData.cParam0 = Decoder.Decode(b.ReadUInt32());

						for (int index2 = 0; index2 < tMeshObject.ShaderInfo.cParam2; ++index2)
							tMeshObject.ShaderData.Param2[index2] = Decoder.Decode(b.ReadUInt32());

						for (int index2 = 0; index2 < tMeshObject.ShaderInfo.cParamFloats; ++index2)
							tMeshObject.ShaderData.ParamFloats[index2] = b.ReadSingle();

						for (int index2 = 0; index2 < tMeshObject.ShaderInfo.cParam1; ++index2)
							tMeshObject.ShaderData.Param1[index2] = Decoder.Decode(b.ReadUInt32());
					}

					pMesh.Objects[index1] = tMeshObject;
				}

				pMesh.Weights = new tMeshJointWeights[(int)pMesh.HeaderInfo.JointCount];

				for (int index1 = 0; index1 < pMesh.HeaderInfo.JointCount; ++index1)
				{
					pMesh.Weights[index1] = new tMeshJointWeights();
					pMesh.Weights[index1].JointName = b.ReadBytes(b.ReadInt32());
					pMesh.Weights[index1].Count = Decoder.Decode(b.ReadUInt32());
					pMesh.Weights[index1].WeightsMap = new tMeshWeightsMap[(int)pMesh.Weights[index1].Count];

					for (int index2 = 0; index2 < pMesh.Weights[index1].Count; ++index2)
						pMesh.Weights[index1].WeightsMap[index2] = new tMeshWeightsMap(b.ReadInt32(), b.ReadSingle());
				}

				pMesh.MorphMap = new tMeshMorphMap[(int)pMesh.HeaderInfo.VertexCount];

				for (int index = 0; index < pMesh.HeaderInfo.VertexCount; ++index)
					pMesh.MorphMap[index] = new tMeshMorphMap(b.ReadBytes(4), b.ReadBytes(4));

				Pos = b.BaseStream.Position;

				return Pos == (pMesh.HeaderInfo.MeshDataSize + 8);
			}
		}

		private void CameraPositioning()
		{
			pDevice.SetTransform(TransformState.Projection, Matrix.PerspectiveFovLH(100f, 1f, 1f, 100f));

			fZoom = fRotation = 0.0f;
		}

		private static Format ConvFormat(texFormat tFormat)
		{
			Format format = Format.Unknown;
			switch (tFormat)
			{
				case texFormat.RGB:
					return Format.R8G8B8;
				case texFormat.ARGB:
					return Format.A8R8G8B8;
				case texFormat.DXT1:
					return Format.Dxt1;
				case texFormat.DXT3:
					return Format.Dxt3;
				default:
					return format;
			}
		}

		private Texture BuildTexture(byte[] imageData, Format imageFormat, int width, int height)
		{
			if (imageFormat == Format.R8G8B8)
			{
				MemoryStream memoryStream;
				using (memoryStream = new MemoryStream())
				{
					Tex.makeRGB8(imageData, width, height).Save(memoryStream, ImageFormat.Bmp);
					memoryStream.Write(imageData, 0, imageData.Length);
					memoryStream.Position = 0L;

					return Texture.FromStream(pDevice, memoryStream, width, height, 0, Usage.SoftwareProcessing, Format.A8B8G8R8, Pool.Default, Filter.None, Filter.None, 0);
				}
			}
			else if (imageFormat == Format.A8R8G8B8)
			{
				MemoryStream memoryStream;
				using (memoryStream = new MemoryStream())
				{
					Tex.makeRGB(imageData, width, height).Save(memoryStream, ImageFormat.Bmp);
					memoryStream.Write(imageData, 0, imageData.Length);
					memoryStream.Position = 0L;

					return Texture.FromStream(pDevice, memoryStream, width, height, 0, Usage.SoftwareProcessing, Format.A8B8G8R8, Pool.Default, Filter.None, Filter.None, 0);
				}
			}
			else
			{
				Texture texture = new Texture(pDevice, width, height, 0, Usage.None, imageFormat, Pool.Managed);
				using (Stream data = texture.LockRectangle(0, LockFlags.None).Data)
				{
					data.Write(imageData, 0, (imageData).Count<byte>());
					texture.UnlockRectangle(0);
				}

				return texture;
			}
		}

		private Texture GetTextureFromFile(string FileName)
		{
			Texture texture = null;
			if (File.Exists(FileName))
			{
				Tex.ReadFile(FileName);
				SlimDX.Direct3D9.Format imageFormat = ConvFormat(Tex.GetFormat());

				//texture = BuildTexture(Tex.lcTex.imageData[0], imageFormat, (int)Tex.lcTex.Header.Width, (int)Tex.lcTex.Header.Height);
				if (Tex.lcTex.imageData != null && Tex.lcTex.imageData.Length > 0 && Tex.lcTex.imageData[0] != null)
					texture = BuildTexture(Tex.lcTex.imageData[0], imageFormat, (int)Tex.lcTex.Header.Width, (int)Tex.lcTex.Header.Height);
				else
					pMain.Logger("Render Dialog > imageData is empty or null (SMC: " + pstrFilePath + ").", Color.Red);
			}

			return texture;
		}

		public struct PositionNormalTextured
		{
			public Vector3 Position;
			public Vector3 Normal;
			public Vector2 Texture;
		}

		/*private void MakeLCModels(string SMCFile)
		{
			List<float> source1 = new List<float>();
			List<float> source2 = new List<float>();
			List<float> source3 = new List<float>();
			List<float> floatList1 = new List<float>();
			List<float> floatList2 = new List<float>();
			List<float> floatList3 = new List<float>();
			pModel = new List<tMesh>();

			List<smcMesh> source4 = SMCReader.ReadFile(SMCFile);

			for (int index1 = 0; index1 < source4.Count<smcMesh>(); ++index1)
			{
				if (LCMeshReader.ReadFile(source4[index1].FileName))
				{
					source1.Add(((IEnumerable<tVertex3f>)pMesh.Vertices).Max<tVertex3f>((Func<tVertex3f, float>)(p => p.X)));
					source2.Add(((IEnumerable<tVertex3f>)pMesh.Vertices).Max<tVertex3f>((Func<tVertex3f, float>)(p => p.Y)));
					source3.Add(((IEnumerable<tVertex3f>)pMesh.Vertices).Max<tVertex3f>((Func<tVertex3f, float>)(p => p.Z)));
					floatList1.Add(((IEnumerable<tVertex3f>)pMesh.Vertices).Min<tVertex3f>((Func<tVertex3f, float>)(p => p.X)));
					floatList2.Add(((IEnumerable<tVertex3f>)pMesh.Vertices).Min<tVertex3f>((Func<tVertex3f, float>)(p => p.Y)));
					floatList3.Add(((IEnumerable<tVertex3f>)pMesh.Vertices).Min<tVertex3f>((Func<tVertex3f, float>)(p => p.Z)));

					for (int index2 = 0; index2 < ((IEnumerable<tMeshObject>)pMesh.Objects).Count<tMeshObject>(); ++index2)
					{
						int toVert = (int)pMesh.Objects[index2].ToVert;
						int faceCount = (int)pMesh.Objects[index2].FaceCount;
						short[] faces = pMesh.Objects[index2].GetFaces();
						PositionNormalTextured[] data = new PositionNormalTextured[toVert];
						int fromVert = (int)pMesh.Objects[index2].FromVert;

						for (int index3 = 0; (long)index3 < (long)pMesh.Objects[index2].ToVert; ++index3)
						{
							data[index3].Position = new Vector3(pMesh.Vertices[fromVert].X, pMesh.Vertices[fromVert].Y, pMesh.Vertices[fromVert].Z);
							data[index3].Normal = new Vector3(pMesh.Normals[fromVert].X, pMesh.Normals[fromVert].Y, pMesh.Normals[fromVert].Z);

							try
							{
								data[index3].Texture = new Vector2(pMesh.UVMaps[0].Coords[fromVert].U, pMesh.UVMaps[0].Coords[fromVert].V);
							}
							catch
							{
								data[index3].Texture = new Vector2(0.0f, 0.0f);
							}

							++fromVert;
						}

						VertexBuffer vertexBuffer = new VertexBuffer(pDevice, ((IEnumerable<PositionNormalTextured>)data).Count<PositionNormalTextured>() * 32, Usage.None, VertexFormat.PositionNormal | VertexFormat.Texture1, Pool.Default);

						Mesh mesh = new Mesh(pDevice, ((IEnumerable<short>)faces).Count<short>() / 3, ((IEnumerable<PositionNormalTextured>)data).Count<PositionNormalTextured>(), MeshFlags.Managed, VertexFormat.PositionNormal | VertexFormat.Texture1);
						DataStream dataStream1;

						using (dataStream1 = mesh.VertexBuffer.Lock(0, ((IEnumerable<PositionNormalTextured>)data).Count<PositionNormalTextured>() * 32, LockFlags.None))
						{
							dataStream1.WriteRange<PositionNormalTextured>(data);
							mesh.VertexBuffer.Unlock();
						}

						vertexBuffer.Dispose();

						DataStream dataStream2;
						using (dataStream2 = mesh.IndexBuffer.Lock(0, ((IEnumerable<short>)faces).Count<short>() * 2, LockFlags.None))
						{
							dataStream2.WriteRange<short>(faces);
							mesh.IndexBuffer.Unlock();
						}

						if ((uint)((IEnumerable<tMeshJointWeights>)pMesh.Weights).Count<tMeshJointWeights>() > 0U)
						{
                            string[] strArray = new string[((IEnumerable<tMeshJointWeights>)pMesh.Weights).Count<tMeshJointWeights>()];
							List<int>[] intListArray = new List<int>[((IEnumerable<tMeshJointWeights>)pMesh.Weights).Count<tMeshJointWeights>()];
							List<float>[] floatListArray = new List<float>[((IEnumerable<tMeshJointWeights>)pMesh.Weights).Count<tMeshJointWeights>()];
							for (int index3 = 0; index3 < ((IEnumerable<tMeshJointWeights>)pMesh.Weights).Count<tMeshJointWeights>(); ++index3)
							{
								strArray[index3] = pEnc.GetString(pMesh.Weights[index3].JointName);
								intListArray[index3] = new List<int>();
								floatListArray[index3] = new List<float>();

								for (int index4 = 0; index4 < ((IEnumerable<tMeshWeightsMap>)pMesh.Weights[index3].WeightsMap).Count<tMeshWeightsMap>(); ++index4)
								{
									intListArray[index3].Add(pMesh.Weights[index3].WeightsMap[index4].Index);
									floatListArray[index3].Add(pMesh.Weights[index3].WeightsMap[index4].Weight);
								}
							}

							mesh.SkinInfo = new SkinInfo(((IEnumerable<PositionNormalTextured>)data).Count<PositionNormalTextured>(), VertexFormat.PositionNormal | VertexFormat.Texture1, (int)pMesh.HeaderInfo.JointCount);

                            for (int bone = 0; bone < ((IEnumerable<List<int>>)intListArray).Count<List<int>>(); ++bone)
							{
								mesh.SkinInfo.SetBoneName(bone, strArray[bone]);

								mesh.SkinInfo.SetBoneInfluence(bone, intListArray[bone].ToArray(), floatListArray[bone].ToArray());
							}

                            mesh.SkinInfo.Dispose();
						}

						mesh.GenerateAdjacency(0.5f);
						mesh.ComputeNormals();
						Texture texture = (Texture)null;
						string objName = pEnc.GetString(pMesh.Objects[index2].Textures[0].InternalName);
						int index5 = source4[index1].Object.FindIndex((Predicate<smcObject>)(x => x.Name.Equals(objName)));
						if (index5 != -1)
							texture = GetTextureFromFile(source4[index1].Object[index5].Texture);

						pModel.Add(new tMesh(mesh, texture));
					}
				}
			}

			fZoom = ((IEnumerable<float>)new float[3] { source1.Max(), source2.Max(), source3.Max() }).Max() * 3f;
		}*/
		private void MakeLCModels(string SMCFile, int nWearingPosition)
		{
			List<smcMesh> list = SMCReader.ReadFile(SMCFile);
			pModel = new List<tMesh>();

			for (int i = 0; i < list.Count(); i++)
			{
				bool flag = (nWearingPosition != 0 ||
				!list[i].FileName.Contains("_hair_000")) && (nWearingPosition != 1 ||
				!list[i].FileName.Contains("_bu_000")) && (nWearingPosition != 3 ||
				!list[i].FileName.Contains("_bd_000")) && (nWearingPosition != 5 ||
				!list[i].FileName.Contains("_hn_000")) && (nWearingPosition != 6 ||
				!list[i].FileName.Contains("_ft_000"));

				if (flag && LCMeshReader.ReadFile(list[i].FileName))
				{
					for (int j = 0; j < pMesh.Objects.Count(); j++)
					{
						int toVert = (int)pMesh.Objects[j].ToVert;
						short[] faces = pMesh.Objects[j].GetFaces();
						PositionNormalTextured[] array = new PositionNormalTextured[toVert];
						int num3 = (int)pMesh.Objects[j].FromVert;
						int k = 0;

						while (k < (long)(ulong)pMesh.Objects[j].ToVert)
						{
							array[k].Position = new Vector3(pMesh.Vertices[num3].X, pMesh.Vertices[num3].Y, pMesh.Vertices[num3].Z);
							array[k].Normal = new Vector3(pMesh.Normals[num3].X, pMesh.Normals[num3].Y, pMesh.Normals[num3].Z);

							try
							{
								array[k].Texture = new Vector2(pMesh.UVMaps[0].Coords[num3].U, pMesh.UVMaps[0].Coords[num3].V);
							}
							catch
							{
								array[k].Texture = new Vector2(0f, 0f);
							}

							num3++;
							k++;
						}

						//new VertexBuffer(pDevice, array.Count<PositionNormalTextured>() * 32, Usage.None, VertexFormat.Position | VertexFormat.Texture1 | VertexFormat.Normal, Pool.Default);

						Mesh mesh = new Mesh(pDevice, faces.Count<short>() / 3, array.Count(), MeshFlags.Managed, VertexFormat.Position | VertexFormat.Texture1 | VertexFormat.Normal);

						DataStream dataStream2;
						DataStream dataStream = dataStream2 = mesh.VertexBuffer.Lock(0, array.Count() * 32, LockFlags.None);

						try
						{
							dataStream.WriteRange(array);
							mesh.VertexBuffer.Unlock();
						}
						finally
						{
							if (dataStream2 != null)
								((IDisposable)dataStream2).Dispose();

							mesh.VertexBuffer.Dispose();    // TEST
						}

						DataStream dataStream3;
						dataStream = (dataStream3 = mesh.IndexBuffer.Lock(0, faces.Count() * 2, LockFlags.None));

						try
						{
							dataStream.WriteRange(faces);
							mesh.IndexBuffer.Unlock();
						}
						finally
						{
							if (dataStream3 != null)
								((IDisposable)dataStream3).Dispose();

							mesh.IndexBuffer.Dispose(); // TEST
						}

						if (pMesh.Weights.Count() != 0)
						{
							string[] array2 = new string[pMesh.Weights.Count()];
							List<int>[] array3 = new List<int>[pMesh.Weights.Count()];
							List<float>[] array4 = new List<float>[pMesh.Weights.Count()];

							for (int l = 0; l < pMesh.Weights.Count(); l++)
							{
								array2[l] = pEnc.GetString(pMesh.Weights[l].JointName);
								array3[l] = new List<int>();
								array4[l] = new List<float>();

								for (int m = 0; m < pMesh.Weights[l].WeightsMap.Count(); m++)
								{
									array3[l].Add(pMesh.Weights[l].WeightsMap[m].Index);
									array4[l].Add(pMesh.Weights[l].WeightsMap[m].Weight);
								}
							}

							mesh.SkinInfo = new SkinInfo(array.Count(), VertexFormat.Position | VertexFormat.Texture1 | VertexFormat.Normal, (int)pMesh.HeaderInfo.JointCount);

							for (k = 0; k < array3.Count(); k++)
							{
								mesh.SkinInfo.SetBoneName(k, array2[k]);

								if (array3[k].Count > 0 && array4[k].Count > 0)
									mesh.SkinInfo.SetBoneInfluence(k, array3[k].ToArray(), array4[k].ToArray());
								else
									pMain.Logger("Render Dialog > Some list is empty (i thing, who knows jeje MLGHackxor360RezaSpoon123-321... I need sleep dude) (SMC: " + pstrFilePath + ").", Color.Red);
							}

							mesh.SkinInfo.Dispose();    // TEST
						}

						mesh.GenerateAdjacency(0.5f);
						mesh.ComputeNormals();

						Texture texture = null;
						int num4 = list[i].Object.FindIndex((smcObject x) => x.Name.Equals(pEnc.GetString(pMesh.Objects[j].Textures[0].InternalName)));

						if (num4 != -1)
							texture = GetTextureFromFile(list[i].Object[num4].Texture);

						pModel.Add(new tMesh(mesh, texture));
					}
				}
			}

			fZoom = 4f;
		}

		private void InitializeDevice()
		{
			pDirect3D = new Direct3D();
			Direct3D direct3D = pDirect3D;
			int adapter = 0;
			int num1 = 1;
			IntPtr handle1 = Handle;
			int num2 = 32;
			PresentParameters[] presentParametersArray = new PresentParameters[1];
			int index = 0;
			PresentParameters presentParameters = new PresentParameters();
			presentParameters.SwapEffect = SwapEffect.Discard;
			IntPtr handle2 = panel3DView.Handle;
			presentParameters.DeviceWindowHandle = handle2;
			int num3 = 1;
			presentParameters.Windowed = num3 != 0;
			int width = panel3DView.Width;
			presentParameters.BackBufferWidth = width;
			int height = panel3DView.Height;
			presentParameters.BackBufferHeight = height;
			int num4 = 21;
			presentParameters.BackBufferFormat = (Format)num4;
			presentParametersArray[index] = presentParameters;

			pDevice = new Device(direct3D, adapter, (DeviceType)num1, handle1, (CreateFlags)num2, presentParametersArray);
			pDevice.SetRenderState(RenderState.CullMode, Cull.None);
			pDevice.SetRenderState(RenderState.FillMode, FillMode.Solid);
			pDevice.SetRenderState(RenderState.Lighting, false);

			CameraPositioning();
		}

		private void timerRender_Tick(object sender, EventArgs e)
		{
			pDevice.Viewport = new Viewport(0, 0, panel3DView.Width, panel3DView.Height);

			pDevice.Clear(ClearFlags.ZBuffer | ClearFlags.Target, Color.FromArgb(0, 255, 0), 1f, 0);
			pDevice.BeginScene();

			vecCameraPosition.Z = 0.1f - fZoom;
			vecEntityPosition.Y = fUpDown;

			pDevice.SetTransform(TransformState.View, Matrix.LookAtLH(vecCameraPosition, vecEntityPosition, Vector3.UnitY));
			pDevice.SetTransform(TransformState.World, Matrix.RotationYawPitchRoll(fRotation, 3.1f, 0.0f));

			if (pModel != null)
			{
				for (int index = 0; index < pModel.Count(); ++index)
				{
					if (pModel[index].TexData != null)
						pDevice.SetTexture(0, pModel[index].TexData);

					//for (int subset = 0; subset < 1; ++subset)
					//     pModel[index].MeshData.DrawSubset(subset);
					pModel[index].MeshData.DrawSubset(0);
				}
			}

			pDevice.EndScene();
			pDevice.Present();

			if (cbRotation.Checked)
				fRotation = fRotation - 0.03f;
		}
	}
}
