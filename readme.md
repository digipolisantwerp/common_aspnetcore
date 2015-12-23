# Common Toolbox

> The Common Toolbox contains helper classes that can be useful in most ASP.NET 5 projects.

<br>
## Installation
The toolbox is added to a project via the NuGet Package Manager in Visual Studio or by adding the package directly to the project.json file :

``` json
 "dependencies": {
    ...,
    "Toolbox.Common":  "1.1.0", 
    ...
 }
```
<br>
## Handlers

### PlatformHandler

The PlatformHandler wraps the PlatformID in a class and adds methods tho easily check which platform the source code is running on. It can be
used in a loosely coupled project where the PlatformID can be mocked for testing purposes. 

#### Property Platform
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
#### GetAllMessages
Returns a string with all messages of all (inner-)exceptions.

#### GetAllStackTraces
Returns a string with all stacktrace of all (inner-)exceptions.

#### GetAllToStrings
Returns a string with the result of all ToString() calls of all (inner-)exceptions.

<br>
### ReflectionHelper

The ReflectionHelper provides methods that wrap common used reflection scenario's.

#### GetAttributeFrom
Returns the attribute if defined on the given type, null if the type does not have the attribute.

``` csharp
   var attrib = ReflectionHelper.GetAttributeFrom<AnAttribute>(typeof(AClass));
```

#### GetClassesInheritingFrom
Returns a list of classes that inherit from the given class.

``` csharp
   var lijst = ReflectionHelper.GetClassesInheritingFrom(Assembly.GetCallingAssembly(), typeof(BaseClass));
```

#### GetReferencingAssemblies
Returns a list of assemblies that reference the given assembly.

``` csharp
   var assemblies = ReflectionHelper.GetReferencingAssemblies("Toolbox.Common.dll");
```

#### GetTypesFromAppDomain
Returns a list of the given types in the AppDomain.

``` csharp
   var lijst = ReflectionHelper.GetTypesFromAppDomain("MyClass");
```

#### GetTypesThatStartWith
Returns a list of the types that start with the given string.

``` csharp
   var lijst = ReflectionHelper.GetTypesThatStartWith("Http");
```

#### GetTypesWithAttribute
Returns a list of the types that are decorated with the given attribute.

``` csharp
   var lijst = ReflectionHelper.GetTypesWithAttribute<AnAttribute>(Assembly.GetExecutingAssembly(), true);
```

<br>
## Validation

### ArgumentValidator

The ArgumentValidator can be used to check arguments that are used as parameters in e.g. a method. It provides a way to enforce code contracts at 
run time.

#### AssertNotEmpty
Raises an ArgumentException if the given string is an empty string.

#### AssertNotNull
Raises an ArgumentNullException if the given string or object is null.

#### AssertNotNullOrEmpty
Raises an ArgumentNullException if the given string is null or an ArgumentException if the given string is an empty string.

#### AssertNotNullOrWhiteSpace
Raises an ArgumentNullException if the given string is null or an ArgumentException if the given string is an empty string or contains only white spaces.

**Usage :**
<br>
(e.g. Code contract : builder must be an instantiated object and route must contain a value)

``` csharp
public void SetRoute(IApplicationBuilder builder, string route)
{
   ArgumentValidator.AssertNotNull(builder, nameof(builder));
   ArgumentValidator.AssertNotNullOrWhiteSpace(route, nameof(route));
   // Set de route, using the builder
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
<br>
The default messages are :

| Property         | Message                   |
| ---------------- | ------------------------- |
| NullString       | {0} is null.              |
| EmptyString      | {0} is empty.             |
| WhiteSpaceString | {0} contains only spaces. |

<br>
## Versies

| Version | Author                                  | Description
| ------- | ----------------------------------------| ----------------------------------------------------
| 1.0.1   | Steven Vanden Broeck                    | Init.
| 1.0.2   | Steven Vanden Broeck                    | ReflectionHelper.
| 1.0.3   | Steven Vanden Broeck                    | PlatformHandler.
| 1.0.4   | Steven Vanden Broeck                    | PlatformHandler extended.
| 1.0.5   | Steven Vanden Broeck                    | ExceptionHelper.
| 1.1.0   | Steven Vanden Broeck                    | Upgrade to ASP.NET 5 RC1.
