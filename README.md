# LastChaos ToolBox <img align="left" src="https://user-images.githubusercontent.com/5092697/138568453-9cbbedb8-7889-4a9d-ac72-5d2dae9bae9f.png" width="100px">

<br/>
<br/>

It provides the basics for creating tools to manage Databases and perhaps files related to LastChaos.

In Item Editor there are notes and examples on how to manage the request, storage and management of data.


# Concept of Global Tables
* The idea behind the project is to have a fast and efficient tool in terms of requests to the database. With that in mind I designed a scheme in which there are __Global Tables__, these are populated for the first time by the Tool that requires the information, and later said information can be used by another tool, Avoiding constants requests each time some Tool open.

* When a Tool populates a __Global Table__, it is not necessarily populated with all the information available in the Database, but rather the system is designed so that different tools request only the columns necessary for the operation of said Tool. Being able to load different columns by different Tools without the information overlapping or replacing.

* Finally, when in a Tool the operator decides to apply changes made, an attempt is made to execute a Query either type UPDATE or INSERT, in case of success, said changes are updated in the __Global Tables__.