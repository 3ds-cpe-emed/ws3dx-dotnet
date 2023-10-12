
# WS3DX .NET
The WS3DX .NET repository contains a collection of C# client SDKs to access Dassault Systèmes 3DEXPERIENCE web services.

## Overview
The WS3DX .NET repository contains multiple Visual Studio solutions one for each 3DEXPERIENCE Web Service family. Check the [3DEXPERIENCE Web Service public documentation](https://media.3ds.com/support/documentation/developer/Cloud/en/DSDoc.htm?show=CAAiamREST/CAATciamRESTToc.htm) for details on how the 3DEXPERIENCE web services are organized.

The solution files are named in the form *ws3dx.**xyz**.sln* where **xyz** matches the 3DEXPERIENCE web service family abreviation name that the solution addresses (e.g. *ws3dx.**dseng**.sln* for engineering item, *ws3dx.**dsmfg**.sln* for manufacturing items - see coverage table below for more).

The only current exception is the *wd3dx.sln* file that is used only has an aggregator for all projects.

With a few exceptions a ws3dx solution normally contains 5 projects. As a general example, for the {xyz} corpus, we would have the followin projects:

- *ws3dx.**{xyz}.data**.csproj* - Definition of the specific family attributes that are exchanged with the web services in the form of interfaces.
- *ws3dx.**{xyz}.core** * - Classes that implement the interfaces in data for serialization and deserialization. Client services exposing the 3DEXPERIENCE web service resources to the client application logic.
- *ws3dx.**{xyz}.tests** * - Unit tests classes that demonstrate how to used a given the client service methods. 

- *ws3dx.**shared** *- Data and utilities logic that can be commonly reused accross different families.
- *ws3dx.**core** *- Common application logic and base services. 

## 3DEXPERIENCE Web Services coverage
The current (initial) set of C# client web services SDKs provided is detailed in the table below. This table will be expanded as time and opportunity allows to incorporate other families.

The main priority is to support the 3DEXPERIENCE Cloud Web Services. Support for specific 3DEXPERIENCE OnPremise Web Services is second priority. Please note however that Cloud and OnPremise web services are - for the most part - the same.

| 3DEXPERIENCE WS | VS Solution | Versions |
|----------|-----------------|--------|
|[Advanced-Filter Web Services 1.0.0](https://media.3ds.com/support/documentation/developer/Cloud/en/DSDoc.htm?show=CAAAdvancedFilteringWS/dsadvfilter_v1.htm)|[ws3dx.dsadvfilter](./ws3dx.dsadvfilter)| 2023x FD01/02/03 |
|[Bookmark REST Services 1.1.1](https://media.3ds.com/support/documentation/developer/Cloud/en/DSDoc.htm?show=CAABookmarkWS/BookmarkAPI1_v1.htm)|[ws3dx.dsbks](./ws3dx.dsbks)| 2023x FD01/02/03/04 |
|[CAD Collaboration Web Services 1.5.0](https://media.3ds.com/support/documentation/developer/Cloud/en/DSDoc.htm?show=CAAXCADWS/dsxcad_v1.htm)|[ws3dx.dsxcad](./ws3dx.dsxcad)| 2023x FD01/02/03/04 |
|[Issue Web Services 1.1.0](https://media.3ds.com/support/documentation/developer/Cloud/en/DSDoc.htm?show=CAAChangeWS/dslc_change_issue_v1.htm)|[ws3dx.dsiss](./ws3dx.dsiss)| 2023x FD01/02/03/04 |
|[Derived Outputs Web Services 1.2.1](https://media.3ds.com/support/documentation/developer/Cloud/en/DSDoc.htm?show=CAADerivedOutputsWS/dsdo_v1.htm)|[ws3dx.dsdo](./ws3dx.dsdo)| 2023x FD01/03/04 |
|[Document REST Services 1.1.5](https://media.3ds.com/support/documentation/developer/Cloud/en/DSDoc.htm?show=CAADocumentWS/dsdoc_v1.htm)|[ws3dx.document](./ws3dx.document)| 2023x FD01/02/03/04 |
|[Engineering Web Services 1.3.0](https://media.3ds.com/support/documentation/developer/Cloud/en/DSDoc.htm?show=CAAEngineeringWS/dseng_v1.htm)|[ws3dx.dseng](./ws3dx.dseng)| 2023x FD01/02/03/04 |
|[IP Classification Web Services 1.1.2](https://media.3ds.com/support/documentation/developer/Cloud/en/DSDoc.htm?show=CAAClassificationWS/dslib_v1.htm)|[ws3dx.dslib](./ws3dx.dslib)| 2023x FD01/03 |
|[Collaborative Lifecycle Web Services 1.2.0](https://media.3ds.com/support/documentation/developer/Cloud/en/DSDoc.htm?show=CAALifecycleWS/dslc_lifecycle_v1.htm)|[ws3dx.dslc](./ws3dx.dslc)| 2023x FD01/03/04 |
|[Manufacturing Item Web Services 1.12.0](https://media.3ds.com/support/documentation/developer/Cloud/en/DSDoc.htm?show=CAAManufItemWS/dsmfg_v1.htm)|[ws3dx.dsmfg](./ws3dx.dsmfg)| 2023x FD01/02/03/04 |
|[Manufacturing Process Web Services 1.11.0](https://media.3ds.com/support/documentation/developer/Cloud/en/DSDoc.htm?show=CAAManufProcessWS/dsprcs_v1.htm)|[ws3dx.dsprcs](./ws3dx.dsprcs)| 2023x FD01/03/04 |
|[dssrc: Manufacturer Equivalent Items corpus 1.0.0](https://media.3ds.com/support/documentation/developer/Cloud/en/DSDoc.htm?show=CAAManufacturerEqItemWS/dssrc_mei_v1.htm)|[ws3dx.dssrc](./ws3dx.dssrc)| 2023x FD01/02/03/04 |
|[Portfolio Web Services 1.9.0](https://media.3ds.com/support/documentation/developer/Cloud/en/DSDoc.htm?show=CAAPortfolioWS/dspfl_v1.htm)|[ws3dx.dspfl](./ws3dx.dspfl)| 2023x FD01/03 |
|[Project Rest Services 1.2.0](https://media.3ds.com/support/documentation/developer/Cloud/en/DSDoc.htm?show=CAAProjectManagementWSTechArticles/dsproject_v1.2.htm)|[ws3dx.project.project](./ws3dx.project/project)| 2023x FD01/03/04 |
|[Task Rest Services 1.1.0](https://media.3ds.com/support/documentation/developer/Cloud/en/DSDoc.htm?show=CAAProjectManagementWSTechArticles/dstask_v1.htm)|[ws3dx.project.task](./ws3dx.project/task)| 2023x FD01/03/04 |
|[Program Web Services 1.0.0](https://media.3ds.com/support/documentation/developer/Cloud/en/DSDoc.htm?show=CAAProjectManagementWSTechArticles/dsprogram_v1.htm)|[ws3dx.project.program](./ws3dx.project/program)| 2023x FD01/03/04 |
|[Risk Management Rest Services 1.1.0](https://media.3ds.com/support/documentation/developer/Cloud/en/DSDoc.htm?show=CAAProjectManagementWSTechArticles/dsrisk_v1.1.htm)|[ws3dx.project.risk](./ws3dx.project/risk)|  2023x FD01/03/04 |
|[Raw Material Public Web Services 1.1.0](https://media.3ds.com/support/documentation/developer/Cloud/en/DSDoc.htm?show=CAARawMaterialWS/dsrm_v1.htm)|[ws3dx.dsrm](./ws3dx.dsrm)| 2023x FD01/03 |
|[Requirement Web Services 1.0.0](https://media.3ds.com/support/documentation/developer/Cloud/en/DSDoc.htm?show=CAARequirementWS/dsreq_v1.htm)|[ws3dx.dsreq](./ws3dx.dsreq)| 2023x FD01/03/04 |
|[Resource Web Services 1.3.0](https://media.3ds.com/support/documentation/developer/Cloud/en/DSDoc.htm?show=CAAResourceWS/dsrsc_v1.htm)|[ws3dx.dsrsc](./ws3dx.dsrsc)| 2023x FD01/02/03 |

Note access to the 3DEXPERIENCE web service public documentation requires a 3DEXPERIENCE ID.

## Getting Started
In order to compile the source code you need to have Visual Studio 2019 and .NET Core 3.1 available. Other Visual Studio versions have not been tried and are currently not supported.

- Clone the repository to a local folder

- Select the solution file you are interested based on the 3DEXPERIENCE web services coverage  list below.

The following Nuget packages are required but should be downloaded and installed automatically for you. 

For the core and data libraries:
 
| Nuget package | Version |
|----------|-----------------|
|System.Net.Http.Json|6.0.0|
|System.Text.Json|6.0.7|

For the Unit Tests:

| Nuget package | Version |
|----------|-----------------|
|NUnit|3.13.1|
|NUnit3TestAdapter|3.17.0|
|Microsoft.NET.Test.Sdk|16.9.4|
|coverlet.collector|3.0.2|

## SDK Design Goals
The following points describe the goals driving some of the design decisions taken in this project.

- **Easier adoption of 3DEXPERIENCE web services** a) Even if it is easy to create Postman APIs and collections to test the 3DEXPERIENCE web services, there is a lack of a consistent, robust, client side SDK to be used as a base for real-world integration applications. b) Reuse of Web Services documentation as comments in the language.

- **Shorten development time** a) translate 3DEXPERIENCE concepts into target language specific constructs that most developers in that language are familiar with. b) Provide Unit Tests to show how to quickly setup and use the SDK. c) Encapsulate some of the 3DEXPERIENCE concepts (e.g. Security Context, CSRF, ...) in lower abstraction layers - this doesn't mean that it is not important for developers to know about these but they can be hidden out of view and handled automatically at lower code levels for most common uses.  

- **Keep up with changes** with the continuous release of new and updated web services it is not easy to maintain updates on a strongly typed language SDK. Hence the decision to create an semi-automated process to generate this SDK.

- **Open Source, shared development** this is an evolving work in progress project driven by our CPE Emed team. It is a tool for collaboration between developers, it is not a standard Dassault Systèmes product. See below how you can contribute.

- **Consistency**, as much as possible, on naming types and properties accross the different families. Follow best, or at most common, formatting practices of the target language.

## SDK Design Choices
Find below some of the technical decisions taken to support 3DEXPERIENCE web service concepts:

### Mask concept as interface
The mask concept determines what should be returned from a given web service. Depending on the mask parameter passed the same web service can return different attributes. Many (but not all) 3DEXPERIENCE web services make use of this mask concept.

This has been translated in the C# SDK as an interface that is marked with the ```csharp MaskSchema ``` attribute. for instance :
```csharp 
namespace ws3dx.dseng.data 
{
 [MaskSchema('dskern:Mask.Default')]
 public interface IEngItemDefaultMask : IItem
 {}
}
```
To restrict the client service methods to use only the masks that are supported by each web service, would ideally have been done on the method definition itself using template constraints 
(e.g```IList<T> method1<T>(...) where T : IMask1, IMask2```) However, even if C# allows this syntax, it does not give the expected results. Due to this limitation, this type-checking constraint needs to be done at runtime. This is the responsibility of the ``` GenericParameterConstraintUtils.CheckConstraints``` that is used as input validation in many of the client service functions.

### Enterprise attributes
Enterprise Attributes provide a way to extend the existing 3DEXPERIENCE standard attributes with additional custom attributes associated to different types of items. The Enterprise Attributes concept is common to all Cloud flavours as well as OnPremise environments. Enterprise Attributes come in the form of key-value pairs but given that it is not possible to know in advance their definitions, as each customer will implement ones depending on their needs, the current SDK support for this is to derive enterprise attributes interfaces from an ```csharp IDictionary<string, object>```. This gives the greater flexibility to serialize/deserialize a key-value pair structure. 

### Customer attributes
At the web services layer, Customer Attributes are similar to Enterprise Attributes. They also provide a mechanism to extend the 3DEXPERIENCE data model with additional attributes the only 0difference being the internal 3DEXPERIENCE structure from which they are generated (e.g. TXO Deployment Extensions or Specialization Packages). 

Unlike Enterprise Attributes however, Customer Attributes are not available on public Cloud and are only applicable to private and dedicate Cloud and OnPremise environments. In the same way that Enterprise Attributes, the support for it is to derive from an ```csharp IDictionary<string, object>``` which gives the maximum freedom to set a key-value pair.

### simplify return collections
Many web services return a collection in the form
For instance in the case of ```/resources/v1/modeler/dseng/dseng:EngItem/{ID}``` we could have, as a successful response (simplified):
```jsonc {
    "totalItems": 1,
    "member": [
        {
		    "id": "A437358E0000861C61E6E89F0000C526",
            "title": "Physical Product00410106",
            "type": "VPMReference",
			"cestamp": "795A0F6C8258000061EE6364000476D6",
				//...
        }
    ],
    "nlsLabel": {
       //...
    }
}
```

The data that we are interested comes in the array of the json ```member``` attribute. So, in order to simplify, a design decision was made to directly to wrap the return type within an IList or IEnumeration. 

In the future we want to be able to also differentiate web services that return at most a single value from those that can return multiple values. In the first case we can even simplify further by returning a single object rather than the IList/IEnumeration.

## Known Limitations
- *$fields* and *$include* parameters are not yet fully supported by the SDK. If needed these will have to be added manually and the return types redefined with the attributes added by the fiels or include parameters.

- In some cases implementation classes are missing.

- Upload/Download document functions required

## Semi-automated SDK generation process
In order to be able to keep up with new updates every new 3DEXPERIENCE release, or FD release, the creation of this SDK relies on a semi-automated process.

This process relies on two main transformation steps.

- Step 1: **Transformation of the 3DEXPERIENCE Web Services OpenAPI documentation to a neutral UML model** in CAMEO Enterprise Architect. The OpenAPI json file of each individual 3DEXPERIENCE web services family is downloaded from the public  site and a corresponding SDK UML-based model is created. This is done using a custom CAMEO plugin built on purpose.

- Step 2: **Transformation of the SDK Model into source code**. With the help of the same custom CAMEO plugin and some Mustache files the C# sharp code for the data, the services and the tests is generated. As explained before currently C# code is created but other languages (e.g. Java) are being investigated.

Given that the process is still being improved some manual tweaks might be required at the end of any of the steps above.

## Contributing
Feel free to contribute by creating issues on the repository. If you would like to contribute with code contact us directly.

## Next Steps
Some of the planned next activities.

- Test and refine both the SDK and the automated generation process.

- Creation of Nuget packages

- Add more 3DEXPERIENCE Web service families

- Work on a Java equivalent SDK

## Related Projects
This project is a spin-off and learning experience result of the first SDK project here:

- [3DXWS Dotnet Core SDK](https://github.com/3ds-cpe-emed/3dxws-dotnet-core-sdk) in the future while still active, this project will be discontinued and archived in the future.

## License
The [MIT license](https://opensource.org/license/mit/) applies to all of the artifacts produced and maintained in this repository.

## Credits
Dassault Systèmes Euromed CPE

## Disclaimer
As described by the associated open source MIT license, <ins>this is not an official dassault systèmes product</ins>, so, it's not subject, under any circumstance, to official Dassault Systèmes warranty or support.
