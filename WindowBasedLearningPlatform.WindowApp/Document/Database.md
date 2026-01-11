USE [master]
GO
/****** Object:  Database [LearningPlatformDB]    Script Date: 1/11/2026 10:57:03 PM ******/
CREATE DATABASE [LearningPlatformDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LearningPlatformDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL17.MSSQLSERVER\MSSQL\DATA\LearningPlatformDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LearningPlatformDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL17.MSSQLSERVER\MSSQL\DATA\LearningPlatformDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [LearningPlatformDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LearningPlatformDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LearningPlatformDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LearningPlatformDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LearningPlatformDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LearningPlatformDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LearningPlatformDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [LearningPlatformDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LearningPlatformDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LearningPlatformDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LearningPlatformDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LearningPlatformDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LearningPlatformDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LearningPlatformDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LearningPlatformDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LearningPlatformDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LearningPlatformDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LearningPlatformDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LearningPlatformDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LearningPlatformDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LearningPlatformDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LearningPlatformDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LearningPlatformDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LearningPlatformDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LearningPlatformDB] SET RECOVERY FULL 
GO
ALTER DATABASE [LearningPlatformDB] SET  MULTI_USER 
GO
ALTER DATABASE [LearningPlatformDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LearningPlatformDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LearningPlatformDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LearningPlatformDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LearningPlatformDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LearningPlatformDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [LearningPlatformDB] SET OPTIMIZED_LOCKING = OFF 
GO
ALTER DATABASE [LearningPlatformDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [LearningPlatformDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [LearningPlatformDB]
GO
/****** Object:  Table [dbo].[Tbl_LessonContents]    Script Date: 1/11/2026 10:57:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_LessonContents](
	[ContentId] [int] IDENTITY(1,1) NOT NULL,
	[LessonCode] [varchar](50) NOT NULL,
	[ContentType] [varchar](50) NULL,
	[ContentBody] [nvarchar](max) NOT NULL,
	[LessonId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ContentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Lessons]    Script Date: 1/11/2026 10:57:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Lessons](
	[LessonId] [int] IDENTITY(1,1) NOT NULL,
	[LessonCode] [varchar](50) NOT NULL,
	[SectionCode] [varchar](50) NOT NULL,
	[LessonTitle] [varchar](200) NOT NULL,
	[SortOrder] [int] NOT NULL,
	[SectionId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LessonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Sections]    Script Date: 1/11/2026 10:57:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Sections](
	[SectionId] [int] IDENTITY(1,1) NOT NULL,
	[SectionCode] [varchar](50) NOT NULL,
	[SectionName] [varchar](100) NOT NULL,
	[SortOrder] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_User]    Script Date: 1/11/2026 10:57:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[LoginPassword] [nvarchar](255) NOT NULL,
	[CreatedDateTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_LessonContents] ON 

INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (1, N'CSharp.Intro', N'MARKDOWN', N'# Welcome to C#
C# (pronounced "C-Sharp") is a modern, object-oriented programming language developed by Microsoft. It runs on the .NET Framework.

## Why learn C#?
* **Versatile:** Used for web, mobile, desktop, and game development (Unity).
* **Powerful:** Part of the .NET ecosystem.
* **Easy to Start:** Readable syntax similar to Java and C++.

In this course, we will cover the basics of syntax, variables, loops, and more.

### Example Code
```csharp
// This is a simple C# program
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine("Welcome to C# Learning!");
    }
}
```', 1)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (2, N'CSharp.Variables', N'MARKDOWN', N'# Variables in C#
Variables are containers for storing data values. In C#, every variable must have a specified **Data Type**.

## Common Types
* `int`: Whole numbers (e.g., 123)
* `double`: Decimal numbers (e.g., 19.99)
* `char`: Single characters (e.g., ''a'')
* `string`: Text (e.g., "Hello")
* `bool`: True or False

### Declaring Variables
To declare a variable, use the syntax: `type variableName = value;`

```csharp
using System;

class Program
{
    static void Main()
    {
        int myAge = 25;
        string myName = "Alice";
        bool isStudent = true;

        Console.WriteLine("Name: " + myName);
        Console.WriteLine("Age: " + myAge);
        Console.WriteLine("Is Student? " + isStudent);
    }
}
```', 2)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (3, N'CSharp.Input', N'MARKDOWN', N'# User Input
To make programs interactive, we often need to read what the user types.

## Console.ReadLine()
The `Console.ReadLine()` method allows you to read a string from the user.

> **Note:** `ReadLine()` always returns a string. If you need a number, you must convert it (e.g., using `Convert.ToInt32()`).

```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter your username:");
        // In a real console, you would type here. 
        // For this demo, we simulate input.
        string userName = "StudentUser"; 
        
        Console.WriteLine("Username is: " + userName);
    }
}
```', 3)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (4, N'CSharp.IfElse', N'MARKDOWN', N'# Making Decisions (If/Else)
C# supports logical conditions from mathematics (Less than, Greater than, Equal to, etc.).

You can use the `if` statement to specify a block of C# code to be executed if a condition is **True**.

## Syntax
```csharp
if (condition) 
{
  // block of code to be executed if the condition is True
} 
else 
{
  // block of code to be executed if the condition is False
}
```

### Example
```csharp
using System;

class Program
{
    static void Main()
    {
        int time = 20;
        
        if (time < 18) 
        {
            Console.WriteLine("Good day.");
        } 
        else 
        {
            Console.WriteLine("Good evening.");
        }
    }
}
```', 4)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (5, N'CSharp.Loops', N'MARKDOWN', N'# Loops
Loops can execute a block of code as long as a specified condition is reached.

## The While Loop
The `while` loop loops through a block of code as long as a specified condition is `True`.

## The For Loop
When you know exactly how many times you want to loop, use the `for` loop instead of a while loop.

```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Counting to 5:");
        
        for (int i = 1; i <= 5; i++) 
        {
            Console.WriteLine(i);
        }
    }
}
```', 5)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (6, N'CSharp.Arrays', N'MARKDOWN', N'# Arrays
Arrays are used to store multiple values in a single variable, instead of declaring separate variables for each value.

## Declaring an Array
To declare an array, define the variable type with square brackets:
`string[] cars;`

## Initializing
You can specify the values immediately:
`string[] cars = {"Volvo", "BMW", "Ford", "Mazda"};`

## Accessing Elements
Access an array element by referring to the index number. **Note:** Array indexes start with 0.

```csharp
using System;

class Program
{
    static void Main()
    {
        string[] cars = {"Volvo", "BMW", "Ford", "Mazda"};
        Console.WriteLine(cars[0]); // Outputs Volvo
    }
}
```', 6)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (7, N'CSharp.ArrayMethods', N'MARKDOWN', N'# Array Methods
There are many array methods available, for example `Sort()`, which sorts an array alphabetically or in an ascending order.

Another useful namespace is `System.Linq`, which provides methods like `Min`, `Max`, and `Sum`.

```csharp
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] myNumbers = {5, 1, 8, 9};
        
        Console.WriteLine("Max Value: " + myNumbers.Max());  // returns 9
        Console.WriteLine("Min Value: " + myNumbers.Min());  // returns 1
        Console.WriteLine("Sum Value: " + myNumbers.Sum());  // returns 23
    }
}
```', 7)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (8, N'CSharp.Strings', N'MARKDOWN', N'# Strings
A string variable contains a collection of characters surrounded by double quotes.

## String Length
A string in C# is actually an object, which contains properties and methods that can perform certain operations on strings. For example, the length of a string can be found with the `Length` property.

## ToUpper() and ToLower()
There are many string methods available, for example `ToUpper()` and `ToLower()`.

```csharp
using System;

class Program
{
    static void Main()
    {
        string txt = "Hello World";
        Console.WriteLine("The length of the txt string is: " + txt.Length);
        Console.WriteLine(txt.ToUpper());   
        Console.WriteLine(txt.ToLower());   
    }
}
```', 8)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (9, N'CSharp.Methods', N'MARKDOWN', N'# Methods
A method is a block of code which only runs when it is called.
You can pass data, known as parameters, into a method.
Methods are used to perform certain actions, and they are also known as functions.

## Create a Method
A method is defined with the name of the method, followed by parentheses `()`.

```csharp
using System;

class Program
{
    static void MyMethod()
    {
        Console.WriteLine("I just got executed!");
    }

    static void Main()
    {
        MyMethod();
        MyMethod();
    }
}
```', 9)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (10, N'CSharp.MethodParams', N'MARKDOWN', N'# Parameters and Arguments
Information can be passed to methods as parameter. Parameters act as variables inside the method.

## Return Values
The `void` keyword indicates that the method should not return a value. If you want the method to return a value, you can use a primitive data type (such as `int` or `double`) instead of `void`, and use the `return` keyword.

```csharp
using System;

class Program
{
    static int PlusMethod(int x, int y)
    {
        return x + y;
    }

    static void Main()
    {
        int z = PlusMethod(5, 3);
        Console.WriteLine("The sum is: " + z);
    }
}
```', 10)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (11, N'CSharp.Overloading', N'MARKDOWN', N'# Method Overloading
With method overloading, multiple methods can have the same name with different parameters.

Example:
`int MyMethod(int x)`
`float MyMethod(float x)`
`double MyMethod(double x, double y)`

### Example Code
```csharp
using System;

class Program
{
    static int PlusMethod(int x, int y)
    {
        return x + y;
    }

    static double PlusMethod(double x, double y)
    {
        return x + y;
    }

    static void Main()
    {
        int myNum1 = PlusMethod(8, 5);
        double myNum2 = PlusMethod(4.3, 6.26);
        Console.WriteLine("Int: " + myNum1);
        Console.WriteLine("Double: " + myNum2);
    }
}
```', 11)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (12, N'CSharp.Classes', N'MARKDOWN', N'# Classes and Objects
C# is an object-oriented programming language.
Everything in C# is associated with classes and objects, along with its attributes and methods.

* **Class:** A template or blueprint (e.g., Car).
* **Object:** An instance of a class (e.g., Toyota, Ford).

### Create a Class
```csharp
using System;

class Car
{
    string color = "red";

    static void Main()
    {
        Car myObj = new Car();
        Console.WriteLine(myObj.color);
    }
}
```', 12)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (13, N'CSharp.Members', N'MARKDOWN', N'# Class Members
Fields and methods inside classes are often referred to as "Class Members".

* **Fields:** Variables inside a class.
* **Methods:** Functions inside a class.

### Example
```csharp
using System;

class MyClass
{
    // Class members
    string color = "red";        // field
    int maxSpeed = 200;          // field
    
    public void fullThrottle()   // method
    {
        Console.WriteLine("The car is going as fast as it can!");
    }

    static void Main()
    {
        MyClass myObj = new MyClass();
        Console.WriteLine(myObj.color);
        Console.WriteLine(myObj.maxSpeed);
        myObj.fullThrottle();
    }
}
```', 13)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (14, N'CSharp.Constructors', N'MARKDOWN', N'# Constructors
A constructor is a special method that is used to initialize objects. The advantage of a constructor, is that it is called when an object of a class is created.

Note that the constructor name must match the class name, and it cannot have a return type.

### Example
```csharp
using System;

class Car
{
    public string model;

    // Create a class constructor for the Car class
    public Car(string modelName)
    {
        model = modelName;
    }

    static void Main()
    {
        Car Ford = new Car("Mustang");
        Console.WriteLine(Ford.model);
    }
}
```', 14)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (15, N'CSharp.Access', N'MARKDOWN', N'# Access Modifiers
Access modifiers define the scope and visibility of a class member.

* **public**: The code is accessible for all classes.
* **private**: The code is only accessible within the same class.
* **protected**: The code is accessible within the same class, or in a class that is inherited from that class.

### Example
```csharp
using System;

class Car
{
    public string model = "Mustang";
}

class Program
{
    static void Main()
    {
        Car myCar = new Car();
        Console.WriteLine(myCar.model);
    }
}
```', 15)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (16, N'CSharp.Abstract', N'MARKDOWN', N'# Abstract Classes and Methods
Data abstraction is the process of hiding certain details and showing only essential information to the user.

* **Abstract class:** cannot be used to create objects.
* **Abstract method:** can only be used in an abstract class, and it does not have a body.

### Example
```csharp
using System;

abstract class Animal
{
    public abstract void animalSound();
    public void sleep()
    {
        Console.WriteLine("Zzz");
    }
}

class Pig : Animal
{
    public override void animalSound()
    {
        Console.WriteLine("The pig says: wee wee");
    }
}

class Program
{
    static void Main()
    {
        Pig myPig = new Pig();
        myPig.animalSound();
        myPig.sleep();
    }
}
```', 16)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (17, N'CSharp.Enums', N'MARKDOWN', N'# C# Enums
An `enum` is a special "class" that represents a group of constants (unchangeable/read-only variables).

To create an enum, use the `enum` keyword (instead of class or interface), and separate the enum items with a comma.

### Example
```csharp
using System;

enum Level 
{
  Low,
  Medium,
  High
}

class Program
{
  static void Main()
  {
    Level myVar = Level.Medium;
    Console.WriteLine(myVar);
  }
}
```', 17)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (18, N'CSharp.Files', N'MARKDOWN', N'# C# Files
The File class from the `System.IO` namespace allows us to work with files.

Common methods:
* `WriteAllText()`: Creates a new file, writes the specified string to the file, and then closes the file.
* `ReadAllText()`: Reads the contents of a file.

### Example
```csharp
using System;
using System.IO; 

class Program
{
  static void Main()
  {
    string writeText = "Hello World!";
    // Write
    File.WriteAllText("filename.txt", writeText);

    // Read
    string readText = File.ReadAllText("filename.txt");
    Console.WriteLine(readText);
  }
}
```', 18)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (19, N'CSharp.Exceptions', N'MARKDOWN', N'# C# Exceptions
The `try` statement allows you to define a block of code to be tested for errors while it is being executed.
The `catch` statement allows you to define a block of code to be executed, if an error occurs in the try block.

### Example
```csharp
using System;

class Program
{
  static void Main()
  {
    try
    {
      int[] myNumbers = {1, 2, 3};
      Console.WriteLine(myNumbers[10]); // Error!
    }
    catch (Exception e)
    {
      Console.WriteLine("Something went wrong.");
    }
  }
}
```', 19)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (20, N'CSharp.Math', N'MARKDOWN', N'# C# Math
The C# Math class has many methods that allows you to perform mathematical tasks on numbers.

* `Math.Max(x, y)`
* `Math.Min(x, y)`
* `Math.Sqrt(x)`
* `Math.Abs(x)`
* `Math.Round()`

### Example
```csharp
using System;

class Program
{
  static void Main()
  {
    Console.WriteLine(Math.Max(5, 10));
    Console.WriteLine(Math.Sqrt(64));
    Console.WriteLine(Math.Abs(-4.7));
    Console.WriteLine(Math.Round(9.99));
  }
}
```', 20)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (21, N'CSharp.StringsAdv', N'MARKDOWN', N'# String Properties & Methods
A string in C# is an object that contains properties and methods that can perform certain operations on strings.

## Length
The length of a string can be found with the `Length` property:

```csharp
string txt = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
Console.WriteLine("The length of the txt string is: " + txt.Length);
```

## ToUpper() and ToLower()
These methods return a copy of the string converted to uppercase or lowercase:

```csharp
string txt = "Hello World";
Console.WriteLine(txt.ToUpper());   // Outputs "HELLO WORLD"
Console.WriteLine(txt.ToLower());   // Outputs "hello world"
```

## String Concatenation
The `+` operator can be used between strings to combine them. This is called concatenation:

```csharp
string firstName = "John";
string lastName = "Doe";
string name = firstName + " " + lastName;
Console.WriteLine(name);
```', 21)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (22, N'CSharp.Booleans', N'MARKDOWN', N'# C# Booleans
Very often, in programming, you will need a data type that can only have one of two values, like:
* YES / NO
* ON / OFF
* TRUE / FALSE

For this, C# has a `bool` data type, which can take the values `true` or `false`.

### Boolean Values
A boolean type is declared with the `bool` keyword and can only take the values `true` or `false`:

```csharp
bool isCSharpFun = true;
bool isFishTasty = false;
Console.WriteLine(isCSharpFun);   // Outputs True
Console.WriteLine(isFishTasty);   // Outputs False
```

### Boolean Expression
A Boolean expression returns a boolean value: `True` or `False`, by comparing values/variables.

```csharp
int x = 10;
int y = 9;
Console.WriteLine(x > y); // returns True, because 10 is higher than 9
```', 22)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (23, N'CSharp.Switch', N'MARKDOWN', N'# C# Switch Statement
Use the `switch` statement to select one of many code blocks to be executed.

### Syntax
```csharp
switch(expression) 
{
  case x:
    // code block
    break;
  case y:
    // code block
    break;
  default:
    // code block
}
```

This is how it works:
* The `switch` expression is evaluated once.
* The value of the expression is compared with the values of each `case`.
* If there is a match, the associated block of code is executed.

### Example
```csharp
int day = 4;
switch (day) 
{
  case 1:
    Console.WriteLine("Monday");
    break;
  case 2:
    Console.WriteLine("Tuesday");
    break;
  case 3:
    Console.WriteLine("Wednesday");
    break;
  case 4:
    Console.WriteLine("Thursday");
    break;
  case 5:
    Console.WriteLine("Friday");
    break;
  case 6:
    Console.WriteLine("Saturday");
    break;
  case 7:
    Console.WriteLine("Sunday");
    break;
}
// Outputs "Thursday" (day 4)
```', 23)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (24, N'CSharp.Break', N'MARKDOWN', N'# C# Break and Continue

### Break
You have already seen the `break` statement used in an earlier chapter of this tutorial. It was used to "jump out" of a switch statement.

The `break` statement can also be used to jump out of a **loop**.

```csharp
for (int i = 0; i < 10; i++) 
{
  if (i == 4) 
  {
    break;
  }
  Console.WriteLine(i);
}
```

### Continue
The `continue` statement breaks one iteration (in the loop), if a specified condition occurs, and continues with the next iteration in the loop.

```csharp
for (int i = 0; i < 10; i++) 
{
  if (i == 4) 
  {
    continue;
  }
  Console.WriteLine(i);
}
```', 24)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (25, N'CSharp.Casting', N'MARKDOWN', N'# C# Type Casting
Type casting is when you assign a value of one data type to another type.

In C#, there are two types of casting:

* **Implicit Casting** (automatically) - converting a smaller type to a larger type size
  `char` -> `int` -> `long` -> `float` -> `double`

* **Explicit Casting** (manually) - converting a larger type to a smaller size type
  `double` -> `float` -> `long` -> `int` -> `char`

### Implicit Casting
Implicit casting is done automatically when passing a smaller size type to a larger size type:

```csharp
int myInt = 9;
double myDouble = myInt;       // Automatic casting: int to double

Console.WriteLine(myInt);      // Outputs 9
Console.WriteLine(myDouble);   // Outputs 9
```

### Explicit Casting
Explicit casting must be done manually by placing the type in parentheses in front of the value:

```csharp
double myDouble = 9.78;
int myInt = (int) myDouble;    // Manual casting: double to int

Console.WriteLine(myDouble);   // Outputs 9.78
Console.WriteLine(myInt);      // Outputs 9
```', 25)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (26, N'CSharp.Dates', N'MARKDOWN', N'# C# Dates
C# does not have a built-in Date class, but you can import the `System` namespace to use the `DateTime` struct.

### Current Date and Time
To get the current date and time, use the `DateTime.Now` property.

```csharp
using System;

class Program
{
  static void Main()
  {
    DateTime myObj = DateTime.Now;
    Console.WriteLine(myObj);
  }
}
```

### Formatting
You can format the date using the `ToString()` method with format strings like "yyyy-MM-dd".

```csharp
DateTime myObj = DateTime.Now;
Console.WriteLine(myObj.ToString("dd/MM/yyyy"));
```', 26)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (27, N'CSharp.ArrayList', N'MARKDOWN', N'# C# ArrayList
The `ArrayList` class is a non-generic collection that can store elements of any data type. It is found in the `System.Collections` namespace.

Unlike arrays, an ArrayList can grow dynamically. However, because it stores items as `object`, it is slower than generic collections and requires casting when retrieving items.

**Note:** In modern C#, `List<T>` is preferred over `ArrayList`.

```csharp
using System;
using System.Collections; // Required for ArrayList

class Program
{
  static void Main()
  {
    ArrayList myArry = new ArrayList();
    myArry.Add("Hello");
    myArry.Add(123); // Can add different types
    myArry.Add(true);
    
    foreach (var item in myArry)
    {
        Console.WriteLine(item);
    }
  }
}
```', 27)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (28, N'CSharp.List', N'MARKDOWN', N'# C# List<T>
The `List<T>` class is the most commonly used collection in C#. It is a generic version of ArrayList found in `System.Collections.Generic`.

It is strongly typed, meaning you must specify the data type it will hold (e.g., `List<int>` or `List<string>`).

### Key Methods
* `Add()`: Adds an item to the end.
* `Remove()`: Removes the first occurrence of a specific object.
* `Count`: Gets the number of elements.

```csharp
using System;
using System.Collections.Generic;

class Program
{
  static void Main()
  {
    List<string> food = new List<string>();
    food.Add("Pizza");
    food.Add("Burger");
    food.Add("Sushi");
    
    Console.WriteLine(food[0]); // Access like array
    
    food.Remove("Burger");
    
    Console.WriteLine("Count: " + food.Count);
  }
}
```', 28)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (29, N'CSharp.Dictionary', N'MARKDOWN', N'# C# Dictionary
A `Dictionary` stores data in key-value pairs. Keys must be unique, but values can be duplicated.

It is found in `System.Collections.Generic`.

### Accessing Items
You access values by referring to the key name inside square brackets, like `cities["UK"]`.

```csharp
using System;
using System.Collections.Generic;

class Program
{
  static void Main()
  {
    Dictionary<string, string> cities = new Dictionary<string, string>();
    cities.Add("UK", "London");
    cities.Add("USA", "New York");
    cities.Add("India", "Mumbai");

    Console.WriteLine(cities["USA"]); // Outputs New York
    
    // Check if key exists
    if (cities.ContainsKey("France")) 
    {
        Console.WriteLine("France is in the list");
    }
    else
    {
        Console.WriteLine("France not found");
    }
  }
}
```', 29)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (30, N'CSharp.Foreach', N'MARKDOWN', N'# C# Foreach Loop
There is a special loop, which is used exclusively to loop through elements in an **array** or other **collections** (like Lists).

### Syntax
```csharp
foreach (type variableName in arrayName) 
{
  // code block to be executed
}
```

The `foreach` loop is cleaner and less error-prone than a standard `for` loop when you do not need the index.

```csharp
string[] cars = {"Volvo", "BMW", "Ford", "Mazda"};

foreach (string i in cars) 
{
  Console.WriteLine(i);
}
```', 30)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (31, N'CSharp.Recursion', N'MARKDOWN', N'# C# Recursion
Recursion is the technique of making a function call itself. This technique provides a way to break complicated problems down into simple problems which are easier to solve.

### Example
Adding a range of numbers together:

```csharp
using System;

class Program
{
  static void Main()
  {
    int result = Sum(10);
    Console.WriteLine(result);
  }

  static int Sum(int k)
  {
    if (k > 0)
    {
      return k + Sum(k - 1);
    }
    else
    {
      return 0;
    }
  }
}
```

**Explanation:** When the `Sum()` function is called, it adds parameter `k` to the sum of all numbers smaller than `k` and returns the result. When `k` becomes 0, the function just returns 0.', 31)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (32, N'CSharp.Structs', N'MARKDOWN', N'# C# Structs
A `struct` (structure) is a value type that is typically used to encapsulate small groups of related variables, such as coordinates.

### Struct vs Class
* **Structs** are Value Types (stored in Stack).
* **Classes** are Reference Types (stored in Heap).
* Structs cannot inherit from other structs or classes (but can implement interfaces).

```csharp
using System;

struct Coordinate
{
    public int x;
    public int y;

    public Coordinate(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

class Program
{
    static void Main()
    {
        Coordinate point = new Coordinate(10, 20);
        Console.WriteLine("X: " + point.x);
        Console.WriteLine("Y: " + point.y);
    }
}
```', 32)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (33, N'CSharp.Nullables', N'MARKDOWN', N'# C# Nullable Types
By default, value types like `int`, `double`, and `bool` cannot be null. However, sometimes you need them to be null (e.g., database fields).

To allow nulls, use the `?` operator after the type name: `int?`.

### Properties
* `HasValue`: True if the variable contains a value, False if it is null.
* `Value`: Gets the value if `HasValue` is true.

```csharp
using System;

class Program
{
    static void Main()
    {
        int? num = null;

        if (num.HasValue)
        {
            Console.WriteLine("num = " + num.Value);
        }
        else
        {
            Console.WriteLine("num is null");
        }

        num = 10;
        Console.WriteLine(num); // Outputs 10
    }
}
```', 33)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (34, N'CSharp.Random', N'MARKDOWN', N'# C# Random Class
The `Random` class is used to generate random numbers.

### Methods
* `Next()`: Returns a random non-negative integer.
* `Next(max)`: Returns a random integer less than `max`.
* `Next(min, max)`: Returns a random integer within the range.

```csharp
using System;

class Program
{
    static void Main()
    {
        Random rnd = new Random();
        
        int month = rnd.Next(1, 13); // 1 to 12
        int dice = rnd.Next(1, 7);   // 1 to 6
        
        Console.WriteLine("Random Month: " + month);
        Console.WriteLine("Dice Roll: " + dice);
    }
}
```', 34)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (35, N'CSharp.Debugging', N'MARKDOWN', N'# Debugging Concepts
Debugging is the process of finding and fixing errors.

### Tracing Values
In a simple console environment, you often use `Console.WriteLine` to trace the execution flow and check variable values.

In professional development (Visual Studio), you use **Breakpoints** to pause execution and inspect variables.

```csharp
using System;

class Program
{
    static void Main()
    {
        int x = 5;
        int y = 10;
        
        Console.WriteLine("Step 1: Variables Initialized");
        
        int result = Add(x, y);
        
        Console.WriteLine("Step 3: Result calculated is " + result);
    }
    
    static int Add(int a, int b)
    {
        Console.WriteLine("Step 2: Inside Add Method");
        return a + b;
    }
}
```', 35)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (36, N'Java.Intro', N'MARKDOWN', N'# Java Introduction
Java is a popular programming language, created in 1995.
It is owned by Oracle, and more than 3 billion devices run Java.

## Why Use Java?
* Java works on different platforms (Windows, Mac, Linux, etc.)
* It is one of the most popular programming languages
* It is open-source and free
* It is secure, fast and powerful', 36)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (37, N'Java.Syntax', N'MARKDOWN', N'# Java Syntax
Every line of code that runs in Java must be inside a `class`. In our example, we named the class `Main`. A class should always start with an uppercase first letter.

### The main Method
The `main()` method is required and you will see it in every Java program:

```java
public static void main(String[] args)
```

Any code inside the `main()` method will be executed.', 37)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (38, N'Java.Output', N'MARKDOWN', N'# Java Output
You can add as many `System.out.println()` methods as you want. Note that it will add a new line for each method:

```java
System.out.println("Hello World");
System.out.println("I am learning Java.");
System.out.println("It is awesome!");
```', 38)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (39, N'Java.Comments', N'MARKDOWN', N'# Java Comments
Comments can be used to explain Java code, and to make it more readable. It can also be used to prevent execution when testing alternative code.

### Single-line Comments
Single-line comments start with two forward slashes (`//`).

### Multi-line Comments
Multi-line comments start with `/*` and ends with `*/`.', 39)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (40, N'Java.Variables', N'MARKDOWN', N'# Java Variables
Variables are containers for storing data values.
In Java, there are different types of variables, for example:

* `String` - stores text, such as "Hello". String values are surrounded by double quotes
* `int` - stores integers (whole numbers), without decimals
* `float` - stores floating point numbers, with decimals
* `char` - stores single characters, such as ''a'' or ''B''
* `boolean` - stores values with two states: true or false', 40)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (41, N'Java.DataTypes', N'MARKDOWN', N'# Java Data Types
Data types are divided into two groups:

1.  **Primitive** data types - includes `byte`, `short`, `int`, `long`, `float`, `double`, `boolean` and `char`
2.  **Non-primitive** data types - such as String, Arrays and Classes', 41)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (42, N'Java.TypeCasting', N'MARKDOWN', N'# Java Type Casting
Type casting is when you assign a value of one primitive data type to another type.

In Java, there are two types of casting:

* **Widening Casting** (automatically) - converting a smaller type to a larger type size
* **Narrowing Casting** (manually) - converting a larger type to a smaller size type', 42)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (43, N'Java.Operators', N'MARKDOWN', N'# Java Operators
Operators are used to perform operations on variables and values.

* `+` Addition
* `-` Subtraction
* `*` Multiplication
* `/` Division
* `%` Modulus', 43)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (44, N'Java.Strings', N'MARKDOWN', N'# Java Strings
Strings are used for storing text.
A `String` variable contains a collection of characters surrounded by double quotes:

```java
String greeting = "Hello";
```', 44)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (45, N'Java.Math', N'MARKDOWN', N'# Java Math
The Java Math class has many methods that allows you to perform mathematical tasks on numbers.

* `Math.max(x, y)`
* `Math.min(x, y)`
* `Math.sqrt(x)`
* `Math.abs(x)`
* `Math.random()`', 45)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (46, N'Java.WhileLoop', N'MARKDOWN', N'# Java While Loop
Loops can execute a block of code as long as a specified condition is reached.

### The While Loop
The `while` loop loops through a block of code as long as a specified condition is `true`:

```java
while (condition) {
  // code block to be executed
}
```', 46)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (47, N'Java.ForLoop', N'MARKDOWN', N'# Java For Loop
When you know exactly how many times you want to loop through a block of code, use the `for` loop instead of a `while` loop:

```java
for (statement 1; statement 2; statement 3) {
  // code block to be executed
}
```', 47)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (48, N'Java.Arrays', N'MARKDOWN', N'# Java Arrays
Arrays are used to store multiple values in a single variable, instead of declaring separate variables for each value.

To declare an array, define the variable type with square brackets:

```java
String[] cars;
```', 48)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (49, N'Java.Methods', N'MARKDOWN', N'# Java Methods
A method is a block of code which only runs when it is called.
You can pass data, known as parameters, into a method.

### Create a Method
A method must be declared within a class. It is defined with the name of the method, followed by parentheses `()`.', 49)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (50, N'Java.MethodParams', N'MARKDOWN', N'# Java Method Parameters
Information can be passed to methods as parameter. Parameters act as variables inside the method.

```java
static void myMethod(String fname) {
  System.out.println(fname + " Refsnes");
}
```', 50)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (51, N'Java.MethodOverloading', N'MARKDOWN', N'# Java Method Overloading
With method overloading, multiple methods can have the same name with different parameters:

```java
int myMethod(int x)
float myMethod(float x)
double myMethod(double x, double y)
```', 51)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (52, N'Java.Scope', N'MARKDOWN', N'# Java Scope
In Java, variables are only accessible inside the region they are created. This is called scope.

### Block Scope
A block of code refers to all of the code between curly braces `{}`.', 52)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (53, N'Java.Recursion', N'MARKDOWN', N'# Java Recursion
Recursion is the technique of making a function call itself. This technique provides a way to break complicated problems down into simple problems which are easier to solve.', 53)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (54, N'Java.Classes', N'MARKDOWN', N'# Java Classes/Objects
Java is an object-oriented programming language.

Everything in Java is associated with classes and objects, along with its attributes and methods.

### Create a Class
To create a class, use the keyword `class`:

```java
public class Main {
  int x = 5;
}
```', 54)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (55, N'Java.Attributes', N'MARKDOWN', N'# Java Class Attributes
In the previous chapter, we used the term "variable" for `x` in the example (as shown below). It is actually an attribute of the class. Or you could say that class attributes are variables within a class:

```java
public class Main {
  int x;
  int y;
}
```', 55)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (56, N'Java.Constructors', N'MARKDOWN', N'# Java Constructors
A constructor in Java is a special method that is used to initialize objects. The constructor is called when an object of a class is created. It can be used to set initial values for object attributes.

```java
public class Main {
  int x;

  public Main() {
    x = 5;
  }

  public static void main(String[] args) {
    Main myObj = new Main();
    System.out.println(myObj.x);
  }
}
```', 56)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (57, N'Java.Modifiers', N'MARKDOWN', N'# Java Modifiers
By now, you are quite familiar with the `public` keyword that appears in almost all of our examples:

```java
public class Main
```

The `public` keyword is an **access modifier**, meaning that it is used to set the access level for classes, attributes, methods and constructors.

We divide modifiers into two groups:
* **Access Modifiers** - controls the access level
* **Non-Access Modifiers** - do not control access level, but provides other functionality', 57)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (58, N'Java.Encapsulation', N'MARKDOWN', N'# Java Encapsulation
The meaning of **Encapsulation**, is to make sure that "sensitive" data is hidden from users. To achieve this, you must:

* declare class variables/attributes as `private`
* provide public **get** and **set** methods to access and update the value of a `private` variable

```java
public class Person {
  private String name; // private = restricted access

  // Getter
  public String getName() {
    return name;
  }

  // Setter
  public void setName(String newName) {
    this.name = newName;
  }
}
```', 58)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (59, N'Java.Packages', N'MARKDOWN', N'# Java Packages & API
A package in Java is used to group related classes. Think of it as a folder in a file directory. We use packages to avoid name conflicts, and to write a better maintainable code.

Packages are divided into two categories:
* Built-in Packages (packages from the Java API)
* User-defined Packages (create your own packages)

```java
import java.util.Scanner;
```', 59)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (60, N'Java.Inheritance', N'MARKDOWN', N'# Java Inheritance
In Java, it is possible to inherit attributes and methods from one class to another. We group the "inheritance concept" into two categories:

* **Subclass** (child) - the class that inherits from another class
* **Superclass** (parent) - the class being inherited from

To inherit from a class, use the `extends` keyword.

```java
class Vehicle {
  protected String brand = "Ford";
  public void honk() {
    System.out.println("Tuut, tuut!");
  }
}

class Car extends Vehicle {
  private String modelName = "Mustang";
  public static void main(String[] args) {
    Car myCar = new Car();
    myCar.honk();
    System.out.println(myCar.brand + " " + myCar.modelName);
  }
}
```', 60)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (61, N'Java.Polymorphism', N'MARKDOWN', N'# Java Polymorphism
Polymorphism means "many forms", and it occurs when we have many classes that are related to each other by inheritance.

Like we specified in the previous chapter; Inheritance lets us inherit attributes and methods from another class. Polymorphism uses those methods to perform different tasks. This allows us to perform a single action in different ways.', 61)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (62, N'Java.InnerClasses', N'MARKDOWN', N'# Java Inner Classes
In Java, it is also possible to nest classes (a class within a class). The purpose of nested classes is to group classes that belong together, which makes your code more readable and maintainable.

To access the inner class, create an object of the outer class, and then create an object of the inner class:

```java
class OuterClass {
  int x = 10;

  class InnerClass {
    int y = 5;
  }
}

public class Main {
  public static void main(String[] args) {
    OuterClass myOuter = new OuterClass();
    OuterClass.InnerClass myInner = myOuter.new InnerClass();
    System.out.println(myInner.y + myOuter.x);
  }
}
```', 62)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (63, N'Java.Abstraction', N'MARKDOWN', N'# Java Abstraction
Data abstraction is the process of hiding certain details and showing only essential information to the user.
Abstraction can be achieved with either **abstract classes** or **interfaces**.

The `abstract` keyword is a non-access modifier, used for classes and methods:

* **Abstract class:** is a restricted class that cannot be used to create objects (to access it, it must be inherited from another class).
* **Abstract method:** can only be used in an abstract class, and it does not have a body. The body is provided by the subclass (inherited from).', 63)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (64, N'Java.Interface', N'MARKDOWN', N'# Java Interface
Another way to achieve abstraction in Java, is with interfaces.

An `interface` is a completely "abstract class" that is used to group related methods with empty bodies:

```java
interface Animal {
  public void animalSound(); // interface method (does not have a body)
  public void sleep(); // interface method (does not have a body)
}

class Pig implements Animal {
  public void animalSound() {
    System.out.println("The pig says: wee wee");
  }
  public void sleep() {
    System.out.println("Zzz");
  }
}
```', 64)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (65, N'Java.Enums', N'MARKDOWN', N'# Java Enums
An `enum` is a special "class" that represents a group of constants (unchangeable variables, like `final` variables).

To create an enum, use the `enum` keyword (instead of class or interface), and separate the constants with a comma. Note that they should be in uppercase letters:

```java
enum Level {
  LOW,
  MEDIUM,
  HIGH
}
```', 65)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (66, N'Java.Input', N'MARKDOWN', N'# Java User Input
The `Scanner` class is used to get user input, and it is found in the `java.util` package.

To use the `Scanner` class, create an object of the class and use any of the available methods found in the `Scanner` class documentation.

```java
import java.util.Scanner;  // Import the Scanner class

class Main {
  public static void main(String[] args) {
    Scanner myObj = new Scanner(System.in);  // Create a Scanner object
    System.out.println("Enter username");

    String userName = myObj.nextLine();  // Read user input
    System.out.println("Username is: " + userName);  // Output user input
  }
}
```', 66)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (67, N'Java.Dates', N'MARKDOWN', N'# Java Date and Time
Java does not have a built-in Date class, but we can import the `java.time` package to work with the date and time API. The package includes many date and time classes.

### Display Current Date
To display the current date, import the `java.time.LocalDate` class, and use its `now()` method:

```java
import java.time.LocalDate; // import the LocalDate class

public class Main {
  public static void main(String[] args) {
    LocalDate myObj = LocalDate.now(); // Create a date object
    System.out.println(myObj); // Display the current date
  }
}
```', 67)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (68, N'Java.ArrayList', N'MARKDOWN', N'# Java ArrayList
The `ArrayList` class is a resizable array, which can be found in the `java.util` package.

The difference between a built-in array and an `ArrayList` in Java, is that the size of an array cannot be modified (if you want to add or remove elements to/from an array, you have to create a new one). While elements can be added and removed from an `ArrayList` whenever you want.

```java
import java.util.ArrayList; // import the ArrayList class

public class Main {
  public static void main(String[] args) {
    ArrayList<String> cars = new ArrayList<String>();
    cars.add("Volvo");
    cars.add("BMW");
    cars.add("Ford");
    cars.add("Mazda");
    System.out.println(cars);
  }
}
```', 68)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (69, N'Java.LinkedList', N'MARKDOWN', N'# Java LinkedList
The `LinkedList` class is almost identical to the `ArrayList`.

The `LinkedList` class is a collection which can contain many objects of the same type, just like the `ArrayList`.

The `LinkedList` class has all of the same methods as the `ArrayList` class because they both implement the `List` interface. This means that you can add items, change items, remove items and clear the list in the same way.

```java
import java.util.LinkedList;

public class Main {
  public static void main(String[] args) {
    LinkedList<String> cars = new LinkedList<String>();
    cars.add("Volvo");
    cars.add("BMW");
    cars.add("Ford");
    cars.add("Mazda");
    System.out.println(cars);
  }
}
```', 69)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (70, N'Java.HashMap', N'MARKDOWN', N'# Java HashMap
In the `ArrayList` chapter, you learned that Arrays store items as an ordered collection, and you have to access them with an index number (int type). A `HashMap` however, store items in "key/value" pairs, and you can access them by an index of another type (e.g. a `String`).

One object is used as a key (index) to another object (value). It can store different types: String keys and Integer values, or the same type, like: String keys and String values.

```java
import java.util.HashMap; // import the HashMap class

public class Main {
  public static void main(String[] args) {
    HashMap<String, String> capitalCities = new HashMap<String, String>();
    capitalCities.put("England", "London");
    capitalCities.put("Germany", "Berlin");
    capitalCities.put("Norway", "Oslo");
    capitalCities.put("USA", "Washington DC");
    System.out.println(capitalCities); 
  }
}
```', 70)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (71, N'Java.Iterator', N'MARKDOWN', N'# Java Iterator
An `Iterator` is an object that can be used to loop through collections, like `ArrayList` and `HashSet`. It is called an "iterator" because "iterating" is the technical term for looping.

To use an `Iterator`, you must import it from the `java.util` package.

```java
import java.util.ArrayList;
import java.util.Iterator;

public class Main {
  public static void main(String[] args) {
    ArrayList<String> cars = new ArrayList<String>();
    cars.add("Volvo");
    cars.add("BMW");
    cars.add("Ford");
    cars.add("Mazda");

    // Get the iterator
    Iterator<String> it = cars.iterator();

    // Print the first item
    System.out.println(it.next());
  }
}
```', 71)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (72, N'Java.Wrappers', N'MARKDOWN', N'# Java Wrapper Classes
Wrapper classes provide a way to use primitive data types (int, boolean, etc..) as objects.

The table below shows the primitive type and the equivalent wrapper class:

* byte -> Byte
* short -> Short
* int -> Integer
* long -> Long
* float -> Float
* double -> Double
* boolean -> Boolean
* char -> Character

Sometimes you must use wrapper classes, for example when working with Collection objects, such as `ArrayList`, where primitive types cannot be used (the list can only store objects):

```java
public class Main {
  public static void main(String[] args) {
    Integer myInt = 5; 
    Double myDouble = 5.99; 
    Character myChar = ''A''; 
    System.out.println(myInt);
    System.out.println(myDouble);
    System.out.println(myChar);
  }
}
```', 72)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (73, N'Java.Exceptions', N'MARKDOWN', N'# Java Exceptions
When executing Java code, different errors can occur: coding errors made by the programmer, errors due to wrong input, or other unforeseeable things.

When an error occurs, Java will normally stop and generate an error message. The technical term for this is: Java will throw an exception (throw an error).

### Try...Catch
The `try` statement allows you to define a block of code to be tested for errors while it is being executed.
The `catch` statement allows you to define a block of code to be executed, if an error occurs in the try block.

```java
public class Main {
  public static void main(String[] args) {
    try {
      int[] myNumbers = {1, 2, 3};
      System.out.println(myNumbers[10]);
    } catch (Exception e) {
      System.out.println("Something went wrong.");
    }
  }
}
```', 73)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (74, N'Java.RegEx', N'MARKDOWN', N'# Java Regular Expressions
A regular expression is a sequence of characters that forms a search pattern. When you search for data in a text, you can use this search pattern to describe what you are searching for.

A regular expression can be a single character, or a more complicated pattern.
Regular expressions can be used to perform all types of text search and text replace operations.

Java does not have a built-in Regular Expression class, but we can import the `java.util.regex` package to work with regular expressions. The package includes the following classes:

* `Pattern` Class - Defines a pattern (to be used in a search)
* `Matcher` Class - Used to search for the pattern
* `PatternSyntaxException` Class - Indicates syntax error in a regular expression pattern

```java
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Main {
  public static void main(String[] args) {
    Pattern pattern = Pattern.compile("w3schools", Pattern.CASE_INSENSITIVE);
    Matcher matcher = pattern.matcher("Visit W3Schools!");
    boolean matchFound = matcher.find();
    if(matchFound) {
      System.out.println("Match found");
    } else {
      System.out.println("Match not found");
    }
  }
}
```', 74)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (75, N'Java.Threads', N'MARKDOWN', N'# Java Threads
Threads allows a program to operate more efficiently by doing multiple things at the same time.

Threads can be used to perform complicated tasks in the background without interrupting the main program.

### Creating a Thread
There are two ways to create a thread.

It can be created by extending the `Thread` class and overriding its `run()` method:

```java
public class Main extends Thread {
  public void run() {
    System.out.println("This code is running in a thread");
  }
}
```', 75)
SET IDENTITY_INSERT [dbo].[Tbl_LessonContents] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Lessons] ON 

INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (1, N'CSharp.Intro', N'C#', N'Introduction', 1, 1)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (2, N'CSharp.Variables', N'C#', N'Variables & Data Types', 2, 2)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (3, N'CSharp.Input', N'C#', N'User Input', 3, 3)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (4, N'CSharp.IfElse', N'C#', N'Control Flow (If/Else)', 4, 4)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (5, N'CSharp.Loops', N'C#', N'Loops (While & For)', 5, 5)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (6, N'CSharp.Arrays', N'C#', N'Arrays', 6, 6)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (7, N'CSharp.ArrayMethods', N'C#', N'Array Sorting & Linq', 7, 7)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (8, N'CSharp.Strings', N'C#', N'String Operations', 8, 8)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (9, N'CSharp.Methods', N'C#', N'Methods Basics', 9, 9)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (10, N'CSharp.MethodParams', N'C#', N'Parameters and Arguments', 10, 10)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (11, N'CSharp.Overloading', N'C#', N'Method Overloading', 11, 11)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (12, N'CSharp.Classes', N'C#', N'Classes and Objects', 12, 12)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (13, N'CSharp.Members', N'C#', N'Fields and Methods', 13, 13)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (14, N'CSharp.Constructors', N'C#', N'Constructors', 14, 14)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (15, N'CSharp.Access', N'C#', N'Access Modifiers', 15, 15)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (16, N'CSharp.Abstract', N'C#', N'Abstract Classes and Methods', 16, 16)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (17, N'CSharp.Enums', N'C#', N'Enums', 17, 17)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (18, N'CSharp.Files', N'C#', N'Working with Files', 18, 18)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (19, N'CSharp.Exceptions', N'C#', N'Exceptions (Try..Catch)', 19, 19)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (20, N'CSharp.Math', N'C#', N'Math Class', 20, 20)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (21, N'CSharp.StringsAdvanced', N'C#', N'String Properties', 21, 21)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (22, N'CSharp.Booleans', N'C#', N'Booleans', 22, 22)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (23, N'CSharp.Switch', N'C#', N'Switch Statement', 23, 23)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (24, N'CSharp.BreakContinue', N'C#', N'Break and Continue', 24, 24)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (25, N'CSharp.TypeCasting', N'C#', N'Type Casting', 25, 25)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (26, N'CSharp.Dates', N'C#', N'Working with Dates', 26, 26)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (27, N'CSharp.ArrayList', N'C#', N'ArrayList (Non-Generic)', 27, 27)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (28, N'CSharp.List', N'C#', N'List<T> (Generic)', 28, 28)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (29, N'CSharp.Dictionary', N'C#', N'Dictionary<TKey, TValue>', 29, 29)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (30, N'CSharp.Foreach', N'C#', N'Foreach Loop', 30, 30)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (31, N'CSharp.Recursion', N'C#', N'Methods - Recursion', 31, 31)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (32, N'CSharp.Structs', N'C#', N'Structs', 32, 32)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (33, N'CSharp.Nullables', N'C#', N'Nullable Types', 33, 33)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (34, N'CSharp.Random', N'C#', N'Random Numbers', 34, 34)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (35, N'CSharp.Debugging', N'C#', N'Debugging Basics', 35, 35)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (36, N'Java.Intro', N'Java', N'Introduction', 1, 36)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (37, N'Java.Syntax', N'Java', N'Syntax', 2, 37)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (38, N'Java.Output', N'Java', N'Output', 3, 38)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (39, N'Java.Comments', N'Java', N'Comments', 4, 39)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (40, N'Java.Variables', N'Java', N'Variables', 5, 40)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (41, N'Java.DataTypes', N'Java', N'Data Types', 6, 41)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (42, N'Java.TypeCasting', N'Java', N'Type Casting', 7, 42)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (43, N'Java.Operators', N'Java', N'Operators', 8, 43)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (44, N'Java.Strings', N'Java', N'Strings', 9, 44)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (45, N'Java.Math', N'Java', N'Math', 10, 45)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (46, N'Java.WhileLoop', N'Java', N'While Loop', 11, 46)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (47, N'Java.ForLoop', N'Java', N'For Loop', 12, 47)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (48, N'Java.Arrays', N'Java', N'Arrays', 13, 48)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (49, N'Java.Methods', N'Java', N'Methods', 14, 49)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (50, N'Java.MethodParams', N'Java', N'Method Parameters', 15, 50)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (51, N'Java.MethodOverloading', N'Java', N'Method Overloading', 16, 51)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (52, N'Java.Scope', N'Java', N'Scope', 17, 52)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (53, N'Java.Recursion', N'Java', N'Recursion', 18, 53)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (54, N'Java.Classes', N'Java', N'Classes', 19, 54)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (55, N'Java.Attributes', N'Java', N'Class Attributes', 20, 55)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (56, N'Java.Constructors', N'Java', N'Constructors', 21, 56)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (57, N'Java.Modifiers', N'Java', N'Modifiers', 22, 57)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (58, N'Java.Encapsulation', N'Java', N'Encapsulation', 23, 58)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (59, N'Java.Packages', N'Java', N'Packages / API', 24, 59)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (60, N'Java.Inheritance', N'Java', N'Inheritance', 25, 60)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (61, N'Java.Polymorphism', N'Java', N'Polymorphism', 26, 61)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (62, N'Java.InnerClasses', N'Java', N'Inner Classes', 27, 62)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (63, N'Java.Abstraction', N'Java', N'Abstraction', 28, 63)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (64, N'Java.Interface', N'Java', N'Interface', 29, 64)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (65, N'Java.Enums', N'Java', N'Enums', 30, 65)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (66, N'Java.Input', N'Java', N'User Input', 31, 66)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (67, N'Java.Dates', N'Java', N'Date and Time', 32, 67)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (68, N'Java.ArrayList', N'Java', N'ArrayList', 33, 68)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (69, N'Java.LinkedList', N'Java', N'LinkedList', 34, 69)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (70, N'Java.HashMap', N'Java', N'HashMap', 35, 70)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (71, N'Java.Iterator', N'Java', N'Iterator', 36, 71)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (72, N'Java.Wrappers', N'Java', N'Wrapper Classes', 37, 72)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (73, N'Java.Exceptions', N'Java', N'Exceptions', 38, 73)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (74, N'Java.RegEx', N'Java', N'Regular Expressions', 39, 74)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (75, N'Java.Threads', N'Java', N'Threads', 40, 75)
SET IDENTITY_INSERT [dbo].[Tbl_Lessons] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Sections] ON 

INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (1, N'C#', N'Introduction', 1)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (2, N'C#', N'Variables & Data Types', 2)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (3, N'C#', N'User Input', 3)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (4, N'C#', N'Control Flow', 4)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (5, N'C#', N'Loops', 5)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (6, N'C#', N'Arrays', 6)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (7, N'C#', N'Array Methods', 7)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (8, N'C#', N'Strings', 8)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (9, N'C#', N'Methods', 9)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (10, N'C#', N'Method Parameters', 10)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (11, N'C#', N'Method Overloading', 11)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (12, N'C#', N'Classes', 12)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (13, N'C#', N'Class Members', 13)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (14, N'C#', N'Constructors', 14)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (15, N'C#', N'Access Modifiers', 15)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (16, N'C#', N'Abstract Classes', 16)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (17, N'C#', N'Enums', 17)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (18, N'C#', N'Files', 18)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (19, N'C#', N'Exceptions', 19)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (20, N'C#', N'Math', 20)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (21, N'C#', N'Strings', 21)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (22, N'C#', N'Booleans', 22)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (23, N'C#', N'Switch', 23)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (24, N'C#', N'Break/Continue', 24)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (25, N'C#', N'Type Casting', 25)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (26, N'C#', N'Dates and Time', 26)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (27, N'C#', N'ArrayList', 27)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (28, N'C#', N'List Collection', 28)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (29, N'C#', N'Dictionary', 29)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (30, N'C#', N'Foreach Loop', 30)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (31, N'C#', N'Recursion', 31)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (32, N'C#', N'Structs', 32)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (33, N'C#', N'Nullables', 33)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (34, N'C#', N'Random', 34)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (35, N'C#', N'Debugging', 35)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (36, N'Java', N'Introduction', 1)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (37, N'Java', N'Syntax', 2)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (38, N'Java', N'Output', 3)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (39, N'Java', N'Comments', 4)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (40, N'Java', N'Variables', 5)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (41, N'Java', N'Data Types', 6)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (42, N'Java', N'Type Casting', 7)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (43, N'Java', N'Operators', 8)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (44, N'Java', N'Strings', 9)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (45, N'Java', N'Math', 10)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (46, N'Java', N'While Loop', 11)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (47, N'Java', N'For Loop', 12)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (48, N'Java', N'Arrays', 13)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (49, N'Java', N'Methods', 14)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (50, N'Java', N'Method Parameters', 15)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (51, N'Java', N'Method Overloading', 16)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (52, N'Java', N'Scope', 17)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (53, N'Java', N'Recursion', 18)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (54, N'Java', N'Classes', 19)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (55, N'Java', N'Class Attributes', 20)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (56, N'Java', N'Constructors', 21)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (57, N'Java', N'Modifiers', 22)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (58, N'Java', N'Encapsulation', 23)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (59, N'Java', N'Packages', 24)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (60, N'Java', N'Inheritance', 25)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (61, N'Java', N'Polymorphism', 26)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (62, N'Java', N'Inner Classes', 27)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (63, N'Java', N'Abstraction', 28)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (64, N'Java', N'Interface', 29)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (65, N'Java', N'Enums', 30)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (66, N'Java', N'User Input', 31)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (67, N'Java', N'Date and Time', 32)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (68, N'Java', N'ArrayList', 33)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (69, N'Java', N'LinkedList', 34)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (70, N'Java', N'HashMap', 35)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (71, N'Java', N'Iterator', 36)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (72, N'Java', N'Wrapper Classes', 37)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (73, N'Java', N'Exceptions', 38)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (74, N'Java', N'RegEx', 39)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (75, N'Java', N'Threads', 40)
SET IDENTITY_INSERT [dbo].[Tbl_Sections] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_User] ON 

INSERT [dbo].[Tbl_User] ([UserId], [Username], [LoginPassword], [CreatedDateTime]) VALUES (1, N'Testing1', N'ttt', CAST(N'2025-12-30T18:07:05.070' AS DateTime))
INSERT [dbo].[Tbl_User] ([UserId], [Username], [LoginPassword], [CreatedDateTime]) VALUES (2, N'Testing2', N'ttt', CAST(N'2025-12-30T18:07:43.330' AS DateTime))
INSERT [dbo].[Tbl_User] ([UserId], [Username], [LoginPassword], [CreatedDateTime]) VALUES (3, N'Testing3', N'ttt', CAST(N'2025-12-30T18:17:14.400' AS DateTime))
INSERT [dbo].[Tbl_User] ([UserId], [Username], [LoginPassword], [CreatedDateTime]) VALUES (4, N'ttt', N'ttt', CAST(N'2026-01-01T18:06:59.360' AS DateTime))
INSERT [dbo].[Tbl_User] ([UserId], [Username], [LoginPassword], [CreatedDateTime]) VALUES (5, N'NayKhantKyaw', N'Nay', CAST(N'2026-01-01T18:07:27.407' AS DateTime))
INSERT [dbo].[Tbl_User] ([UserId], [Username], [LoginPassword], [CreatedDateTime]) VALUES (6, N'ThuTa', N'1234', CAST(N'2026-01-02T13:14:58.043' AS DateTime))
INSERT [dbo].[Tbl_User] ([UserId], [Username], [LoginPassword], [CreatedDateTime]) VALUES (7, N'NayKhanKyaw', N'Nay', CAST(N'2026-01-09T02:26:31.803' AS DateTime))
INSERT [dbo].[Tbl_User] ([UserId], [Username], [LoginPassword], [CreatedDateTime]) VALUES (8, N'NayKhatKyaw', N'Nay', CAST(N'2026-01-09T03:08:50.540' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tbl_User] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Tbl_User__536C85E45ED4AB4D]    Script Date: 1/11/2026 10:57:04 PM ******/
ALTER TABLE [dbo].[Tbl_User] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tbl_User] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
USE [master]
GO
ALTER DATABASE [LearningPlatformDB] SET  READ_WRITE 
GO
