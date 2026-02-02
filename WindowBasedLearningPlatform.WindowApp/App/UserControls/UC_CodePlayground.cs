using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowBasedLearningPlatform.WindowApp.Services;

namespace WindowBasedLearningPlatform.WindowApp.App.UserControls
{
    public partial class UC_CodePlayground : UserControl
    {
        private RichTextBox _txtCodeInput;
        private RichTextBox _txtOutput; // Changed to RichTextBox for better formatting/visibility
        private Button _btnRun;
        private Button _btnClose;

        // AI Integration
        private readonly OllamaService _aiService;
        private Button _btnAiExplain;

        // Zoom Slider
        private TrackBar _zoomSlider;
        private Label _lblZoom;

        public event EventHandler RequestClose;

        public UC_CodePlayground()
        {
            InitializeComponent();
            _aiService = new OllamaService("codellama");
            SetupUI();
        }

        private void SetupUI()
        {
            // Clear any default designer controls to prevent conflicts
            this.Controls.Clear();

            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            // 1. Main Split Container
            SplitContainer split = new SplitContainer();
            split.Dock = DockStyle.Fill;
            split.Orientation = Orientation.Horizontal;
            split.FixedPanel = FixedPanel.Panel2; // Output panel stays stable on resize
            this.Controls.Add(split);

            // --- INPUT PANEL (Top - Panel1) ---
            Panel inputPanel = new Panel();
            inputPanel.Dock = DockStyle.Fill;
            split.Panel1.Controls.Add(inputPanel);

            // 2. Define Input Controls

            // Header (Top)
            Panel headerPanel = new Panel();
            headerPanel.Height = 40;
            headerPanel.BackColor = Color.FromArgb(245, 245, 245);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Padding = new Padding(10, 0, 10, 0);

            Label lblCode = new Label();
            lblCode.Text = "Code Editor (C#)";
            lblCode.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblCode.Dock = DockStyle.Left;
            lblCode.AutoSize = true;
            lblCode.TextAlign = ContentAlignment.MiddleLeft;
            // Center vert workaround
            lblCode.Padding = new Padding(0, 10, 0, 0);

            headerPanel.Controls.Add(lblCode);

            _btnClose = new Button();
            _btnClose.Text = "❌ Close";
            _btnClose.ForeColor = Color.Red;
            _btnClose.FlatStyle = FlatStyle.Flat;
            _btnClose.FlatAppearance.BorderSize = 0;
            _btnClose.Dock = DockStyle.Right;
            _btnClose.Width = 80;
            _btnClose.Cursor = Cursors.Hand;
            _btnClose.Click += (s, e) => RequestClose?.Invoke(this, EventArgs.Empty);
            headerPanel.Controls.Add(_btnClose);

            // Footer / Controls (Bottom)
            Panel controlsPanel = new Panel();
            controlsPanel.Height = 50;
            controlsPanel.BackColor = Color.WhiteSmoke;
            controlsPanel.Dock = DockStyle.Bottom;
            controlsPanel.Padding = new Padding(10, 5, 10, 5);

            _btnRun = new Button();
            _btnRun.Text = "▶ Run Code";
            _btnRun.BackColor = Color.FromArgb(76, 175, 80); // Green
            _btnRun.ForeColor = Color.White;
            _btnRun.FlatStyle = FlatStyle.Flat;
            _btnRun.Size = new Size(100, 30);
            _btnRun.Dock = DockStyle.Right;
            _btnRun.Cursor = Cursors.Hand;
            _btnRun.Click += BtnRun_Click;
            controlsPanel.Controls.Add(_btnRun);

            _btnAiExplain = new Button();
            _btnAiExplain.Text = "🤖 Explain with AI";
            _btnAiExplain.BackColor = Color.DodgerBlue;
            _btnAiExplain.ForeColor = Color.White;
            _btnAiExplain.FlatStyle = FlatStyle.Flat;
            _btnAiExplain.Size = new Size(130, 30);
            _btnAiExplain.Dock = DockStyle.Left;
            _btnAiExplain.Cursor = Cursors.Hand;
            _btnAiExplain.Click += BtnAiExplain_Click;
            controlsPanel.Controls.Add(_btnAiExplain);

            // Zoom Slider Panel
            Panel zoomPanel = new Panel();
            zoomPanel.Width = 200;
            zoomPanel.Dock = DockStyle.Right;
            zoomPanel.Padding = new Padding(10, 0, 10, 0);

            _lblZoom = new Label();
            _lblZoom.Text = "Zoom";
            _lblZoom.AutoSize = true;
            _lblZoom.Dock = DockStyle.Left;
            _lblZoom.TextAlign = ContentAlignment.MiddleRight;
            _lblZoom.Padding = new Padding(0, 8, 0, 0);

            _zoomSlider = new TrackBar();
            _zoomSlider.Minimum = 5;
            _zoomSlider.Maximum = 50;
            _zoomSlider.Value = 10;
            _zoomSlider.TickStyle = TickStyle.None;
            _zoomSlider.Dock = DockStyle.Fill;
            _zoomSlider.Scroll += (s, e) => {
                if (_txtCodeInput != null)
                {
                    float zoom = _zoomSlider.Value / 10f;
                    if (zoom <= 0.1f) zoom = 0.1f;
                    _txtCodeInput.ZoomFactor = zoom;
                }
            };

            zoomPanel.Controls.Add(_zoomSlider);
            zoomPanel.Controls.Add(_lblZoom);
            controlsPanel.Controls.Add(zoomPanel);

            // Editor Container (Fill) - Wrapper to prevent Header overlap
            Panel editorContainer = new Panel();
            editorContainer.Dock = DockStyle.Fill;
            editorContainer.Padding = new Padding(0);

            _txtCodeInput = new RichTextBox();
            _txtCodeInput.Dock = DockStyle.Fill;
            _txtCodeInput.Font = new Font("Consolas", 11);
            _txtCodeInput.BackColor = Color.FromArgb(30, 30, 30); // Dark Theme
            _txtCodeInput.ForeColor = Color.White;
            _txtCodeInput.BorderStyle = BorderStyle.None;
            _txtCodeInput.Text = "// Type your C# code here...\nConsole.WriteLine(\"Hello from AI-Powered Learning Platform!\");";
            _txtCodeInput.AcceptsTab = true;

            editorContainer.Controls.Add(_txtCodeInput);

            // 3. Assemble Input Panel - Add Dock.Top/Bottom FIRST to ensure they cut space correctly
            // Actually, adding them to Controls collection: Index 0 is Top Priority.
            // We add Header (Index 0), Footer (Index 0 -> Header=1), Editor (Index 0 -> Footer=1 -> Header=2)
            // Wait, to get Top/Bottom priority, controls should be at the FRONT of Z-Order (Index 0).

            inputPanel.Controls.Add(editorContainer);
            inputPanel.Controls.Add(controlsPanel);
            inputPanel.Controls.Add(headerPanel);

            // Explicitly set Z-Order: Header (Top) -> Footer (Bottom) -> Editor (Fill)
            headerPanel.BringToFront();
            controlsPanel.BringToFront(); // If we bring footer to front now, it becomes index 0. Header becomes 1. 
            // Layout priority: Index 0 takes slice. Index 1 takes slice of remainder.
            // Either order of Header/Footer works as long as they are before Editor.
            // Editor is implicitly at back now.

            // --- OUTPUT PANEL (Bottom - Panel2) ---
            Panel outputPanel = new Panel();
            outputPanel.Dock = DockStyle.Fill;
            outputPanel.Padding = new Padding(0);
            split.Panel2.Controls.Add(outputPanel);

            // Header for Output
            Panel outputHeader = new Panel();
            outputHeader.Dock = DockStyle.Top;
            outputHeader.Height = 30;
            outputHeader.BackColor = Color.FromArgb(230, 230, 230);
            outputHeader.Padding = new Padding(5);

            Label lblOutput = new Label();
            lblOutput.Text = "Output / Result";
            lblOutput.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblOutput.Dock = DockStyle.Left;
            lblOutput.AutoSize = true;
            outputHeader.Controls.Add(lblOutput);

            outputPanel.Controls.Add(outputHeader);

            // Output TextBox
            _txtOutput = new RichTextBox();
            _txtOutput.ReadOnly = true;
            _txtOutput.Dock = DockStyle.Fill;
            _txtOutput.Font = new Font("Consolas", 10);
            _txtOutput.BackColor = Color.FromArgb(240, 240, 240);
            _txtOutput.ForeColor = Color.Black;
            _txtOutput.BorderStyle = BorderStyle.None;
            _txtOutput.ScrollBars = RichTextBoxScrollBars.Vertical;

            outputPanel.Controls.Add(_txtOutput);

            outputHeader.BringToFront();
            _txtOutput.SendToBack();

            // 4. Set Splitter Distance Logic - Use percentage to be safe
            // If control is not visible yet, Height might be default.
            int defaultHeight = this.Height > 0 ? this.Height : 500;
            split.SplitterDistance = (int)(defaultHeight * 0.75); // 75% Code, 25% Output
        }

        private async void BtnRun_Click(object sender, EventArgs e)
        {
            _txtOutput.Clear();
            _txtOutput.AppendText("Compiling and Running...\n");

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
                    string resultOutput = result != null ? result.ToString() : "null";

                    _txtOutput.AppendText("--- Output ---\n");
                    if (!string.IsNullOrEmpty(consoleOutput))
                        _txtOutput.AppendText(consoleOutput + "\n");
                    else
                        _txtOutput.AppendText("(No Console Output)\n");

                    _txtOutput.AppendText("--- Result ---\n");
                    _txtOutput.AppendText(resultOutput);
                }
                catch (Exception ex)
                {
                    _txtOutput.AppendText("\n[Error]\n" + ex.Message);
                }
                finally
                {
                    Console.SetOut(originalConsoleOut);
                    _txtOutput.AppendText("\n\nExecution Finished.");
                    _txtOutput.SelectionStart = _txtOutput.Text.Length;
                    _txtOutput.ScrollToCaret();
                }
            }
        }

        private async void BtnAiExplain_Click(object sender, EventArgs e)
        {
            _btnAiExplain.Enabled = false;
            _btnAiExplain.Text = "Connecting...";

            try
            {
                string code = _txtCodeInput?.Text ?? "";
                if (string.IsNullOrWhiteSpace(code))
                {
                    MessageBox.Show("Please enter some code to explain.", "Empty Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool isRunning = await _aiService.IsRunningAsync();
                if (!isRunning)
                {
                    MessageBox.Show("Could not connect to Ollama (http://127.0.0.1:11434).\nPlease ensure 'ollama serve' is running.", "AI Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _btnAiExplain.Text = "Thinking...";
                string explanation = await _aiService.GetCodeExplanationAsync(code);

                // For now, show in MessageBox, or we could pipe it to output
                MessageBox.Show(explanation, "AI Tutor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"AI Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_btnAiExplain != null)
                {
                    _btnAiExplain.Enabled = true;
                    _btnAiExplain.Text = "🤖 Explain with AI";
                }
            }
        }
    }
}