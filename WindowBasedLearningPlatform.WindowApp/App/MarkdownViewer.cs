using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace WindowBasedLearningPlatform.WindowApp.App
{
    public partial class MarkdownViewer : Form
    {
        private string _markdownContent;
        private bool _isWebViewInitialized = false;

        /// <summary>
        /// Constructor that requires markdown content to display
        /// </summary>
        /// <param name="markdownContent">The markdown text to display</param>
        public MarkdownViewer(string markdownContent)
        {
            _markdownContent = markdownContent;
            InitializeComponent();
            InitializeAsync();
        }

        /// <summary>
        /// Set or update the markdown content to display
        /// </summary>
        /// <param name="markdownContent">The markdown text to display</param>
        public void SetMarkdownContent(string markdownContent)
        {
            _markdownContent = markdownContent;
            if (_isWebViewInitialized)
            {
                LoadMarkdownContent();
            }
        }

        private async void InitializeAsync()
        {
            try
            {
                await webView.EnsureCoreWebView2Async(null);
                _isWebViewInitialized = true;

                // Load the markdown content
                LoadMarkdownContent();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing WebView2: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMarkdownContent()
        {
            try
            {
                string showdownJs = GetEmbeddedResource("showdown.min.js");
                string htmlContent = GenerateHtmlContent(_markdownContent, showdownJs);
                webView.NavigateToString(htmlContent);
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

        private string GenerateHtmlContent(string markdownContent, string showdownJs)
        {
            // Escape the markdown content for JavaScript
            string escapedMarkdown = markdownContent
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
      background: #ffffff;
      color: #333;
    }}
    h1, h2, h3, h4, h5, h6 {{ 
      margin-top: 24px; 
      margin-bottom: 16px;
      font-weight: 600;
      line-height: 1.25;
    }}
    h1 {{ font-size: 2em; border-bottom: 1px solid #eaecef; padding-bottom: 8px; }}
    h2 {{ font-size: 1.5em; border-bottom: 1px solid #eaecef; padding-bottom: 8px; }}
    h3 {{ font-size: 1.25em; }}
    pre {{ 
      padding: 16px; 
      overflow: auto; 
      background: #f6f8fa;
      border-radius: 6px;
      font-size: 14px;
      line-height: 1.45;
    }}
    code {{ 
      background: #f6f8fa; 
      border-radius: 3px;
      padding: 2px 6px;
      font-family: 'Consolas', 'Monaco', monospace;
      font-size: 85%;
    }}
    pre code {{
      background: transparent;
      padding: 0;
    }}
    table {{ 
      border-collapse: collapse; 
      width: 100%; 
      margin: 16px 0;
    }}
    th, td {{ 
      border: 1px solid #dfe2e5; 
      padding: 8px 13px; 
      text-align: left;
    }}
    th {{
      background: #f6f8fa;
      font-weight: 600;
    }}
    tr:nth-child(even) {{
      background: #f6f8fa;
    }}
    blockquote {{ 
      border-left: 4px solid #dfe2e5; 
      padding-left: 16px; 
      margin-left: 0; 
      color: #6a737d;
      margin: 16px 0;
    }}
    a {{
      color: #0366d6;
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
      document.getElementById('output').innerHTML = '<p style=""color: red;"">Error rendering markdown: ' + error.message + '</p>';
    }}
  </script>
</body>
</html>";
        }
    }
}
