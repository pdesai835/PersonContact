Person Contact
Read Me:
1)	REST based webAPI Project developed to manage:
  a.	Insertion of Person Contact.
  b.	Deletion of a Person Contact.
  c.	Update of a Person Contact.
  d.	View one OR all Person Contact.

2)	Salient features: 
  a.	Business validation imposed:
      i.	FirstName & LastName must be of fixed length and alphabets only.
      ii.	 EmailId must have @ and of fixed length.
      iii.	Phone Number must not contain Non-numeric character and should be of Fixed length.
  b.	Data Integrity validation imposed:
      i.	FirstName and LastName must not be duplicated.
      ii.	EmailId must not be duplicated.
      iii.	PhoneNumber must not be duplicated.

3)	Technology used:
  a.	ASP.Net WebAPI 2.0
  b.	Entity Frame-Work with Code first Approach.
  c.	DataAnnotation Attributes usage to define Business Model (PersonContact)
  d.	SQL server 2014 for data storage.(Windows Identity based connection used from AppConString).
  e.	POSTMAN for WebAPI testing. (includes Test Collection files for testing.)

	Steps to install/Use the project:
  1)	Install and host the project as an IIS website.
  2)	Update the Connection String in webConfig:
  <add name="ContactAPIContext" connectionString="Server=ReplaceActualDBinstanceNamehere;Database=PersonContactDB;Integrated Security=SSPI;"providerName="System.Data.SqlClient" />
  3)	Use POSTMAN collection shared to test all defined testcases.
    a.	Import collection from file: “Person Contact.postman_collection”.
    b.	Import environment file from: “PersonContact API Test Environment.postman_environment”.
