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
        // NEW: Close Button
        private Button _btnClose;

        // NEW: Event to notify parent to close this control
        public event EventHandler RequestClose;

        public UC_CodePlayground()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            // ... (Your existing SplitContainer setup) ...
            SplitContainer split = new SplitContainer();
            split.Dock = DockStyle.Fill;
            split.Orientation = Orientation.Horizontal;
            split.SplitterDistance = 300;
            this.Controls.Add(split);

            // ... (Input Panel) ...
            Panel inputPanel = new Panel();
            inputPanel.Dock = DockStyle.Fill;
            inputPanel.Padding = new Padding(10);
            split.Panel1.Controls.Add(inputPanel);

            // NEW: Header Panel for Close Button
            Panel headerPanel = new Panel();
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 35;
            inputPanel.Controls.Add(headerPanel);

            Label lblCode = new Label();
            lblCode.Text = "Code Editor (C#)";
            lblCode.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblCode.Dock = DockStyle.Left;
            lblCode.AutoSize = true;
            lblCode.Padding = new Padding(0, 8, 0, 0);
            headerPanel.Controls.Add(lblCode);

            // NEW: Close Button logic
            _btnClose = new Button();
            _btnClose.Text = "❌ Close";
            _btnClose.ForeColor = Color.Red;
            _btnClose.FlatStyle = FlatStyle.Flat;
            _btnClose.FlatAppearance.BorderSize = 0;
            _btnClose.Dock = DockStyle.Right;
            _btnClose.Cursor = Cursors.Hand;
            _btnClose.Click += (s, e) => RequestClose?.Invoke(this, EventArgs.Empty);
            headerPanel.Controls.Add(_btnClose);

            // ... (Rest of your existing setup for _txtCodeInput, _btnRun, Output, etc.) ...
            _txtCodeInput = new RichTextBox();
            _txtCodeInput.Dock = DockStyle.Fill;
            _txtCodeInput.Font = new Font("Consolas", 11);
            _txtCodeInput.BackColor = Color.FromArgb(30, 30, 30);
            _txtCodeInput.ForeColor = Color.White;
            _txtCodeInput.Text = "// Type your C# code here...\nConsole.WriteLine(\"Hello World!\");";
            // Ensure this is added AFTER headerPanel so it fills the rest
            inputPanel.Controls.Add(_txtCodeInput);
            _txtCodeInput.BringToFront();

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

            // Output Panel Setup (Same as before)
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
            _txtOutput.ReadOnly = true;
            _txtOutput.Dock = DockStyle.Fill;
            _txtOutput.Font = new Font("Consolas", 10);
            _txtOutput.BackColor = Color.FromArgb(240, 240, 240);
            _txtOutput.ScrollBars = ScrollBars.Vertical;
            outputPanel.Controls.Add(_txtOutput);
        }

        private async void BtnRun_Click(object sender, EventArgs e)
        {
            // ... (Keep your existing Run logic) ...
            _txtOutput.Text = "Running...";
            string code = _txtCodeInput.Text;
            TextWriter originalConsoleOut = Console.Out;
            using (StringWriter writer = new StringWriter())
            {
                try
                {
                    Console.SetOut(writer);
                    var options = ScriptOptions.Default.WithImports("System", "System.Collections.Generic", "System.Linq", "System.Text", "System.Windows.Forms", "System.Drawing")
                        .AddReferences(typeof(object).Assembly, typeof(Enumerable).Assembly, typeof(List<>).Assembly, typeof(MessageBox).Assembly, typeof(Point).Assembly);
                    object result = await CSharpScript.EvaluateAsync(code, options);
                    string consoleOutput = writer.ToString();
                    string resultOutput = result != null ? result.ToString() : "";
                    _txtOutput.Text = (string.IsNullOrEmpty(consoleOutput) ? "" : "--- Output ---\r\n" + consoleOutput + "\r\n") +
                                      (string.IsNullOrEmpty(resultOutput) ? "" : "--- Result ---\r\n" + resultOutput);
                }
                catch (Exception ex) { _txtOutput.Text = "Error: " + ex.Message; }
                finally { Console.SetOut(originalConsoleOut); }
            }
        }
    }
}