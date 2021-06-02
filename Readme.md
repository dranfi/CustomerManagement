Test C# Application
We will need a new console app to read in a CSV file from a directory. The contents will then need to be sent to a REST API endpoint, in JSON format, and saved to a SQL database.
Create a console app to read in a CSV file from a directory.
Parse the CSV file of which the contents are:
Customer Ref
Customer Name
Address Line 1
Address Line 2
Town
County
Country
Postcode
Loop through the rows of the CSV file and send each row to a REST API POST endpoint, in JSON format.
The REST API should then save the content to a database table. Format can match the CSV file.
Create a REST API GET endpoint to retrieve the customer information, passing in a customer ref to filter the data. Contents should be returned in JSON format.
Some documentation or Wiki to explain the approach taken.

====>
Documentation is documentation.txt
