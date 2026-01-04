using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Linq;
using System.Collections.Generic;

namespace WindowBasedLearningPlatform.WindowApp.App.UserControls
{
    public partial class UC_CodePlayground : UserControl
    {
        private RichTextBox _txtCodeInput;
        private TextBox _txtOutput;
        private Button _btnRun;

        public UC_CodePlayground()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            // 1. Split Container
            SplitContainer split = new SplitContainer();
            split.Dock = DockStyle.Fill;
            split.Orientation = Orientation.Horizontal;
            split.SplitterDistance = 300;
            this.Controls.Add(split);

            // 2. Code Input (Panel1)
            Panel inputPanel = new Panel();
            inputPanel.Dock = DockStyle.Fill;
            inputPanel.Padding = new Padding(10);
            split.Panel1.Controls.Add(inputPanel);

            Label lblCode = new Label();
            lblCode.Text = "Code Editor (C#)";
            lblCode.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblCode.Dock = DockStyle.Top;
            inputPanel.Controls.Add(lblCode);

            _txtCodeInput = new RichTextBox();
            _txtCodeInput.Dock = DockStyle.Fill;
            _txtCodeInput.Font = new Font("Consolas", 11);
            _txtCodeInput.BackColor = Color.FromArgb(30, 30, 30);
            _txtCodeInput.ForeColor = Color.White;
            // Updated default text to show capabilities
            _txtCodeInput.Text = "// Try these examples:\n" +
                                 "// 1. Console Output:\n" +
                                 "Console.WriteLine(\"Hello from Console!\");\n\n" +
                                 "// 2. Simple Math (Return value):\n" +
                                 "int a = 10;\n" +
                                 "int b = 20;\n" +
                                 "a + b // Returns 30\n\n" +
                                 "// 3. GUI Interaction:\n" +
                                 "// MessageBox.Show(\"Hello from a popup!\");";
            inputPanel.Controls.Add(_txtCodeInput);

            _btnRun = new Button();
            _btnRun.Text = "▶ Run Code";
            _btnRun.BackColor = Color.FromArgb(76, 175, 80);
            _btnRun.ForeColor = Color.White;
            _btnRun.FlatStyle = FlatStyle.Flat;
            _btnRun.Height = 40;
            _btnRun.Dock = DockStyle.Bottom;
            _btnRun.Cursor = Cursors.Hand;
            _btnRun.Click += BtnRun_Click;
            inputPanel.Controls.Add(_btnRun);

            // 3. Output (Panel2)
            Panel outputPanel = new Panel();
            outputPanel.Dock = DockStyle.Fill;
            outputPanel.Padding = new Padding(10);
            split.Panel2.Controls.Add(outputPanel);

            Label lblOutput = new Label();
            lblOutput.Text = "Output / Result";
            lblOutput.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblOutput.Dock = DockStyle.Top;
            outputPanel.Controls.Add(lblOutput);

            _txtOutput = new TextBox();
            _txtOutput.Multiline = true;
            _txtOutput.ReadOnly = true; // Keeps it as an output log, not an interactive terminal
            _txtOutput.Dock = DockStyle.Fill;
            _txtOutput.Font = new Font("Consolas", 10);
            _txtOutput.BackColor = Color.FromArgb(240, 240, 240);
            _txtOutput.ScrollBars = ScrollBars.Vertical;
            outputPanel.Controls.Add(_txtOutput);
        }

        private async void BtnRun_Click(object sender, EventArgs e)
        {
            _txtOutput.Text = "Running...";
            _btnRun.Enabled = false;
            _txtOutput.ForeColor = Color.Black;

            string code = _txtCodeInput.Text;

            // Capture Standard Output
            TextWriter originalConsoleOut = Console.Out;
            using (StringWriter writer = new StringWriter())
            {
                try
                {
                    Console.SetOut(writer);

                    // Add imports AND References to support MessageBox and Linq
                    var options = ScriptOptions.Default
                        .WithImports("System", "System.Collections.Generic", "System.Linq", "System.Text", "System.Windows.Forms", "System.Drawing")
                        .AddReferences(
                            typeof(object).Assembly, // System.Private.CoreLib
                            typeof(System.Linq.Enumerable).Assembly, // System.Linq
                            typeof(System.Collections.Generic.List<>).Assembly, // System.Collections
                            typeof(System.Windows.Forms.MessageBox).Assembly, // System.Windows.Forms
                            typeof(System.Drawing.Point).Assembly // System.Drawing
                        );

                    // Run Script
                    object result = await CSharpScript.EvaluateAsync(code, options);

                    // 1. Get Console Output
                    string consoleOutput = writer.ToString();

                    // 2. Get Return Value (if any)
                    string resultOutput = result != null ? result.ToString() : "";

                    // Combine them
                    string finalOutput = "";
                    if (!string.IsNullOrEmpty(consoleOutput))
                    {
                        finalOutput += "--- Console Output ---\r\n" + consoleOutput + "\r\n";
                    }
                    if (!string.IsNullOrEmpty(resultOutput))
                    {
                        finalOutput += "--- Return Value ---\r\n" + resultOutput;
                    }

                    if (string.IsNullOrWhiteSpace(finalOutput))
                    {
                        finalOutput = "Code executed successfully (No Output).";
                    }

                    _txtOutput.Text = finalOutput;
                }
                catch (CompilationErrorException ex)
                {
                    _txtOutput.Text = "Build Error:\r\n" + string.Join(Environment.NewLine, ex.Diagnostics);
                    _txtOutput.ForeColor = Color.Red;
                }
                catch (Exception ex)
                {
                    _txtOutput.Text = "Runtime Error:\r\n" + ex.Message;
                    _txtOutput.ForeColor = Color.Red;
                }
                finally
                {
                    // Restore Console
                    Console.SetOut(originalConsoleOut);
                    _btnRun.Enabled = true;
                }
            }
        }
    }
}