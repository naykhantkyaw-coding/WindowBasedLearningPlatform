namespace WindowBasedLearningPlatform.WindowApp.App
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenMarkdownViewer = new System.Windows.Forms.Button();
            this.btnOpenFromDatabase = new System.Windows.Forms.Button();
            this.btnOpenFromTextBox = new System.Windows.Forms.Button();
            this.txtMarkdownInput = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInputLabel = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenMarkdownViewer
            // 
            this.btnOpenMarkdownViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnOpenMarkdownViewer.FlatAppearance.BorderSize = 0;
            this.btnOpenMarkdownViewer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenMarkdownViewer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOpenMarkdownViewer.ForeColor = System.Drawing.Color.White;
            this.btnOpenMarkdownViewer.Location = new System.Drawing.Point(20, 20);
            this.btnOpenMarkdownViewer.Name = "btnOpenMarkdownViewer";
            this.btnOpenMarkdownViewer.Size = new System.Drawing.Size(300, 50);
            this.btnOpenMarkdownViewer.TabIndex = 0;
            this.btnOpenMarkdownViewer.Text = "Example 1: Open with Sample Content";
            this.btnOpenMarkdownViewer.UseVisualStyleBackColor = false;
            this.btnOpenMarkdownViewer.Click += new System.EventHandler(this.btnOpenMarkdownViewer_Click);
            // 
            // btnOpenFromDatabase
            // 
            this.btnOpenFromDatabase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnOpenFromDatabase.FlatAppearance.BorderSize = 0;
            this.btnOpenFromDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFromDatabase.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOpenFromDatabase.ForeColor = System.Drawing.Color.White;
            this.btnOpenFromDatabase.Location = new System.Drawing.Point(20, 90);
            this.btnOpenFromDatabase.Name = "btnOpenFromDatabase";
            this.btnOpenFromDatabase.Size = new System.Drawing.Size(300, 50);
            this.btnOpenFromDatabase.TabIndex = 1;
            this.btnOpenFromDatabase.Text = "Example 2: Open from Database";
            this.btnOpenFromDatabase.UseVisualStyleBackColor = false;
            this.btnOpenFromDatabase.Click += new System.EventHandler(this.btnOpenFromDatabase_Click);
            // 
            // btnOpenFromTextBox
            // 
            this.btnOpenFromTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnOpenFromTextBox.FlatAppearance.BorderSize = 0;
            this.btnOpenFromTextBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFromTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOpenFromTextBox.ForeColor = System.Drawing.Color.White;
            this.btnOpenFromTextBox.Location = new System.Drawing.Point(20, 160);
            this.btnOpenFromTextBox.Name = "btnOpenFromTextBox";
            this.btnOpenFromTextBox.Size = new System.Drawing.Size(300, 50);
            this.btnOpenFromTextBox.TabIndex = 2;
            this.btnOpenFromTextBox.Text = "Example 3: Open from TextBox Below";
            this.btnOpenFromTextBox.UseVisualStyleBackColor = false;
            this.btnOpenFromTextBox.Click += new System.EventHandler(this.btnOpenFromTextBox_Click);
            // 
            // txtMarkdownInput
            // 
            this.txtMarkdownInput.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtMarkdownInput.Location = new System.Drawing.Point(30, 340);
            this.txtMarkdownInput.Multiline = true;
            this.txtMarkdownInput.Name = "txtMarkdownInput";
            this.txtMarkdownInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMarkdownInput.Size = new System.Drawing.Size(740, 270);
            this.txtMarkdownInput.TabIndex = 3;
            this.txtMarkdownInput.Text = "# Your Markdown Here\r\n\r\n## Try editing this!\r\n\r\nWrite your **markdown** cont" +
    "ent here and click the button above to preview it.\r\n\r\n- Item 1\r\n- Item 2\r\n- Ite" +
    "m 3";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(352, 30);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "MarkdownViewer Usage Examples";
            // 
            // lblInputLabel
            // 
            this.lblInputLabel.AutoSize = true;
            this.lblInputLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblInputLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblInputLabel.Location = new System.Drawing.Point(30, 310);
            this.lblInputLabel.Name = "lblInputLabel";
            this.lblInputLabel.Size = new System.Drawing.Size(238, 20);
            this.lblInputLabel.TabIndex = 5;
            this.lblInputLabel.Text = "Enter your markdown content:";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelButtons.Controls.Add(this.btnOpenMarkdownViewer);
            this.panelButtons.Controls.Add(this.btnOpenFromDatabase);
            this.panelButtons.Controls.Add(this.btnOpenFromTextBox);
            this.panelButtons.Location = new System.Drawing.Point(30, 60);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(740, 230);
            this.panelButtons.TabIndex = 6;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 630);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.lblInputLabel);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtMarkdownInput);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MarkdownViewer Example - Form2";
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnOpenMarkdownViewer;
        private System.Windows.Forms.Button btnOpenFromDatabase;
        private System.Windows.Forms.Button btnOpenFromTextBox;
        private System.Windows.Forms.TextBox txtMarkdownInput;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInputLabel;
        private System.Windows.Forms.Panel panelButtons;
    }
}

