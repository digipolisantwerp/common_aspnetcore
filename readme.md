# Common Toolbox

The Common Toolbox contains helper classes that can be useful in most ASP.NET 5 projects.

## Table of Contents

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->


- [Installation](#installation)
- [Components](#components)
  - [DisposableObject](#disposableobject)
- [Handlers](#handlers)
  - [PlatformHandler](#platformhandler)
    - [PlatformHandler.Platform](#platformhandlerplatform)
    - [Platform.IsLinux](#platformislinux)
    - [Platform.IsMac](#platformismac)
    - [Platform.IsUnix](#platformisunix)
    - [Platform.IsWindows](#platformiswindows)
    - [Platform.IsXbox](#platformisxbox)
- [Helpers](#helpers)
  - [ExceptionHelper](#exceptionhelper)
    - [ExceptionHelper.GetAllMessages()](#exceptionhelpergetallmessages)
    - [ExceptionHelper.GetAllStackTraces()](#exceptionhelpergetallstacktraces)
    - [ExceptionHelper.GetAllToStrings()](#exceptionhelpergetalltostrings)
  - [ReflectionHelper](#reflectionhelper)
    - [ReflectionHelper.GetAttributeFrom()](#reflectionhelpergetattributefrom)
    - [ReflectionHelper.GetClassesInheritingFrom()](#reflectionhelpergetclassesinheritingfrom)
    - [ReflectionHelper.GetReferencingAssemblies()](#reflectionhelpergetreferencingassemblies)
    - [ReflectionHelper.GetTypesFromAppDomain()](#reflectionhelpergettypesfromappdomain)
    - [ReflectionHelper.GetTypesThatStartWith()](#reflectionhelpergettypesthatstartwith)
    - [ReflectionHelper.GetTypesWithAttribute()](#reflectionhelpergettypeswithattribute)
  - [StringHelper](#stringhelper)
    - [StringHelper.GetValidString(string input)](#stringhelpergetvalidstringstring-input)
    - [StringHelper.GetValidString(object input)](#stringhelpergetvalidstringobject-input)
    - [StringHelper.RemoveWhitespaces(string input)](#stringhelperremovewhitespacesstring-input)
    - [StringHelper.TrimOrDefault(string input)](#stringhelpertrimordefaultstring-input)
    - [StringHelper.ToCamelCase(string input)](#stringhelpertocamelcasestring-input)
    - [StringHelper.ToPascalCase(string input)](#stringhelpertopascalcasestring-input)
    - [StringHelper.FromBase64(string input)](#stringhelperfrombase64string-input)
    - [StringHelper.ToBase64(string input)](#stringhelpertobase64string-input)
  - [UriHelper](#urihelper)
    - [UriHelper.IsValidUri(string url)](#urihelperisvaliduristring-url)
    - [UriHelper.GetPrimaryHostName()](#urihelpergetprimaryhostname)
- [Validation](#validation)
  - [ArgumentValidator](#argumentvalidator)
    - [ArgumentValidator.AssertNotEmpty()](#argumentvalidatorassertnotempty)
    - [ArgumentValidator.AssertNotNull()](#argumentvalidatorassertnotnull)
    - [ArgumentValidator.AssertNotNullOrEmpty()](#argumentvalidatorassertnotnullorempty)
    - [ArgumentValidator.AssertNotNullOrWhiteSpace()](#argumentvalidatorassertnotnullorwhitespace)
  - [DateTimeCompareAttribute](#datetimecompareattribute)
- [Version History](#version-history)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

## Installation
The toolbox is added to a project via the NuGet Package Manager in Visual Studio or by adding the package directly to the project.json file :

``` json
 "dependencies": {
    "Digipolis.Common":  "2.0.0",
 }
```

<br>
## Components

### DisposableObject

Inherit from this class if you have a class that must implement IDisposable.
In the inherited class you can implement the dispose logic by overriding the methods DisposeManagedResources and DisposeUnmanagedResources.


<br>
## Handlers

### PlatformHandler

The PlatformHandler wraps the PlatformID in a class and adds methods tho easily check which platform the source code is running on. It can be
used in a loosely coupled project where the PlatformID can be mocked for testing purposes.

#### PlatformHandler.Platform
The methods and platformID are available through the Platform property. By default the Platform property is initialized to the OS of the machine.
The Platform can be changed (e.g. for unit tests) through its setter.  

``` csharp
  PlatformHandler.Platform = new Platform(PlatformID.MacOSX);
```
#### Platform.IsLinux

Returns true if the platform is Linux.

#### Platform.IsMac

Returns true if the platform is Mac OSX.

#### Platform.IsUnix

Returns true if the platform is Unix.

#### Platform.IsWindows

Returns true if the platform is Windows.

#### Platform.IsXbox

Returns true if the platform is XBox.

<br>
## Helpers

### ExceptionHelper

The ExceptionHelper has methods to recursively extract properties of (inner-)exceptions. This can be handy when logging errors.

<br>
#### ExceptionHelper.GetAllMessages()
Returns a string with all messages of all (inner-)exceptions.

#### ExceptionHelper.GetAllStackTraces()
Returns a string with all stacktrace of all (inner-)exceptions.

#### ExceptionHelper.GetAllToStrings()
Returns a string with the result of all ToString() calls of all (inner-)exceptions.

<br>
### ReflectionHelper

The ReflectionHelper provides methods that wrap common used reflection scenario's.

#### ReflectionHelper.GetAttributeFrom()
Returns the attribute if defined on the given type, null if the type does not have the attribute.

``` csharp
   var attrib = ReflectionHelper.GetAttributeFrom<AnAttribute>(typeof(AClass));
```

#### ReflectionHelper.GetClassesInheritingFrom()
Returns a list of classes that inherit from the given class.

``` csharp
   var classes = ReflectionHelper.GetClassesInheritingFrom(Assembly.GetCallingAssembly(), typeof(BaseClass));
```

#### ReflectionHelper.GetReferencingAssemblies()
Returns a list of assemblies that reference the given assembly.

``` csharp
   var assemblies = ReflectionHelper.GetReferencingAssemblies("Digipolis.Common.dll");
```

#### ReflectionHelper.GetTypesFromAppDomain()
Returns a list of the given types in the AppDomain.

``` csharp
   var types = ReflectionHelper.GetTypesFromAppDomain("MyClass");
```

#### ReflectionHelper.GetTypesThatStartWith()
Returns a list of the types that start with the given string.

``` csharp
   var types = ReflectionHelper.GetTypesThatStartWith("Http");
```

#### ReflectionHelper.GetTypesWithAttribute()
Returns a list of the types that are decorated with the given attribute.

``` csharp
   var types = ReflectionHelper.GetTypesWithAttribute<AnAttribute>(Assembly.GetExecutingAssembly(), true);
```

<br>
### StringHelper

#### StringHelper.GetValidString(string input)
Returns a string value that contains the contents of the given string or specifies whether the string is empty or null.

#### StringHelper.GetValidString(object input)
Returns the ToString() value of the given object or null if the object is null.

#### StringHelper.RemoveWhitespaces(string input)

The input string without whitespace characters, null if the input string is null.

#### StringHelper.TrimOrDefault(string input)

Returns null (= default) if the input value is null and the trimmed value if they are not null.

#### StringHelper.ToCamelCase(string input)

Returns the given string, starting with a lowercase letter.

#### StringHelper.ToPascalCase(string input)

 Returns the given string, beginning with an uppercase letter.

#### StringHelper.FromBase64(string input)

Returns a decoded string of the base64 input string.

#### StringHelper.ToBase64(string input)

Returns the given string in base64 format.

 <br>
### UriHelper

#### UriHelper.IsValidUri(string url)
 Returns true if the given string contains a valid url.

#### UriHelper.GetPrimaryHostName()
Returns the name of the primary host.

 <br>

## Validation

### ArgumentValidator

The ArgumentValidator can be used to check arguments that are used as parameters in e.g. a method. It provides a way to enforce code contracts at
run time.

#### ArgumentValidator.AssertNotEmpty()
Raises an ArgumentException if the given string is an empty string.

#### ArgumentValidator.AssertNotNull()
Raises an ArgumentNullException if the given string or object is null.

#### ArgumentValidator.AssertNotNullOrEmpty()
Raises an ArgumentNullException if the given string is null or an ArgumentException if the given string is an empty string.

#### ArgumentValidator.AssertNotNullOrWhiteSpace()
Raises an ArgumentNullException if the given string is null or an ArgumentException if the given string is an empty string or contains only white spaces.

**Usage :**

(e.g. Code contract : builder must be an instantiated object and route must contain a value)

``` csharp
public void SetRoute(IApplicationBuilder builder, string route)
{
   ArgumentValidator.AssertNotNull(builder, nameof(builder));
   ArgumentValidator.AssertNotNullOrWhiteSpace(route, nameof(route));
   // Set the route, using the builder
}
```

The content of the exception messages can be set via the _Message_ property :

``` csharp
  ArgumentValidator.Messages.NullString = "My own null-string error message.";
  ArgumentValidator.Messages.EmptyString = "My own empty-string error message with {0} parameter.";
```

The default message values can be restored with the _SetDefaults_ method :

``` csharp
  ArgumentValidator.Messages.SetDefaults();
```

The default messages are :

| Property         | Message                   |
| ---------------- | ------------------------- |
| NullString       | {0} is null.              |
| EmptyString      | {0} is empty.             |
| WhiteSpaceString | {0} contains only spaces. |


### DateTimeCompareAttribute




## Version History

| Version | Date       | Author                                  | Description
| ------- | ---------- | ----------------------------------------| ----------------------------------------------------
| 1.0.1   | 2015-09-08 | Steven Vanden Broeck                    | Init.
| 1.0.2   | 2015-09-09 | Steven Vanden Broeck                    | ReflectionHelper.
| 1.0.3   | 2015-09-24 | Steven Vanden Broeck                    | PlatformHandler.
| 1.0.4   | 2015-09-25 | Steven Vanden Broeck                    | PlatformHandler extended.
| 1.0.5   | 2015-10-15 | Steven Vanden Broeck                    | ExceptionHelper.
| 1.1.0   | 2015-12-28 | Steven Vanden Broeck                    | Upgrade to ASP.NET 5 RC1.
| 1.2.1   | 2016-02-17 | Koen Stroobants                         | StringHelper, UriHelper, DisposableObject, DateTimeComparer.
