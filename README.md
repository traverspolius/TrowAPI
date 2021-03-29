# TrowAPI
A simple CMS Rest API and Client created with ASP.NET Core.
## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)

## General info
This solution consists of two projects, TrowCmsAPI which is the RestAPI and TrowCmsClient which is the client. This solution allows the user to create, edit and delete pages.
	
## Technologies
Project is created with: 
* Visual Studio 2019
* ASP.NET Core
* EntityFramework Core
* Newtonssoft.Json
* Bootstrap
* JQuery
* ckeditor.js

	
## Setup
In the TrowCmsAPI project confirm that DefaultConnection in the appsettings.json file has the correct information for your local computer then run the following comands from the Visual Studio console.

```
Add-Migration InitCreate
```

...then run the update database command..

```
Update-Database
```

Run the TrowCmsAPI project and confirm the the URL then in the TrowCmsClient project paste the URL into the ApiUrl consant variable in the PagesController.
```
namespace TrowCmsClient.Controllers
{
    public class PagesController : Controller
    {
        private const String ApiUrl = // TrowCmsAPI url entered here

```
