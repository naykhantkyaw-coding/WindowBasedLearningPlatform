USE [master]
GO
/****** Object:  Database [LearningPlatformDB]    Script Date: 01/11/2026 7:59:51 PM ******/
CREATE DATABASE [LearningPlatformDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LearningPlatformDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\LearningPlatformDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LearningPlatformDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\LearningPlatformDB_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
EXEC sys.sp_db_vardecimal_storage_format N'LearningPlatformDB', N'ON'
GO
ALTER DATABASE [LearningPlatformDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [LearningPlatformDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [LearningPlatformDB]
GO
/****** Object:  Table [dbo].[Tbl_LessonContents]    Script Date: 01/11/2026 7:59:52 PM ******/
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
/****** Object:  Table [dbo].[Tbl_Lessons]    Script Date: 01/11/2026 7:59:52 PM ******/
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
/****** Object:  Table [dbo].[Tbl_Sections]    Script Date: 01/11/2026 7:59:52 PM ******/
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
/****** Object:  Table [dbo].[Tbl_User]    Script Date: 01/11/2026 7:59:52 PM ******/
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

INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (1, N'CSharp.Intro', N'MARKDOWN', N'
# 🌟 C# Introduction

C# (pronounced **C-sharp**) is a modern, **object-oriented programming language** developed by Microsoft. It''s widely used for creating **desktop apps, web apps, games, and more**. Think of it as a super-tool in your coding toolbox 🛠️💻.

---

## 🔹 Key Features of C#

1. **Object-Oriented Programming (OOP) 🏗️**
   C# uses **classes** and **objects**, which makes it easy to model real-world things in code.

2. **Strongly Typed 💪**
   Every variable has a type (`int`, `string`, `bool`, etc.), which helps prevent errors.

3. **Cross-Platform 🌍**
   With **.NET Core / .NET 6+**, C# apps can run on **Windows, Linux, macOS**, and even mobile.

4. **Rich Standard Library 📚**
   You get tons of built-in functions for **file handling, math, networking, and more**.

5. **Memory Management 🧹**
   C# has **automatic garbage collection**, so you don’t have to manually manage memory like in C++.

---

## 🔹 Basic Syntax Example

Here’s a simple C# program that prints “Hello World”:

```csharp
using System; // Import system libraries

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello World! 👋");
    }
}
```

**What’s happening here?** 🤔

* `using System;` → lets us use built-in tools like `Console`.
* `class Program` → defines a **class**, the blueprint of your program.
* `static void Main()` → **entry point** of every C# program.
* `Console.WriteLine()` → prints text to the screen.

---

## 🔹 Variables in C#

Variables store data. Examples:

```csharp
int age = 20;           // Numbers 🧮
string name = "Alice";  // Text ✍️
bool isStudent = true;  // True/False ✅❌
```

---

## 🔹 Simple Calculator Example ➕➖✖️➗

```csharp
int a = 10;
int b = 5;

Console.WriteLine("Add: " + (a + b));      // 15
Console.WriteLine("Subtract: " + (a - b)); // 5
Console.WriteLine("Multiply: " + (a * b)); // 50
Console.WriteLine("Divide: " + (a / b));   // 2
```

---

C# is **fun, powerful, and beginner-friendly** 🎉. Once you master the basics, you can move into **Windows Forms, Blazor, Unity games, or ASP.NET web apps**. 🚀


', 1)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (2, N'CSharp.Start', N'MARKDOWN', N'
# 🌟 C# Get Started

C# is a **modern, object-oriented language**. To get started, all you need is **.NET SDK** and a **code editor** like **Visual Studio** or **VS Code**.

---

## 1️⃣ Install the Tools 🛠️

1. **Install .NET SDK**
   Download from [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
   (This lets you run and build C# apps)

2. **Install VS Code or Visual Studio**

   * VS Code → Lightweight and fast
   * Visual Studio → Full IDE with designer tools

---

## 2️⃣ Create Your First Program 👋

Open your terminal/command prompt:

```bash
dotnet new console -n MyFirstApp
cd MyFirstApp
dotnet run
```

Output:

```
Hello, World!
```

🎉 You just ran your **first C# program**!

---

## 3️⃣ Basic C# Concepts

### 🔹 Variables

```csharp
int age = 25;          // Numbers 🧮
string name = "Alice"; // Text ✍️
bool isHappy = true;   // True/False ✅❌
```

### 🔹 Methods (Functions)

```csharp
void SayHello(string person)
{
    Console.WriteLine("Hello, " + person + " 👋");
}

// Usage
SayHello("Alice");
```

### 🔹 Loops 🔄

```csharp
for(int i = 1; i <= 5; i++)
{
    Console.WriteLine("Number: " + i);
}
```

### 🔹 Conditional Statements ⚡

```csharp
int score = 80;

if(score >= 50)
{
    Console.WriteLine("Pass ✅");
}
else
{
    Console.WriteLine("Fail ❌");
}
```

---

## 4️⃣ Your First Mini Calculator ➕➖✖️➗

```csharp
int a = 10;
int b = 5;

Console.WriteLine($"Add: {a + b}");      // 15
Console.WriteLine($"Subtract: {a - b}"); // 5
Console.WriteLine($"Multiply: {a * b}"); // 50
Console.WriteLine($"Divide: {a / b}");   // 2
```', 2)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (3, N'CSharp.Syntax', N'MARKDOWN', N'
# 🌟 C# Syntax Basics

C# syntax defines **how we write code** so the compiler understands it. Think of it as **grammar for code** 📝.

---

## 1️⃣ Structure of a C# Program 🏗️

```csharp
using System; // Import libraries

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! 👋");
        }
    }
}
```

**Explanation:**

* `using System;` → gives access to built-in features like `Console`.
* `namespace MyApp` → groups your code into a logical container.
* `class Program` → defines a class (blueprint for objects).
* `static void Main()` → **entry point** of your program.
* `Console.WriteLine()` → prints text to the screen.

---

## 2️⃣ Comments 📝

Used to explain code. The compiler ignores them.

```csharp
// This is a single-line comment
/* This is a 
   multi-line comment */
```

---

## 3️⃣ Variables & Data Types 💾

```csharp
int age = 25;          // Numbers 🧮
double price = 19.99;  // Decimal numbers 💵
string name = "Alice"; // Text ✍️
bool isStudent = true; // True/False ✅❌
char grade = ''A'';      // Single character 🔤
```

---

## 4️⃣ Operators ➕➖✖️➗

```csharp
int a = 10;
int b = 5;

Console.WriteLine(a + b); // Add ➕
Console.WriteLine(a - b); // Subtract ➖
Console.WriteLine(a * b); // Multiply ✖️
Console.WriteLine(a / b); // Divide ➗
Console.WriteLine(a % b); // Modulus (remainder) 🔢
```

---

## 5️⃣ Conditionals ⚡

```csharp
int score = 80;

if(score >= 50)
{
    Console.WriteLine("Pass ✅");
}
else
{
    Console.WriteLine("Fail ❌");
}
```

---

## 6️⃣ Loops 🔄

### For loop:

```csharp
for(int i = 1; i <= 5; i++)
{
    Console.WriteLine("Number: " + i);
}
```

### While loop:

```csharp
int i = 1;
while(i <= 5)
{
    Console.WriteLine(i);
    i++;
}
```

### Foreach loop (for collections):

```csharp
string[] fruits = {"🍎", "🍌", "🍇"};
foreach(var fruit in fruits)
{
    Console.WriteLine(fruit);
}
```

---

## 7️⃣ Methods (Functions) 🛠️

```csharp
int Add(int x, int y)
{
    return x + y;
}

int result = Add(5, 3);
Console.WriteLine(result); // 8
```

---

## 8️⃣ Classes & Objects 🏗️

```csharp
class Person
{
    public string Name;
    public int Age;

    public void Greet()
    {
        Console.WriteLine("Hello, " + Name + " 👋");
    }
}

// Create an object
Person p = new Person();
p.Name = "Alice";
p.Age = 25;
p.Greet(); // Hello, Alice 👋
```
', 3)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (4, N'CSharp.Output', N'MARKDOWN', N'
# 🌟 C# Output Basics

In C#, we usually use the **`Console` class** to show output in the console (command line).

---

## 1️⃣ Basic Output

```csharp
Console.WriteLine("Hello, World! 👋"); // Prints with a new line
Console.Write("Hello");                 // Prints without new line
Console.Write(" World!");               // Continues on the same line
```

**Output:**

```
Hello, World! 👋
Hello World!
```

* `WriteLine()` → prints **and moves to a new line**
* `Write()` → prints **on the same line**

---

## 2️⃣ Output Variables

```csharp
int age = 25;
string name = "Alice";

Console.WriteLine("Name: " + name);
Console.WriteLine("Age: " + age);
```

**Output:**

```
Name: Alice
Age: 25
```

💡 Tip: You can combine text and variables using **string interpolation** (easier!):

```csharp
Console.WriteLine($"Name: {name}, Age: {age} 🎉");
```

Output:

```
Name: Alice, Age: 25 🎉
```

---

## 3️⃣ Output Expressions

```csharp
int a = 10;
int b = 5;

Console.WriteLine($"Add: {a + b}");
Console.WriteLine($"Multiply: {a * b}");
```

Output:

```
Add: 15
Multiply: 50
```

---

## 4️⃣ Output Special Characters

You can add **new lines** or **tabs**:

```csharp
Console.WriteLine("Line1\nLine2"); // \n = new line
Console.WriteLine("Col1\tCol2");   // \t = tab
```

Output:

```
Line1
Line2
Col1    Col2
```

---

## 5️⃣ Output Emoji 😄

Yes, you can even print emojis in the console:

```csharp
Console.WriteLine("I love C#! ❤️🚀");
```

Output:

```
I love C#! ❤️🚀
```

---
', 4)
INSERT [dbo].[Tbl_LessonContents] ([ContentId], [LessonCode], [ContentType], [ContentBody], [LessonId]) VALUES (5, N'CSharp.Comments', N'MARKDOWN', N'
# 🌟 C# Comments

Comments are **ignored by the compiler**. They are used to **explain code** to yourself or other developers.

---

## 1️⃣ Single-Line Comment

```csharp
// This is a single-line comment
Console.WriteLine("Hello World! 👋"); // This prints Hello World
```

* Start with `//`
* Everything after `//` on that line is a comment

---

## 2️⃣ Multi-Line Comment

```csharp
/*
 This is a multi-line comment
 It can span multiple lines
 Useful for explaining complex logic
*/
Console.WriteLine("Hello World! 👋");
```

* Start with `/*` and end with `*/`
* Can cover **several lines**

---

## 3️⃣ Documentation Comment (XML Comments) 📄

Used to **document your code**. These comments can be used to generate **API documentation**.

```csharp
/// <summary>
/// This method adds two numbers and returns the result
/// </summary>
/// <param name="a">First number</param>
/// <param name="b">Second number</param>
/// <returns>The sum of a and b</returns>
int Add(int a, int b)
{
    return a + b;
}
```

* Start with `///`
* Use **XML tags** like `<summary>`, `<param>`, `<returns>`
* Helps **IntelliSense** in Visual Studio display useful info

---

## ✅ Why Comments are Important

1. Explain what the code **does** 🧠
2. Help others **understand** your code 👥
3. Useful for **temporary debugging** 🔧
4. Improves **maintainability** of your project 💡

---

💡 **Tip:**

* Don’t over-comment obvious code (like `int x = 5; // assign 5`).
* Focus on **why**, not **what**, because code itself shows the “what”

', 5)
SET IDENTITY_INSERT [dbo].[Tbl_LessonContents] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Lessons] ON 

INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (1, N'CSharp.Intro', N'C#', N'Introduction', 1, 1)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (2, N'CSharp.Start', N'C#', N'Get Started', 2, 2)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (3, N'CSharp.Syntax', N'C#', N'Syntax', 3, 3)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (4, N'CSharp.Output', N'C#', N'Output', 4, 4)
INSERT [dbo].[Tbl_Lessons] ([LessonId], [LessonCode], [SectionCode], [LessonTitle], [SortOrder], [SectionId]) VALUES (5, N'CSharp.Comments', N'C#', N'Comments', 5, 5)
SET IDENTITY_INSERT [dbo].[Tbl_Lessons] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Sections] ON 

INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (1, N'C#', N'Introduction', 1)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (2, N'C#', N'Get Started', 2)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (3, N'C#', N'Syntax', 3)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (4, N'C#', N'OutPut', 4)
INSERT [dbo].[Tbl_Sections] ([SectionId], [SectionCode], [SectionName], [SortOrder]) VALUES (5, N'C#', N'Comments', 5)
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
/****** Object:  Index [UQ__Tbl_User__536C85E4C8F996ED]    Script Date: 01/11/2026 7:59:52 PM ******/
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
