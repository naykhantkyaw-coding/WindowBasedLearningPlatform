USE [master]
GO
/****** Object:  Database [LearningPlatformDB]    Script Date: 1/28/2026 4:54:17 PM ******/
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
/****** Object:  Table [dbo].[Tbl_LessonContents]    Script Date: 1/28/2026 4:54:17 PM ******/
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
/****** Object:  Table [dbo].[Tbl_Lessons]    Script Date: 1/28/2026 4:54:17 PM ******/
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
/****** Object:  Table [dbo].[Tbl_QuizzData]    Script Date: 1/28/2026 4:54:17 PM ******/
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
/****** Object:  Table [dbo].[Tbl_Sections]    Script Date: 1/28/2026 4:54:17 PM ******/
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
/****** Object:  Table [dbo].[Tbl_User]    Script Date: 1/28/2026 4:54:17 PM ******/
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
/****** Object:  Table [dbo].[Tbl_UserLessonProgress]    Script Date: 1/28/2026 4:54:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_UserLessonProgress](
	[ProgressId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[LessonId] [int] NOT NULL,
	[IsRead] [bit] NULL,
	[IsCompleted] [bit] NULL,
	[CompletedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProgressId] ASC
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
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (76, N'Python.Intro', N'MARKDOWN', N'# Python Introduction
Python is a popular programming language. It was created by Guido van Rossum, and released in 1991.

### It is used for:
* Web development (server-side)
* Software development
* Mathematics
* System scripting

### Why Python?
* Python works on different platforms (Windows, Mac, Linux, Raspberry Pi, etc).
* Python has a simple syntax similar to the English language.
* Python handles new lines to complete a command, as opposed to other programming languages which often use semicolons or parentheses.', 76)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (77, N'Python.Syntax', N'MARKDOWN', N'# Python Syntax
Python syntax can be executed by writing directly in the Command Line:

```python
print("Hello, World!")
```

### Python Indentation
Indentation refers to the spaces at the beginning of a code line.
Where in other programming languages the indentation in code is for readability only, the indentation in Python is very important.
Python uses indentation to indicate a block of code.

```python
if 5 > 2:
  print("Five is greater than two!")
```', 77)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (78, N'Python.Comments', N'MARKDOWN', N'# Python Comments
Comments can be used to explain Python code.
Comments can be used to make the code more readable.
Comments can be used to prevent execution when testing code.

### Creating a Comment
Comments starts with a `#`, and Python will ignore them:

```python
# This is a comment
print("Hello, World!")
```', 78)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (79, N'Python.Variables', N'MARKDOWN', N'# Python Variables
Variables are containers for storing data values.

### Creating Variables
Python has no command for declaring a variable.
A variable is created the moment you first assign a value to it.

```python
x = 5
y = "John"
print(x)
print(y)
```

Variables do not need to be declared with any particular type, and can even change type after they have been set.', 79)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (80, N'Python.DataTypes', N'MARKDOWN', N'# Python Data Types
In programming, data type is an important concept.
Variables can store data of different types, and different types can do different things.

Python has the following data types built-in by default, in these categories:
* Text Type: `str`
* Numeric Types: `int`, `float`, `complex`
* Sequence Types: `list`, `tuple`, `range`
* Mapping Type: `dict`
* Set Types: `set`, `frozenset`
* Boolean Type: `bool`
* Binary Types: `bytes`, `bytearray`, `memoryview`
* None Type: `NoneType`', 80)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (81, N'Python.Numbers', N'MARKDOWN', N'# Python Numbers
There are three numeric types in Python:

* `int`
* `float`
* `complex`

Variables of numeric types are created when you assign a value to them:

```python
x = 1    # int
y = 2.8  # float
z = 1j   # complex
```

To verify the type of any object in Python, use the `type()` function:
```python
print(type(x))
```', 81)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (82, N'Python.Casting', N'MARKDOWN', N'# Python Casting
There may be times when you want to specify a type on to a variable. This can be done with casting. Python is an object-orientated language, and as such it uses classes to define data types, including its primitive types.

Casting in python is therefore done using constructor functions:
* `int()` - constructs an integer number from an integer literal, a float literal (by removing all decimals), or a string literal (providing the string represents a whole number)
* `float()` - constructs a float number from an integer literal, a float literal or a string literal (providing the string represents a float or an integer)
* `str()` - constructs a string from a wide variety of data types, including strings, integer literals and float literals', 82)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (83, N'Python.Strings', N'MARKDOWN', N'# Python Strings
Strings in python are surrounded by either single quotation marks, or double quotation marks.

`''hello''` is the same as `"hello"`.

You can display a string literal with the `print()` function:

```python
print("Hello")
print(''Hello'')
```

### Multiline Strings
You can assign a multiline string to a variable by using three quotes:

```python
a = """Lorem ipsum dolor sit amet,
consectetur adipiscing elit,
sed do eiusmod tempor incididunt
ut labore et dolore magna aliqua."""
print(a)
```', 83)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (84, N'Python.Booleans', N'MARKDOWN', N'# Python Booleans
Booleans represent one of two values: `True` or `False`.

### Boolean Values
In programming you often need to know if an expression is `True` or `False`.
You can evaluate any expression in Python, and get one of two answers, `True` or `False`.

When you compare two values, the expression is evaluated and Python returns the Boolean answer:

```python
print(10 > 9)
print(10 == 9)
print(10 < 9)
```', 84)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (85, N'Python.Operators', N'MARKDOWN', N'# Python Operators
Operators are used to perform operations on variables and values.
In the example below, we use the `+` operator to add together two values:

```python
print(10 + 5)
```

Python divides the operators in the following groups:
* Arithmetic operators
* Assignment operators
* Comparison operators
* Logical operators
* Identity operators
* Membership operators
* Bitwise operators', 85)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (86, N'Python.Lists', N'MARKDOWN', N'# Python Lists
Lists are used to store multiple items in a single variable.

Lists are one of 4 built-in data types in Python used to store collections of data, the other 3 are Tuple, Set, and Dictionary, all with different qualities and usage.

Lists are created using square brackets:

```python
thislist = ["apple", "banana", "cherry"]
print(thislist)
```

### List Items
List items are ordered, changeable, and allow duplicate values.
List items are indexed, the first item has index `[0]`, the second item has index `[1]` etc.', 86)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (87, N'Python.Tuples', N'MARKDOWN', N'# Python Tuples
Tuples are used to store multiple items in a single variable.

A tuple is a collection which is ordered and **unchangeable**.

Tuples are written with round brackets.

```python
thistuple = ("apple", "banana", "cherry")
print(thistuple)
```

### Tuple Items
Tuple items are ordered, unchangeable, and allow duplicate values.
Tuple items are indexed, the first item has index `[0]`, the second item has index `[1]` etc.', 87)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (88, N'Python.Sets', N'MARKDOWN', N'# Python Sets
Sets are used to store multiple items in a single variable.

A set is a collection which is unordered, unchangeable*, and unindexed.

*Note: Set items are unchangeable, but you can remove items and add new items.

Sets are written with curly brackets.

```python
thisset = {"apple", "banana", "cherry"}
print(thisset)
```

### Set Items
Set items are unordered, unchangeable, and do not allow duplicate values.', 88)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (89, N'Python.Dictionaries', N'MARKDOWN', N'# Python Dictionaries
Dictionaries are used to store data values in key:value pairs.

A dictionary is a collection which is ordered*, changeable and do not allow duplicates.

Dictionaries are written with curly brackets, and have keys and values:

```python
thisdict = {
  "brand": "Ford",
  "model": "Mustang",
  "year": 1964
}
print(thisdict)
```

### Dictionary Items
Dictionary items are ordered, changeable, and does not allow duplicates.
Dictionary items are presented in key:value pairs, and can be referred to by using the key name.', 89)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (90, N'Python.IfElse', N'MARKDOWN', N'# Python If ... Else
Python supports the usual logical conditions from mathematics:
* Equals: `a == b`
* Not Equals: `a != b`
* Less than: `a < b`
* Less than or equal to: `a <= b`
* Greater than: `a > b`
* Greater than or equal to: `a >= b`

These conditions can be used in several ways, most commonly in "if statements" and loops.

An "if statement" is written by using the `if` keyword.

```python
a = 33
b = 200
if b > a:
  print("b is greater than a")
```', 90)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (91, N'Python.While', N'MARKDOWN', N'# Python While Loops
Python has two primitive loop commands:
* `while` loops
* `for` loops

### The while Loop
With the while loop we can execute a set of statements as long as a condition is true.

```python
i = 1
while i < 6:
  print(i)
  i += 1
```

**Note:** remember to increment i, or else the loop will continue forever.', 91)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (92, N'Python.For', N'MARKDOWN', N'# Python For Loops
A for loop is used for iterating over a sequence (that is either a list, a tuple, a dictionary, a set, or a string).

This is less like the `for` keyword in other programming languages, and works more like an iterator method as found in other object-orientated programming languages.

With the for loop we can execute a set of statements, once for each item in a list, tuple, set etc.

```python
fruits = ["apple", "banana", "cherry"]
for x in fruits:
  print(x)
```', 92)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (93, N'Python.Functions', N'MARKDOWN', N'# Python Functions
A function is a block of code which only runs when it is called.
You can pass data, known as parameters, into a function.
A function can return data as a result.

### Creating a Function
In Python a function is defined using the `def` keyword:

```python
def my_function():
  print("Hello from a function")
```

### Calling a Function
To call a function, use the function name followed by parenthesis:

```python
def my_function():
  print("Hello from a function")

my_function()
```', 93)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (94, N'Python.Lambda', N'MARKDOWN', N'# Python Lambda
A lambda function is a small anonymous function.
A lambda function can take any number of arguments, but can only have one expression.

### Syntax
`lambda arguments : expression`
The expression is executed and the result is returned:

```python
x = lambda a : a + 10
print(x(5))
```

Lambda functions can take any number of arguments:
```python
x = lambda a, b : a * b
print(x(5, 6))
```', 94)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (95, N'Python.Arrays', N'MARKDOWN', N'# Python Arrays
Note: Python does not have built-in support for Arrays, but Python Lists can be used instead.

However, to work with arrays in Python you will have to import a library, like the NumPy library.

Arrays are used to store multiple values in a single variable:

```python
cars = ["Ford", "Volvo", "BMW"]
```

### Access the Elements of an Array
You refer to an array element by referring to the index number.
```python
x = cars[0]
print(x)
```', 95)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (96, N'Python.Classes', N'MARKDOWN', N'# Python Classes/Objects
Python is an object oriented programming language.
Almost everything in Python is an object, with its properties and methods.
A Class is like an object constructor, or a "blueprint" for creating objects.

### Create a Class
To create a class, use the keyword `class`:

```python
class MyClass:
  x = 5

p1 = MyClass()
print(p1.x)
```

### The __init__() Function
All classes have a function called `__init__()`, which is always executed when the class is being initiated.
Use the `__init__()` function to assign values to object properties.', 96)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (97, N'Python.Inheritance', N'MARKDOWN', N'# Python Inheritance
Inheritance allows us to define a class that inherits all the methods and properties from another class.

**Parent class** is the class being inherited from, also called base class.
**Child class** is the class that inherits from another class, also called derived class.

```python
class Person:
  def __init__(self, fname, lname):
    self.firstname = fname
    self.lastname = lname

  def printname(self):
    print(self.firstname, self.lastname)

class Student(Person):
  pass

x = Student("Mike", "Olsen")
x.printname()
```', 97)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (98, N'Python.Iterators', N'MARKDOWN', N'# Python Iterators
An iterator is an object that contains a countable number of values.
An iterator is an object that can be iterated upon, meaning that you can traverse through all the values.

Technically, in Python, an iterator is an object which implements the iterator protocol, which consist of the methods `__iter__()` and `__next__()`.

```python
mytuple = ("apple", "banana", "cherry")
myit = iter(mytuple)

print(next(myit))
print(next(myit))
print(next(myit))
```', 98)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (99, N'Python.Scope', N'MARKDOWN', N'# Python Scope
A variable is only available from inside the region it is created. This is called scope.

### Local Scope
A variable created inside a function belongs to the local scope of that function, and can only be used inside that function.

```python
def myfunc():
  x = 300
  print(x)

myfunc()
```

### Global Scope
A variable created in the main body of the Python code is a global variable and belongs to the global scope.', 99)
GO
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (100, N'Python.Modules', N'MARKDOWN', N'# Python Modules
Consider a module to be the same as a code library.
A file containing a set of functions you want to include in your application.

### Create a Module
To create a module just save the code you want in a file with the file extension `.py`:

```python
def greeting(name):
  print("Hello, " + name)
```

### Use a Module
Now we can use the module we just created, by using the `import` statement.', 100)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (101, N'Python.Dates', N'MARKDOWN', N'# Python Dates
A date in Python is not a data type of its own, but we can import a module named `datetime` to work with dates as date objects.

```python
import datetime

x = datetime.datetime.now()
print(x)
```

### Date Output
The date contains year, month, day, hour, minute, second, and microsecond.

The `datetime` module has many methods to return information about the date object.', 101)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (102, N'Python.Math', N'MARKDOWN', N'# Python Math
Python has a set of built-in math functions, including an extensive math module, that allows you to perform mathematical tasks on numbers.

### Built-in Math Functions
The `min()` and `max()` functions can be used to find the lowest or highest value in an iterable:

```python
x = min(5, 10, 25)
y = max(5, 10, 25)

print(x)
print(y)
```

The `abs()` function returns the absolute (positive) value of the specified number.', 102)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (103, N'Python.JSON', N'MARKDOWN', N'# Python JSON
JSON is a syntax for storing and exchanging data.
Python has a built-in package called `json`, which can be used to work with JSON data.

### Parse JSON - Convert from JSON to Python
If you have a JSON string, you can parse it by using the `json.loads()` method.

```python
import json

# some JSON:
x = ''{ "name":"John", "age":30, "city":"New York"}''

# parse x:
y = json.loads(x)

# the result is a Python dictionary:
print(y["age"])
```', 103)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (104, N'Python.RegEx', N'MARKDOWN', N'# Python RegEx
A RegEx, or Regular Expression, is a sequence of characters that forms a search pattern.
RegEx can be used to check if a string contains the specified search pattern.

Python has a built-in package called `re`, which can be used to work with Regular Expressions.

```python
import re

txt = "The rain in Spain"
x = re.search("^The.*Spain$", txt)
```', 104)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (105, N'Python.PIP', N'MARKDOWN', N'# Python PIP
PIP is a package manager for Python packages, or modules if you like.

### What is a Package?
A package contains all the files you need for a module.
Modules are Python code libraries you can include in your project.

### Check if PIP is Installed
Navigate your command line to the location of Python''s script directory, and type the following:

`pip --version`

### Download a Package
Downloading a package is very easy. Open the command line interface and tell PIP to download the package you want.', 105)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (106, N'Python.TryExcept', N'MARKDOWN', N'# Python Try Except
The `try` block lets you test a block of code for errors.
The `except` block lets you handle the error.
The `finally` block lets you execute code, regardless of the result of the try- and except blocks.

### Exception Handling
When an error occurs, or exception as we call it, Python will normally stop and generate an error message.
These exceptions can be handled using the `try` statement:

```python
try:
  print(x)
except:
  print("An exception occurred")
```', 106)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (107, N'Python.UserInput', N'MARKDOWN', N'# Python User Input
Python allows for user input.
That means we can ask the user for input.
The method is different in Python 3.6 than Python 2.7.
Python 3.6 uses the `input()` method.
Python 2.7 uses the `raw_input()` method.

The following example asks for the username, and when you entered the username, it gets printed on the screen:

```python
username = input("Enter username:")
print("Username is: " + username)
```', 107)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (108, N'Python.StringFormat', N'MARKDOWN', N'# Python String Formatting
To make sure a string will display as expected, we can format the result with the `format()` method.

### String format()
The `format()` method allows you to format selected parts of a string.
Sometimes there are parts of a text that you do not control, maybe they come from a database, or user input?
To control such values, add placeholders (curly brackets `{}`) in the text, and run the values through the `format()` method:

```python
price = 49
txt = "The price is {} dollars"
print(txt.format(price))
```', 108)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (109, N'Python.FileHandling', N'MARKDOWN', N'# Python File Handling
File handling is an important part of any web application.
Python has several functions for creating, reading, updating, and deleting files.

### File Handling
The key function for working with files in Python is the `open()` function.
The `open()` function takes two parameters; filename, and mode.

There are four different methods (modes) for opening a file:
* `"r"` - Read - Default value. Opens a file for reading, error if the file does not exist
* `"a"` - Append - Opens a file for appending, creates the file if it does not exist
* `"w"` - Write - Opens a file for writing, creates the file if it does not exist
* `"x"` - Create - Creates the specified file, returns an error if the file exists', 109)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (110, N'Python.ReadFiles', N'MARKDOWN', N'# Python Read Files
To open the file, use the built-in `open()` function.
The `open()` function returns a file object, which has a `read()` method for reading the content of the file:

```python
f = open("demofile.txt", "r")
print(f.read())
```

If the file is located in a different location, you will have to specify the file path.', 110)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (111, N'Python.WriteFiles', N'MARKDOWN', N'# Python Write/Create Files
To write to an existing file, you must add a parameter to the `open()` function:

* `"a"` - Append - will append to the end of the file
* `"w"` - Write - will overwrite any existing content

```python
f = open("demofile2.txt", "a")
f.write("Now the file has more content!")
f.close()

#open and read the file after the appending:
f = open("demofile2.txt", "r")
print(f.read())
```', 111)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (112, N'Python.DeleteFiles', N'MARKDOWN', N'# Python Delete Files
To delete a file, you must import the OS module, and run its `os.remove()` function:

```python
import os
os.remove("demofile.txt")
```

### Check if File exist:
To avoid getting an error, you might want to check if the file exists before you try to delete it:

```python
import os
if os.path.exists("demofile.txt"):
  os.remove("demofile.txt")
else:
  print("The file does not exist")
```', 112)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (113, N'Python.ListMethods', N'MARKDOWN', N'# Python List Methods
Python has a set of built-in methods that you can use on lists.

* `append()`	Adds an element at the end of the list
* `clear()`	Removes all the elements from the list
* `copy()`	Returns a copy of the list
* `count()`	Returns the number of elements with the specified value
* `extend()`	Add the elements of a list (or any iterable), to the end of the current list
* `index()`	Returns the index of the first element with the specified value
* `insert()`	Adds an element at the specified position
* `pop()`	Removes the element at the specified position
* `remove()`	Removes the first item with the specified value
* `reverse()`	Reverses the order of the list
* `sort()`	Sorts the list', 113)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (114, N'Python.DictMethods', N'MARKDOWN', N'# Python Dictionary Methods
Python has a set of built-in methods that you can use on dictionaries.

* `clear()`	Removes all the elements from the dictionary
* `copy()`	Returns a copy of the dictionary
* `fromkeys()`	Returns a dictionary with the specified keys and value
* `get()`	Returns the value of the specified key
* `items()`	Returns a list containing a tuple for each key value pair
* `keys()`	Returns a list containing the dictionary''s keys
* `pop()`	Removes the element with the specified key
* `popitem()`	Removes the last inserted key-value pair
* `setdefault()`	Returns the value of the specified key. If the key does not exist: insert the key, with the specified value
* `update()`	Updates the dictionary with the specified key-value pairs
* `values()`	Returns a list of all the values in the dictionary', 114)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (115, N'Python.SetMethods', N'MARKDOWN', N'# Python Set Methods
Python has a set of built-in methods that you can use on sets.

* `add()`	Adds an element to the set
* `clear()`	Removes all the elements from the set
* `copy()`	Returns a copy of the set
* `difference()`	Returns a set containing the difference between two or more sets
* `difference_update()`	Removes the items in this set that are also included in another, specified set
* `discard()`	Remove the specified item
* `intersection()`	Returns a set, that is the intersection of two other sets
* `intersection_update()`	Removes the items in this set that are not present in other, specified set(s)
* `isdisjoint()`	Returns whether two sets have a intersection or not', 115)
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
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (76, N'Python.Intro', N'Python', N'Introduction', 1, 76)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (77, N'Python.Syntax', N'Python', N'Syntax', 2, 77)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (78, N'Python.Comments', N'Python', N'Comments', 3, 78)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (79, N'Python.Variables', N'Python', N'Variables', 4, 79)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (80, N'Python.DataTypes', N'Python', N'Data Types', 5, 80)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (81, N'Python.Numbers', N'Python', N'Numbers', 6, 81)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (82, N'Python.Casting', N'Python', N'Casting', 7, 82)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (83, N'Python.Strings', N'Python', N'Strings', 8, 83)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (84, N'Python.Booleans', N'Python', N'Booleans', 9, 84)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (85, N'Python.Operators', N'Python', N'Operators', 10, 85)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (86, N'Python.Lists', N'Python', N'Lists', 11, 86)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (87, N'Python.Tuples', N'Python', N'Tuples', 12, 87)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (88, N'Python.Sets', N'Python', N'Sets', 13, 88)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (89, N'Python.Dictionaries', N'Python', N'Dictionaries', 14, 89)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (90, N'Python.IfElse', N'Python', N'If...Else', 15, 90)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (91, N'Python.While', N'Python', N'While Loops', 16, 91)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (92, N'Python.For', N'Python', N'For Loops', 17, 92)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (93, N'Python.Functions', N'Python', N'Functions', 18, 93)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (94, N'Python.Lambda', N'Python', N'Lambda', 19, 94)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (95, N'Python.Arrays', N'Python', N'Arrays', 20, 95)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (96, N'Python.Classes', N'Python', N'Classes/Objects', 21, 96)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (97, N'Python.Inheritance', N'Python', N'Inheritance', 22, 97)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (98, N'Python.Iterators', N'Python', N'Iterators', 23, 98)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (99, N'Python.Scope', N'Python', N'Scope', 24, 99)
GO
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (100, N'Python.Modules', N'Python', N'Modules', 25, 100)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (101, N'Python.Dates', N'Python', N'Dates', 26, 101)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (102, N'Python.Math', N'Python', N'Math', 27, 102)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (103, N'Python.JSON', N'Python', N'JSON', 28, 103)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (104, N'Python.RegEx', N'Python', N'RegEx', 29, 104)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (105, N'Python.PIP', N'Python', N'PIP', 30, 105)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (106, N'Python.TryExcept', N'Python', N'Try...Except', 31, 106)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (107, N'Python.UserInput', N'Python', N'User Input', 32, 107)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (108, N'Python.StringFormat', N'Python', N'String Formatting', 33, 108)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (109, N'Python.FileHandling', N'Python', N'File Handling', 34, 109)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (110, N'Python.ReadFiles', N'Python', N'Read Files', 35, 110)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (111, N'Python.WriteFiles', N'Python', N'Write/Create Files', 36, 111)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (112, N'Python.DeleteFiles', N'Python', N'Delete Files', 37, 112)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (113, N'Python.ListMethods', N'Python', N'List Methods', 38, 113)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (114, N'Python.DictMethods', N'Python', N'Dictionary Methods', 39, 114)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (115, N'Python.SetMethods', N'Python', N'Set Methods', 40, 115)
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
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (356, 36, N'Who owns the Java programming language?', N'Microsoft', N'Apple', N'Oracle', N'Google', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (357, 36, N'In which year was Java created?', N'1989', N'1995', N'2000', N'1990', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (358, 36, N'Which statement is true about Java?', N'It only runs on Windows', N'It is platform-independent', N'It is not secure', N'It is not object-oriented', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (359, 36, N'What is the Java Virtual Machine (JVM)?', N'A compiler', N'An engine that executes bytecode', N'A text editor', N'A database', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (360, 36, N'Java is short for "JavaScript".', N'True', N'False', N'Sometimes', N'Only in web', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (361, 36, N'Which file extension is used for Java source code?', N'.js', N'.txt', N'.class', N'.java', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (362, 36, N'What is the slogan of Java?', N'Write once, run anywhere', N'Just do it', N'Think different', N'Code hard', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (363, 36, N'Is Java Object-Oriented?', N'Yes', N'No', N'Partially', N'Only interface', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (364, 36, N'Which devices run Java?', N'Laptops', N'Data Centers', N'Game Consoles', N'All of the above', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (365, 36, N'Java was originally called:', N'Oak', N'Pine', N'C++', N'Coffee', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (366, 37, N'Every Java program must have at least one:', N'Variable', N'Class', N'Interface', N'Loop', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (367, 37, N'The name of the java file must match:', N'The package name', N'The class name', N'The main method', N'Any name', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (368, 37, N'What is the entry point of a Java application?', N'start()', N'run()', N'main()', N'init()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (369, 37, N'Correct syntax for the main method?', N'void main(String[] args)', N'public static void main(String[] args)', N'static void main()', N'public void main()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (370, 37, N'Does Java capitalization matter (Case Sensitivity)?', N'Yes', N'No', N'Only for variables', N'Only for classes', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (371, 37, N'Which character ends a Java statement?', N'.', N':', N';', N',', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (372, 37, N'What is a block of code surrounded by?', N'[]', N'()', N'{}', N'<>', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (373, 37, N'System.out.println() is used to:', N'Read input', N'Print text', N'Calculate math', N'Delete files', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (374, 37, N'Keywords in Java are:', N'Uppercase', N'Lowercase', N'CamelCase', N'Mixed', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (375, 37, N'Can you have multiple classes in one file?', N'Yes', N'No', N'Only if public', N'Only if static', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (376, 38, N'Which method prints text without a new line?', N'print()', N'println()', N'write()', N'echo()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (377, 38, N'Which method prints text and adds a new line?', N'print()', N'println()', N'writeLine()', N'log()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (378, 38, N'What will System.out.println(3 + 3); output?', N'33', N'3 + 3', N'6', N'Error', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (379, 38, N'Can you print numbers without quotes?', N'Yes', N'No', N'Only integers', N'Only floats', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (380, 38, N'What is "System" in System.out.println?', N'A method', N'A variable', N'A built-in class', N'A package', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (381, 38, N'How do you print a double quote character?', N'""', N'\"', N'/"', N'q', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (382, 38, N'Output of System.out.print("A"); System.out.print("B");', N'A\nB', N'AB', N'B A', N'Error', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (383, 38, N'Can you output mathematical operations inside println?', N'Yes', N'No', N'Only addition', N'Only subtraction', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (384, 38, N'What happens if you forget the semicolon?', N'It runs fine', N'Runtime Error', N'Syntax Error', N'It prints warning', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (385, 38, N'To print specific formatted text, use:', N'printf()', N'print()', N'format()', N'text()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (386, 39, N'How do you start a single-line comment?', N'#', N'//', N'--', N'/*', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (387, 39, N'How do you start a multi-line comment?', N'//', N'/*', N'<!--', N'#', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (388, 39, N'How do you end a multi-line comment?', N'*/', N'//', N'-->', N'#', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (389, 39, N'Are comments executed by the compiler?', N'Yes', N'No', N'Only single-line', N'Only multi-line', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (390, 39, N'Why use comments?', N'To make code run faster', N'To explain code and hide execution', N'To increase file size', N'Required by Java', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (391, 39, N'Can you nest comments?', N'Yes', N'No', N'Only single line', N'Only multi line', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (392, 39, N'What is a documentation comment?', N'/** ... */', N'// ...', N'/* ... */', N'# ...', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (393, 39, N'Comments are useful for:', N'Debugging', N'Documentation', N'Code readability', N'All of the above', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (394, 39, N'Can a comment be on the same line as code?', N'Yes', N'No', N'Only after semicolon', N'Only before code', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (395, 39, N'Which symbol is used for Javadoc?', N'//', N'/*', N'/**', N'#', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (396, 40, N'Which type stores text?', N'string', N'String', N'Text', N'char', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (397, 40, N'Which type stores whole numbers?', N'float', N'double', N'int', N'num', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (398, 40, N'Which type stores true or false?', N'bool', N'boolean', N'Boolean', N'bit', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (399, 40, N'Correct way to declare a variable?', N'type name = value;', N'name = value;', N'value = name;', N'dim name as type;', N'A')
GO
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (400, 40, N'What is "final" variable?', N'Last variable', N'Cannot be changed (constant)', N'Deleted variable', N'Static variable', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (401, 40, N'Can you declare multiple variables of same type?', N'No', N'Yes, comma separated', N'Yes, semicolon separated', N'Only ints', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (402, 40, N'String values are surrounded by:', N'Single quotes', N'Double quotes', N'Brackets', N'None', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (403, 40, N'Char values are surrounded by:', N'Single quotes', N'Double quotes', N'Brackets', N'None', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (404, 40, N'Which is a valid variable name?', N'1stName', N'first-Name', N'firstName', N'class', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (405, 40, N'How to assign value 5 to int x?', N'x == 5', N'int x = 5;', N'x : 5', N'5 = x', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (406, 41, N'Which is a primitive data type?', N'String', N'int', N'ArrayList', N'Scanner', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (407, 41, N'Which is a non-primitive type?', N'char', N'boolean', N'String', N'byte', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (408, 41, N'Size of an int?', N'2 bytes', N'4 bytes', N'8 bytes', N'16 bytes', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (409, 41, N'Size of a double?', N'4 bytes', N'8 bytes', N'16 bytes', N'32 bytes', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (410, 41, N'Which type holds decimal numbers?', N'int', N'short', N'float', N'long', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (411, 41, N'Difference between float and double?', N'Float is larger', N'Double is more precise', N'No difference', N'Float is integer', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (412, 41, N'Default value of boolean?', N'true', N'false', N'null', N'0', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (413, 41, N'What does "char" store?', N'Text', N'Single character', N'Numbers', N'Booleans', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (414, 41, N'Can primitive types be null?', N'Yes', N'No', N'Only int', N'Only boolean', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (415, 41, N'Scientific numbers can be written with:', N'e or E', N'x', N'#', N'^', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (416, 42, N'What is Widening Casting?', N'Converting smaller type to larger', N'Converting larger to smaller', N'Converting to string', N'Converting to boolean', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (417, 42, N'What is Narrowing Casting?', N'Converting smaller type to larger', N'Converting larger to smaller', N'Automatic', N'Safe', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (418, 42, N'Is widening casting automatic?', N'Yes', N'No', N'Sometimes', N'Only for float', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (419, 42, N'Is narrowing casting automatic?', N'Yes', N'No, manual', N'Sometimes', N'Only for double', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (420, 42, N'Syntax for manual casting?', N'(type) value', N'type(value)', N'value as type', N'convert(value)', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (421, 42, N'int x = 9; double d = x; is example of:', N'Widening', N'Narrowing', N'Error', N'Boxing', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (422, 42, N'double d = 9.78; int i = (int) d; Value of i?', N'9.78', N'10', N'9', N'0', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (423, 42, N'Can you cast boolean to int?', N'Yes', N'No', N'Only true', N'Only false', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (424, 42, N'Can you cast char to int?', N'Yes (ASCII value)', N'No', N'Only if number', N'Only if letter', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (425, 42, N'Which method converts types?', N'Type()', N'Cast()', N'Parse()', N'No methods exist', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (426, 43, N'Operator for addition?', N'&', N'+', N'plus', N'add', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (427, 43, N'Operator for modulus (remainder)?', N'/', N'#', N'%', N'mod', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (428, 43, N'What does ++x do?', N'Decrements x', N'Increments x by 1', N'Adds 2', N'Nothing', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (429, 43, N'Operator for "Equal to"?', N'=', N'==', N'===', N'equals', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (430, 43, N'Operator for "Not Equal"?', N'<>', N'!=', N'~=', N'not', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (431, 43, N'Logical AND operator?', N'&', N'&&', N'and', N'+', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (432, 43, N'Logical OR operator?', N'|', N'||', N'or', N'/', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (433, 43, N'Assignment operator?', N'==', N'=', N':=', N'<-', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (434, 43, N'What is x += 5 equivalent to?', N'x = 5', N'x = x + 5', N'x = x * 5', N'x = 5 + 5', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (435, 43, N'Bitwise OR operator?', N'||', N'|', N'or', N'^', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (436, 44, N'Method to find string length?', N'size()', N'length', N'length()', N'count()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (437, 44, N'Method to convert to uppercase?', N'toUpper()', N'toUpperCase()', N'UpperCase()', N'Upper()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (438, 44, N'Method to find a character index?', N'find()', N'search()', N'indexOf()', N'locate()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (439, 44, N'Operator for string concatenation?', N'.', N'+', N'&', N',', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (440, 44, N'Method to combine strings?', N'append()', N'concat()', N'join()', N'add()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (441, 44, N'Escape character for double quote?', N'/"', N'\"', N'""', N'q', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (442, 44, N'Escape character for new line?', N'\n', N'\t', N'\r', N'\l', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (443, 44, N'What happens adding number and string?', N'Math addition', N'String concatenation', N'Error', N'Nothing', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (444, 44, N'Are Java strings mutable?', N'Yes', N'No (Immutable)', N'Only if static', N'Only if public', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (445, 44, N'Method to extract part of string?', N'slice()', N'sub()', N'substring()', N'part()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (446, 45, N'Which class contains math methods?', N'System.Math', N'Math', N'Calc', N'Algebra', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (447, 45, N'Method to find highest value?', N'Math.high()', N'Math.max()', N'Math.largest()', N'Math.top()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (448, 45, N'Method to find square root?', N'Math.sq()', N'Math.root()', N'Math.sqrt()', N'Math.s()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (449, 45, N'Method to return absolute (positive) value?', N'Math.abs()', N'Math.pos()', N'Math.absolute()', N'Math.neg()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (450, 45, N'Method to generate random number?', N'Math.rand()', N'Math.random()', N'Math.rnd()', N'Math.next()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (451, 45, N'What does Math.random() return?', N'Integer 0-100', N'Double 0.0-1.0', N'Integer 0-1', N'Boolean', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (452, 45, N'Method to find lowest value?', N'Math.min()', N'Math.low()', N'Math.bottom()', N'Math.small()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (453, 45, N'Is Math class static?', N'Yes', N'No', N'Partially', N'Only max method', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (454, 45, N'Math.pow(2, 3) returns?', N'6', N'8', N'5', N'9', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (455, 45, N'Math.ceil(1.1) returns?', N'1.0', N'2.0', N'1.1', N'1.5', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (456, 46, N'Which loop runs as long as a condition is true?', N'if', N'while', N'switch', N'void', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (457, 46, N'What is the syntax for a while loop?', N'while (condition) { }', N'while { condition }', N'loop while (condition)', N'do { } while', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (458, 46, N'What happens if the condition in a while loop never becomes false?', N'It runs once', N'It throws an error', N'Infinite loop', N'It breaks automatically', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (459, 46, N'Which loop is guaranteed to run at least once?', N'for', N'while', N'do-while', N'foreach', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (460, 46, N'int i = 0; while (i < 5) { System.out.print(i); i++; } Output?', N'01234', N'12345', N'012345', N'5', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (461, 46, N'How do you stop a while loop manually?', N'stop', N'exit', N'break', N'return', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (462, 46, N'Can you put a while loop inside another while loop?', N'No', N'Yes', N'Only for integers', N'Only if static', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (463, 46, N'What is the initial value of i in: while(i < 10)?', N'0', N'1', N'Undefined (must be initialized)', N'10', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (464, 46, N'Can the condition in a while loop be false initially?', N'Yes', N'No', N'Error', N'Only in do-while', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (465, 46, N'Which keyword skips the current iteration?', N'break', N'continue', N'next', N'skip', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (466, 47, N'Syntax for a standard for loop?', N'for (init; condition; increment)', N'for (condition; init; increment)', N'loop (init; condition)', N'for (increment; condition)', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (467, 47, N'What is the "For-Each" loop used for?', N'Math', N'Arrays / Collections', N'Strings only', N'Infinite loops', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (468, 47, N'Which part of the for loop runs only once?', N'Condition', N'Increment', N'Initialization', N'Body', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (469, 47, N'for (int i=0; i<5; i+=2) Output?', N'0 1 2 3 4', N'0 2 4', N'0 2 4 6', N'1 3 5', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (470, 47, N'Can you declare the loop variable outside the for loop?', N'Yes', N'No', N'Only if static', N'Only if final', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (471, 47, N'What happens if you omit the condition: for(;;)?', N'Error', N'Runs once', N'Infinite loop', N'Does nothing', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (472, 47, N'Syntax for For-Each loop?', N'for (type var : array)', N'foreach (type var in array)', N'for (array as var)', N'loop (var : array)', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (473, 47, N'Can you modify the array size inside a for loop?', N'Yes', N'No, arrays are fixed size', N'Only if ArrayList', N'Only if empty', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (474, 47, N'Which statement exits the loop immediately?', N'continue', N'break', N'exit', N'stop', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (475, 47, N'What is the scope of variable "i" declared in "for(int i=0...)"?', N'Global', N'Inside the loop only', N'Inside the main method', N'Class level', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (476, 48, N'How do you declare an array of strings?', N'String[] cars;', N'String cars[];', N'Array<String> cars;', N'Both A and B', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (477, 48, N'How do you access the first element?', N'arr[0]', N'arr(0)', N'arr.first()', N'arr[1]', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (478, 48, N'Which property gives the size of an array?', N'length()', N'size', N'length', N'count', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (479, 48, N'Can an array hold different data types?', N'Yes', N'No', N'Only if Object', N'Only in Java 10', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (480, 48, N'What is the index of the last element in array "arr"?', N'arr.length', N'arr.length - 1', N'arr.size', N'arr.last', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (481, 48, N'How do you initialize an array with values?', N'{1, 2, 3}', N'[1, 2, 3]', N'(1, 2, 3)', N'<1, 2, 3>', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (482, 48, N'What is the default value of int array elements?', N'null', N'0', N'-1', N'undefined', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (483, 48, N'Can you change the size of an array after creation?', N'Yes', N'No', N'Using resize()', N'Using add()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (484, 48, N'How do you loop through an array?', N'for loop', N'for-each loop', N'while loop', N'All of the above', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (485, 48, N'What exception occurs if you access an invalid index?', N'NullPointerException', N'ArrayIndexOutOfBoundsException', N'InvalidIndexException', N'Error', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (486, 49, N'What is a method?', N'A variable', N'A block of code that runs when called', N'A class', N'A loop', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (487, 49, N'How do you call a method named "myMethod"?', N'myMethod;', N'myMethod[];', N'myMethod();', N'(myMethod)', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (488, 49, N'Which keyword means no return value?', N'int', N'void', N'null', N'static', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (489, 49, N'Where must a method be declared?', N'Inside a class', N'Outside a class', N'Inside another method', N'In a file', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (490, 49, N'What does "static" mean for a method?', N'It belongs to the class, not object', N'It cannot be changed', N'It is private', N'It returns void', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (491, 49, N'Can a method call another method?', N'No', N'Yes', N'Only main', N'Only if public', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (492, 49, N'Naming convention for methods in Java?', N'PascalCase', N'camelCase', N'snake_case', N'UPPERCASE', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (493, 49, N'Can a method return an array?', N'No', N'Yes', N'Only int arrays', N'Only string arrays', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (494, 49, N'What happens when a method finishes?', N'Program stops', N'Returns to caller', N'Loops', N'Deletes data', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (495, 49, N'Can you define a method inside main?', N'No', N'Yes', N'Only in Java 8', N'Only static', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (496, 50, N'What are variables inside the parenthesis of a method called?', N'Parameters', N'Arguments', N'Fields', N'Classes', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (497, 50, N'What are the values passed when calling a method called?', N'Parameters', N'Arguments', N'Values', N'Inputs', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (498, 50, N'How do you return a value?', N'get value;', N'return value;', N'send value;', N'value;', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (499, 50, N'If a method returns int, what can it return?', N'5.5', N'"Hello"', N'10', N'true', N'C')
GO
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (500, 50, N'Can a method have multiple parameters?', N'No', N'Yes, separated by commas', N'Yes, separated by spaces', N'Only if same type', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (501, 50, N'void myMethod(String fname). What is fname?', N'Argument', N'Parameter', N'Class', N'Method', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (502, 50, N'Can you pass an array to a method?', N'Yes', N'No', N'Only int arrays', N'Only if static', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (503, 50, N'What happens if you don''t return a value in a non-void method?', N'Returns 0', N'Returns null', N'Compilation Error', N'Runtime Error', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (504, 50, N'Can parameters be final?', N'Yes', N'No', N'Only int', N'Only String', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (505, 50, N'Is Java pass-by-value or pass-by-reference?', N'Pass-by-value', N'Pass-by-reference', N'Both', N'Neither', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (506, 51, N'What is method overloading?', N'Same method name, different parameters', N'Different name, same parameters', N'Same name and parameters', N'Overriding a method', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (507, 51, N'Can you overload based on return type only?', N'Yes', N'No', N'Only for void', N'Only for int', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (508, 51, N'Which makes a signature unique?', N'Access modifier', N'Return type', N'Parameter list', N'Throws clause', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (509, 51, N'Why use overloading?', N'Code readability and reuse', N'To make code faster', N'To hide methods', N'Required by Java', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (510, 51, N'Can you overload the main method?', N'No', N'Yes', N'Only if private', N'Only if void', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (511, 51, N'Is "void add(int a)" and "void add(double a)" valid overloading?', N'Yes', N'No', N'Only in main', N'Only if static', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (512, 51, N'What determines which overloaded method is called?', N'Return type', N'Arguments passed', N'Randomly', N'First one defined', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (513, 51, N'Can constructors be overloaded?', N'No', N'Yes', N'Only default', N'Only private', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (514, 51, N'Does overloading support variable arguments?', N'Yes', N'No', N'Only strings', N'Only ints', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (515, 51, N'Is overloading polymorphism?', N'Yes, Compile-time polymorphism', N'Yes, Runtime polymorphism', N'No', N'Only inheritance', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (516, 52, N'What is scope?', N'A microscope', N'Region where a variable is accessible', N'A method type', N'A class', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (517, 52, N'Variables defined inside a method are:', N'Global', N'Local', N'Static', N'Public', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (518, 52, N'Can a local variable be accessed outside its method?', N'Yes', N'No', N'Only if public', N'Only if static', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (519, 52, N'What is block scope?', N'Code between {}', N'Code in a file', N'Code in a class', N'Code in main', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (520, 52, N'Can you have two variables with the same name in the same scope?', N'Yes', N'No', N'Only if different types', N'Only if static', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (521, 52, N'Are loop variables (int i) accessible outside the loop?', N'Yes', N'No', N'Only for while loops', N'Only if declared before loop', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (522, 52, N'Class level variables are accessible to:', N'Only main', N'All methods in the class', N'Only constructor', N'None', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (523, 52, N'If a local variable has the same name as a class variable, which is used?', N'Class variable', N'Local variable (Shadowing)', N'Error', N'Both', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (524, 52, N'How do you access the class variable if shadowed?', N'super.var', N'this.var', N'class.var', N'var', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (525, 52, N'Parameters have which scope?', N'Method scope', N'Class scope', N'Global scope', N'Block scope', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (526, 53, N'What is recursion?', N'A loop', N'A method calling itself', N'A database call', N'A variable', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (527, 53, N'What is required to stop recursion?', N'Halting condition', N'Break statement', N'Return null', N'Error', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (528, 53, N'What happens without a halting condition?', N'Infinite loop / StackOverflow', N'It stops automatically', N'Returns 0', N'Compiles faster', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (529, 53, N'Example of a recursive problem?', N'Printing Hello', N'Factorial / Fibonacci', N'Adding 1+1', N'Reading a file', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (530, 53, N'Is recursion always better than loops?', N'Yes', N'No, can be memory intensive', N'They are the same', N'Only for math', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (531, 53, N'Where are recursive calls stored?', N'Heap', N'Stack', N'SSD', N'Cache', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (532, 53, N'Can any recursive function be written iteratively?', N'Yes', N'No', N'Only void ones', N'Only int ones', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (533, 53, N'10! (Factorial) is calculated as:', N'10 * 9!', N'10 + 9', N'10 * 10', N'10 / 9', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (534, 53, N'What is the base case?', N'The condition to stop recursion', N'The first call', N'The main method', N'The variable', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (535, 53, N'Does recursion use more memory than loops?', N'Usually Yes', N'Usually No', N'Same', N'Depends on OS', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (536, 54, N'What is a Class?', N'An object', N'A blueprint for objects', N'A method', N'A variable', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (537, 54, N'How do you create an object of class "MyClass"?', N'MyClass obj = new MyClass();', N'new MyClass();', N'MyClass obj;', N'obj = MyClass();', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (538, 54, N'Which keyword creates a class?', N'object', N'class', N'struct', N'new', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (539, 54, N'Java is:', N'Procedural', N'Object-Oriented', N'Functional', N'Scripting', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (540, 54, N'A class contains:', N'Attributes and Methods', N'Only text', N'Only numbers', N'Files', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (541, 54, N'Standard naming for classes?', N'camelCase', N'PascalCase (UpperCase)', N'snake_case', N'lowercase', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (542, 54, N'Can you have multiple objects of one class?', N'No', N'Yes', N'Only 2', N'Only if static', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (543, 54, N'Where is a class usually defined?', N'In a .java file', N'In a .txt file', N'In main', N'In a method', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (544, 54, N'Can a class be empty?', N'Yes', N'No', N'Only if abstract', N'Only if void', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (545, 54, N'Does every Java program need a class?', N'Yes', N'No', N'Only for GUI', N'Only for Web', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (546, 55, N'What are Class Attributes?', N'Variables inside a class', N'Methods', N'Constructors', N'Files', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (547, 55, N'Another name for attributes?', N'Fields', N'Tags', N'Labels', N'Comments', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (548, 55, N'How do you access an attribute x of object obj?', N'obj->x', N'obj.x', N'obj[x]', N'x(obj)', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (549, 55, N'Can attributes be modified?', N'Yes', N'No', N'Only in main', N'Only if static', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (550, 55, N'How do you prevent modification of an attribute?', N'Use "static"', N'Use "final"', N'Use "void"', N'Use "const"', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (551, 55, N'int x = 5; inside a class is:', N'A method', N'An attribute', N'A constructor', N'An object', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (552, 55, N'Can you have multiple attributes?', N'No', N'Yes', N'Only 5', N'Only strings', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (553, 55, N'What is the default value of an int attribute?', N'null', N'0', N'1', N'undefined', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (554, 55, N'Can attributes be objects?', N'No', N'Yes (e.g. String)', N'Only arrays', N'Only lists', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (555, 55, N'To modify an attribute, you use:', N'Dot syntax', N'Arrow syntax', N'Brackets', N'Parenthesis', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (556, 56, N'What is a constructor?', N'A static method', N'A special method to initialize objects', N'A variable', N'A class type', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (557, 56, N'What must match the class name?', N'The main method', N'The constructor name', N'The package name', N'The variable name', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (558, 56, N'What is the return type of a constructor?', N'void', N'int', N'Object', N'None (no return type)', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (559, 56, N'When is a constructor called?', N'When the class is defined', N'When an object is created', N'When the program ends', N'Manually only', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (560, 56, N'Can a constructor take parameters?', N'No', N'Yes', N'Only strings', N'Only int', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (561, 56, N'If you don''t define a constructor, what happens?', N'Compilation Error', N'Java provides a default one', N'Runtime Error', N'Class cannot be used', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (562, 56, N'Can you overload constructors?', N'No', N'Yes (multiple constructors)', N'Only if private', N'Only if static', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (563, 56, N'What keyword calls one constructor from another?', N'super()', N'this()', N'call()', N'new()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (564, 56, N'Can a constructor be private?', N'No', N'Yes (Singleton pattern)', N'Only in abstract classes', N'Only in interfaces', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (565, 56, N'What is the default constructor parameter list?', N'Empty ()', N'(int x)', N'(String s)', N'(Object o)', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (566, 57, N'Which modifier makes a member accessible only within the same class?', N'public', N'protected', N'private', N'default', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (567, 57, N'Which modifier allows access from anywhere?', N'public', N'private', N'protected', N'static', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (568, 57, N'Which modifier allows access in the same package and subclasses?', N'private', N'protected', N'public', N'final', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (569, 57, N'What does "static" mean?', N'Variable cannot change', N'Belongs to class, not instance', N'Access is restricted', N'Method returns void', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (570, 57, N'What does "final" mean for a variable?', N'It is the last one', N'Value cannot be changed', N'It is private', N'It is static', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (571, 57, N'Can a class be private?', N'Yes', N'No (only nested classes can)', N'Only abstract ones', N'Only interfaces', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (572, 57, N'What does "abstract" mean for a method?', N'It has no body', N'It is private', N'It is static', N'It is final', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (573, 57, N'Can you override a "final" method?', N'Yes', N'No', N'Only in same package', N'Only if public', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (574, 57, N'Which is the default access modifier (no keyword)?', N'public', N'private', N'package-private', N'protected', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (575, 57, N'What does "transient" modifier do?', N'Makes variable temporary', N'Skips serialization', N'Makes it thread-safe', N'Optimizes memory', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (576, 58, N'What is Encapsulation?', N'Hiding sensitive data', N'Inheriting classes', N'Overloading methods', N'Importing packages', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (577, 58, N'How do you achieve encapsulation?', N'Declare variables as public', N'Declare variables as private and use Getters/Setters', N'Use static methods', N'Use inheritance', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (578, 58, N'What is a Getter?', N'Method to update value', N'Method to read value', N'Variable', N'Constructor', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (579, 58, N'What is a Setter?', N'Method to update value', N'Method to read value', N'Constructor', N'Static block', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (580, 58, N'Why use Encapsulation?', N'To make code slower', N'Control over data (read-only/write-only)', N'To use more memory', N'Required by JVM', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (581, 58, N'Which keyword is used for the private variable?', N'public', N'class', N'private', N'void', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (582, 58, N'Standard naming for a getter of variable "name"?', N'getName()', N'name()', N'readName()', N'fetchName()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (583, 58, N'Can a setter include validation logic?', N'No', N'Yes (e.g. check if age > 0)', N'Only for strings', N'Only for static', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (584, 58, N'If you only provide a get method, the variable is:', N'Read-only', N'Write-only', N'Public', N'Invalid', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (585, 58, N'Encapsulation increases:', N'Coupling', N'Flexibility and Maintainability', N'File size', N'Compilation time', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (586, 59, N'What is a Package in Java?', N'A box', N'A group of related classes', N'A method', N'A variable type', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (587, 59, N'Which keyword is used to import a package?', N'package', N'include', N'import', N'using', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (588, 59, N'Which package contains the Scanner class?', N'java.io', N'java.util', N'java.lang', N'java.net', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (589, 59, N'Do you need to import java.lang?', N'Yes', N'No, it is automatic', N'Only for String', N'Only for Math', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (590, 59, N'How do you create a user-defined package?', N'import mypack', N'package mypack;', N'create package mypack', N'class mypack', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (591, 59, N'What does "import java.util.*" do?', N'Imports nothing', N'Imports only ArrayList', N'Imports all classes in java.util', N'Imports sub-packages', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (592, 59, N'Why use packages?', N'To avoid naming conflicts', N'To organize code', N'To control access', N'All of the above', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (593, 59, N'Where must the "package" statement be?', N'Inside the class', N'First line of the file', N'Last line', N'Anywhere', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (594, 59, N'Can a class have multiple package statements?', N'Yes', N'No', N'Only if different names', N'Only if public', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (595, 59, N'What is the root of the Java package hierarchy?', N'java', N'javax', N'org', N'com', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (596, 60, N'Which keyword is used for inheritance?', N'inherits', N'extends', N'implements', N'uses', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (597, 60, N'What is a subclass?', N'The parent class', N'The child class that inherits', N'A static class', N'An abstract class', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (598, 60, N'What is a superclass?', N'The parent class being inherited from', N'The child class', N'The main class', N'A final class', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (599, 60, N'Can a class extend multiple classes in Java?', N'Yes', N'No (Single Inheritance)', N'Only if abstract', N'Only interfaces', N'B')
GO
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (600, 60, N'How do you access the superclass constructor?', N'this()', N'super()', N'parent()', N'base()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (601, 60, N'Which modifier prevents inheritance?', N'static', N'final', N'private', N'abstract', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (602, 60, N'Does a subclass inherit private members?', N'Yes, directly accessible', N'No, but they exist in memory', N'No, they are deleted', N'Only if static', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (603, 60, N'What is the root class of all Java classes?', N'Main', N'String', N'Object', N'System', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (604, 60, N'If Class B extends Class A, is "A a = new B()" valid?', N'Yes (Upcasting)', N'No', N'Only if A is abstract', N'Only if B is final', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (605, 60, N'Can you override a final method?', N'Yes', N'No', N'Only in same package', N'Only if private', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (606, 61, N'What is Polymorphism?', N'Many forms', N'One form', N'Data hiding', N'Code copying', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (607, 61, N'Which concept is "Method Overriding" related to?', N'Encapsulation', N'Polymorphism', N'Abstraction', N'Constructors', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (608, 61, N'When does method overriding occur?', N'In the same class', N'Between superclass and subclass', N'Between two interfaces', N'In main method', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (609, 61, N'What annotation is used for overriding?', N'@Overload', N'@Override', N'@Super', N'@New', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (610, 61, N'Can you override a static method?', N'Yes', N'No (it is Method Hiding)', N'Only if private', N'Only if final', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (611, 61, N'Does the overridden method need the same name?', N'Yes', N'No', N'Only if void', N'Only if public', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (612, 61, N'Does the overridden method need the same parameters?', N'Yes', N'No (that is overloading)', N'Only if int', N'Only if string', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (613, 61, N'Why use Polymorphism?', N'Code reusability and flexibility', N'To make code strict', N'To prevent inheritance', N'To use more memory', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (614, 61, N'Dynamic Binding happens at:', N'Compile time', N'Runtime', N'Writing time', N'Loading time', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (615, 61, N'Can an object of Parent class hold reference to Child class?', N'Yes', N'No', N'Only if abstract', N'Only if interface', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (616, 62, N'Can a class be defined inside another class?', N'No', N'Yes (Nested/Inner Class)', N'Only in methods', N'Only in loops', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (617, 62, N'What is the purpose of inner classes?', N'Grouping logically related classes', N'Making code larger', N'Slowing down execution', N'Nothing', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (618, 62, N'How do you instantiate a non-static inner class?', N'new Inner()', N'Outer.new Inner()', N'outerObj.new Inner()', N'new Outer.Inner()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (619, 62, N'Can an inner class be private?', N'Yes', N'No', N'Only if static', N'Only if abstract', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (620, 62, N'Can a static inner class access non-static members of Outer?', N'Yes', N'No', N'Only private ones', N'Only public ones', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (621, 62, N'Can an inner class access private members of Outer?', N'Yes', N'No', N'Only if static', N'Only if final', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (622, 62, N'How do you instantiate a static nested class?', N'outerObj.new Inner()', N'new Outer.Inner()', N'new Inner()', N'Outer.Inner()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (623, 62, N'Can a class be defined inside a method?', N'Yes (Local Inner Class)', N'No', N'Only in main', N'Only in constructor', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (624, 62, N'What file is generated for Inner class?', N'Outer.class', N'Inner.class', N'Outer$Inner.class', N'Outer_Inner.class', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (625, 62, N'Can an anonymous inner class have a constructor?', N'Yes', N'No (it has no name)', N'Only default', N'Only static', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (626, 63, N'What is an abstract class?', N'A class that cannot be instantiated', N'A normal class', N'A final class', N'A static class', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (627, 63, N'Can an abstract class have a constructor?', N'Yes', N'No', N'Only static', N'Only private', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (628, 63, N'Does an abstract method have a body?', N'Yes', N'No', N'Only empty braces', N'Only return null', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (629, 63, N'Where must an abstract method be defined?', N'Any class', N'Abstract class or Interface', N'Static class', N'Final class', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (630, 63, N'If a class inherits abstract class, what must it do?', N'Nothing', N'Implement all abstract methods (or be abstract itself)', N'Override constructor', N'Delete methods', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (631, 63, N'Can an abstract class have non-abstract methods?', N'Yes', N'No', N'Only private', N'Only static', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (632, 63, N'Which keyword declares an abstract class?', N'virtual', N'abstract', N'implements', N'interface', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (633, 63, N'Can you create an object of an abstract class?', N'Yes', N'No', N'Only if empty', N'Only in main', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (634, 63, N'Why use abstraction?', N'To hide implementation details', N'To show all details', N'To make code faster', N'To remove classes', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (635, 63, N'Can an abstract class be final?', N'Yes', N'No (contradiction)', N'Only if empty', N'Only if static', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (636, 64, N'What keyword is used to implement an interface?', N'extends', N'implements', N'using', N'inherits', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (637, 64, N'Can an interface have a constructor?', N'Yes', N'No', N'Only default', N'Only static', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (638, 64, N'By default, methods in an interface are:', N'private', N'public abstract', N'protected', N'static', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (639, 64, N'Can a class implement multiple interfaces?', N'Yes', N'No', N'Only 2', N'Only if abstract', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (640, 64, N'Can an interface extend another interface?', N'Yes', N'No', N'Only class', N'Only abstract', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (641, 64, N'Variables in an interface are implicitly:', N'private', N'public static final', N'protected', N'transient', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (642, 64, N'Can you create an object of an interface?', N'Yes', N'No', N'Only if empty', N'Only in main', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (643, 64, N'Difference between Abstract Class and Interface?', N'Abstract class can have state/constructors', N'Interface can have constructors', N'No difference', N'Interface is faster', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (644, 64, N'What is a marker interface?', N'Interface with no methods', N'Interface with 1 method', N'Interface with main', N'Interface with static', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (645, 64, N'From Java 8, interfaces can have:', N'Constructors', N'Default and Static methods', N'Instance variables', N'Destructors', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (646, 65, N'What is an Enum?', N'A class', N'A group of constants', N'A method', N'A variable', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (647, 65, N'Which keyword defines an enum?', N'class', N'enum', N'interface', N'struct', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (648, 65, N'Can an enum have methods?', N'Yes', N'No', N'Only static', N'Only private', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (649, 65, N'Can an enum have a constructor?', N'Yes', N'No', N'Only public', N'Only protected', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (650, 65, N'What is the default value of the first enum constant?', N'1', N'0', N'-1', N'null', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (651, 65, N'How do you iterate over enum values?', N'Enum.values()', N'Enum.all()', N'Enum.list()', N'Enum.array()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (652, 65, N'Can an enum extend a class?', N'Yes', N'No (extends java.lang.Enum)', N'Only Object', N'Only String', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (653, 65, N'Can an enum implement an interface?', N'Yes', N'No', N'Only Serializable', N'Only Cloneable', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (654, 65, N'Are enum constants type-safe?', N'Yes', N'No', N'Only if ints', N'Only if strings', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (655, 65, N'Can you use enum in a switch statement?', N'Yes', N'No', N'Only if cast to int', N'Only strings', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (656, 66, N'Which class is commonly used for user input?', N'System.Input', N'Scanner', N'Reader', N'InputReader', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (657, 66, N'Which package contains the Scanner class?', N'java.io', N'java.util', N'java.net', N'java.input', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (658, 66, N'How do you create a Scanner object?', N'Scanner s = new Scanner(System.in);', N'Scanner s = Scanner();', N'new Scanner();', N'Scanner s = new Scanner();', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (659, 66, N'Which method reads a string line?', N'nextString()', N'nextLine()', N'read()', N'getLine()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (660, 66, N'Which method reads an integer?', N'nextInt()', N'readInt()', N'getInteger()', N'nextInteger()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (661, 66, N'What happens if you input a string when nextInt() is called?', N'It converts it', N'InputMismatchException', N'Returns 0', N'It ignores it', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (662, 66, N'Which method reads a boolean?', N'nextBoolean()', N'readBool()', N'getBool()', N'isBoolean()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (663, 66, N'Which method reads a double?', N'nextDouble()', N'readDouble()', N'getDouble()', N'float()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (664, 66, N'Do you need to import the Scanner class?', N'Yes', N'No', N'Only for file input', N'Only for ints', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (665, 66, N'What is System.in?', N'Standard Output', N'Standard Input', N'Error Stream', N'File Stream', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (666, 67, N'Which package contains the modern Date/Time API (Java 8+)?', N'java.util', N'java.time', N'java.date', N'java.sql', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (667, 67, N'Which class represents a date (year, month, day)?', N'Date', N'LocalDate', N'LocalTime', N'LocalDateTime', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (668, 67, N'Which class represents time without a date?', N'Time', N'LocalTime', N'Clock', N'Timer', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (669, 67, N'Which class represents both date and time?', N'Date', N'DateTime', N'LocalDateTime', N'Timestamp', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (670, 67, N'How do you get the current date?', N'LocalDate.now()', N'new LocalDate()', N'Date.today()', N'Current.Date()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (671, 67, N'Which class is used for formatting dates?', N'DateFormat', N'DateTimeFormatter', N'DateFormatter', N'TimeFormat', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (672, 67, N'What pattern represents year-month-day?', N'yyyy-MM-dd', N'dd-MM-yyyy', N'MM-dd-yyyy', N'Year-Month-Day', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (673, 67, N'Are LocalDate objects mutable?', N'Yes', N'No (Immutable)', N'Only time', N'Only date', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (674, 67, N'How do you add days to a LocalDate?', N'date.add(1)', N'date.plusDays(1)', N'date + 1', N'date.append(1)', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (675, 67, N'Which class represents a specific moment in time (timestamp)?', N'Instant', N'Moment', N'Time', N'Clock', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (676, 68, N'What is an ArrayList?', N'A fixed-size array', N'A resizable array', N'A linked list', N'A map', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (677, 68, N'Which package contains ArrayList?', N'java.lang', N'java.util', N'java.io', N'java.net', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (678, 68, N'How do you add an item?', N'list.insert()', N'list.add()', N'list.push()', N'list.append()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (679, 68, N'How do you access an item at index 0?', N'list[0]', N'list.get(0)', N'list(0)', N'list.first()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (680, 68, N'How do you modify an item?', N'list[0] = x', N'list.set(index, value)', N'list.change(index, value)', N'list.put(index, value)', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (681, 68, N'How do you remove an item?', N'list.remove(index)', N'list.delete(index)', N'list.pop()', N'list.minus()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (682, 68, N'How do you get the size of the ArrayList?', N'list.length', N'list.size()', N'list.count', N'list.getSize()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (683, 68, N'Can ArrayList store primitive types (int)?', N'Yes', N'No, use Wrapper Classes (Integer)', N'Only double', N'Only boolean', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (684, 68, N'How do you clear all elements?', N'list.clear()', N'list.empty()', N'list.reset()', N'list.deleteAll()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (685, 68, N'Can ArrayList contain duplicates?', N'Yes', N'No', N'Only if strings', N'Only if ints', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (686, 69, N'What is the difference between ArrayList and LinkedList?', N'No difference', N'ArrayList uses array, LinkedList uses nodes', N'ArrayList is slower', N'LinkedList cannot store strings', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (687, 69, N'Which is generally faster for inserting/deleting items in the middle?', N'ArrayList', N'LinkedList', N'Both same', N'Arrays', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (688, 69, N'Which is generally faster for accessing items by index?', N'ArrayList', N'LinkedList', N'Both same', N'Maps', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (689, 69, N'Which method adds an item to the beginning?', N'addFirst()', N'addStart()', N'pushFront()', N'insertFirst()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (690, 69, N'Which method adds an item to the end?', N'addLast()', N'addEnd()', N'pushBack()', N'append()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (691, 69, N'Which interface does LinkedList implement?', N'List', N'Queue', N'Deque', N'All of the above', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (692, 69, N'How do you remove the first item?', N'removeFirst()', N'deleteFirst()', N'popFirst()', N'shift()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (693, 69, N'Can LinkedList contain null elements?', N'Yes', N'No', N'Only one', N'Only strings', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (694, 69, N'How is data stored in a LinkedList?', N'Contiguous memory', N'Containers (Nodes) linked to each other', N'Hash table', N'Tree', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (695, 69, N'What method gets the first item?', N'getFirst()', N'first()', N'head()', N'top()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (696, 70, N'What does a HashMap store?', N'Single values', N'Key/Value pairs', N'Arrays', N'Lists', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (697, 70, N'How do you add an item to a HashMap?', N'add()', N'put()', N'insert()', N'set()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (698, 70, N'How do you access a value?', N'get(key)', N'access(key)', N'map[key]', N'value(key)', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (699, 70, N'Can keys be duplicates?', N'Yes', N'No (Overwrites existing)', N'Only if null', N'Only strings', N'B')
GO
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (700, 70, N'Can values be duplicates?', N'Yes', N'No', N'Only null', N'Only ints', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (701, 70, N'How do you remove an item?', N'remove(key)', N'delete(key)', N'pop(key)', N'erase(key)', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (702, 70, N'How do you check if a key exists?', N'containsKey()', N'hasKey()', N'exists()', N'find()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (703, 70, N'How do you check if a value exists?', N'containsValue()', N'hasValue()', N'checkValue()', N'valueExists()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (704, 70, N'How do you get the number of items?', N'size()', N'length', N'count', N'capacity', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (705, 70, N'How do you loop through keys?', N'map.keySet()', N'map.keys()', N'map.getKeys()', N'map.loop()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (706, 71, N'What is an Iterator used for?', N'Sorting', N'Looping through collections', N'Adding items', N'Connecting to DB', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (707, 71, N'Which package is Iterator in?', N'java.util', N'java.io', N'java.lang', N'java.net', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (708, 71, N'How do you get an iterator for an ArrayList?', N'list.iterator()', N'list.getIterator()', N'new Iterator(list)', N'Iterator.from(list)', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (709, 71, N'Which method checks if there are more items?', N'next()', N'hasNext()', N'more()', N'check()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (710, 71, N'Which method gets the next item?', N'next()', N'getNext()', N'item()', N'value()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (711, 71, N'How do you remove an item while iterating?', N'list.remove()', N'it.remove()', N'delete()', N'Cannot remove', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (712, 71, N'Can you use Iterator with a HashMap?', N'No', N'Yes (on keySet or values)', N'Only keys', N'Only values', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (713, 71, N'What happens if you call next() when no items are left?', N'Returns null', N'NoSuchElementException', N'Returns 0', N'Loops back', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (714, 71, N'Is Iterator preferred over for-loop for removing items?', N'Yes, avoids ConcurrentModificationException', N'No, for-loop is better', N'They are same', N'Iterator is slower', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (715, 71, N'Does Iterator work with arrays?', N'No', N'Yes', N'Only int arrays', N'Only String arrays', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (716, 72, N'What are Wrapper Classes?', N'Classes that wrap primitive types', N'Classes for security', N'Classes for files', N'Classes for UI', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (717, 72, N'Wrapper class for int?', N'Int', N'Integer', N'Int32', N'Number', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (718, 72, N'Wrapper class for char?', N'Char', N'Character', N'String', N'Letter', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (719, 72, N'Why use Wrapper Classes?', N'To use primitives in Collections', N'To make code faster', N'To save memory', N'To avoid nulls', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (720, 72, N'What is Autoboxing?', N'Automatic conversion of primitive to wrapper', N'Automatic sorting', N'Wrapping code in try-catch', N'Creating a box UI', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (721, 72, N'What is Unboxing?', N'Conversion of wrapper to primitive', N'Removing items from list', N'Deleting a class', N'Opening a file', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (722, 72, N'Method to get int value from Integer object?', N'intValue()', N'getValue()', N'toInt()', N'value()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (723, 72, N'Can Wrapper objects be null?', N'Yes', N'No', N'Only Integer', N'Only Boolean', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (724, 72, N'Is "Integer myInt = 5;" valid?', N'Yes (Autoboxing)', N'No, use new Integer(5)', N'No, use int', N'Only in Java 5', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (725, 72, N'Method to convert Integer to String?', N'toString()', N'parseString()', N'convert()', N'text()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (726, 73, N'Which keyword is used to handle exceptions?', N'try', N'catch', N'finally', N'All of the above', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (727, 73, N'Which block contains the code to test for errors?', N'try', N'catch', N'throw', N'finally', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (728, 73, N'Which block executes if an error occurs?', N'try', N'catch', N'else', N'finally', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (729, 73, N'Which block executes regardless of the result?', N'always', N'finally', N'done', N'end', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (730, 73, N'Which keyword creates a custom error?', N'throw', N'raise', N'create', N'error', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (731, 73, N'What is the base class for exceptions?', N'Error', N'Exception', N'Throwable', N'Object', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (732, 73, N'Can you catch multiple types of exceptions?', N'Yes', N'No', N'Only 2', N'Only RuntimeException', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (733, 73, N'What happens if an exception is not caught?', N'Program continues', N'Program crashes/terminates', N'Nothing', N'Warning is shown', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (734, 73, N'Is "finally" mandatory?', N'Yes', N'No', N'Only if catch is used', N'Only if try is used', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (735, 73, N'Common exception for array index error?', N'NullPointerException', N'ArrayIndexOutOfBoundsException', N'IOException', N'ClassCastException', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (736, 74, N'What does Regex stand for?', N'Regular Extension', N'Regular Expression', N'Region Extra', N'Register Exit', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (737, 74, N'Which package contains Regex classes?', N'java.util.regex', N'java.text', N'java.io', N'java.lang', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (738, 74, N'Which class defines the pattern?', N'Pattern', N'Matcher', N'Regex', N'Template', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (739, 74, N'Which class searches for the pattern?', N'Pattern', N'Matcher', N'Searcher', N'Finder', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (740, 74, N'Method to check if pattern matches?', N'check()', N'matches()', N'find()', N'search()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (741, 74, N'Pattern "[abc]" means?', N'Any character a, b, or c', N'The string "abc"', N'a, followed by b, then c', N'Any letter', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (742, 74, N'Pattern "[0-9]" means?', N'Any digit', N'Numbers 0 and 9', N'String "0-9"', N'Calculations', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (743, 74, N'Pattern "w3schools" case-insensitive?', N'Pattern.CASE_INSENSITIVE', N'Pattern.NO_CASE', N'Pattern.IGNORE', N'Regex.Case', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (744, 74, N'Method to find the next match?', N'next()', N'find()', N'search()', N'match()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (745, 74, N'Pattern "^" means?', N'End of line', N'Start of line', N'Any character', N'Escape', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (746, 75, N'What allows programs to do multiple things at once?', N'Loops', N'Threads', N'Classes', N'Methods', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (747, 75, N'Which class is used to create a thread?', N'System', N'Thread', N'Run', N'Process', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (748, 75, N'Which interface can be implemented to create a thread?', N'Runnable', N'Threadable', N'Executable', N'Startable', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (749, 75, N'Which method contains the code for the thread?', N'start()', N'run()', N'init()', N'main()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (750, 75, N'How do you start a thread?', N'run()', N'start()', N'go()', N'execute()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (751, 75, N'What happens if you call run() directly?', N'Starts new thread', N'Runs in current thread (no concurrency)', N'Error', N'Nothing', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (752, 75, N'Can a thread be paused?', N'Yes, sleep()', N'No', N'Only stopped', N'Only killed', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (753, 75, N'Which method checks if thread is alive?', N'isAlive()', N'checkAlive()', N'status()', N'running()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (754, 75, N'Why use threads?', N'Efficiency / Concurrency', N'To make code smaller', N'To save disk space', N'Required for Java', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (755, 75, N'Concurrency problem when threads access same variable?', N'Deadlock', N'Race Condition', N'Thread Safe', N'None', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (756, 76, N'Who created Python?', N'Guido van Rossum', N'Dennis Ritchie', N'James Gosling', N'Bjarne Stroustrup', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (757, 76, N'When was Python released?', N'1980', N'1991', N'1995', N'2000', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (758, 76, N'Python is used for:', N'Web Development', N'Data Science', N'System Scripting', N'All of the above', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (759, 76, N'What is a key feature of Python syntax?', N'Uses braces {}', N'Uses indentation', N'Uses semicolons ;', N'Uses tags <>', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (760, 76, N'Is Python interpreted or compiled?', N'Compiled', N'Interpreted', N'Both', N'Neither', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (761, 76, N'What is the latest major version of Python?', N'Python 2', N'Python 3', N'Python 4', N'Python 5', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (762, 76, N'Which OS supports Python?', N'Windows', N'Mac', N'Linux', N'All of them', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (763, 76, N'Is Python open source?', N'Yes', N'No', N'Partially', N'Only for students', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (764, 76, N'Python relies on:', N'Complexity', N'Readability', N'Speed only', N'Binary code', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (765, 76, N'Can Python connect to database systems?', N'Yes', N'No', N'Only SQL Server', N'Only MySQL', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (766, 77, N'How do you print "Hello World" in Python?', N'echo "Hello World"', N'p("Hello World")', N'print("Hello World")', N'Console.WriteLine("Hello World")', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (767, 77, N'What indicates a code block in Python?', N'Brackets {}', N'Indentation', N'Parentheses ()', N'Semicolons ;', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (768, 77, N'What is the correct file extension for Python files?', N'.pt', N'.pyt', N'.py', N'.python', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (769, 77, N'How do you create a variable named x equal to 5?', N'x = 5', N'int x = 5', N'dim x = 5', N'var x = 5', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (770, 77, N'If you skip indentation in a block, what happens?', N'It runs fine', N'It warns you', N'Syntax Error', N'It fixes itself', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (771, 77, N'How many spaces are typically used for indentation?', N'1', N'2', N'4', N'8', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (772, 77, N'Is Python case sensitive?', N'Yes', N'No', N'Only for keywords', N'Only for strings', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (773, 77, N'Which character ends a Python statement?', N';', N'.', N':', N'None (New line)', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (774, 77, N'Can you use single quotes for strings?', N'Yes', N'No', N'Only for chars', N'Only in Python 2', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (775, 77, N'What happens if you mix spaces and tabs for indentation?', N'It works', N'IndentationError', N'It ignores tabs', N'It converts tabs', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (776, 78, N'How do you insert a single-line comment in Python?', N'//', N'#', N'/*', N'--', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (777, 78, N'Can a comment be placed at the end of a line?', N'Yes', N'No', N'Only if line is empty', N'Only in functions', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (778, 78, N'Does Python have a specific syntax for multi-line comments?', N'Yes, /* */', N'Yes, <!-- -->', N'No, use # on each line or triple quotes', N'Yes, """ """ only', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (779, 78, N'What happens to code inside a comment?', N'Executed', N'Ignored', N'Compiled', N'Printed', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (780, 78, N'Triple quotes """ are often used for:', N'Multi-line comments / Docstrings', N'Single line comments', N'Variables', N'Loops', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (781, 78, N'Is "# This is a comment" valid?', N'Yes', N'No', N'Only at start of file', N'Only at end of file', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (782, 78, N'Why use comments?', N'To make code run faster', N'To explain code', N'To hide errors', N'Required by Python', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (783, 78, N'Can comments prevent code execution?', N'Yes (Comment out code)', N'No', N'Only print statements', N'Only loops', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (784, 78, N'Which shortcut often toggles comments in IDEs?', N'Ctrl + /', N'Ctrl + C', N'Alt + F4', N'Shift + Enter', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (785, 78, N'Is `//` a valid comment in Python?', N'Yes', N'No', N'Only in Python 3', N'Only in scripts', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (786, 79, N'How do you create a variable?', N'Assign a value to it', N'Use "var" keyword', N'Use "new" keyword', N'Declare type first', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (787, 79, N'Do you need to declare the type of a variable?', N'Yes', N'No', N'Only for numbers', N'Only for strings', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (788, 79, N'Can a variable name start with a number?', N'Yes', N'No', N'Only if underscored', N'Only if integer', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (789, 79, N'Which is a valid variable name?', N'my-var', N'my var', N'_my_var', N'2myvar', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (790, 79, N'How do you assign values to multiple variables in one line?', N'x, y = 1, 2', N'x = 1, y = 2', N'x = 1; y = 2', N'x 1 y 2', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (791, 79, N'Can you change the type of a variable after setting it?', N'Yes', N'No', N'Only to string', N'Only to int', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (792, 79, N'What is the output of: x = 5; y = "John"; print(x + y)?', N'5John', N'John5', N'Error (TypeError)', N'NaN', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (793, 79, N'Which keyword outputs a variable?', N'echo', N'print', N'console', N'write', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (794, 79, N'What is a global variable?', N'Created outside a function', N'Created inside a function', N'Created in a loop', N'Created in a class', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (795, 79, N'How do you create a global variable inside a function?', N'global keyword', N'static keyword', N'public keyword', N'extern keyword', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (796, 80, N'Which function returns the data type of a variable?', N'type()', N'typeof()', N'gettype()', N'dataType()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (797, 80, N'Which is NOT a standard Python data type?', N'int', N'str', N'char', N'list', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (798, 80, N'What type is x = 5?', N'float', N'int', N'str', N'complex', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (799, 80, N'What type is x = 20.5?', N'int', N'complex', N'float', N'double', N'C')
GO
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (800, 80, N'What type is x = ["apple", "banana"]?', N'tuple', N'set', N'list', N'dict', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (801, 80, N'What type is x = ("apple", "banana")?', N'tuple', N'list', N'set', N'dict', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (802, 80, N'What type is x = {"name" : "John", "age" : 36}?', N'list', N'dict', N'set', N'tuple', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (803, 80, N'What type is x = True?', N'bool', N'boolean', N'int', N'str', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (804, 80, N'What type is x = range(6)?', N'list', N'range', N'int', N'loop', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (805, 80, N'Can you set a specific data type?', N'No', N'Yes, e.g. x = str("Hello")', N'Only for numbers', N'Only for lists', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (806, 81, N'Which are the three numeric types in Python?', N'int, float, complex', N'int, double, decimal', N'short, int, long', N'num, float, big', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (807, 81, N'What is an int?', N'Decimal number', N'Whole number', N'Complex number', N'Text string', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (808, 81, N'What is a float?', N'Whole number', N'Number with decimal', N'Text', N'Boolean', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (809, 81, N'How do you define a complex number?', N'x = 1j', N'x = 1c', N'x = 1i', N'x = complex(1)', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (810, 81, N'Can you convert float to int?', N'Yes', N'No', N'Only if 0.0', N'Only if positive', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (811, 81, N'Is there a limit to the size of an int?', N'Yes, 32 bit', N'Yes, 64 bit', N'No (only memory limit)', N'Yes, 255', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (812, 81, N'What does 1.10e4 mean?', N'Scientific notation', N'Error', N'String', N'Complex', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (813, 81, N'Which module creates random numbers?', N'Math', N'Random', N'random', N'Rnd', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (814, 81, N'How to verify if an object is an integer?', N'isinstance(x, int)', N'type(x) == int', N'Both A and B', N'check(x, int)', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (815, 81, N'Does Python have a "double" type?', N'Yes', N'No, use float', N'Yes, for big numbers', N'Yes, for currency', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (816, 82, N'How do you cast an integer to a float?', N'float(5)', N'int(5.0)', N'cast(5, float)', N'5.to_float()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (817, 82, N'What is int(2.8)?', N'2.8', N'3', N'2', N'Error', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (818, 82, N'What is str(2)?', N'2', N'"2"', N'2.0', N'Error', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (819, 82, N'Can you cast a string "s1" to an integer?', N'Yes', N'No, causes error', N'Returns 0', N'Returns null', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (820, 82, N'Why use casting?', N'To specify a type on a variable', N'To delete a variable', N'To print text', N'To loop', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (821, 82, N'What is float("3")?', N'"3"', N'3', N'3.0', N'Error', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (822, 82, N'What is int("3")?', N'3', N'3.0', N'"3"', N'Error', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (823, 82, N'Casting is done using:', N'Keywords', N'Constructor functions', N'Operators', N'Brackets', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (824, 82, N'What is str(3.0)?', N'3', N'"3.0"', N'"3"', N'3.0', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (825, 82, N'Can you cast complex numbers?', N'Yes', N'No, usually not to int/float directly', N'Yes to string only', N'Yes to list', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (826, 83, N'How are strings defined in Python?', N'Single quotes', N'Double quotes', N'Both A and B', N'Ticks', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (827, 83, N'How do you assign a multiline string?', N'Three quotes """', N'One quote ''', N'Backslash \', N'Parentheses ()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (828, 83, N'Are strings arrays of bytes representing unicode characters?', N'Yes', N'No', N'Only ASCII', N'Only UTF-8', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (829, 83, N'How do you get the character at position 1?', N'str(1)', N'str[1]', N'str.get(1)', N'str.charAt(1)', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (830, 83, N'How do you loop through a string?', N'for x in "banana":', N'loop "banana":', N'while "banana":', N'foreach x "banana":', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (831, 83, N'Which function returns the length of a string?', N'len()', N'length()', N'size()', N'count()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (832, 83, N'How to check if "free" is present in a string?', N'"free" in txt', N'txt.has("free")', N'txt.contains("free")', N'check("free")', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (833, 83, N'How to check if "free" is NOT present?', N'"free" not in txt', N'!"free" in txt', N'txt.not("free")', N'not "free"', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (834, 83, N'Can you slice strings?', N'Yes', N'No', N'Only removing chars', N'Only sorting', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (835, 83, N'Syntax to slice from start to position 5?', N'str[0:5]', N'str[:5]', N'str(5)', N'Both A and B', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (836, 84, N'What are the two boolean values?', N'True, False', N'true, false', N'1, 0', N'Yes, No', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (837, 84, N'What does 10 > 9 return?', N'True', N'False', N'10', N'9', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (838, 84, N'What does 10 == 9 return?', N'True', N'False', N'Error', N'None', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (839, 84, N'How do you evaluate if a variable is True?', N'bool(x)', N'eval(x)', N'isTrue(x)', N'check(x)', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (840, 84, N'Most values are True if they have:', N'Content', N'No content', N'Zero', N'Null', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (841, 84, N'Which value evaluates to False?', N'Empty string ""', N'0', N'None', N'All of the above', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (842, 84, N'Is bool("abc") True or False?', N'True', N'False', N'Error', N'None', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (843, 84, N'Is bool(0) True or False?', N'True', N'False', N'Error', N'None', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (844, 84, N'Can functions return a boolean?', N'Yes', N'No', N'Only built-in ones', N'Only if void', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (845, 84, N'Which built-in function checks data type and returns boolean?', N'isinstance()', N'istype()', N'checktype()', N'typeof()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (846, 85, N'Which operator is used for exponentiation?', N'^', N'**', N'^^', N'pow', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (847, 85, N'Which operator is used for floor division?', N'/', N'//', N'%', N'div', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (848, 85, N'What is 5 % 2?', N'2', N'2.5', N'1', N'0', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (849, 85, N'Which operator means "Equal to"?', N'=', N'==', N'===', N'is', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (850, 85, N'Which operator means "Not equal"?', N'<>', N'!=', N'~=', N'not =', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (851, 85, N'Which is a logical operator?', N'and', N'or', N'not', N'All of the above', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (852, 85, N'What does "is" operator check?', N'Values are equal', N'Objects are same object in memory', N'Types are equal', N'Sizes are equal', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (853, 85, N'What does "in" operator check?', N'Sequence membership', N'Equality', N'Type', N'Size', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (854, 85, N'What is x += 3 equivalent to?', N'x = 3', N'x = x + 3', N'x + 3 = x', N'3 = x', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (855, 85, N'Bitwise AND operator?', N'&&', N'&', N'and', N'+', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (856, 86, N'Which syntax creates a list?', N'{1, 2, 3}', N'[1, 2, 3]', N'(1, 2, 3)', N'<1, 2, 3>', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (857, 86, N'Are Python lists mutable (changeable)?', N'Yes', N'No', N'Only if integers', N'Only if empty', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (858, 86, N'How do you access the second item in `mylist`?', N'mylist[1]', N'mylist(2)', N'mylist[2]', N'mylist.get(2)', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (859, 86, N'Which method adds an item to the end of a list?', N'push()', N'add()', N'append()', N'insert()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (860, 86, N'How do you remove the last item from a list?', N'remove()', N'pop()', N'delete()', N'minus()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (861, 86, N'Can lists contain items of different data types?', N'Yes', N'No', N'Only Strings and Ints', N'Only if declared as object', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (862, 86, N'What is the result of `len(["a", "b", "c"])`?', N'2', N'3', N'4', N'Error', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (863, 86, N'How do you insert an item at a specific index?', N'add(index, item)', N'insert(item, index)', N'insert(index, item)', N'append(index, item)', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (864, 86, N'How do you access the last item using negative indexing?', N'list[-1]', N'list[0]', N'list[last]', N'list[-0]', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (865, 86, N'Which operator checks if an item exists in a list?', N'exists', N'has', N'in', N'contains', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (866, 87, N'How do you create a tuple?', N'{}', N'[]', N'()', N'<>', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (867, 87, N'Are tuples mutable?', N'Yes', N'No (Immutable)', N'Only if empty', N'Only if converting to list', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (868, 87, N'How do you create a tuple with one item?', N'(item)', N'(item,)', N'[item]', N'{item}', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (869, 87, N'Can you access tuple items by index?', N'Yes', N'No', N'Only first item', N'Only last item', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (870, 87, N'How do you find the number of items in a tuple?', N'count()', N'size()', N'len()', N'length', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (871, 87, N'Can a tuple contain duplicate values?', N'Yes', N'No', N'Only if different types', N'Only if numbers', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (872, 87, N'Can you add items to an existing tuple?', N'Yes, append()', N'Yes, add()', N'No, tuples are unchangeable', N'Yes, push()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (873, 87, N'What is "Unpacking" a tuple?', N'Deleting it', N'Extracting values into variables', N'Converting to list', N'Printing it', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (874, 87, N'Which method finds the index of a value?', N'find()', N'search()', N'index()', N'locate()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (875, 87, N'How to delete a tuple completely?', N'delete myTuple', N'del myTuple', N'remove myTuple', N'clear myTuple', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (876, 88, N'How do you create a set?', N'[]', N'()', N'{}', N'<>', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (877, 88, N'Are sets ordered?', N'Yes', N'No (Unordered)', N'Only if numbers', N'Only if strings', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (878, 88, N'Can sets contain duplicate values?', N'Yes', N'No', N'Only if different types', N'Only if None', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (879, 88, N'How do you access items in a set?', N'By index', N'By key', N'You cannot access by index (use loop)', N'By value', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (880, 88, N'Which method adds an item to a set?', N'append()', N'insert()', N'push()', N'add()', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (881, 88, N'Which method removes a specific item?', N'delete()', N'remove()', N'pop()', N'clear()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (882, 88, N'What happens if you try to remove an item that does not exist using remove()?', N'Nothing', N'Returns False', N'Raises an Error', N'Adds it', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (883, 88, N'What does the `discard()` method do?', N'Removes item, no error if missing', N'Removes item, raises error if missing', N'Removes all items', N'Deletes the set', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (884, 88, N'How do you join two sets?', N'join()', N'append()', N'union()', N'combine()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (885, 88, N'Can you change items in a set?', N'Yes', N'No, but you can add/remove', N'Only strings', N'Only integers', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (886, 89, N'What is a dictionary?', N'Ordered list of values', N'Key-Value pairs', N'Unordered set', N'Array of arrays', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (887, 89, N'How do you create a dictionary?', N'[]', N'()', N'{}', N'<>', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (888, 89, N'How do you access the value of a key "model"?', N'dict[0]', N'dict.model', N'dict["model"]', N'dict(model)', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (889, 89, N'Which method returns all keys?', N'get_keys()', N'keys()', N'all_keys()', N'list_keys()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (890, 89, N'Which method returns all values?', N'get_values()', N'values()', N'all_values()', N'list_values()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (891, 89, N'How do you change a value?', N'dict["key"] = new_value', N'dict.add("key", new_value)', N'dict.change("key", new_value)', N'dict.set("key", new_value)', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (892, 89, N'Can dictionary keys be duplicates?', N'Yes', N'No (Duplicates overwrite)', N'Only if None', N'Only if different types', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (893, 89, N'Which method removes the item with the specified key?', N'delete()', N'remove()', N'pop()', N'clear()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (894, 89, N'What method removes the last inserted item?', N'poplast()', N'popitem()', N'removeLast()', N'deleteLast()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (895, 89, N'Can you use a loop to iterate through a dictionary?', N'Yes', N'No', N'Only for keys', N'Only for values', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (896, 90, N'Which keyword checks a condition?', N'check', N'test', N'if', N'when', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (897, 90, N'Which keyword handles "if previous conditions were not true, then try this"?', N'else if', N'elseif', N'elif', N'then if', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (898, 90, N'Which keyword catches anything not caught by preceding conditions?', N'finally', N'else', N'otherwise', N'default', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (899, 90, N'What is the correct syntax for if statement?', N'if x > y:', N'if (x > y)', N'if x > y then', N'if {x > y}', N'A')
GO
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (900, 90, N'What signifies the code block inside an if statement?', N'Brackets {}', N'Parentheses ()', N'Indentation', N'Keywords', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (901, 90, N'Short hand if ... else syntax?', N'print("A") if a > b else print("B")', N'if a > b ? print("A") : print("B")', N'print("A") when a > b else "B"', N'a > b ? "A" : "B"', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (902, 90, N'Logical operator for "AND"?', N'&&', N'&', N'and', N'plus', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (903, 90, N'Logical operator for "OR"?', N'||', N'|', N'or', N'either', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (904, 90, N'What is the "pass" statement used for?', N'To skip an iteration', N'To avoid errors in empty loops/if', N'To return a value', N'To break execution', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (905, 90, N'Can you have nested if statements?', N'Yes', N'No', N'Only 2 levels', N'Only inside functions', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (906, 91, N'A while loop runs as long as:', N'The program is running', N'A condition is true', N'A condition is false', N'The user types input', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (907, 91, N'Syntax for while loop?', N'while x < 6:', N'while (x < 6)', N'while x < 6 then', N'loop x < 6', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (908, 91, N'What statement stops the loop?', N'stop', N'exit', N'break', N'end', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (909, 91, N'What statement skips the current iteration?', N'next', N'skip', N'continue', N'jump', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (910, 91, N'What happens if you forget to increment the counter variable?', N'Syntax Error', N'Loop runs once', N'Infinite Loop', N'Variable becomes null', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (911, 91, N'Can you use an "else" block with a while loop?', N'Yes, runs when condition is false', N'No', N'Only if break is used', N'Only in Python 2', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (912, 91, N'i = 1; while i < 6: print(i); i += 1. Output?', N'1 2 3 4 5 6', N'1 2 3 4 5', N'0 1 2 3 4 5', N'1 3 5', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (913, 91, N'Is indentation required for the while loop body?', N'Yes', N'No', N'Optional', N'Only for first line', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (914, 91, N'Can you nest while loops?', N'Yes', N'No', N'Only 2 levels', N'Only if variables differ', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (915, 91, N'Does "do-while" exist in Python?', N'Yes', N'No', N'Called repeat-until', N'Called loop-do', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (916, 92, N'A for loop is used for:', N'Iterating over a sequence', N'Checking conditions', N'Defining functions', N'Handling errors', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (917, 92, N'Syntax to loop through a list "fruits"?', N'for x in fruits:', N'for x inside fruits', N'loop x in fruits', N'foreach x in fruits', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (918, 92, N'What does `range(6)` return?', N'0, 1, 2, 3, 4, 5, 6', N'1, 2, 3, 4, 5, 6', N'0, 1, 2, 3, 4, 5', N'1 to 6', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (919, 92, N'What does `range(2, 6)` return?', N'2, 3, 4, 5, 6', N'2, 3, 4, 5', N'3, 4, 5', N'2, 4, 6', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (920, 92, N'How to increment by 3 in range?', N'range(0, 30, 3)', N'range(0, 30, +3)', N'range(3, 0, 30)', N'range(3)', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (921, 92, N'Can you use "else" in a for loop?', N'No', N'Yes, runs when loop finishes', N'Yes, runs if break is hit', N'Only if list is empty', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (922, 92, N'What happens if you use `break` in a loop with `else`?', N'Else block runs', N'Else block is NOT executed', N'Error', N'Loop restarts', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (923, 92, N'Can you loop through a string?', N'Yes', N'No', N'Only if converted to list', N'Only with range()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (924, 92, N'What does `continue` do in a for loop?', N'Stops the loop', N'Skips remaining code in iteration', N'Restarts the program', N'Exits the function', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (925, 92, N'Nested loops are:', N'Loops inside loops', N'Loops next to loops', N'Illegal in Python', N'Only for matrices', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (926, 93, N'Which keyword defines a function?', N'func', N'define', N'def', N'function', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (927, 93, N'How do you call a function named "my_function"?', N'my_function', N'call my_function', N'my_function()', N'run my_function', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (928, 93, N'Information passed to functions is called:', N'Arguments', N'Parameters', N'Data', N'Variables', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (929, 93, N'How to specify unknown number of arguments?', N'*args', N'**args', N'args[]', N'...args', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (930, 93, N'How to specify unknown keyword arguments?', N'*kwargs', N'**kwargs', N'kwargs{}', N'##kwargs', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (931, 93, N'Can you assign a default value to a parameter?', N'Yes (param = value)', N'No', N'Only strings', N'Only None', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (932, 93, N'How do you return a value from a function?', N'get value', N'return value', N'send value', N'output value', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (933, 93, N'What does the "pass" statement do?', N'Returns true', N'Does nothing (placeholder)', N'Skips function', N'Calls parent', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (934, 93, N'Can a function call itself?', N'Yes (Recursion)', N'No', N'Only if void', N'Only 10 times', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (935, 93, N'Positional-only arguments are specified using:', N'/', N'*', N'\', N'-', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (936, 94, N'What is a lambda function?', N'A named function', N'A small anonymous function', N'A loop', N'A class', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (937, 94, N'Syntax for lambda?', N'lambda arguments : expression', N'def lambda(args)', N'lambda expression -> args', N'function lambda', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (938, 94, N'Can lambda have multiple arguments?', N'Yes', N'No', N'Only one', N'Only strings', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (939, 94, N'Can lambda have multiple expressions?', N'Yes', N'No (Only one)', N'Up to 3', N'If separated by commas', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (940, 94, N'x = lambda a : a + 10. What is x(5)?', N'5', N'10', N'15', N'Error', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (941, 94, N'Why use lambda functions?', N'To write complex logic', N'As anonymous function inside another function', N'To replace class', N'To import modules', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (942, 94, N'x = lambda a, b : a * b. What is x(5, 6)?', N'11', N'30', N'56', N'Error', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (943, 94, N'Is "def" required for lambda?', N'Yes', N'No', N'Optional', N'Only for return', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (944, 94, N'Can lambda return a value?', N'Yes (Implicitly)', N'No', N'Only with return keyword', N'Only print', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (945, 94, N'What type is a lambda?', N'int', N'function', N'string', N'object', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (946, 95, N'Does Python have built-in support for Arrays?', N'Yes', N'No, use Lists instead', N'Yes, identical to C', N'Only fixed size', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (947, 95, N'Which element refers to the first item?', N'0', N'1', N'-1', N'Start', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (948, 95, N'How do you calculate the length of an array (list)?', N'length()', N'len()', N'count()', N'size()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (949, 95, N'How do you loop through array elements?', N'for in', N'foreach', N'while', N'All of the above', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (950, 95, N'Method to add an element to an array (list)?', N'push()', N'add()', N'append()', N'insert()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (951, 95, N'Method to remove the first element with specific value?', N'delete()', N'remove()', N'pop()', N'clear()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (952, 95, N'Method to remove element at specific position?', N'pop()', N'remove()', N'delete()', N'cut()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (953, 95, N'How to sort an array?', N'sort()', N'order()', N'arrange()', N'filter()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (954, 95, N'How to reverse the order?', N'reverse()', N'back()', N'flip()', N'invert()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (955, 95, N'To make a copy of a list/array?', N'copy()', N'clone()', N'duplicate()', N'new()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (956, 96, N'What is a class in Python?', N'An object', N'A function', N'A blueprint for creating objects', N'A variable', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (957, 96, N'How do you create a class named "MyClass"?', N'class MyClass:', N'create class MyClass:', N'class MyClass()', N'def MyClass:', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (958, 96, N'How do you create an object of "MyClass"?', N'p1 = new MyClass()', N'p1 = MyClass()', N'p1 = create MyClass()', N'MyClass p1;', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (959, 96, N'Which function is executed when the class is initiated?', N'__init__()', N'init()', N'start()', N'main()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (960, 96, N'What does the "self" parameter represent?', N'The class itself', N'The current instance of the class', N'A static variable', N'The parent class', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (961, 96, N'Can you modify object properties?', N'Yes', N'No', N'Only inside class', N'Only if public', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (962, 96, N'How do you delete an object property?', N'remove p1.age', N'del p1.age', N'delete p1.age', N'p1.age.delete()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (963, 96, N'How do you delete an object completely?', N'delete p1', N'del p1', N'remove p1', N'clear p1', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (964, 96, N'Can a class be empty?', N'No', N'Yes, using "pass"', N'Yes, using "null"', N'Only if abstract', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (965, 96, N'Is "self" a reserved keyword?', N'Yes', N'No, it is just a convention', N'Only in Python 3', N'Only in constructors', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (966, 97, N'What is inheritance?', N'Defining a class that inherits from another class', N'Creating a copy of a class', N'Hiding data', N'Linking files', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (967, 97, N'Which class is the "Parent"?', N'The class being inherited from', N'The class that inherits', N'The main class', N'The static class', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (968, 97, N'Which class is the "Child"?', N'The base class', N'The class that inherits from another class', N'The super class', N'The private class', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (969, 97, N'Syntax to inherit from "Person"?', N'class Student(Person):', N'class Student extends Person:', N'class Student inherits Person:', N'class Student : Person', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (970, 97, N'Does the child class inherit methods from parent?', N'Yes', N'No', N'Only public methods', N'Only __init__', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (971, 97, N'How do you add the `__init__()` function to child class?', N'def __init__(self):', N'super().__init__()', N'Both A and calling super logic', N'You cannot', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (972, 97, N'What function calls the parent class?', N'parent()', N'super()', N'base()', N'top()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (973, 97, N'If you add `__init__` to child, what happens to parent `__init__`?', N'It is deleted', N'It is overridden (no longer called automatically)', N'It runs automatically', N'Error', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (974, 97, N'Can you add new properties to the child class?', N'Yes', N'No', N'Only if static', N'Only methods', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (975, 97, N'Can a child class override parent methods?', N'Yes', N'No', N'Only if abstract', N'Only if private', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (976, 98, N'What is an Iterator?', N'An object that contains a countable number of values', N'A loop', N'A function', N'A list', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (977, 98, N'Which two methods define an iterator?', N'__init__, __str__', N'__iter__, __next__', N'next, hasNext', N'start, end', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (978, 98, N'How do you get an iterator from a tuple?', N'getIter()', N'iter()', N'iterator()', N'loop()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (979, 98, N'Which method returns the next item?', N'next()', N'getNext()', N'move()', N'step()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (980, 98, N'Are lists iterable?', N'Yes', N'No', N'Only if strings', N'Only if sorted', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (981, 98, N'Are strings iterable?', N'Yes', N'No', N'Only ASCII', N'Only Unicode', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (982, 98, N'What happens if you call next() at the end?', N'Returns None', N'StopIteration error', N'Loops to start', N'Returns 0', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (983, 98, N'How to loop through an iterator?', N'for loop', N'while loop', N'Both', N'None', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (984, 98, N'Can you create your own iterator?', N'Yes, by implementing __iter__ and __next__', N'No', N'Only in C++', N'Only for numbers', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (985, 98, N'What stops the iteration in a for loop?', N'Break statement', N'StopIteration exception (handled internally)', N'User input', N'Memory full', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (986, 99, N'What is scope?', N'A variable type', N'The region where a variable is available', N'A function', N'A module', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (987, 99, N'A variable created inside a function is:', N'Global', N'Local', N'Static', N'Universal', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (988, 99, N'Can a local variable be used outside the function?', N'Yes', N'No', N'Only if printed', N'Only if returned', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (989, 99, N'A variable created in the main body is:', N'Global', N'Local', N'Private', N'Internal', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (990, 99, N'Can a global variable be used inside a function?', N'Yes', N'No', N'Only if passed', N'Only if int', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (991, 99, N'How do you create a global variable inside a function?', N'global x', N'var x', N'public x', N'extern x', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (992, 99, N'What is "Function Inside Function" scope?', N'Inner function can access outer variables', N'Outer can access inner', N'No access', N'Global only', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (993, 99, N'If local and global variables have same name, which is used inside function?', N'Global', N'Local', N'Error', N'Both', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (994, 99, N'Does Python have block scope (like if-statements)?', N'Yes', N'No (variables in if/for are visible in function)', N'Only in classes', N'Only in Python 2', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (995, 99, N'Where is the "global" keyword used?', N'Inside a function to modify a global variable', N'Outside a function', N'In class definition', N'In import', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (996, 100, N'What is a module?', N'A code library', N'A variable', N'A loop', N'A comment', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (997, 100, N'How do you save a module?', N'Save as .mod', N'Save as .py', N'Save as .txt', N'Save as .lib', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (998, 100, N'How do you use a module named "mymodule"?', N'using mymodule', N'include mymodule', N'import mymodule', N'require mymodule', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (999, 100, N'How do you access a function "greeting" in "mymodule"?', N'greeting()', N'mymodule.greeting()', N'mymodule->greeting()', N'greeting(mymodule)', N'B')
GO
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1000, 100, N'Can you rename a module when importing?', N'No', N'Yes, using "as"', N'Yes, using "rename"', N'Only if system module', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1001, 100, N'What is a built-in module?', N'A module you created', N'A module included with Python', N'A downloaded module', N'A deleted module', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1002, 100, N'Which function lists all names in a module?', N'list()', N'dir()', N'names()', N'show()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1003, 100, N'Can you import only specific parts of a module?', N'Yes, using "from ... import ..."', N'No', N'Only functions', N'Only dictionaries', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1004, 100, N'When using "from", do you use the module name to access elements?', N'Yes', N'No', N'Sometimes', N'Only for variables', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1005, 100, N'What is the platform module?', N'sys', N'platform', N'os', N'win', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1006, 101, N'Is "date" a built-in data type in Python?', N'Yes', N'No, need to import datetime', N'Only in Python 2', N'Yes, float', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1007, 101, N'Which module works with dates?', N'date', N'time', N'datetime', N'calendar', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1008, 101, N'How to get current date/time?', N'datetime.now()', N'datetime.datetime.now()', N'date.today()', N'time.now()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1009, 101, N'What does the date object contain?', N'Year, Month, Day, Hour, Minute, Second, Microsecond', N'Only Year', N'Only Time', N'Only Day', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1010, 101, N'How do you create a date object?', N'datetime.datetime(2020, 5, 17)', N'new Date(2020, 5, 17)', N'Date(2020)', N'create(2020)', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1011, 101, N'Which method formats date objects into strings?', N'format()', N'strftime()', N'toString()', N'convert()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1012, 101, N'What does "%Y" represent in strftime?', N'Short year (23)', N'Full year (2023)', N'Month', N'Day', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1013, 101, N'What does "%B" represent?', N'Month name (Full)', N'Month name (Short)', N'Month number', N'Day name', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1014, 101, N'What does "%A" represent?', N'Weekday (Full)', N'Weekday (Short)', N'AM/PM', N'Area', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1015, 101, N'Does datetime support timezones?', N'No', N'Yes, but naive by default', N'Only UTC', N'Only local', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1016, 102, N'Which built-in function finds the lowest value?', N'low()', N'bottom()', N'min()', N'minimum()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1017, 102, N'Which built-in function finds the highest value?', N'high()', N'top()', N'max()', N'maximum()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1018, 102, N'Which built-in function returns absolute (positive) value?', N'pos()', N'absolute()', N'abs()', N'val()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1019, 102, N'Which function returns x to the power of y?', N'power(x,y)', N'pow(x,y)', N'exp(x,y)', N'x^y', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1020, 102, N'Which module provides advanced math functions?', N'calc', N'math', N'algebra', N'numbers', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1021, 102, N'How to find square root?', N'math.sq()', N'math.root()', N'math.sqrt()', N'sqrt()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1022, 102, N'How to round upwards?', N'math.up()', N'math.ceil()', N'math.floor()', N'math.round()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1023, 102, N'How to round downwards?', N'math.down()', N'math.floor()', N'math.ceil()', N'math.low()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1024, 102, N'What is the value of math.pi?', N'3.14159...', N'3.14', N'22/7', N'Unknown', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1025, 102, N'Does min() and max() work on lists?', N'Yes', N'No', N'Only tuple', N'Only set', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1026, 103, N'What is JSON?', N'Java Standard Object Name', N'JavaScript Object Notation', N'Just Some Object Notes', N'Python Dictionary', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1027, 103, N'Which package works with JSON?', N'json', N'pyson', N'jscript', N'data', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1028, 103, N'Method to parse JSON string to Python?', N'json.parse()', N'json.load()', N'json.loads()', N'json.read()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1029, 103, N'What does json.loads() return?', N'String', N'Python Dictionary', N'List', N'File', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1030, 103, N'Method to convert Python to JSON string?', N'json.convert()', N'json.dump()', N'json.dumps()', N'json.write()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1031, 103, N'Can you convert a Python list to JSON?', N'Yes, becomes JSON array', N'No', N'Only dicts', N'Only tuples', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1032, 103, N'Can you convert a Python Tuple to JSON?', N'Yes, becomes JSON array', N'No', N'Becomes JSON object', N'Error', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1033, 103, N'Can you convert True/False to JSON?', N'Yes, becomes true/false', N'No', N'Becomes 1/0', N'Becomes "True"/"False"', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1034, 103, N'How to format the JSON result (pretty print)?', N'Use indent parameter', N'Use format parameter', N'Use pretty parameter', N'Use style parameter', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1035, 103, N'How to sort keys in the result?', N'sort=True', N'keys=True', N'sort_keys=True', N'order=True', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1036, 104, N'What is a RegEx?', N'Regular Extension', N'Regular Expression', N'Regional Extra', N'Register Exit', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1037, 104, N'Which module is used for RegEx?', N'reg', N'regex', N're', N'rx', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1038, 104, N'Which function returns a Match object if there is a match?', N're.find()', N're.search()', N're.look()', N're.scan()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1039, 104, N'Which function returns a list of all matches?', N're.findall()', N're.searchall()', N're.list()', N're.matchall()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1040, 104, N'Which function splits string at matches?', N're.cut()', N're.split()', N're.divide()', N're.break()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1041, 104, N'Which function replaces matches?', N're.replace()', N're.sub()', N're.change()', N're.swap()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1042, 104, N'Metacharacter "^" starts with?', N'Starts with', N'Ends with', N'Contains', N'Excludes', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1043, 104, N'Metacharacter "$" ends with?', N'Starts with', N'Ends with', N'Contains', N'Currency', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1044, 104, N'Special Sequence "\d" matches?', N'Digits 0-9', N'Letters', N'Whitespace', N'Special chars', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1045, 104, N'Set "[a-z]" matches?', N'Alphabet a to z', N'Digits', N'Spaces', N'Symbols', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1046, 105, N'What is PIP?', N'Python Image Processor', N'Package Manager for Python', N'Python Interface Protocol', N'Python Input Parser', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1047, 105, N'What is a package?', N'Contains all files for a module', N'A single variable', N'A loop', N'A database', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1048, 105, N'How do you install a package named "camelcase"?', N'install camelcase', N'pip install camelcase', N'python get camelcase', N'get camelcase', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1049, 105, N'How do you uninstall a package?', N'pip remove', N'pip delete', N'pip uninstall', N'pip erase', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1050, 105, N'How do you list installed packages?', N'pip show', N'pip all', N'pip list', N'pip installed', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1051, 105, N'Where are packages usually downloaded from?', N'GitHub', N'PyPI (Python Package Index)', N'Python.org', N'Google', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1052, 105, N'Do you need to import installed packages?', N'Yes', N'No', N'Only standard ones', N'Only large ones', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1053, 105, N'Is PIP included with modern Python?', N'Yes', N'No', N'Only Mac', N'Only Windows', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1054, 105, N'Command to check pip version?', N'pip --version', N'pip -v', N'pip check', N'pip info', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1055, 105, N'Can you use PIP in the Python shell?', N'Yes', N'No, use Command Line', N'Only IDLE', N'Only in scripts', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1056, 106, N'Which block lets you test a block of code for errors?', N'try', N'except', N'finally', N'catch', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1057, 106, N'Which block handles the error?', N'try', N'except', N'finally', N'throw', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1058, 106, N'Which block executes regardless of the result?', N'try', N'except', N'finally', N'else', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1059, 106, N'How do you raise an exception manually?', N'throw', N'raise', N'error', N'stop', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1060, 106, N'Can you have multiple except blocks?', N'Yes', N'No', N'Only 2', N'Only if nested', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1061, 106, N'What is the `else` keyword used for in try..except?', N'If no errors were raised', N'If an error occurred', N'Always runs', N'Never runs', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1062, 106, N'What error is raised if you divide by zero?', N'ValueError', N'ZeroDivisionError', N'TypeError', N'MathError', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1063, 106, N'Can you catch specific exceptions?', N'Yes, e.g. except NameError:', N'No, only generic', N'Only syntax errors', N'Only runtime errors', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1064, 106, N'Is `finally` block mandatory?', N'Yes', N'No', N'Only if try is used', N'Only if except is missing', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1065, 106, N'What keyword defines a custom exception class?', N'class', N'exception', N'def', N'error', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1066, 107, N'Which method is used for user input in Python 3.6+?', N'get()', N'input()', N'raw_input()', N'scan()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1067, 107, N'What data type does input() return?', N'int', N'str (String)', N'float', N'bool', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1068, 107, N'How do you prompt the user with a message?', N'input("Message")', N'print("Message")', N'get("Message")', N'scan("Message")', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1069, 107, N'In Python 2.7, which method was used for string input?', N'input()', N'raw_input()', N'get_input()', N'read()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1070, 107, N'How do you convert user input to an integer?', N'int(input())', N'input().toInt()', N'Integer(input())', N'parse(input())', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1071, 107, N'What happens if user enters text when you expect int?', N'Returns 0', N'ValueError', N'Returns null', N'Converts to ASCII', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1072, 107, N'Can input() read multiple lines at once?', N'Yes', N'No, stops at Enter', N'Only if configured', N'Yes, with loop', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1073, 107, N'Does input() automatically trim whitespace?', N'Yes', N'No', N'Only spaces', N'Only tabs', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1074, 107, N'How to read a float from user?', N'float(input())', N'input().float()', N'Double(input())', N'readFloat()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1075, 107, N'Is input() blocking (waits for user)?', N'Yes', N'No', N'Only in console', N'Only in IDE', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1076, 108, N'Which method formats specified values in a string?', N'format()', N'replace()', N'insert()', N'add()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1077, 108, N'What placeholder is used in format()?', N'[]', N'()', N'{}', N'<>', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1078, 108, N'txt = "Price: {:.2f}".format(49). Output?', N'Price: 49', N'Price: 49.00', N'Price: 49.2', N'Error', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1079, 108, N'Can you use index numbers in placeholders {0}?', N'Yes', N'No', N'Only for strings', N'Only for ints', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1080, 108, N'Can you use named indexes {price}?', N'Yes', N'No', N'Only in f-strings', N'Only in Python 2', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1081, 108, N'What is an f-string?', N'String starting with f', N'Function string', N'File string', N'Fast string', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1082, 108, N'Syntax for f-string variable insertion?', N'f"Hello {name}"', N'f"Hello (name)"', N'"Hello {name}"', N'"Hello " + name', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1083, 108, N'How to escape a curly bracket in f-strings?', N'\{', N'{{', N'\[', N'\\{', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1084, 108, N'Does format() modify the original string?', N'Yes', N'No, returns new string', N'Only if assigned', N'Error', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1085, 108, N'What does {:>} do in formatting?', N'Left aligns', N'Right aligns', N'Centers', N'Bold text', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1086, 109, N'Key function for working with files?', N'file()', N'open()', N'read()', N'load()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1087, 109, N'Which mode opens a file for reading?', N'"r"', N'"w"', N'"a"', N'"x"', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1088, 109, N'Which mode opens a file for appending?', N'"r"', N'"w"', N'"a"', N'"x"', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1089, 109, N'Which mode opens a file for writing (overwrites)?', N'"r"', N'"w"', N'"a"', N'"x"', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1090, 109, N'Which mode creates a file, error if exists?', N'"c"', N'"w"', N'"n"', N'"x"', N'D')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1091, 109, N'What is the default mode if omitted?', N'"r" (Read)', N'"w" (Write)', N'"a" (Append)', N'"x" (Create)', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1092, 109, N'Which mode handles binary images?', N'"b"', N'"t"', N'"i"', N'"p"', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1093, 109, N'Does "w" create the file if it does not exist?', N'Yes', N'No', N'Error', N'Only if forced', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1094, 109, N'What does "t" mode stand for?', N'Text (Default)', N'Time', N'Table', N'Type', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1095, 109, N'Do you need to import a module to use open()?', N'Yes, os', N'No, built-in', N'Yes, io', N'Yes, file', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1096, 110, N'Which method reads the content of the file?', N'get()', N'read()', N'load()', N'scan()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1097, 110, N'How do you read only the first 5 characters?', N'read(5)', N'read[5]', N'read.limit(5)', N'read(0,5)', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1098, 110, N'Which method reads one line?', N'readLine()', N'readline()', N'getLine()', N'nextLine()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1099, 110, N'How do you loop through a file line by line?', N'for x in f:', N'while f.hasLines():', N'f.loop()', N'foreach line in f', N'A')
GO
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1100, 110, N'Good practice after opening a file?', N'Leave it open', N'Close it using close()', N'Delete it', N'Rename it', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1101, 110, N'What happens if "r" file does not exist?', N'Creates it', N'Returns empty', N'FileNotFoundError', N'Warnings', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1102, 110, N'Can you read a closed file?', N'Yes', N'No, ValueError', N'Only metadata', N'Only name', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1103, 110, N'Method to return all lines as a list?', N'readList()', N'readlines()', N'getAll()', N'listLines()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1104, 110, N'What is "with open(...) as f:" used for?', N'Auto-closing the file', N'Renaming the file', N'Looping', N'Error handling only', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1105, 110, N'Does read() cursor move to the end?', N'Yes', N'No', N'Only if saved', N'Only if printed', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1106, 111, N'Which method writes text to a file?', N'print()', N'write()', N'save()', N'output()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1107, 111, N'If you open with "a", where is text added?', N'End of file', N'Start of file', N'Overwrites file', N'Randomly', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1108, 111, N'If you open with "w", what happens to existing content?', N'It is preserved', N'It is deleted (Overwritten)', N'It is moved', N'It is copied', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1109, 111, N'Does write() add a newline automatically?', N'Yes', N'No', N'Only on Windows', N'Only on Mac', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1110, 111, N'How do you add a newline manually?', N'write(\n)', N'write(/n)', N'write(newline)', N'write(br)', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1111, 111, N'Can you write numbers directly using write()?', N'Yes', N'No, must convert to string', N'Only integers', N'Only floats', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1112, 111, N'If file does not exist in "w" mode?', N'Error', N'Created', N'Ignored', N'Prompt user', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1113, 111, N'If file does not exist in "a" mode?', N'Error', N'Created', N'Ignored', N'Prompt user', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1114, 111, N'To check if a file is writable?', N'f.writable()', N'f.canWrite()', N'f.isWrite()', N'f.checkWrite()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1115, 111, N'Does write() return anything?', N'Nothing', N'Number of characters written', N'True/False', N'File object', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1116, 112, N'Which module is needed to delete files?', N'file', N'os', N'sys', N'io', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1117, 112, N'Which function deletes a file?', N'os.remove()', N'os.delete()', N'file.remove()', N'del file', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1118, 112, N'How to check if file exists before deleting?', N'os.path.exists()', N'os.check()', N'os.hasFile()', N'file.exists()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1119, 112, N'What happens if you remove a non-existent file?', N'Nothing', N'FileNotFoundError', N'Creates it', N'Returns False', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1120, 112, N'How do you delete an empty folder?', N'os.remove()', N'os.rmdir()', N'os.deldir()', N'os.clear()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1121, 112, N'Can os.remove() delete a folder?', N'Yes', N'No', N'Only if empty', N'Only if full', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1122, 112, N'How do you delete a non-empty folder?', N'os.rmdir()', N'shutil.rmtree()', N'os.remove()', N'del folder', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1123, 112, N'Does os.remove() move file to Trash/Recycle Bin?', N'Yes', N'No, permanent delete', N'Depends on OS', N'Only on Windows', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1124, 112, N'Which command creates a directory?', N'os.mkdir()', N'os.create()', N'os.newdir()', N'os.make()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1125, 112, N'Do you need admin rights to delete system files?', N'Yes', N'No', N'Never', N'Always No', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1126, 113, N'Method to add element at end?', N'append()', N'add()', N'push()', N'insert()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1127, 113, N'Method to remove all elements?', N'empty()', N'clear()', N'delete()', N'reset()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1128, 113, N'Method to return a copy of the list?', N'clone()', N'copy()', N'duplicate()', N'new()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1129, 113, N'Method to count occurrences of a value?', N'size()', N'count()', N'number()', N'amount()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1130, 113, N'Method to add elements of a list to another list?', N'merge()', N'extend()', N'append()', N'combine()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1131, 113, N'Method to find index of first matching element?', N'find()', N'search()', N'index()', N'locate()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1132, 113, N'Method to add element at specific position?', N'add()', N'append()', N'insert()', N'put()', N'C')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1133, 113, N'Method to remove element at specific position?', N'remove()', N'pop()', N'delete()', N'cut()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1134, 113, N'Method to remove first item with specific value?', N'remove()', N'pop()', N'delete()', N'clear()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1135, 113, N'Method to reverse the order?', N'sort()', N'reverse()', N'flip()', N'back()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1136, 114, N'Method to remove all elements?', N'clear()', N'empty()', N'delete()', N'reset()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1137, 114, N'Method to return a copy?', N'copy()', N'clone()', N'duplicate()', N'new()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1138, 114, N'Method to create dict with specified keys/value?', N'create()', N'fromkeys()', N'make()', N'build()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1139, 114, N'Method to return value of specified key?', N'value()', N'get()', N'fetch()', N'find()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1140, 114, N'Method to return list of (key, value) tuples?', N'list()', N'items()', N'pairs()', N'all()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1141, 114, N'Method to return list of keys?', N'keys()', N'getKeys()', N'listKeys()', N'names()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1142, 114, N'Method to return list of values?', N'values()', N'getValues()', N'listValues()', N'data()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1143, 114, N'Method to remove last inserted key-value pair?', N'pop()', N'popitem()', N'removeLast()', N'deleteLast()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1144, 114, N'Method to return value if key exists, else insert it?', N'setdefault()', N'getorset()', N'ensure()', N'check()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1145, 114, N'Method to update dict with key-value pairs?', N'update()', N'merge()', N'add()', N'set()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1146, 115, N'Method to add element to set?', N'append()', N'add()', N'push()', N'insert()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1147, 115, N'Method to remove all elements?', N'clear()', N'empty()', N'delete()', N'reset()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1148, 115, N'Method to return set difference?', N'diff()', N'difference()', N'minus()', N'subtract()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1149, 115, N'Method to remove item (no error if missing)?', N'remove()', N'discard()', N'delete()', N'drop()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1150, 115, N'Method to return intersection of sets?', N'intersection()', N'meet()', N'common()', N'join()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1151, 115, N'Method to return True if no common elements?', N'isdisjoint()', N'isdistinct()', N'isunique()', N'isseparate()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1152, 115, N'Method to return True if it contains another set?', N'issubset()', N'issuperset()', N'contains()', N'holds()', N'B')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1153, 115, N'Method to return union of sets?', N'union()', N'join()', N'combine()', N'add()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1154, 115, N'Method to remove item (error if missing)?', N'remove()', N'discard()', N'delete()', N'pop()', N'A')
INSERT [dbo].[Tbl_QuizzData] ([QuizID], [LessonID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectOption]) VALUES (1155, 115, N'Method to return symmetric difference?', N'symmetric_difference()', N'xor()', N'diff_sym()', N'outer()', N'A')
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
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (76, N'Python', N'Introduction', 1)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (77, N'Python', N'Syntax', 2)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (78, N'Python', N'Comments', 3)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (79, N'Python', N'Variables', 4)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (80, N'Python', N'Data Types', 5)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (81, N'Python', N'Numbers', 6)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (82, N'Python', N'Casting', 7)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (83, N'Python', N'Strings', 8)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (84, N'Python', N'Booleans', 9)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (85, N'Python', N'Operators', 10)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (86, N'Python', N'Lists', 11)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (87, N'Python', N'Tuples', 12)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (88, N'Python', N'Sets', 13)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (89, N'Python', N'Dictionaries', 14)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (90, N'Python', N'If...Else', 15)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (91, N'Python', N'While Loops', 16)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (92, N'Python', N'For Loops', 17)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (93, N'Python', N'Functions', 18)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (94, N'Python', N'Lambda', 19)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (95, N'Python', N'Arrays', 20)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (96, N'Python', N'Classes/Objects', 21)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (97, N'Python', N'Inheritance', 22)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (98, N'Python', N'Iterators', 23)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (99, N'Python', N'Scope', 24)
GO
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (100, N'Python', N'Modules', 25)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (101, N'Python', N'Dates', 26)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (102, N'Python', N'Math', 27)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (103, N'Python', N'JSON', 28)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (104, N'Python', N'RegEx', 29)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (105, N'Python', N'PIP', 30)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (106, N'Python', N'Try...Except', 31)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (107, N'Python', N'User Input', 32)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (108, N'Python', N'String Formatting', 33)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (109, N'Python', N'File Handling', 34)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (110, N'Python', N'Read Files', 35)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (111, N'Python', N'Write/Create Files', 36)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (112, N'Python', N'Delete Files', 37)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (113, N'Python', N'List Methods', 38)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (114, N'Python', N'Dictionary Methods', 39)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (115, N'Python', N'Set Methods', 40)
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
SET IDENTITY_INSERT [dbo].[Tbl_UserLessonProgress] ON 

INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (1, 5, 38, 1, 0, CAST(N'2026-01-27T20:42:35.603' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (2, 5, 8, 1, 0, CAST(N'2026-01-27T20:42:41.360' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (3, 5, 32, 1, 0, CAST(N'2026-01-27T20:44:02.237' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (4, 5, 4, 1, 0, CAST(N'2026-01-27T21:15:47.770' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (5, 5, 5, 1, 0, CAST(N'2026-01-27T21:15:54.480' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (6, 5, 13, 1, 0, CAST(N'2026-01-27T21:15:57.830' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (7, 5, 15, 1, 0, CAST(N'2026-01-27T21:15:58.820' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (8, 5, 22, 1, 0, CAST(N'2026-01-27T21:16:00.030' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (9, 5, 29, 1, 0, CAST(N'2026-01-27T21:16:01.110' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (10, 5, 30, 1, 0, CAST(N'2026-01-27T21:16:01.690' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (11, 5, 2, 1, 0, CAST(N'2026-01-27T21:19:53.080' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (12, 5, 1, 1, 0, CAST(N'2026-01-27T21:20:20.767' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (13, 5, 7, 1, 0, CAST(N'2026-01-27T21:21:42.730' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (14, 5, 10, 1, 0, CAST(N'2026-01-27T21:21:43.537' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (15, 5, 11, 1, 0, CAST(N'2026-01-27T21:21:44.103' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (16, 5, 14, 1, 0, CAST(N'2026-01-27T21:22:22.373' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (17, 5, 16, 1, 0, CAST(N'2026-01-27T21:22:24.560' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (18, 5, 39, 1, 0, CAST(N'2026-01-27T21:22:53.503' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (19, 5, 6, 1, 0, CAST(N'2026-01-27T21:27:55.420' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (20, 5, 46, 1, 0, CAST(N'2026-01-27T21:28:40.197' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (21, 5, 77, 1, 0, CAST(N'2026-01-27T21:37:39.130' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (22, 5, 76, 1, 0, CAST(N'2026-01-27T21:37:39.700' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (23, 5, 78, 1, 0, CAST(N'2026-01-27T21:37:40.367' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (24, 5, 79, 1, 0, CAST(N'2026-01-27T21:37:41.740' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (25, 5, 80, 1, 0, CAST(N'2026-01-27T21:37:42.860' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (26, 5, 82, 1, 0, CAST(N'2026-01-27T21:37:45.817' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (27, 5, 84, 1, 0, CAST(N'2026-01-27T21:37:46.290' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (28, 5, 85, 1, 0, CAST(N'2026-01-27T21:37:47.600' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (29, 5, 83, 1, 0, CAST(N'2026-01-27T21:37:49.517' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (30, 5, 81, 1, 0, CAST(N'2026-01-27T21:38:02.460' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (31, 5, 99, 1, 0, CAST(N'2026-01-27T22:14:47.147' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (32, 5, 110, 1, 0, CAST(N'2026-01-27T22:14:48.083' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (33, 5, 114, 1, 0, CAST(N'2026-01-27T22:14:48.920' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (34, 5, 115, 1, 0, CAST(N'2026-01-27T22:14:49.620' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (35, 5, 86, 1, 0, CAST(N'2026-01-27T22:14:58.730' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (36, 5, 87, 1, 0, CAST(N'2026-01-27T22:14:59.317' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (37, 5, 88, 1, 0, CAST(N'2026-01-27T22:15:00.397' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (38, 5, 89, 1, 0, CAST(N'2026-01-27T22:15:00.990' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (39, 5, 90, 1, 0, CAST(N'2026-01-27T22:15:01.643' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (40, 5, 92, 1, 0, CAST(N'2026-01-27T22:15:02.590' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (41, 5, 94, 1, 0, CAST(N'2026-01-27T22:15:04.297' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (42, 5, 96, 1, 0, CAST(N'2026-01-27T22:15:05.780' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (43, 5, 97, 1, 0, CAST(N'2026-01-27T22:15:06.237' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (44, 5, 98, 1, 0, CAST(N'2026-01-27T22:15:07.743' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (45, 5, 100, 1, 0, CAST(N'2026-01-27T22:15:08.300' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (46, 5, 102, 1, 0, CAST(N'2026-01-27T22:15:09.577' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (47, 5, 104, 1, 0, CAST(N'2026-01-27T22:15:10.667' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (48, 5, 103, 1, 0, CAST(N'2026-01-27T22:15:11.213' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (49, 5, 105, 1, 0, CAST(N'2026-01-27T22:15:11.970' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (50, 5, 106, 1, 0, CAST(N'2026-01-27T22:15:12.920' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (51, 5, 108, 1, 0, CAST(N'2026-01-27T22:15:13.310' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (52, 5, 112, 1, 0, CAST(N'2026-01-27T22:15:15.250' AS DateTime))
INSERT [dbo].[Tbl_UserLessonProgress] ([ProgressId], [UserId], [LessonId], [IsRead], [IsCompleted], [CompletedDate]) VALUES (53, 5, 113, 1, 0, CAST(N'2026-01-27T22:15:16.593' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tbl_UserLessonProgress] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Tbl_User__536C85E45ED4AB4D]    Script Date: 1/28/2026 4:54:17 PM ******/
ALTER TABLE [dbo].[Tbl_User] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tbl_User] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[Tbl_UserLessonProgress] ADD  DEFAULT ((0)) FOR [IsRead]
GO
ALTER TABLE [dbo].[Tbl_UserLessonProgress] ADD  DEFAULT ((0)) FOR [IsCompleted]
GO
ALTER TABLE [dbo].[Tbl_QuizzData]  WITH CHECK ADD FOREIGN KEY([LessonID])
REFERENCES [dbo].[Tbl_Lessons] ([LessonId])
GO
USE [master]
GO
ALTER DATABASE [LearningPlatformDB] SET  READ_WRITE 
GO
