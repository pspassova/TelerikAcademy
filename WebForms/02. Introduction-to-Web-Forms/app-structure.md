## ASP.NET Web Forms Intro Homework ##

*Start Visual Studio and create new Web Forms App. Look at the files generated and tell what's purpose of each file. Explain the "code behind" model. *



> **App_Browser**
>  Contains browser definitions (.browser files) that ASP.NET uses to identify individual browsers and determine their  capabilities.
>  
>  **App_Code**
>  Contains source code for shared classes and business objects (for example, ..cs, and .vb files) that you want to compile as part of your application. In a dynamically compiled Web site project, ASP.NET compiles the code in the App_Code folder on the initial request to your application. Items in this folder are then recompiled when any changes are detected.
>  Code in the App_Code folder is referenced automatically in your application. The App_Code folder can contain subdirectories of files, which can include class files that in different programming languages. 
>  
>  **App_Data**
>  Contains application data files including .mdf database files, XML files, and other data store files. The App_Data folder is used by ASP.NET to store an application's local database, such as the database for maintaining membership and role information.
>  
>  **App_GlobalResources**
Contains resources (.resx and .resources files) that are compiled into assemblies with global scope. Resources in the App_GlobalResources folder are strongly typed and can be accessed programmatically.

> **App_LocalResources**
> Contains resources (.resx and .resources files) that are associated with a specific page, user control, or master page in an application.
> 
**App_Themes**
Contains a collection of files (.skin and .css files, as well as image files and generic resources) that define the appearance of ASP.NET Web pages and controls. 
> 
> **App_WebReferences**
> Contains reference contract files (.wsdl files), schemas (.xsd files), and discovery document files (.disco and .discomap files) that
> let you create a Web reference for use in an application.
> 
> **Bin** 
> Contains compiled assemblies (.dll files) for controls, components, or other code that you want to reference in your
> application. Any classes represented by code in the Bin folder are
> automatically referenced in your application.

