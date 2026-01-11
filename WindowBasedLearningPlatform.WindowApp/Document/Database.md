USE [master]
GO
/****** Object:  Database [LearningPlatformDB]    Script Date: 1/11/2026 9:22:06 PM ******/
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
/****** Object:  Table [dbo].[Tbl_LessonContents]    Script Date: 1/11/2026 9:22:07 PM ******/
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
/****** Object:  Table [dbo].[Tbl_Lessons]    Script Date: 1/11/2026 9:22:07 PM ******/
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
/****** Object:  Table [dbo].[Tbl_Sections]    Script Date: 1/11/2026 9:22:07 PM ******/
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
/****** Object:  Table [dbo].[Tbl_User]    Script Date: 1/11/2026 9:22:07 PM ******/
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
    C# (pronounced "C-Sharp") is a modern, object-oriented programming language developed by Microsoft.
    
    ## Why learn C#?
    - **Versatile:** Used for web, mobile, desktop, and game development (Unity).
    - **Powerful:** Part of the .NET ecosystem.
    - **Easy to Start:** Readable syntax similar to Java and C++.
    
    In this course, we will cover the basics of syntax, variables, loops, and more.
    
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
    
    ## Common Types:
    - `int`: Whole numbers (e.g., 123)
    - `double`: Decimal numbers (e.g., 19.99)
    - `char`: Single characters (e.g., "a")
    - `string`: Text (e.g., "Hello")
    - `bool`: True or False
    
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
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (3, N'CSharp.Input', N'MARKDOWN', N'# Reading Input
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
            // Note: In this playground, input is simulated or limited.
            Console.WriteLine("Enter your username:");
            string userName = "User"; // Simulated input
            
            Console.WriteLine("Username is: " + userName);
        }
    }
    ```', 3)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (4, N'CSharp.IfElse', N'MARKDOWN', N'# Making Decisions
    C# supports logical conditions from mathematics (Less than, Greater than, Equal to, etc.).
    
    You can use the `if` statement to specify a block of C# code to be executed if a condition is **True**.
    
    ## Syntax
    ```csharp
    if (condition) 
    {
      // block of code
    } 
    else 
    {
      // block of code
    }
    ```
    
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
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (6, N'CSharp.Arrays', N'MARKDOWN', N'# C# Arrays
    Arrays are used to store multiple values in a single variable, instead of declaring separate variables for each value.
    
    To declare an array, define the variable type with square brackets:
    
    ```csharp
    string[] cars;
    ```
    
    We have now declared a variable that holds an array of strings. To insert values to it, we can use an array literal - place the values in a comma-separated list, inside curly braces:
    
    ```csharp
    string[] cars = {"Volvo", "BMW", "Ford", "Mazda"};
    ```
    
    Access the elements of an array by referring to the index number.
    
    ```csharp
    using System;

    class Program
    {
        static void Main()
        {
            string[] cars = {"Volvo", "BMW", "Ford", "Mazda"};
            Console.WriteLine(cars[0]);
        }
    }
    ```', 6)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (7, N'CSharp.ArrayMethods', N'MARKDOWN', N'# Sort an Array
    There are many array methods available, for example `Sort()`, which sorts an array alphabetically or in an ascending order:
    
    ```csharp
    using System;
    using System.Linq; // Essential for Max, Min, Sum

    class Program
    {
        static void Main()
        {
            int[] myNumbers = {5, 1, 8, 9};
            Array.Sort(myNumbers);
            foreach(int i in myNumbers)
            {
                Console.WriteLine(i);
            }
            
            // System.Linq methods
            Console.WriteLine("Max: " + myNumbers.Max());
            Console.WriteLine("Min: " + myNumbers.Min());
            Console.WriteLine("Sum: " + myNumbers.Sum());
        }
    }
    ```', 7)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (8, N'CSharp.Strings', N'MARKDOWN', N'# Strings
    A string variable contains a collection of characters surrounded by double quotes.
    
    ## String Length
    A string in C# is actually an object, which contain properties and methods that can perform certain operations on strings. For example, the length of a string can be found with the `Length` property.
    
    ## ToUpper() and ToLower()
    Other useful methods are `ToUpper()` and `ToLower()`.
    
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
    The `void` keyword, used in the previous examples, indicates that the method should not return a value. If you want the method to return a value, you can use a primitive data type (such as `int` or `double`) instead of `void`, and use the `return` keyword inside the method.
    
    ```csharp
    using System;

    class Program
    {
        static int MyMethod(int x)
        {
            return 5 + x;
        }

        static void Main()
        {
            Console.WriteLine(MyMethod(3));
        }
    }
    ```', 10)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (11, N'CSharp.Overloading', N'MARKDOWN', N'# Method Overloading
    With method overloading, multiple methods can have the same name with different parameters.
    
    `int MyMethod(int x)`
    `float MyMethod(float x)`
    `double MyMethod(double x, double y)`
    
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
    Everything in C# is associated with classes and objects, along with its attributes and methods. For example: in real life, a car is an object. The car has attributes, such as weight and color, and methods, such as drive and brake.
    
    A Class is like an object constructor, or a "blueprint" for creating objects.
    
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
    
    Variables inside a class are called fields, and methods inside a class are called methods.
    
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
    A constructor is a special method that is used to initialize objects. The advantage of a constructor, is that it is called when an object of a class is created. It can be used to set initial values for fields.
    
    Note that the constructor name must match the class name, and it cannot have a return type (like void or int).
    
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
    By now, you are quite familiar with the `public` keyword that appears in many of our examples. The `public` keyword is an access modifier.
    
    Access modifiers define the scope and visibility of a class member.
    
    * **public** The code is accessible for all classes
    * **private** The code is only accessible within the same class
    * **protected** The code is accessible within the same class, or in a class that is inherited from that class.
    
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
    Abstraction can be achieved with either abstract classes or interfaces.
    
    The `abstract` keyword is used for classes and methods:
    - **Abstract class:** is a restricted class that cannot be used to create objects (to access it, it must be inherited from another class).
    - **Abstract method:** can only be used in an abstract class, and it does not have a body. The body is provided by the derived class (inherited from).
    
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
    
    You can access enum items with the dot syntax.
    
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
    The File class from the `System.IO` namespace, allows us to work with files:
    
    - `AppendText()`: Appends text at the end of an existing file.
    - `Copy()`: Copies a file.
    - `Create()`: Creates or overwrites a file.
    - `Delete()`: Deletes a file.
    - `Exists()`: Tests whether the file exists.
    - `ReadAllText()`: Reads the contents of a file.
    - `WriteAllText()`: Creates a new file, writes the specified string to the file, and then closes the file.
    
    ```csharp
    using System;
    using System.IO;  // include the System.IO namespace

    class Program
    {
      static void Main()
      {
        string writeText = "Hello World!";
        // Note: File operations might be restricted in online playgrounds
        File.WriteAllText("filename.txt", writeText);

        string readText = File.ReadAllText("filename.txt");
        Console.WriteLine(readText);
      }
    }
    ```', 18)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (19, N'CSharp.Exceptions', N'MARKDOWN', N'# C# Exceptions - Try..Catch
    When executing C# code, different errors can occur: coding errors made by the programmer, errors due to wrong input, or other unforeseeable things.
    
    When an error occurs, C# will normally stop and generate an error message. The technical term for this is: C# will throw an exception (throw an error).
    
    The `try` statement allows you to define a block of code to be tested for errors while it is being executed.
    The `catch` statement allows you to define a block of code to be executed, if an error occurs in the try block.
    
    ```csharp
    using System;

    class Program
    {
      static void Main()
      {
        try
        {
          int[] myNumbers = {1, 2, 3};
          Console.WriteLine(myNumbers[10]); // Error! Index out of bounds
        }
        catch (Exception e)
        {
          Console.WriteLine("Something went wrong.");
          // Console.WriteLine(e.Message);
        }
      }
    }
    ```', 19)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (20, N'CSharp.Math', N'MARKDOWN', N'# C# Math
    The C# Math class has many methods that allows you to perform mathematical tasks on numbers.
    
    - `Math.Max(x, y)`: returns the highest value of x and y.
    - `Math.Min(x, y)`: returns the lowest value of x and y.
    - `Math.Sqrt(x)`: returns the square root of x.
    - `Math.Abs(x)`: returns the absolute (positive) value of x.
    - `Math.Round()`: rounds a number to the nearest whole number.
    
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
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (21, N'CSharp.StringsAdvanced', N'MARKDOWN', N'# C# Strings
    Strings are used for storing text. A string variable contains a collection of characters surrounded by double quotes.
    
    ## String Length
    A string in C# is actually an object, which contain properties and methods that can perform certain operations on strings. For example, the length of a string can be found with the `Length` property.
    
    ## ToUpper() and ToLower()
    There are many string methods available, for example `ToUpper()` and `ToLower()`.
    
    ```csharp
    using System;

    class Program
    {
      static void Main()
      {
        string txt = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        Console.WriteLine("The length of the txt string is: " + txt.Length);
        
        string txt2 = "Hello World";
        Console.WriteLine(txt2.ToUpper());   // Outputs "HELLO WORLD"
        Console.WriteLine(txt2.ToLower());   // Outputs "hello world"
      }
    }
    ```', 21)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (22, N'CSharp.Booleans', N'MARKDOWN', N'# C# Booleans
    Very often, in programming, you will need a data type that can only have one of two values, like:
    - YES / NO
    - ON / OFF
    - TRUE / FALSE
    
    For this, C# has a `bool` data type, which can take the values `true` or `false`.
    
    ```csharp
    using System;

    class Program
    {
      static void Main()
      {
        bool isCSharpFun = true;
        bool isFishTasty = false;
        Console.WriteLine(isCSharpFun);   // Outputs True
        Console.WriteLine(isFishTasty);   // Outputs False
        
        int x = 10;
        int y = 9;
        Console.WriteLine(x > y); // returns True, because 10 is higher than 9
      }
    }
    ```', 22)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (23, N'CSharp.Switch', N'MARKDOWN', N'# C# Switch
    Use the `switch` statement to select one of many code blocks to be executed.
    
    This is how it works:
    - The `switch` expression is evaluated once
    - The value of the expression is compared with the values of each `case`
    - If there is a match, the associated block of code is executed
    - The `break` keyword breaks out of the switch block.
    
    ```csharp
    using System;

    class Program
    {
      static void Main()
      {
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
      }
    }
    ```', 23)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (24, N'CSharp.BreakContinue', N'MARKDOWN', N'# C# Break and Continue
    You have already seen the `break` statement used in an earlier chapter of this tutorial. It was used to "jump out" of a switch statement.
    The `break` statement can also be used to jump out of a **loop**.
    
    The `continue` statement breaks one iteration (in the loop), if a specified condition occurs, and continues with the next iteration in the loop.
    
    ```csharp
    using System;

    class Program
    {
      static void Main()
      {
        Console.WriteLine("Loop with break at 4:");
        for (int i = 0; i < 10; i++) 
        {
          if (i == 4) 
          {
            break;
          }
          Console.WriteLine(i);
        }
      }
    }
    ```', 24)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (25, N'CSharp.TypeCasting', N'MARKDOWN', N'# C# Type Casting
    Type casting is when you assign a value of one data type to another type.
    
    In C#, there are two types of casting:
    
    - **Implicit Casting** (automatically) - converting a smaller type to a larger type size
      `char` -> `int` -> `long` -> `float` -> `double`
      
    - **Explicit Casting** (manually) - converting a larger type to a smaller size type
      `double` -> `float` -> `long` -> `int` -> `char`
    
    ```csharp
    using System;

    class Program
    {
      static void Main()
      {
        // Implicit Casting
        int myInt = 9;
        double myDouble = myInt;       // Automatic casting: int to double

        Console.WriteLine(myInt);      // Outputs 9
        Console.WriteLine(myDouble);   // Outputs 9

        // Explicit Casting
        double myDouble2 = 9.78;
        int myInt2 = (int) myDouble2;    // Manual casting: double to int

        Console.WriteLine(myDouble2);   // Outputs 9.78
        Console.WriteLine(myInt2);      // Outputs 9
      }
    }
    ```', 25)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (26, N'CSharp.Dates', N'MARKDOWN', N'# C# Dates
    C# does not have a built-in Date class, but you can import the `System` namespace to use the `DateTime` struct.
    
    ## Current Date and Time
    To get the current date and time, use the `DateTime.Now` property.
    
    ## Formatting
    You can format the date using the `ToString()` method with format strings like "yyyy-MM-dd".
    
    ```csharp
    using System;

    class Program
    {
        static void Main()
        {
            DateTime myObj = DateTime.Now;
            Console.WriteLine(myObj);
            
            // Formatting
            Console.WriteLine(myObj.ToString("dd/MM/yyyy"));
            Console.WriteLine(myObj.ToString("HH:mm:ss"));
        }
    }
    ```', 26)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (27, N'CSharp.ArrayList', N'MARKDOWN', N'# C# ArrayList
    The `ArrayList` class is a non-generic collection that can store elements of any data type. It is found in the `System.Collections` namespace.
    
    Unlike arrays, an ArrayList can grow dynamically. However, because it stores items as `object`, it is slower than generic collections and requires casting when retrieving items.
    
    *Note: In modern C#, `List<T>` is preferred over `ArrayList`.*
    
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
    
    ## Key Methods
    - `Add()`: Adds an item to the end.
    - `Remove()`: Removes the first occurrence of a specific object.
    - `Count`: Gets the number of elements.
    
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
    
    ## Accessing Items
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
    
    ## Syntax
    ```csharp
    foreach (type variableName in arrayName) 
    {
      // code block to be executed
    }
    ```
    The `foreach` loop is cleaner and less error-prone than a standard `for` loop when you don''t need the index.
    
    ```csharp
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            string[] cars = {"Volvo", "BMW", "Ford", "Mazda"};
            
            foreach (string i in cars) 
            {
                Console.WriteLine(i);
            }
        }
    }
    ```', 30)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (31, N'CSharp.Recursion', N'MARKDOWN', N'# C# Recursion
    Recursion is the technique of making a function call itself. This technique provides a way to break complicated problems down into simple problems which are easier to solve.
    
    **Example:** Adding a range of numbers together.
    
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
    ```', 31)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (32, N'CSharp.Structs', N'MARKDOWN', N'# C# Structs
    A `struct` (structure) is a value type that is typically used to encapsulate small groups of related variables, such as coordinates.
    
    ## Struct vs Class
    - **Structs** are Value Types (stored in Stack).
    - **Classes** are Reference Types (stored in Heap).
    
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
            Console.WriteLine(point.x);
            Console.WriteLine(point.y);
        }
    }
    ```', 32)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (33, N'CSharp.Nullables', N'MARKDOWN', N'# C# Nullable Types
    By default, value types like `int`, `double`, and `bool` cannot be null. However, sometimes you need them to be null (e.g., database fields).
    
    To allow nulls, use the `?` operator after the type name: `int?`.
    
    ## HasValue and Value
    You can check `HasValue` to see if it''s not null, and access `Value` to get the underlying value.
    
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
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (34, N'CSharp.Random', N'MARKDOWN', N'# C# Random
    The `Random` class is used to generate random numbers.
    
    ## Next()
    The `Next()` method returns a random number.
    - `Next()`: Random int.
    - `Next(max)`: Random int less than max.
    - `Next(min, max)`: Random int between min (inclusive) and max (exclusive).
    
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
    Debugging is the process of finding and fixing errors. While this platform can''t show Visual Studio''s debugger, understanding the logic is key.
    
    ## Debug.WriteLine
    In professional development, you often output debug information to the "Output" window instead of the Console using `System.Diagnostics.Debug.WriteLine`.
    
    In this playground, we stick to `Console.WriteLine` to trace values.
    
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
/****** Object:  Index [UQ__Tbl_User__536C85E45ED4AB4D]    Script Date: 1/11/2026 9:22:07 PM ******/
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
