using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowBasedLearningPlatform.WindowApp.App
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Example 1: Open MarkdownViewer with sample content
        /// </summary>
        private void btnOpenMarkdownViewer_Click(object sender, EventArgs e)
        {
            // Prepare markdown content
            string markdownContent = @"# Welcome to Markdown Viewer

## This is a demonstration

This example shows how to use the **MarkdownViewer** form with markdown content.

### Features:
- Easy to use
- Supports full markdown syntax
- Beautiful rendering

### Code Example:
```csharp
// Create and show the viewer
string markdown = ""# Hello World"";
var viewer = new MarkdownViewer(markdown);
viewer.ShowDialog();
```

> **Note:** The MarkdownViewer now requires markdown content in its constructor.";

            // Create and show the MarkdownViewer
            var markdownViewer = new MarkdownViewer(markdownContent);
            markdownViewer.ShowDialog();
        }

        /// <summary>
        /// Example 2: Open MarkdownViewer with content from database (simulated)
        /// </summary>
        private void btnOpenFromDatabase_Click(object sender, EventArgs e)
        {
            // Simulate fetching content from database
            string markdownFromDatabase = GetMarkdownFromDatabase();

            // Create and show the MarkdownViewer
            var markdownViewer = new MarkdownViewer(markdownFromDatabase);
            markdownViewer.ShowDialog();
        }

        /// <summary>
        /// Example 3: Open MarkdownViewer with content from TextBox
        /// </summary>
        private void btnOpenFromTextBox_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMarkdownInput.Text))
            {
                MessageBox.Show("Please enter some markdown content first!", 
                    "No Content", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create and show the MarkdownViewer with TextBox content
            var markdownViewer = new MarkdownViewer(txtMarkdownInput.Text);
            markdownViewer.ShowDialog();
        }

        /// <summary>
        /// Simulates fetching markdown content from a database
        /// </summary>
        private string GetMarkdownFromDatabase()
        {
            // In a real application, this would query your database
            return @"# Lesson 1: Introduction to Programming

## What is Programming?

Programming is the process of creating a set of instructions that tell a computer how to perform a task.

## Key Concepts

1. **Variables**: Storage locations for data
2. **Functions**: Reusable blocks of code
3. **Control Flow**: Decision making in code

## Example Code

```python
def greet(name):
    print(f'Hello, {name}!')

greet('Student')
```

## Summary

Programming enables us to automate tasks and solve complex problems efficiently.

---
*Content retrieved from database*";
        }
    }
}

