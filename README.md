# _National Parks API_

#### By _**Shaniza Lingle**_

#### _Web API for National Parks_

## Technologies Used

* _C#_
* _.NET_
* _Razor_
* _MySQL_
* _EF Core_


## Description

_The National Parks API allows creating, deleting, and editing of National Parks. This includes a one to many relationship between parks and services. The application can be viewed in Postman or swagger at https://localhost:5000/swagger_

## Setup/Installation Requirements

* _Clone this repository https://github.com/shanizalingle/national-parks.git to your desktop_
* _Navigate to /NationalParks folder and create an appsettings.json file_
* _Add the following_
```js
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[NAME OF DATABASE];uid=root;pwd=[YOUR PASSWORD];"
  }
}
```
* _Run ```dotnet restore``` and ```dotnet build``` inside the terminal_
* _With MySQL, run ```dotnet ef migrations add Initial```_
* _Run ```dotnet ef database update```_
* _Then run ```dotnet watch run```_
* _Lastly, view on  <http://localhost:5000>_

## Swagger

_View swagger documentation through ```https://localhost:5000/swagger```_

_Below are CRUD options for the API. These work with the API in live time to create, edit, and view elements of the database_

<details>
<summary>CRUD OPTIONS</summary>

* _GET /api/Parks: Allows user to look a national park by it's name, state, country, or cost_

* _POST /api/Parks: Allows user to add a new national park to the database_

* _GET /api/Parks: Allows user to look up a national park by it's parkID_

* _PUT /api/Parks: Allows user to edit an existing national park in the database with ID_

* _DELETE /api/Parks: Allows user to delete an existing national park in the database with ID_
</details>

### Swagger Interface

#### GET Method

* _Select the GET method for national parks, the route should be '/api/parks'_
* _To initialize the API you need to press 'Try it out' followed by 'Execute'_

#### POST Method

* _Select the POST method for parks, the route should be '/api/parks'_
* _To initialize the API you need to press 'Try it out' followed by 'Execute'_
* _There should now be a view of placeholder data for you to fill out_
* _Replace this information with a parks info and click 'Execute'_


## Known Bugs

* _No known bugs_

## License


_[MIT](https://en.wikipedia.org/wiki/MIT_License)_

Copyright (c) _2022_ _Shaniza Lingle_