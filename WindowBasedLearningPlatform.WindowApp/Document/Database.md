USE [master]
GO
/****** Object:  Database [LearningPlatformDB]    Script Date: 1/14/2026 11:31:40 PM ******/
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
/****** Object:  Table [dbo].[Tbl_LessonContents]    Script Date: 1/14/2026 11:31:41 PM ******/
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
/****** Object:  Table [dbo].[Tbl_Lessons]    Script Date: 1/14/2026 11:31:41 PM ******/
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
/****** Object:  Table [dbo].[Tbl_QuizzData]    Script Date: 1/14/2026 11:31:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_QuizzData](
	[QuizID] [int] IDENTITY(1,1) NOT NULL,
	[LessonID] [int] NULL,
	[QuestionText] [nvarchar](max) NOT NULL,
	[OptionA] [nvarchar](200) NOT NULL,
	[OptionB] [nvarchar](200) NOT NULL,
	[OptionC] [nvarchar](200) NOT NULL,
	[OptionD] [nvarchar](200) NOT NULL,
	[CorrectOption] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[QuizID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Sections]    Script Date: 1/14/2026 11:31:41 PM ******/
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
/****** Object:  Table [dbo].[Tbl_User]    Script Date: 1/14/2026 11:31:41 PM ******/
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
SET IDENTITY_INSERT [dbo].[Tbl_QuizzData] ON 

INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1, 1, N'Which company developed C#?', N'Google', N'Apple', N'Microsoft', N'Amazon', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (2, 1, N'C# runs on which framework?', N'.NET', N'Java VM', N'Python', N'Node.js', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (3, 2, N'Which keyword is used for integers?', N'float', N'int', N'string', N'bool', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (4, 2, N'How do you declare a string?', N'str name = "A"', N'String name = "A"', N'string name = "A"', N'text name = "A"', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (5, 4, N'Which statement checks a condition?', N'loop', N'switch', N'if', N'break', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (6, 1, N'Who developed the C# programming language?', N'Apple', N'Microsoft', N'Google', N'Sun Microsystems', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (7, 1, N'Which framework does C# primarily run on?', N'Java Virtual Machine', N'.NET Framework', N'Node.js', N'React', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (8, 1, N'What is the correct file extension for C# files?', N'.cpp', N'.cs', N'.csharp', N'.net', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (9, 1, N'Which method is the entry point of a C# console application?', N'Start()', N'Run()', N'Main()', N'Init()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (10, 1, N'C# is widely used for developing which of the following?', N'Game Development (Unity)', N'Enterprise Software', N'Web Applications', N'All of the above', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (11, 1, N'Which character ends a statement in C#?', N'.', N':', N';', N',', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (12, 1, N'C# syntax is arguably most similar to which other language?', N'Python', N'Java', N'HTML', N'SQL', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (13, 1, N'Is C# a case-sensitive language?', N'Yes', N'No', N'Only for variables', N'Only for classes', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (14, 1, N'Which namespace is commonly used for basic Input/Output?', N'System.IO', N'System', N'System.Text', N'System.Drawing', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (15, 1, N'Which command prints text to the console?', N'print()', N'System.out.println()', N'Console.WriteLine()', N'echo', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (16, 2, N'Which keyword creates a variable that cannot be modified?', N'static', N'final', N'const', N'var', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (17, 2, N'What is the correct syntax to declare an integer?', N'integer x = 5;', N'int x = 5;', N'num x = 5;', N'x = 5;', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (18, 2, N'Which data type should you use for text?', N'char', N'string', N'text', N'bool', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (19, 2, N'What value does a bool variable store?', N'Text', N'Numbers', N'True or False', N'Memory Address', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (20, 2, N'Which variable name is invalid in C#?', N'myVar', N'_myVar', N'my_Var', N'2myVar', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (21, 2, N'Which type is best for storing 19.99?', N'int', N'bool', N'double', N'char', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (22, 2, N'How do you assign a value to a variable?', N'x == 5', N'x = 5', N'x : 5', N'x -> 5', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (23, 2, N'What is the default value of an int?', N'null', N'0', N'1', N'-1', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (24, 2, N'Can you change the type of a declared variable in C# (e.g., int to string)?', N'Yes, anytime', N'No, C# is statically typed', N'Yes, using var', N'Only in loops', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (25, 2, N'Which keyword allows the compiler to infer the type?', N'auto', N'dim', N'var', N'dynamic', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (26, 3, N'Which method reads a line of text from the console?', N'Console.Read()', N'Console.ReadLine()', N'Console.GetKey()', N'Console.Input()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (27, 3, N'Console.ReadLine() always returns data as which type?', N'int', N'string', N'bool', N'object', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (28, 3, N'How do you convert a string input "5" to an integer?', N'Convert.ToInt32("5")', N'int.Parse("5")', N'Both A and B', N'None of the above', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (29, 3, N'What happens if you try to store ReadLine() directly into an int variable?', N'It works automatically', N'It throws a compilation error', N'It rounds the number', N'It stores 0', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (30, 3, N'Which method reads the next character from the standard input stream?', N'Console.Read()', N'Console.ReadLine()', N'Console.Write()', N'Console.Peek()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (31, 3, N'When reading user input, what key usually terminates the input line?', N'Space', N'Esc', N'Enter', N'Tab', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (32, 3, N'Why might Int32.Parse() fail when reading input?', N'If input is empty', N'If input is not a number', N'If input is too large', N'All of the above', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (33, 3, N'To convert string input to a double, which method works?', N'Convert.ToBoolean()', N'Convert.ToDouble()', N'Convert.ToChar()', N'Convert.ToString()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (34, 3, N'Console.ReadKey() is often used to:', N'Read a string', N'Convert types', N'Pause the console', N'Clear the screen', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (35, 3, N'What is the "System" in System.Console.ReadLine()?', N'A Class', N'A Method', N'A Namespace', N'A Variable', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (36, 4, N'Which statement is used to specify a block of code to run if a condition is true?', N'else', N'switch', N'if', N'while', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (37, 4, N'What is the correct syntax for an if statement?', N'if x > y then', N'if (x > y)', N'if x > y', N'if [x > y]', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (38, 4, N'How do you write "not equal" in a condition?', N'<>', N'!=', N'==', N'><', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (39, 4, N'Which operator represents logical AND?', N'&', N'&&', N'||', N'AND', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (40, 4, N'Which operator represents logical OR?', N'|', N'||', N'&&', N'OR', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (41, 4, N'What runs if the "if" condition is false?', N'The loop starts', N'The program stops', N'The "else" block (if present)', N'The "if" block anyway', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (42, 4, N'How do you check if x is equal to y?', N'x = y', N'x == y', N'x != y', N'x <> y', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (43, 4, N'Can you have an "if" without an "else"?', N'No', N'Yes', N'Only in loops', N'Only for integers', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (44, 4, N'What is "else if" used for?', N'Ending the logic', N'Checking a new condition if the first failed', N'Looping', N'Defining variables', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (45, 4, N'Which is the ternary operator syntax?', N'condition ? true : false', N'condition : true ? false', N'condition -> true : false', N'condition ?? true : false', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (46, 5, N'Which loop runs as long as a condition is true?', N'if', N'while', N'switch', N'void', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (47, 5, N'Which loop is best when you know the specific number of iterations?', N'while', N'foreach', N'for', N'do-while', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (48, 5, N'What is the syntax for a "for" loop?', N'for (init; condition; increment)', N'for (condition; init; increment)', N'for (increment; condition; init)', N'loop (init; condition)', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (49, 5, N'Which statement stops a loop immediately?', N'stop', N'return', N'break', N'exit', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (50, 5, N'Which statement skips the current iteration and jumps to the next?', N'break', N'continue', N'skip', N'next', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (51, 5, N'A "do-while" loop is guaranteed to run at least how many times?', N'0', N'1', N'2', N'Infinite', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (52, 5, N'What happens if the condition in a while loop never becomes false?', N'It runs once', N'It throws an error', N'Infinite loop', N'It breaks automatically', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (53, 5, N'In "for (int i=0; i<5; i++)", what is the final value of i?', N'4', N'5', N'6', N'0', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (54, 5, N'How do you write a loop that never ends?', N'for(;;)', N'while(true)', N'Both A and B', N'None of the above', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (55, 5, N'Can you nest loops inside each other?', N'No', N'Yes', N'Only while loops', N'Only for loops', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (56, 6, N'Which is the correct way to create an array of strings?', N'string[] cars = {"Volvo", "BMW"};', N'string cars[] = "Volvo", "BMW";', N'Array<string> cars = ["Volvo", "BMW"];', N'string cars = {"Volvo", "BMW"};', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (57, 6, N'Array indexes start with which number?', N'1', N'0', N'-1', N'Any number', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (58, 6, N'How do you access the first element of an array named "cars"?', N'cars[1]', N'cars(0)', N'cars[0]', N'cars.first()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (59, 6, N'How do you change the value of the first element in "cars" array to "Opel"?', N'cars[0] = "Opel";', N'cars[1] = "Opel";', N'cars.set(0, "Opel");', N'cars.first = "Opel";', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (60, 6, N'Which property finds the number of elements in an array?', N'Length', N'Size', N'Count', N'Length()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (61, 6, N'Can you change the size of an array after it is created?', N'Yes, anytime', N'No, arrays are fixed size', N'Only if it is empty', N'Yes, using Resize()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (62, 6, N'What happens if you try to access an index outside the array bounds?', N'It returns null', N'It returns 0', N'IndexOutOfRangeException', N'Compilation Error', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (63, 6, N'Which syntax creates an empty array of 5 integers?', N'int[] num = new int[5];', N'int[] num = {1,2,3,4,5};', N'int num[] = new int(5);', N'Array<int> num = new Array(5);', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (64, 6, N'Can an array hold different data types (e.g. int and string)?', N'Yes', N'No, arrays are type-specific', N'Only if defined as object', N'Yes, in dynamic arrays', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (65, 6, N'How do you loop through all elements of an array?', N'for loop', N'foreach loop', N'while loop', N'All of the above', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (66, 7, N'Which class provides methods like Sort(), Reverse() for arrays?', N'System.Array', N'System.Collections', N'System.List', N'System.Math', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (67, 7, N'Which method sorts an array in ascending order?', N'Array.Order()', N'Array.Sort()', N'Sort.Array()', N'Array.Reverse()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (68, 7, N'To use Min(), Max(), and Sum() on arrays, which namespace is needed?', N'System.IO', N'System.Text', N'System.Linq', N'System.Math', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (69, 7, N'What does Array.Reverse() do?', N'Sorts descending', N'Reverses the order of elements', N'Swaps first and last only', N'Randomizes elements', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (70, 7, N'If you Sort() an array of strings, how are they ordered?', N'By length', N'Alphabetically', N'Randomly', N'Reverse Alphabetically', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (71, 7, N'Which method returns the largest value in an integer array?', N'Largest()', N'Max()', N'Maximum()', N'Top()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (72, 7, N'Which method returns the sum of all elements?', N'Total()', N'Add()', N'Sum()', N'Count()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (73, 7, N'Does Array.Sort() modify the original array?', N'Yes', N'No, it returns a new array', N'Only if assigned', N'No, it prints the result', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (74, 7, N'How do you find the smallest number in an array named "nums"?', N'nums.Smallest()', N'Array.Min(nums)', N'nums.Min()', N'Min(nums)', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (75, 7, N'Can you use these methods on an empty array?', N'Yes', N'No, it throws an exception', N'It returns 0', N'It returns null', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (76, 8, N'Which property gets the number of characters in a string?', N'Size', N'Count', N'Length', N'GetLength()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (77, 8, N'How do you convert a string to uppercase?', N'toUpper()', N'ToUpper()', N'UpperCase()', N'Text.Upper()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (78, 8, N'How do you concatenate (join) two strings?', N'Using + operator', N'string.Concat()', N'Interpolation ($)', N'All of the above', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (79, 8, N'What is the output of "10" + "20"?', N'30', N'"1020"', N'Error', N'"30"', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (80, 8, N'Which symbol is used for String Interpolation?', N'#', N'@', N'$', N'%', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (81, 8, N'How do you access the first character of a string "txt"?', N'txt[0]', N'txt(0)', N'txt.First()', N'txt.CharAt(0)', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (82, 8, N'Which method returns the index of a specific character?', N'Find()', N'Search()', N'IndexOf()', N'Location()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (83, 8, N'Which method extracts a part of a string?', N'Slice()', N'Cut()', N'Substring()', N'Part()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (84, 8, N'What does string.IsNullOrEmpty() check?', N'Only null', N'Only empty string', N'Both null and empty', N'Whitespace', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (85, 8, N'Which escape character represents a new line?', N'\t', N'\n', N'\\', N'\''', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (86, 9, N'What is a method?', N'A variable', N'A block of code that runs when called', N'A class', N'A loop', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (87, 9, N'How do you execute a method named "MyMethod"?', N'MyMethod;', N'MyMethod[];', N'MyMethod();', N'(MyMethod)', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (88, 9, N'Which keyword indicates a method does not return a value?', N'int', N'static', N'void', N'null', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (89, 9, N'Where must a method be declared?', N'Inside a class', N'Outside a class', N'Inside another method', N'In a separate file only', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (90, 9, N'What is "static" used for in a method declaration?', N'Makes it private', N'Allows calling without creating an object', N'Returns a static value', N'Makes it faster', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (91, 9, N'Can a method call another method?', N'No', N'Yes', N'Only if it is main', N'Only if public', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (92, 9, N'What is the standard naming convention for methods in C#?', N'camelCase', N'PascalCase', N'snake_case', N'UPPERCASE', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (93, 9, N'Can you define a method inside the Main method?', N'Yes (Local functions)', N'No, never', N'Only in old C#', N'Only if static', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (94, 9, N'Which is a valid method signature?', N'void MyMethod()', N'function MyMethod()', N'def MyMethod()', N'MyMethod() : void', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (95, 9, N'What happens when a method finishes execution?', N'Program stops', N'It loops', N'Control returns to the caller', N'It deletes itself', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (96, 10, N'What are variables defined in the method signature called?', N'Arguments', N'Parameters', N'Fields', N'Properties', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (97, 10, N'What are the values passed to a method when calling it called?', N'Arguments', N'Parameters', N'Inputs', N'Data', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (98, 10, N'How do you return a value from a method?', N'return value;', N'get value;', N'send value;', N'value;', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (99, 10, N'If a method is defined as "int Add(int x)", what must it return?', N'Nothing', N'A string', N'An integer', N'A double', N'C')
GO
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (100, 10, N'Can a method have multiple parameters?', N'No', N'Yes, separated by commas', N'Yes, separated by semicolons', N'Yes, separated by spaces', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (101, 10, N'What allows a parameter to have a default value?', N'Optional Arguments', N'Named Arguments', N'Default Keyword', N'Nullables', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (102, 10, N'How do you send arguments by name instead of position?', N'Named Arguments', N'Direct Arguments', N'Explicit Arguments', N'Mapped Arguments', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (103, 10, N'Which keyword passes a parameter by reference?', N'ref', N'out', N'in', N'All of the above', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (104, 10, N'Can a method return an array?', N'No', N'Yes', N'Only strings', N'Only integers', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (105, 10, N'What happens if you don''t return a value in a non-void method?', N'It returns 0', N'It returns null', N'Compilation Error', N'Runtime Error', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (106, 11, N'What is method overloading?', N'Same method name, different parameters', N'Different method name, same parameters', N'Same method name and parameters', N'Deleting a method', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (107, 11, N'Can you overload a method by changing only the return type?', N'Yes', N'No', N'Only for int', N'Only for void', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (108, 11, N'Which signature is distinct from "void Add(int a)"?', N'int Add(int b)', N'void Add(int x)', N'void Add(double a)', N'void Add(int c)', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (109, 11, N'Why use method overloading?', N'To increase code size', N'To improve readability and reuse names', N'To make code slower', N'To confuse the compiler', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (110, 11, N'Can you overload the Main method?', N'No', N'Yes', N'Only if private', N'Only if it returns int', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (111, 11, N'How does the compiler distinguish overloaded methods?', N'By return type', N'By access modifier', N'By number and type of parameters', N'By method body', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (112, 11, N'Is "void Print(int i)" and "void Print(string s)" valid overloading?', N'Yes', N'No', N'Only in static classes', N'Only in main', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (113, 11, N'Can constructors be overloaded?', N'No', N'Yes', N'Only one constructor allowed', N'Only static constructors', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (114, 11, N'What happens if two methods have exact same signature?', N'Runtime Error', N'Compile Time Error', N'Warning', N'One overwrites the other', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (115, 11, N'Which is NOT a factor in overloading?', N'Parameter types', N'Number of parameters', N'Order of parameters', N'Return type', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (116, 12, N'What is a Class in C#?', N'An object', N'A blueprint for creating objects', N'A variable', N'A function', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (117, 12, N'How do you create an object of a class named "Car"?', N'Car c = new Car();', N'Car c = Car();', N'new Car c;', N'Car c;', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (118, 12, N'Which keyword is used to define a class?', N'struct', N'object', N'class', N'define', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (119, 12, N'Where are classes typically defined?', N'Inside a method', N'Inside a namespace', N'Inside a loop', N'Inside an if statement', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (120, 12, N'Can a file contain multiple classes?', N'No', N'Yes', N'Only if one is static', N'Only if they share a name', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (121, 12, N'What is an Object?', N'A template', N'An instance of a class', N'A method', N'A library', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (122, 12, N'Standard naming convention for Classes in C#?', N'camelCase', N'PascalCase', N'snake_case', N'UPPERCASE', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (123, 12, N'Can a class inherit from multiple classes in C#?', N'Yes', N'No', N'Only interfaces', N'Only abstract classes', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (124, 12, N'Everything in C# is associated with:', N'Arrays', N'Classes and Objects', N'Pointers', N'Files', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (125, 12, N'Which is correct syntax?', N'class MyClass {}', N'MyClass class {}', N'def class MyClass {}', N'object MyClass {}', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (126, 13, N'What are Class Members?', N'Only methods', N'Only fields', N'Fields, Methods, Properties, etc.', N'Just the name', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (127, 13, N'Variables declared inside a class are called?', N'Local variables', N'Fields', N'Parameters', N'Globals', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (128, 13, N'How do you access a public field "color" of object "myObj"?', N'myObj->color', N'myObj.color', N'myObj[color]', N'color(myObj)', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (129, 13, N'Can a class contain a class?', N'No', N'Yes (Nested Class)', N'Only in structs', N'Only in static', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (130, 13, N'What is the default access modifier for class members?', N'public', N'private', N'protected', N'internal', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (131, 13, N'Methods inside a class define the objects:', N'State', N'Behavior', N'Name', N'Size', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (132, 13, N'Fields inside a class define the objects:', N'State/Data', N'Behavior', N'Methods', N'Logic', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (133, 13, N'How do you call a method "Drive()" on object "car"?', N'car.Drive', N'car.Drive()', N'Drive(car)', N'car->Drive()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (134, 13, N'Can you define fields as "const"?', N'Yes', N'No', N'Only integers', N'Only strings', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (135, 13, N'What keyword refers to the current instance of the class?', N'self', N'me', N'this', N'base', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (136, 14, N'What is a constructor?', N'A method to build the code', N'A special method to initialize objects', N'A variable', N'A destructor', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (137, 14, N'What is the name of a constructor?', N'init()', N'Same as the class name', N'constructor()', N'main()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (138, 14, N'What is the return type of a constructor?', N'void', N'int', N'The class type', N'No return type', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (139, 14, N'When is the constructor called?', N'When the class is defined', N'When an object is created', N'When the program ends', N'Manually called', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (140, 14, N'Can a constructor take parameters?', N'No', N'Yes', N'Only one', N'Only strings', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (141, 14, N'What is a default constructor?', N'One with no parameters', N'One with all parameters', N'A static one', N'A private one', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (142, 14, N'If you do not define a constructor, what happens?', N'Error', N'C# creates a default one', N'You cannot create objects', N'It uses the destructor', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (143, 14, N'Can you call a constructor explicitly like a method?', N'Yes', N'No, only with "new"', N'Only static ones', N'Only inside main', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (144, 14, N'Can a class have multiple constructors?', N'No', N'Yes (Overloading)', N'Only if private', N'Only if static', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (145, 14, N'Keyword used to call a constructor?', N'make', N'create', N'new', N'build', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (146, 15, N'Which modifier makes code accessible for all classes?', N'private', N'protected', N'public', N'internal', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (147, 15, N'Which modifier restricts access to only the same class?', N'public', N'private', N'protected', N'internal', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (148, 15, N'Which modifier allows access in the same class and derived classes?', N'public', N'private', N'protected', N'static', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (149, 15, N'What is the default modifier for a class?', N'public', N'private', N'internal', N'protected', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (150, 15, N'What does "internal" mean?', N'Private to class', N'Public to world', N'Accessible within the same assembly', N'Accessible only to derived', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (151, 15, N'Why use access modifiers?', N'Security/Encapsulation', N'To make code faster', N'To use less memory', N'To look professional', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (152, 15, N'Can a private member be accessed from another class?', N'Yes', N'No', N'Only if static', N'Only if void', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (153, 15, N'Which modifier is most restrictive?', N'public', N'internal', N'private', N'protected', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (154, 15, N'Which modifier is least restrictive?', N'public', N'internal', N'private', N'protected', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (155, 15, N'Can you apply "private" to a top-level class?', N'Yes', N'No', N'Only if abstract', N'Only if static', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (156, 16, N'What is an abstract class?', N'A class that cannot be instantiated', N'A class with only static methods', N'A class that is final', N'A public class', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (157, 16, N'Can an abstract class have a constructor?', N'Yes', N'No', N'Only static constructors', N'Only private constructors', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (158, 16, N'Which keyword is used to declare an abstract class?', N'static', N'virtual', N'abstract', N'interface', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (159, 16, N'Can an abstract method have a body?', N'Yes', N'No', N'Only if it is void', N'Only if it is private', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (160, 16, N'How do you implement an abstract method in a derived class?', N'Using "new"', N'Using "virtual"', N'Using "override"', N'Using "implement"', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (161, 16, N'Can you create an object of an abstract class?', N'Yes', N'No', N'Only inside Main', N'Only if it has no abstract methods', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (162, 16, N'If a class inherits from an abstract class, what must it do?', N'Implement all abstract methods', N'Define a constructor', N'Be static', N'Nothing', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (163, 16, N'Can an abstract class contain non-abstract methods?', N'Yes', N'No', N'Only private ones', N'Only static ones', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (164, 16, N'What is the main purpose of an abstract class?', N'To prevent code reuse', N'To provide a base for subclasses', N'To create objects', N'To hide data', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (165, 16, N'Can an abstract class be sealed?', N'Yes', N'No', N'Only if it has no methods', N'Only if it is static', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (166, 17, N'What does "enum" stand for?', N'Enumerator', N'Enumeration', N'Enumber', N'Encapsulation', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (167, 17, N'Which keyword is used to define an enum?', N'class', N'interface', N'enum', N'struct', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (168, 17, N'What is the default underlying type of an enum?', N'string', N'double', N'int', N'bool', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (169, 17, N'What is the default value of the first item in an enum?', N'1', N'0', N'-1', N'Null', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (170, 17, N'Can you assign specific integer values to enum items?', N'Yes', N'No', N'Only for the first item', N'Only negative values', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (171, 17, N'How do you access an enum item named "High" in enum "Level"?', N'Level["High"]', N'Level.High', N'High', N'Level->High', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (172, 17, N'Can an enum be defined inside a class?', N'Yes', N'No', N'Only if static', N'Only if private', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (173, 17, N'Can you use an enum in a switch statement?', N'Yes', N'No', N'Only if converted to int', N'Only if converted to string', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (174, 17, N'Enums are primarily used to represent:', N'A list of functions', N'A group of constants', N'A database connection', N'A text file', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (175, 17, N'Can you iterate through enum values?', N'Yes, using Enum.GetValues()', N'No', N'Only with a for loop', N'Only manually', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (176, 18, N'Which namespace contains classes for file handling?', N'System.File', N'System.IO', N'System.Data', N'System.Text', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (177, 18, N'Which class provides static methods for creating, copying, deleting, moving, and opening files?', N'FileInfo', N'File', N'Directory', N'Path', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (178, 18, N'Which method is used to verify if a file exists?', N'File.Find()', N'File.Check()', N'File.Exists()', N'File.Verify()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (179, 18, N'Which method writes a string array to a file?', N'WriteAllText()', N'WriteAllLines()', N'WriteLines()', N'OutputLines()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (180, 18, N'What does File.ReadAllText() return?', N'A string array', N'A list of strings', N'A single string containing all text', N'A stream', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (181, 18, N'Which method appends text to an existing file?', N'AppendText()', N'AddText()', N'WriteAppend()', N'InsertText()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (182, 18, N'What exception is thrown if a file is not found?', N'NullReferenceException', N'FileNotFoundException', N'IOException', N'FileException', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (183, 18, N'Which class is used for reading characters from a byte stream?', N'StreamReader', N'BinaryReader', N'TextReader', N'StringReader', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (184, 18, N'How do you delete a file?', N'File.Remove()', N'File.Delete()', N'File.Erase()', N'File.Destroy()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (185, 18, N'Can you copy a file to a new location?', N'No', N'Yes, using File.Copy()', N'Yes, using File.Move()', N'Only if empty', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (186, 19, N'Which block is used to catch exceptions?', N'try', N'catch', N'finally', N'throw', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (187, 19, N'Which block contains code that might throw an exception?', N'try', N'catch', N'finally', N'error', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (188, 19, N'Which block executes regardless of whether an exception occurred?', N'try', N'catch', N'finally', N'always', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (189, 19, N'Which keyword is used to manually throw an exception?', N'raise', N'throw', N'exception', N'error', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (190, 19, N'What is the base class for all exceptions in .NET?', N'Error', N'SystemException', N'Exception', N'ApplicationException', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (191, 19, N'What happens if an exception is not caught?', N'The program crashes', N'It is ignored', N'It prints to console', N'It restarts', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (192, 19, N'Can you have multiple catch blocks?', N'No', N'Yes', N'Only two', N'Only for int errors', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (193, 19, N'How do you get the error message from an exception object "e"?', N'e.Text', N'e.String', N'e.Message', N'e.Error', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (194, 19, N'Can you catch a specific type of exception?', N'Yes', N'No, only generic Exception', N'Only IO exceptions', N'Only math exceptions', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (195, 19, N'Is the "finally" block mandatory?', N'Yes', N'No', N'Only if catch is missing', N'Only if try is empty', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (196, 20, N'Which class provides mathematical functions?', N'System.Math', N'System.Calc', N'System.Numbers', N'System.Algebra', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (197, 20, N'Which method returns the larger of two numbers?', N'Math.Larger()', N'Math.Big()', N'Math.Max()', N'Math.High()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (198, 20, N'Which method returns the square root?', N'Math.Square()', N'Math.Root()', N'Math.Sqrt()', N'Math.Sqr()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (199, 20, N'What does Math.Abs(-5) return?', N'-5', N'5', N'0', N'Error', N'B')
GO
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (200, 20, N'Which method rounds a number to the nearest integer?', N'Math.Round()', N'Math.Floor()', N'Math.Ceiling()', N'Math.Int()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (201, 20, N'What is the value of Math.PI?', N'3.14159...', N'3.14', N'22/7', N'Unknown', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (202, 20, N'Which method returns the smallest of two numbers?', N'Math.Small()', N'Math.Low()', N'Math.Min()', N'Math.Less()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (203, 20, N'What does Math.Pow(2, 3) return?', N'5', N'6', N'8', N'9', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (204, 20, N'Can Math methods be used without creating an instance?', N'No', N'Yes, they are static', N'Only Max and Min', N'Only in Main', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (205, 20, N'Which method always rounds up?', N'Math.Round()', N'Math.Floor()', N'Math.Ceiling()', N'Math.Up()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (206, 21, N'Which property returns the length of a string?', N'size', N'length', N'Length', N'Count', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (207, 21, N'How do you convert a string to uppercase?', N'ToUpper()', N'toUpper()', N'UpperCase()', N'Upper()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (208, 21, N'How do you convert a string to lowercase?', N'ToLower()', N'toLower()', N'LowerCase()', N'Lower()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (209, 21, N'What is string concatenation?', N'Splitting strings', N'Joining strings', N'Deleting strings', N'Comparing strings', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (210, 21, N'Which operator is used for concatenation?', N'*', N'&', N'+', N'-', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (211, 21, N'What is string interpolation?', N'Embedding variables in strings', N'Sorting strings', N'Encrypting strings', N'Looping strings', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (212, 21, N'Which symbol starts an interpolated string?', N'@', N'#', N'$', N'%', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (213, 21, N'How do you access the first character of a string "s"?', N's[1]', N's(0)', N's[0]', N's.First()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (214, 21, N'Which method finds the index of a specific character?', N'Find()', N'Search()', N'IndexOf()', N'Locate()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (215, 21, N'What does the Substring() method do?', N'Deletes a part', N'Extracts a part', N'Replaces a part', N'Counts chars', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (216, 22, N'What values can a boolean type hold?', N'Any number', N'true or false', N'yes or no', N'0 or 1 only', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (217, 22, N'Which keyword is used to declare a boolean?', N'boolean', N'Bit', N'bool', N'Boolean', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (218, 22, N'What is the result of (10 > 9)?', N'false', N'true', N'10', N'9', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (219, 22, N'Which operator means "Equal to"?', N'=', N'==', N'===', N'<>', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (220, 22, N'Which expression evaluates to false?', N'5 > 3', N'10 == 10', N'7 < 2', N'!(false)', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (221, 22, N'What is the default value of a bool variable?', N'true', N'false', N'null', N'0', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (222, 22, N'Can you use booleans in if statements?', N'No', N'Yes', N'Only if cast to int', N'Only if static', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (223, 22, N'What is the output of: bool isFun = true; Console.WriteLine(isFun);', N'1', N'True', N'true', N'isFun', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (224, 22, N'Which operator represents Logical OR?', N'&&', N'||', N'!', N'&', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (225, 22, N'Which operator represents Logical NOT?', N'!', N'~', N'-', N'not', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (226, 23, N'What is the "switch" statement used for?', N'Loops', N'Defining classes', N'Selecting one of many code blocks', N'Error handling', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (227, 23, N'Which keyword breaks out of a switch block?', N'stop', N'break', N'exit', N'end', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (228, 23, N'What is the "default" keyword used for?', N'The first case', N'Code to run if no case match', N'To start the switch', N'To reset variables', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (229, 23, N'Can you use strings in a switch statement?', N'No, only integers', N'Yes', N'Only single chars', N'Only if constant', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (230, 23, N'Is the "break" keyword mandatory for every case?', N'Yes (or other jump statement)', N'No, it falls through automatically', N'Only for the last case', N'Only for default', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (231, 23, N'Can you have duplicate case values?', N'Yes', N'No', N'Only if strings', N'Only if nested', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (232, 23, N'What happens if no case matches and no default exists?', N'Error', N'Infinite loop', N'The switch block is skipped', N'Program crashes', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (233, 23, N'Can you nest switch statements?', N'No', N'Yes', N'Only 2 levels', N'Only in loops', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (234, 23, N'Which data types are allowed in switch expression?', N'int, string, enum', N'double, float', N'arrays', N'classes', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (235, 23, N'Does switch support pattern matching (modern C#)?', N'No', N'Yes', N'Only for numbers', N'Only in Visual Studio', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (236, 24, N'What does the "break" statement do in a loop?', N'Restarts the loop', N'Jumps out of the loop', N'Skips one iteration', N'Pauses the loop', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (237, 24, N'What does the "continue" statement do?', N'Stops the loop', N'Breaks the loop', N'Skips current iteration and continues with next', N'Exits the program', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (238, 24, N'Can you use "break" in a "foreach" loop?', N'Yes', N'No', N'Only in for loops', N'Only in while loops', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (239, 24, N'Can you use "continue" in a "switch" statement?', N'Yes', N'No', N'Only in default', N'Only if nested', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (240, 24, N'If you have nested loops, what does "break" do?', N'Breaks all loops', N'Breaks only the inner loop', N'Breaks only the outer loop', N'Nothing', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (241, 24, N'What happens if "continue" is placed at the end of a loop block?', N'Nothing special', N'Error', N'Loop stops', N'Loop restarts', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (242, 24, N'Which loop structure is "continue" often associated with?', N'If statement', N'Try Catch', N'For/While Loops', N'Classes', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (243, 24, N'Can you use "break" to exit an "if" statement?', N'Yes', N'No, only loops/switch', N'Only if nested', N'Only in Main', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (244, 24, N'Is "return" the same as "break"?', N'Yes', N'No, return exits method, break exits loop', N'No, return restarts loop', N'Yes, in void methods', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (245, 24, N'What will be printed? for(int i=0;i<5;i++){ if(i==3) break; Console.Write(i); }', N'01234', N'012', N'0123', N'3', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (246, 25, N'What is Type Casting?', N'Creating a class', N'Assigning value of one type to another type', N'Deleting a type', N'Sorting types', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (247, 25, N'Which is an example of Implicit Casting?', N'double d = 9;', N'int i = (int) 9.5;', N'string s = (string) 10;', N'bool b = (bool) 1;', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (248, 25, N'Which is an example of Explicit Casting?', N'int i = 9;', N'double d = 9;', N'int i = (int) 9.58;', N'long l = 10;', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (249, 25, N'Can you implicitly cast a double to an int?', N'Yes', N'No, data loss possible', N'Only if value is small', N'Only if negative', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (250, 25, N'Which method converts a value to string?', N'ToString()', N'Parse()', N'Convert()', N'Cast()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (251, 25, N'Which class provides methods like ToInt32(), ToBoolean()?', N'System.Math', N'System.Convert', N'System.Type', N'System.Cast', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (252, 25, N'What happens if you cast 9.78 to int?', N'It becomes 10', N'It becomes 9', N'Error', N'It becomes 0', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (253, 25, N'Is "char" to "int" implicit or explicit?', N'Implicit (ASCII value)', N'Explicit', N'Not possible', N'Depends on char', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (254, 25, N'Can you cast a string "5" to int using (int)?', N'Yes', N'No, use Parse or Convert', N'Only if string is short', N'Only in loops', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (255, 25, N'Which type is larger: float or double?', N'float', N'double', N'Same size', N'Depends on OS', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (256, 26, N'Which struct is used to work with dates and times in C#?', N'Date', N'DateTime', N'Time', N'Calendar', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (257, 26, N'How do you get the current date and time?', N'DateTime.Current', N'DateTime.Today', N'DateTime.Now', N'Date.Now()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (258, 26, N'Which property gets the current date with the time set to 00:00:00?', N'DateTime.Now', N'DateTime.Today', N'DateTime.Date', N'DateTime.CurrentDate', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (259, 26, N'How do you format a date to a string like "2023-12-31"?', N'date.Format("yyyy-MM-dd")', N'date.ToString("yyyy-MM-dd")', N'String.Format(date)', N'date.ToShortDateString()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (260, 26, N'Which method adds days to a DateTime object?', N'AddDate()', N'PlusDays()', N'AddDays()', N'AppendDays()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (261, 26, N'What is the default value of a DateTime variable?', N'Null', N'0001-01-01 00:00:00', N'1970-01-01', N'Today', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (262, 26, N'How do you calculate the difference between two dates?', N'Subtract them', N'Date.Diff()', N'DateTime.Compare()', N'Use TimeSpan.Difference()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (263, 26, N'Which structure represents a time interval?', N'TimeRange', N'Duration', N'TimeSpan', N'Interval', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (264, 26, N'Is DateTime a value type or reference type?', N'Value Type (struct)', N'Reference Type (class)', N'Interface', N'Enum', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (265, 26, N'How do you parse a string "2023-01-01" to DateTime?', N'DateTime.Parse("2023-01-01")', N'new DateTime("2023-01-01")', N'Convert.Date("2023-01-01")', N'Date.Parse()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (266, 27, N'Which namespace contains the ArrayList class?', N'System.Collections.Generic', N'System.Collections', N'System.List', N'System.Array', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (267, 27, N'Is ArrayList generic or non-generic?', N'Generic', N'Non-Generic', N'Both', N'Neither', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (268, 27, N'What type of elements can an ArrayList store?', N'Only strings', N'Only integers', N'Any object (object type)', N'Only classes', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (269, 27, N'Which method adds an item to an ArrayList?', N'Insert()', N'Append()', N'Add()', N'Push()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (270, 27, N'How do you remove an item from an ArrayList?', N'Delete()', N'Remove()', N'Erase()', N'Pop()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (271, 27, N'What happens if you retrieve an item from an ArrayList?', N'It is automatically typed', N'It must be cast to the correct type', N'It is converted to string', N'It throws an error', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (272, 27, N'Does ArrayList have a fixed size?', N'Yes, defined at creation', N'No, it resizes dynamically', N'Yes, default 10', N'No, but max 100', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (273, 27, N'Why is List<T> generally preferred over ArrayList?', N'ArrayList is faster', N'List<T> is type-safe and faster', N'ArrayList is deprecated', N'List<T> supports less types', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (274, 27, N'Can an ArrayList contain null values?', N'Yes', N'No', N'Only if empty', N'Only one', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (275, 27, N'Which property gets the number of elements in an ArrayList?', N'Length', N'Size', N'Count', N'Capacity', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (276, 28, N'Which namespace contains the List<T> class?', N'System.Collections', N'System.Collections.Generic', N'System.Lists', N'System.Linq', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (277, 28, N'What does <T> stand for in List<T>?', N'Template', N'Type', N'Text', N'Table', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (278, 28, N'How do you create a list of integers?', N'List int list = new List();', N'List<int> list = new List<int>();', N'ArrayList<int> list = new ArrayList();', N'int[] list = new List();', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (279, 28, N'Which method adds multiple elements to a list?', N'AddAll()', N'AddRange()', N'AppendList()', N'InsertRange()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (280, 28, N'How do you verify if a list contains a specific item?', N'list.Has()', N'list.Exists()', N'list.Contains()', N'list.Find()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (281, 28, N'Which property gets the number of items in a List?', N'Length', N'Size', N'Count', N'Total', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (282, 28, N'Can a List<int> store a string?', N'Yes', N'No, it is strongly typed', N'Only if cast', N'Yes, as object', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (283, 28, N'How do you sort a List?', N'list.Order()', N'list.Sort()', N'Array.Sort(list)', N'Sort(list)', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (284, 28, N'Does List<T> support indexing like arrays?', N'No', N'Yes, list[0]', N'Only for reading', N'Only for writing', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (285, 28, N'Which method removes all elements from a List?', N'DeleteAll()', N'Clear()', N'Empty()', N'Reset()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (286, 29, N'What does a Dictionary<TKey, TValue> store?', N'Single values', N'Key-Value pairs', N'Arrays', N'Lists', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (287, 29, N'In Dictionary<int, string>, what is the key type?', N'string', N'int', N'object', N'dynamic', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (288, 29, N'Are duplicate keys allowed in a Dictionary?', N'Yes', N'No', N'Only if values differ', N'Only if null', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (289, 29, N'How do you add an item to a dictionary?', N'dict.Add(key, value)', N'dict.Push(key, value)', N'dict.Insert(key, value)', N'dict[key] = value (if exists)', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (290, 29, N'How do you retrieve a value by its key?', N'dict.Get(key)', N'dict(key)', N'dict[key]', N'dict.Value(key)', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (291, 29, N'Which method checks if a key exists?', N'ContainsKey()', N'HasKey()', N'Exists()', N'CheckKey()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (292, 29, N'What happens if you access a non-existent key using []?', N'Returns null', N'Returns 0', N'KeyNotFoundException', N'Adds the key', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (293, 29, N'Which method safely tries to get a value?', N'TryGet()', N'TryGetValue()', N'SafeGet()', N'GetOrNull()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (294, 29, N'Can values in a Dictionary be duplicates?', N'No', N'Yes', N'Only integers', N'Only nulls', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (295, 29, N'Which property gets all keys?', N'dict.AllKeys', N'dict.Keys', N'dict.KeyList', N'dict.GetKeys()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (296, 30, N'What is the foreach loop primarily used for?', N'Counting numbers', N'Iterating through collections/arrays', N'Infinite loops', N'Checking conditions', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (297, 30, N'What is the syntax for foreach?', N'foreach (item in collection)', N'for (item : collection)', N'foreach (collection as item)', N'loop (item of collection)', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (298, 30, N'Can you modify the iteration variable inside a foreach loop?', N'Yes', N'No, it is read-only', N'Only if it is a reference type', N'Only if cast', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (299, 30, N'Do you need an index variable in a foreach loop?', N'Yes', N'No', N'Only for arrays', N'Only for lists', N'B')
GO
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (300, 30, N'Can foreach be used on a Dictionary?', N'No', N'Yes, iterating KeyValuePair', N'Only on Keys', N'Only on Values', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (301, 30, N'What interface must a collection implement to support foreach?', N'ICollection', N'IEnumerable', N'IList', N'IDictionary', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (302, 30, N'Is foreach generally faster or slower than a for loop for arrays?', N'Much faster', N'Slightly slower or similar', N'Twice as fast', N'No difference', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (303, 30, N'Can you use "break" inside a foreach loop?', N'Yes', N'No', N'Only "continue"', N'Only "return"', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (304, 30, N'Does foreach guarantee a specific order for all collection types?', N'Yes', N'No (e.g. Dictionary order is undefined)', N'Only reverse', N'Only sorted', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (305, 30, N'Which type matches "var" in "foreach (var x in list)" if list is List<int>?', N'string', N'object', N'int', N'var', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (306, 31, N'What is recursion?', N'A method that calls itself', N'A method that loops forever', N'A method with no return type', N'A method that calls Main', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (307, 31, N'What is essential to stop infinite recursion?', N'A base case', N'A while loop', N'A static variable', N'A try-catch block', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (308, 31, N'Which problem is a classic example of recursion?', N'Factorial calculation', N'Sorting an array', N'Connecting to a database', N'Printing "Hello World"', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (309, 31, N'What happens if a recursive function lacks a termination condition?', N'It stops automatically', N'StackOverflowException', N'It returns null', N'It compiles faster', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (310, 31, N'Is recursion always faster than iteration?', N'Yes, always', N'No, it can be slower due to stack overhead', N'They are exactly the same speed', N'Yes, because it uses less memory', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (311, 31, N'Can any recursive algorithm be written iteratively?', N'Yes', N'No', N'Only math problems', N'Only void methods', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (312, 31, N'What memory area is used for storing recursive calls?', N'Heap', N'Stack', N'Global memory', N'File system', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (313, 31, N'In `int Sum(int k) { if(k>0) return k + Sum(k-1); else return 0; }`, what is `Sum(2)`?', N'0', N'1', N'3', N'2', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (314, 31, N'What is "indirect recursion"?', N'Function A calls B, B calls A', N'Function A calls A', N'Function A calls B', N'Function calls itself twice', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (315, 31, N'Recursion makes code:', N'Always faster', N'Usually shorter and cleaner for tree-like structures', N'Harder to write', N'Impossible to debug', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (316, 32, N'What is a Struct in C#?', N'A reference type', N'A value type', N'A pointer', N'An interface', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (317, 32, N'Where are Structs stored in memory?', N'Heap', N'Stack (mostly)', N'Hard Drive', N'Cache', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (318, 32, N'Can a Struct inherit from a Class?', N'Yes', N'No', N'Only if abstract', N'Only if sealed', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (319, 32, N'Can a Struct implement an Interface?', N'Yes', N'No', N'Only IDisposable', N'Only generic interfaces', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (320, 32, N'Can you define a default (parameterless) constructor for a Struct in C# (pre-C# 10)?', N'Yes', N'No', N'Only static', N'Only private', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (321, 32, N'Are Structs mutable or immutable by default?', N'Immutable', N'Mutable (but immutable is recommended)', N'Both', N'Neither', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (322, 32, N'Which is better for small, short-lived data structures?', N'Class', N'Struct', N'Array', N'Enum', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (323, 32, N'What happens when you assign one struct variable to another?', N'Reference copy', N'Value copy (all fields copied)', N'Pointer copy', N'Nothing', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (324, 32, N'Can a Struct be null?', N'Yes', N'No (unless Nullable)', N'Only if static', N'Only if empty', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (325, 32, N'Which keyword defines a structure?', N'class', N'structure', N'struct', N'type', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (326, 33, N'Which syntax makes an integer nullable?', N'int null x;', N'int? x;', N'nullable int x;', N'int x = null;', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (327, 33, N'What is the default value of `int? x`?', N'0', N'null', N'-1', N'undefined', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (328, 33, N'Which property checks if a nullable type has a value?', N'IsNotNull', N'HasValue', N'Exists', N'Value', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (329, 33, N'How do you get the value from a nullable type safely?', N'.Value', N'.GetValue()', N'.GetValueOrDefault()', N'.Get()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (330, 33, N'What happens if you access `.Value` when it is null?', N'Returns 0', N'InvalidOperationException', N'Returns null', N'Compiler Error', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (331, 33, N'What does the null-coalescing operator `??` do?', N'Checks for null', N'Returns left operand if not null, otherwise right', N'Assigns null', N'Compares two nulls', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (332, 33, N'Can you assign null to a bool?', N'Yes', N'No', N'Only if defined as bool?', N'Only in loops', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (333, 33, N'What is the underlying type of `int?`?', N'System.Int32', N'System.Nullable<Int32>', N'System.Object', N'System.Null', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (334, 33, N'Is `int? x = 5; int y = x;` valid?', N'Yes', N'No, explicit cast required', N'Yes, implicit cast', N'Only if x is not null', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (335, 33, N'Can reference types (string, class) be nullable?', N'They are nullable by default', N'No', N'Only with ?', N'Only in C# 1.0', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (336, 34, N'Which class generates random numbers?', N'Math.Random', N'System.Random', N'Rand', N'Rnd', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (337, 34, N'How do you create a Random object?', N'Random r = new Random();', N'var r = Random.New();', N'Random r = Random();', N'new Rand();', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (338, 34, N'Which method returns a random integer?', N'GetInteger()', N'Next()', N'RandInt()', N'NewInt()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (339, 34, N'What does `Next(10)` return?', N'A number between 0 and 10 (exclusive)', N'A number between 1 and 10', N'Exactly 10', N'A number up to 100', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (340, 34, N'What does `Next(5, 10)` return?', N'5, 6, 7, 8, 9', N'5, 6, 7, 8, 9, 10', N'1, 2, 3, 4, 5', N'0 to 10', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (341, 34, N'Which method returns a random floating-point number between 0.0 and 1.0?', N'NextFloat()', N'NextDouble()', N'NextDecimal()', N'Random()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (342, 34, N'Is System.Random thread-safe?', N'Yes', N'No', N'Only static', N'Only in loops', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (343, 34, N'If you create two Random objects with the same seed, what happens?', N'They produce different sequences', N'They produce identical sequences', N'Error', N'Nothing', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (344, 34, N'How do you simulate a dice roll (1-6)?', N'Next(6)', N'Next(1, 6)', N'Next(1, 7)', N'Next(0, 6) + 1', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (345, 34, N'What is a "seed" in random number generation?', N'The starting point for the algorithm', N'The max value', N'The min value', N'The result', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (346, 35, N'What is a breakpoint?', N'A syntax error', N'A marker to pause execution', N'A stop command', N'A broken link', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (347, 35, N'Which key usually steps over code in Visual Studio?', N'F5', N'F10', N'F11', N'F12', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (348, 35, N'Which key steps INTO a method?', N'F5', N'F10', N'F11', N'F12', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (349, 35, N'What does F5 do while debugging?', N'Stops debugging', N'Continues execution', N'Steps out', N'Restarts app', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (350, 35, N'Which window shows the values of variables near the breakpoint?', N'Output', N'Locals', N'Solution Explorer', N'Properties', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (351, 35, N'What is the purpose of `Debug.WriteLine()`?', N'Write to console', N'Write to Output window (Debug mode)', N'Write to a file', N'Stop the program', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (352, 35, N'Can you change variable values while debugging?', N'Yes', N'No', N'Only strings', N'Only integers', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (353, 35, N'What is a "conditional breakpoint"?', N'Pauses only if a condition is true', N'Pauses randomly', N'Pauses on errors', N'Pauses on loops', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (354, 35, N'Which exception helper shows exactly where an error occurred?', N'Call Stack', N'Error List', N'Toolbox', N'Server Explorer', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (355, 35, N'What is "Just My Code"?', N'Debugging setting to ignore system/library calls', N'A compiler error', N'A coding style', N'A design pattern', N'A')
SET IDENTITY_INSERT [dbo].[Tbl_QuizzData] OFF
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
/****** Object:  Index [UQ__Tbl_User__536C85E45ED4AB4D]    Script Date: 1/14/2026 11:31:41 PM ******/
ALTER TABLE [dbo].[Tbl_User] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tbl_User] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[Tbl_QuizzData]  WITH CHECK ADD FOREIGN KEY([LessonID])
REFERENCES [dbo].[Tbl_Lessons] ([LessonId])
GO
USE [master]
GO
ALTER DATABASE [LearningPlatformDB] SET  READ_WRITE 
GO
