using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowBasedLearningPlatform.WindowApp.Features.Lessons;
using WindowBasedLearningPlatform.WindowApp.Models.LessonsModel;
using WindowBasedLearningPlatform.WindowApp.Models.UserModel;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;
using static System.Resources.ResXFileRef;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Drawing;

namespace WindowBasedLearningPlatform.WindowApp.App.UserControls
{
    public partial class LessonViewerUserControl : UserControl
    {
        private string _language;
        private Button _activeSectionButton;
        private bool _isWebViewInitialized = false;
        private SplitContainer _layoutContainer;
        private UC_CodePlayground _activePlayground;
        private WebBrowser _contentBrowser;
        private int _currentLessonsId;
        private UserResponseModel _userResponseModel = new UserResponseModel();
        private bool _webEventsHooked = false;
        private bool _lessonReadTriggered = false;

        // Changed to EventHandler to match standard patterns
        public event EventHandler<int> QuizRequested;

        public LessonViewerUserControl(string language, UserResponseModel model)
        {
            InitializeComponent();
            InitializeAsync();
            menuPanel.AutoScroll = true;
            _language = language;
            btn_menuTitle.Text = _language;
            _userResponseModel = model;
            LoadSidebar();

            // --- Action Panel for Buttons ---
            Panel actionPanel = new Panel();
            actionPanel.Dock = DockStyle.Bottom;
            actionPanel.Height = 50;
            actionPanel.Padding = new Padding(10);
            lessonsPanel.Controls.Add(actionPanel);

            // 1. Practice Button
            Button btnPractice = new Button();
            btnPractice.Text = "💻 Open Code Playground";
            btnPractice.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            btnPractice.BackColor = Color.Orange; // Orange for practice
            btnPractice.ForeColor = Color.Black;
            btnPractice.FlatStyle = FlatStyle.Flat;
            btnPractice.FlatAppearance.BorderSize = 0;
            btnPractice.Dock = DockStyle.Left; // Dock left
            btnPractice.Width = 200;
            btnPractice.Cursor = Cursors.Hand;
            btnPractice.Click += BtnPractice_Click; // Renamed handler for clarity
            actionPanel.Controls.Add(btnPractice);

            // 2. Take Quiz Button (The code you selected)
            Button btnQuiz = new Button();
            btnQuiz.Text = "📝 Take Quiz";
            btnQuiz.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            btnQuiz.BackColor = ColorTranslator.FromHtml("#fdd23f"); // Brand Yellow
            btnQuiz.ForeColor = Color.Black;
            btnQuiz.FlatStyle = FlatStyle.Flat;
            btnQuiz.FlatAppearance.BorderSize = 0;
            btnQuiz.Dock = DockStyle.Right; // Dock right
            btnQuiz.Width = 150;
            btnQuiz.Cursor = Cursors.Hand;
            btnQuiz.Click += (s, e) => QuizRequested?.Invoke(this, _currentLessonsId); // Fire event!
            actionPanel.Controls.Add(btnQuiz);
        }

        public void SetMarkdownContent(string markdownContent)
        {
            if (_isWebViewInitialized)
            {
                LoadMarkdownContent(markdownContent); // Pass content
            }
        }

        private async void InitializeAsync()
        {
            try
            {
                await lessonsWebView.EnsureCoreWebView2Async(null);
                _isWebViewInitialized = true;
                SetupWebViewEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing WebView2: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSidebar()
        {
            menuPanel.Controls.Clear();
            List<SectionResponseModel> model = new List<SectionResponseModel>();
            var result = SelectedLessons.LoadSidebar(_language);

            Button titleButton = new Button();
            titleButton.Text = _language;
            titleButton.Width = menuPanel.Width - 10;
            titleButton.Height = 77;
            titleButton.Location = new Point(5, 10);
            titleButton.TextAlign = ContentAlignment.MiddleCenter;
            titleButton.Dock = DockStyle.Top;
            titleButton.FlatStyle = FlatStyle.Flat;
            titleButton.FlatAppearance.BorderSize = 0;
            titleButton.BackColor = Color.FromArgb(30, 30, 30);
            titleButton.ForeColor = Color.White;
            titleButton.Font = new System.Drawing.Font("Segoe UI", 11);

            menuPanel.Controls.Add(titleButton);

            if (result.Count > 0)
            {
                foreach (var sec in result)
                {
                    Button btn = new Button();
                    btn.Text = sec.SectionName;
                    btn.Tag = new SectionResponseModel
                    {
                        SectionCode = sec.SectionCode,
                        SectionId = sec.SectionId,
                    };
                    btn.Dock = DockStyle.Top;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Height = 50;
                    btn.ForeColor = Color.White;
                    btn.BackColor = Color.FromArgb(30, 30, 30);
                    btn.TextAlign = ContentAlignment.MiddleLeft;
                    btn.Font = new System.Drawing.Font("Segoe UI", 11);
                    btn.Click += SectionButton_Click;

                    menuPanel.Controls.Add(btn);
                    menuPanel.Controls.SetChildIndex(btn, 0);
                }

            }
        }

        private void SectionButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var data = (SectionResponseModel)btn.Tag;


            if (_activeSectionButton != null)
                _activeSectionButton.BackColor = Color.FromArgb(30, 30, 30);

            btn.BackColor = Color.FromArgb(50, 90, 200);
            _activeSectionButton = btn;

            LoadLessons(data.SectionCode, data.SectionId);
        }

        private async void LoadLessons(string sectionCode, int sectionId)
        {
            titlepanel.Controls.Clear();
            _lessonReadTriggered = false;

            var lessons = SelectedLessons.LoadLessons(sectionCode, sectionId);
            _currentLessonsId = lessons.LessonId;
            var lbl = new Label()
            {
                Text = $"{lessons.LessonTitle}",
                ForeColor = Color.White,
                Font = new System.Drawing.Font("Segoe UI", 20),
                AutoSize = true
            };

            titlepanel.Controls.Add(lbl);

            var lessonsContent = SelectedLessons.LoadLessonContent(lessons.LessonCode, lessons.LessonId);
            //InitializeAsync();
            LoadMarkdownContent(lessonsContent.ContentBody);
        }

        private void SetupWebViewEvents()
        {
            if (_webEventsHooked) return;
            _webEventsHooked = true;

            lessonsWebView.CoreWebView2.NavigationCompleted += (s, e) =>
            {
                InjectScrollScript();
            };

            lessonsWebView.CoreWebView2.WebMessageReceived += (s, e) =>
            {
                var message = e.TryGetWebMessageAsString();
                if (message == "LessonRead")
                {
                    HandleLessonRead();
                }
            };
        }



        private void HandleLessonRead()
        {
            if (_lessonReadTriggered) return;
            _lessonReadTriggered = true;

            UserProgress.UpdateUserProgress(_currentLessonsId, _userResponseModel.UserId);
            MessageBox.Show("Scroll bottom reached!");
        }


        private void InjectScrollScript()
        {
            lessonsWebView.ExecuteScriptAsync(@"
        function notifyRead() {
            chrome.webview.postMessage('LessonRead');
        }

        let done=false;

        function checkAutoComplete() {
            const bodyHeight = document.body.scrollHeight;
            const viewHeight = window.innerHeight;

            // content fits screen, no scroll needed
            if (bodyHeight <= viewHeight) {
                if (!done) {
                    done = true;
                    notifyRead();
                }
            }
        }

        document.addEventListener('scroll', () => {
            if(done) return;
            const scrolled = window.scrollY + window.innerHeight;
            const bottom = document.body.scrollHeight;
            if (scrolled >= bottom - 10) {
                done = true;
                notifyRead();
            }
        });

        // check after rendering finishes
        setTimeout(checkAutoComplete, 300);
    ");
        }



        private void LoadMarkdownContent(string content = null)
        {
            try
            {
                string showdownJs = GetEmbeddedResource("showdown.min.js");
                string htmlContent = GenerateHtmlContent(content, showdownJs);
                lessonsWebView.NavigateToString(htmlContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading markdown: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetEmbeddedResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourcePath = assembly.GetManifestResourceNames()
                .FirstOrDefault(r => r.EndsWith(resourceName));

            if (string.IsNullOrEmpty(resourcePath))
            {
                throw new Exception($"Embedded resource '{resourceName}' not found.");
            }

            using (Stream? stream = assembly.GetManifestResourceStream(resourcePath))
            {
                if (stream == null)
                {
                    throw new Exception($"Could not load embedded resource '{resourceName}'.");
                }

                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        // Renamed from BtnQuiz_Click to BtnPractice_Click to match logic
        private void BtnPractice_Click(object sender, EventArgs e)
        {
            // Assuming lessonsPanel is the container for content (based on your previous code)
            // Or maybe it should be lessonsWebView's parent? 
            // The previous code added btnPractice to 'lessonsPanel'.

            Panel contentPanel = lessonsPanel;

            // If playground is already open, close it (toggle)
            if (_activePlayground != null && contentPanel.Controls.Contains(_activePlayground))
            {
                contentPanel.Controls.Remove(_activePlayground);
                _activePlayground = null;
                lessonsWebView.Visible = true; // Show lesson again
                ((Button)sender).Text = "💻 Open Code Playground";
            }
            else
            {
                // Open Playground
                _activePlayground = new UC_CodePlayground();
                _activePlayground.Dock = DockStyle.Fill;

                // Hide browser temporarily
                lessonsWebView.Visible = false;

                // Add playground to panel
                contentPanel.Controls.Add(_activePlayground);
                _activePlayground.BringToFront();

                ((Button)sender).Text = "⬅ Back to Lesson";
            }
        }

        private string GenerateHtmlContent(string markdownContent, string showdownJs)
        {
            // Escape the markdown content for JavaScript
            string escapedMarkdown = (markdownContent ?? "")
                .Replace("\\", "\\\\")
                .Replace("`", "\\`")
                .Replace("${", "\\${");

            return $@"<!DOCTYPE html>
<html lang=""en"">
<head>
  <meta charset=""UTF-8"" />
  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
  <title>Markdown Viewer</title>

  <style>
    body {{
      font-family: system-ui, -apple-system, 'Segoe UI', Arial, sans-serif;
      padding: 24px;
      line-height: 1.6;
      max-width: 900px;
      margin: 0 auto;
      background: rgb(31, 41, 55);
      color: white;
    }}

    h1, h2, h3, h4, h5, h6 {{
      margin-top: 24px;
      margin-bottom: 16px;
      font-weight: 600;
      line-height: 1.25;
      color: white;
    }}

    h1 {{
      font-size: 2em;
      border-bottom: 1px solid rgba(255,255,255,0.2);
      padding-bottom: 8px;
    }}

    h2 {{
      font-size: 1.5em;
      border-bottom: 1px solid rgba(255,255,255,0.2);
      padding-bottom: 8px;
    }}

    h3 {{
      font-size: 1.25em;
    }}

    pre {{
      padding: 16px;
      overflow: auto;
      background: rgb(15, 23, 42);
      border-radius: 6px;
      font-size: 14px;
      line-height: 1.45;
      color: white;
    }}

    code {{
      background: rgb(15, 23, 42);
      border-radius: 3px;
      padding: 2px 6px;
      font-family: 'Consolas', 'Monaco', monospace;
      font-size: 85%;
      color: white;
    }}

    pre code {{
      background: transparent;
      padding: 0;
      color: white;
    }}

    table {{
      border-collapse: collapse;
      width: 100%;
      margin: 16px 0;
    }}

    th, td {{
      border: 1px solid rgba(255,255,255,0.3);
      padding: 8px 13px;
      text-align: left;
      color: white;
    }}

    th {{
      background: rgba(255,255,255,0.1);
      font-weight: 600;
    }}

    tr:nth-child(even) {{
      background: rgba(255,255,255,0.05);
    }}

    blockquote {{
      border-left: 4px solid rgba(255,255,255,0.3);
      padding-left: 16px;
      color: rgba(255,255,255,0.8);
      margin: 16px 0;
    }}

    a {{
      color: #93c5fd;
      text-decoration: none;
    }}

    a:hover {{
      text-decoration: underline;
    }}

    img {{
      max-width: 100%;
      height: auto;
    }}

    ul, ol {{
      padding-left: 2em;
      margin: 16px 0;
    }}

    li {{
      margin: 4px 0;
    }}
  </style>
</head>

<body>
  <div id=""output""></div>

  <script>
    {showdownJs}
  </script>

  <script>
    try {{
      const converter = new showdown.Converter({{
        tables: true,
        strikethrough: true,
        tasklists: true,
        simplifiedAutoLink: true,
        ghCodeBlocks: true,
        smoothLivePreview: true
      }});

      const markdownText = `{escapedMarkdown}`;
      const html = converter.makeHtml(markdownText);
      document.getElementById('output').innerHTML = html;
    }} catch (error) {{
      document.getElementById('output').innerHTML =
        '<p style=""color: red;"">Error rendering markdown: ' + error.message + '</p>';
    }}
  </script>
</body>
</html>";
        }


    }
}