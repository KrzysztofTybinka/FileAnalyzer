# About The Project
File Analyzer is a console application developed using C#, offering a comprehensive solution for reading and processing data files. 
The application provides a range of input functions to support data filtering and manipulation, enabling the user to query and extract data 
with ease. The application implements algorithms to analyze the entire data file and locate nested keys, subsequently retrieving 
the associated values. Currently, the application supports two file formats: JSON and XML.
# Getting Started
### Prerequisites
Before installing the application, make sure that you have the following software installed on your computer:
- .NET Framework 4.7.2 or higher
- Visual Studio 2017 or higher
### Downloading the source code
You can download the source code for this application by clicking the "Clone or download" button on the GitHub repository page and then selecting 
"Download ZIP." Extract the contents of the ZIP file to a location of your choice.
### Building the Application
1. Open a command prompt or terminal window and navigate to the directory where you extracted the source code.
2. Run the following command to restore the NuGet packages:
```
dotnet restore
```
3. Run the following command to build the application:
```
dotnet build
```
### Running the Application
4. Open a command prompt or terminal window and navigate to the directory where you extracted the source code.
5. Run the following command to start the application:
``` 
dotnet run
```
The application should now be running, to use the application follow the ons-screen instructions.
# Usage
### User Interface
In order to use the application, user must input the data in format: 
```
attribute -method value path
```
Where:
- attribute is searched key from file that user wants to analyze   
- -method is one of the predefined functions supported by the app  
- value is function parameter  
- path is file path to read data from

Currently supported functions:  
- -gt - greater than, query returns all data greater than value  
- -st - smaller than, query returns all data smaller than value  
- -pt - print, query returns value amount of records, or all if value was 0

Example user input:
```
age -gt 30 C:\Path\File.json
```
Returns list of all ages from File.json file that are greater than 30.
### Code
The application operates as follows: the user inputs the data in the correct format, which is then processed 
by a Phrase object. The methods within the Phrase object get the file content, interpret the user input and determine the appropriate 
FileParser object to be instantiated. The resulting FileParser object is then passed as a parameter to the FileService 
object. The extracted data within the FileParser object is then filtered by methods within the FileService object according to specified parameters, 
resulting in a list that is subsequently output to the console. This pipeline of object interactions and method invocations enables the application 
to efficiently and accurately process user input and produce the desired output.

![This is an image](https://imagizer.imageshack.com/img923/9422/I6bNik.jpg)


The problem of extracting nested keys from JSON and XML files has been resolved through the utilization of LINQ query capabilities. 
The method first obtains the descendants of the data, performs parsing operations, and retrieves the values.

![This is an image](https://imagizer.imageshack.com/img924/1332/50KHqx.jpg)


FileService class methods use LINQ, to select the desired values from the data set and output the results in the form of a list.

![This is an image](https://imagizer.imageshack.com/img924/1696/lCHp0y.jpg)

The application has been developed adhering to SOLID, software design principles, allowing for modular and flexible design with the ability to easily 
extend and add new functionalities for data filtering and other file types.
# Contributing
If you wish to contribute to this project, please feel free to create a pull request with your changes.
# License
This project is licensed under the MIT License - see the LICENSE file for details.
