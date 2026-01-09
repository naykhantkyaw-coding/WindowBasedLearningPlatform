using System.Windows.Forms;
using System.Drawing;

namespace WindowBasedLearningPlatform.WindowApp.App.UserControls
{
    partial class UC_LessonViewer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Controls managed by the Designer
        private SplitContainer _layoutContainer;
        private Label _contentTitle;
        private WebBrowser _contentBrowser;
        private Button _btnPractice; // Promoted from local variable to field
        private Label _lblListHeader; // Promoted to field to set text in code-behind

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._layoutContainer = new System.Windows.Forms.SplitContainer();
            this._lblListHeader = new System.Windows.Forms.Label();
            this._contentTitle = new System.Windows.Forms.Label();
            this._contentBrowser = new System.Windows.Forms.WebBrowser();
            this._btnPractice = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._layoutContainer)).BeginInit();
            this._layoutContainer.Panel1.SuspendLayout();
            this._layoutContainer.Panel2.SuspendLayout();
            this._layoutContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // _layoutContainer
            // 
            this._layoutContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._layoutContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._layoutContainer.IsSplitterFixed = true;
            this._layoutContainer.Location = new System.Drawing.Point(0, 0);
            this._layoutContainer.Name = "_layoutContainer";
            // 
            // _layoutContainer.Panel1
            // 
            this._layoutContainer.Panel1.Controls.Add(this._lblListHeader);
            this._layoutContainer.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // _layoutContainer.Panel2
            // 
            this._layoutContainer.Panel2.Controls.Add(this._contentBrowser);
            this._layoutContainer.Panel2.Controls.Add(this._btnPractice);
            this._layoutContainer.Panel2.Controls.Add(this._contentTitle);
            this._layoutContainer.Panel2.Padding = new System.Windows.Forms.Padding(30);
            this._layoutContainer.Size = new System.Drawing.Size(800, 600);
            this._layoutContainer.SplitterDistance = 250;
            this._layoutContainer.SplitterWidth = 1;
            this._layoutContainer.TabIndex = 0;
            // 
            // _lblListHeader
            // 
            this._lblListHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this._lblListHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this._lblListHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._lblListHeader.Location = new System.Drawing.Point(10, 10);
            this._lblListHeader.Name = "_lblListHeader";
            this._lblListHeader.Size = new System.Drawing.Size(230, 40);
            this._lblListHeader.TabIndex = 0;
            this._lblListHeader.Text = "Lessons"; // Default text, updated in Constructor
            // 
            // _contentTitle
            // 
            this._contentTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this._contentTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this._contentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this._contentTitle.Location = new System.Drawing.Point(30, 30);
            this._contentTitle.Name = "_contentTitle";
            this._contentTitle.Size = new System.Drawing.Size(489, 50);
            this._contentTitle.TabIndex = 0;
            this._contentTitle.Text = "Select a lesson to start";
            // 
            // _contentBrowser
            // 
            this._contentBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this._contentBrowser.IsWebBrowserContextMenuEnabled = false;
            this._contentBrowser.Location = new System.Drawing.Point(30, 80);
            this._contentBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this._contentBrowser.Name = "_contentBrowser";
            this._contentBrowser.Size = new System.Drawing.Size(489, 450);
            this._contentBrowser.TabIndex = 2;
            // 
            // _btnPractice
            // 
            this._btnPractice.BackColor = System.Drawing.ColorTranslator.FromHtml("#fdd23f");
            this._btnPractice.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnPractice.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._btnPractice.FlatAppearance.BorderSize = 0;
            this._btnPractice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnPractice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._btnPractice.ForeColor = System.Drawing.Color.Black;
            this._btnPractice.Location = new System.Drawing.Point(30, 530);
            this._btnPractice.Name = "_btnPractice";
            this._btnPractice.Size = new System.Drawing.Size(489, 40);
            this._btnPractice.TabIndex = 1;
            this._btnPractice.Text = "💻 Open Code Playground";
            this._btnPractice.UseVisualStyleBackColor = false;
            this._btnPractice.Click += new System.EventHandler(this.BtnPractice_Click);
            // 
            // UC_LessonViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._layoutContainer);
            this.Name = "UC_LessonViewer";
            this.Size = new System.Drawing.Size(800, 600);
            this._layoutContainer.Panel1.ResumeLayout(false);
            this._layoutContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._layoutContainer)).EndInit();
            this._layoutContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}