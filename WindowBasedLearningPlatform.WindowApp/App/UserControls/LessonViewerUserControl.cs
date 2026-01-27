using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WindowBasedLearningPlatform.WindowApp.Features.Lessons;
using WindowBasedLearningPlatform.WindowApp.Models.LessonsModel;
using WindowBasedLearningPlatform.WindowApp.Models.UserModel;

namespace WindowBasedLearningPlatform.WindowApp.App.UserControls
{
    public partial class LessonViewerUserControl : UserControl
    {
        private string _language;
        private Button _activeSectionButton;
        private bool _isWebViewInitialized = false;

        // Main Layout: Left=Menu, Right=Content
        private SplitContainer _layoutContainer;

        // Content Layout: Top=Lesson, Bottom=Playground (or Left/Right)
        private SplitContainer _contentSplitContainer;

        private UC_CodePlayground _activePlayground;
        // private WebBrowser _contentBrowser; // Replaced by WebView2 in your code 'lessonsWebView'

        private int _currentLessonId;
        private UserResponseModel _userResponseModel = new UserResponseModel();
        private bool _webEventsHooked = false;
        private bool _lessonReadTriggered = false;
        private DateTime _lessonStartTime;


        public event EventHandler<int> QuizRequested;

        public LessonViewerUserControl(string language, UserResponseModel model)
        {
            InitializeComponent();
            InitializeAsync();
            menuPanel.AutoScroll = true;
            _language = language;
            btn_menuTitle.Text = _language;
            _userResponseModel = model;

            // 1. Re-structuring the Layout
            CreateSplitLayout();

            LoadSidebar();

            // --- Action Panel ---
            Panel actionPanel = new Panel();
            actionPanel.Dock = DockStyle.Bottom;
            actionPanel.Height = 50;
            actionPanel.Padding = new Padding(10);
            lessonsPanel.Controls.Add(actionPanel);
            actionPanel.BringToFront(); // Ensure it's at the bottom

            // 1. Practice Button (Toggle)
            Button btnPractice = new Button();
            btnPractice.Text = "💻 Open Playground Split-View";
            btnPractice.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            btnPractice.BackColor = Color.Orange;
            btnPractice.ForeColor = Color.Black;
            btnPractice.FlatStyle = FlatStyle.Flat;
            btnPractice.FlatAppearance.BorderSize = 0;
            btnPractice.Dock = DockStyle.Left;
            btnPractice.Width = 220;
            btnPractice.Cursor = Cursors.Hand;
            btnPractice.Click += BtnPractice_Click;
            actionPanel.Controls.Add(btnPractice);

            // 2. Take Quiz Button
            Button btnQuiz = new Button();
            btnQuiz.Text = "📝 Take Quiz";
            btnQuiz.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            btnQuiz.BackColor = ColorTranslator.FromHtml("#fdd23f");
            btnQuiz.ForeColor = Color.Black;
            btnQuiz.FlatStyle = FlatStyle.Flat;
            btnQuiz.FlatAppearance.BorderSize = 0;
            btnQuiz.Dock = DockStyle.Right;
            btnQuiz.Width = 150;
            btnQuiz.Cursor = Cursors.Hand;
            btnQuiz.Click += (s, e) =>
            {
                // Close playground if open to focus on quiz
                if (!_contentSplitContainer.Panel2Collapsed)
                {
                    _contentSplitContainer.Panel2Collapsed = true;
                    btnPractice.Text = "💻 Open Playground Split-View";
                }
                QuizRequested?.Invoke(this, _currentLessonId);
            };
            actionPanel.Controls.Add(btnQuiz);
        }

        private void CreateSplitLayout()
        {
            // 1. Create the SplitContainer
            _contentSplitContainer = new SplitContainer();
            _contentSplitContainer.Dock = DockStyle.Fill;
            _contentSplitContainer.Orientation = Orientation.Vertical; // Side by Side

            // Adjust Splitter Distance: Give Lesson Viewer ~60-70% space
            // Assuming default width ~900-1000px.
            // Using a percentage approach isn't directly supported by SplitterDistance (pixels only),
            // but we can set a reasonable default or handle Resize.
            // Let's set it to 600 which is roughly 2/3 of a standard 900-1000px form width.
            _contentSplitContainer.SplitterDistance = 600;

            // 2. Add it to the main lessonsPanel
            lessonsPanel.Controls.Add(_contentSplitContainer);
            _contentSplitContainer.BringToFront();

            // 3. Move WebView2 to Panel1 (Left)
            lessonsWebView.Parent = _contentSplitContainer.Panel1;
            lessonsWebView.Dock = DockStyle.Fill;

            // 4. Initialize Playground in Panel2 (Right)
            _activePlayground = new UC_CodePlayground();
            _activePlayground.Dock = DockStyle.Fill;
            _contentSplitContainer.Panel2.Controls.Add(_activePlayground);

            // 5. Start Collapsed (Hidden)
            _contentSplitContainer.Panel2Collapsed = true;

            // Handle Resize to maintain ratio (Optional polish)
            this.Resize += (s, e) => {
                if (!_contentSplitContainer.Panel2Collapsed && this.Width > 200)
                {
                    // Keep ratio roughly 60/40
                    try { _contentSplitContainer.SplitterDistance = (int)(this.Width * 0.6); } catch { }
                }
            };
        }

        public void SetMarkdownContent(string markdownContent)
        {
            if (_isWebViewInitialized) LoadMarkdownContent(markdownContent);
        }

        private async void InitializeAsync()
        {
            try
            {
                await lessonsWebView.EnsureCoreWebView2Async(null);
                _isWebViewInitialized = true;
                SetupWebViewEvents();
            }
            catch (Exception ex) { MessageBox.Show($"WebView2 Error: {ex.Message}"); }
        }

        private void LoadSidebar()
        {
            menuPanel.Controls.Clear();
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
                    btn.Tag = new SectionResponseModel { SectionCode = sec.SectionCode, SectionId = sec.SectionId };
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
            if (_activeSectionButton != null) _activeSectionButton.BackColor = Color.FromArgb(30, 30, 30);
            btn.BackColor = Color.FromArgb(50, 90, 200);
            _activeSectionButton = btn;
            LoadLessons(data.SectionCode, data.SectionId);
        }

        private void LoadLessons(string sectionCode, int sectionId)
        {
            titlepanel.Controls.Clear();
            _lessonReadTriggered = false;
            _lessonStartTime = DateTime.Now;
            var lessons = SelectedLessons.LoadLessons(sectionCode, sectionId);
            _currentLessonId = lessons.LessonId;


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
            LoadMarkdownContent(lessonsContent.ContentBody);
        }

        private void SetupWebViewEvents()
        {
            if (_webEventsHooked) return;
            _webEventsHooked = true;
            lessonsWebView.CoreWebView2.NavigationCompleted += (s, e) => InjectScrollScript();
            lessonsWebView.CoreWebView2.WebMessageReceived += (s, e) =>
            {
                var message = e.TryGetWebMessageAsString();
                if (message == "LessonRead") HandleLessonRead();
            };
        }

        private void SaveLessonDuration()
        {
            var endTime = DateTime.Now;
            var duration = endTime - _lessonStartTime;

            var minutes = (int)duration.TotalMinutes;
            var seconds = (int)duration.TotalSeconds;

            UserProgress.AddTime(_currentLessonsId, _userResponseModel.UserId, minutes);
        }


        private void HandleLessonRead()
        {
            if (_lessonReadTriggered) return;
            _lessonReadTriggered = true;

            UserProgress.UpdateUserProgress(_currentLessonsId, _userResponseModel.UserId,_language);
            SaveLessonDuration();
            // MessageBox.Show("Scroll bottom reached!");
        }

        private void InjectScrollScript()
        {
            lessonsWebView.ExecuteScriptAsync(@"
                function notifyRead() { chrome.webview.postMessage('LessonRead'); }
                let done=false;
                function checkAutoComplete() {
                    const bodyHeight = document.body.scrollHeight;
                    const viewHeight = window.innerHeight;
                    if (bodyHeight <= viewHeight) { if (!done) { done = true; notifyRead(); } }
                }
                document.addEventListener('scroll', () => {
                    if(done) return;
                    const scrolled = window.scrollY + window.innerHeight;
                    const bottom = document.body.scrollHeight;
                    if (scrolled >= bottom - 10) { done = true; notifyRead(); }
                });
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
                MessageBox.Show($"Error loading markdown: {ex.Message}");
            }
        }

        private string GetEmbeddedResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourcePath = assembly.GetManifestResourceNames().FirstOrDefault(r => r.EndsWith(resourceName));
            if (string.IsNullOrEmpty(resourcePath)) throw new Exception($"Embedded resource '{resourceName}' not found.");
            using (var stream = assembly.GetManifestResourceStream(resourcePath))
            using (var reader = new System.IO.StreamReader(stream)) return reader.ReadToEnd();
        }

        private string GenerateHtmlContent(string markdownContent, string showdownJs)
        {
            string escapedMarkdown = (markdownContent ?? "").Replace("\\", "\\\\").Replace("`", "\\`").Replace("${", "\\${");
            return $@"<!DOCTYPE html>
<html lang=""en"">
<head>
  <meta charset=""UTF-8"" />
  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
  <style>
    body {{ font-family: 'Segoe UI', Arial, sans-serif; padding: 24px; background: rgb(31, 41, 55); color: white; }}
    pre {{ background: rgb(15, 23, 42); padding: 16px; border-radius: 6px; overflow: auto; }}
    code {{ background: rgb(15, 23, 42); padding: 2px 6px; border-radius: 3px; font-family: monospace; }}
  </style>
</head>
<body>
  <div id=""output""></div>
  <script>{showdownJs}</script>
  <script>
    try {{
      const converter = new showdown.Converter({{ tables: true, ghCodeBlocks: true }});
      const html = converter.makeHtml(`{escapedMarkdown}`);
      document.getElementById('output').innerHTML = html;
    }} catch (e) {{ document.getElementById('output').innerHTML = e.message; }}
  </script>
</body>
</html>";
        }

        private void BtnPractice_Click(object sender, EventArgs e)
        {
            _contentSplitContainer.Panel2Collapsed = !_contentSplitContainer.Panel2Collapsed;
            Button btn = sender as Button;
            if (_contentSplitContainer.Panel2Collapsed)
            {
                btn.Text = "💻 Open Playground Split-View";
            }
            else
            {
                btn.Text = "🚫 Close Playground";
                // Optionally adjust splitter here if needed on open
                // _contentSplitContainer.SplitterDistance = (int)(lessonsPanel.Width * 0.6);
            }
        }
    }
}