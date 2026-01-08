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
            btnOpenMarkdownViewer = new Button();
            btnOpenFromDatabase = new Button();
            btnOpenFromTextBox = new Button();
            txtMarkdownInput = new TextBox();
            lblTitle = new Label();
            lblInputLabel = new Label();
            panelButtons = new Panel();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // btnOpenMarkdownViewer
            // 
            btnOpenMarkdownViewer.BackColor = Color.FromArgb(52, 152, 219);
            btnOpenMarkdownViewer.FlatAppearance.BorderSize = 0;
            btnOpenMarkdownViewer.FlatStyle = FlatStyle.Flat;
            btnOpenMarkdownViewer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOpenMarkdownViewer.ForeColor = Color.White;
            btnOpenMarkdownViewer.Location = new Point(23, 27);
            btnOpenMarkdownViewer.Margin = new Padding(3, 4, 3, 4);
            btnOpenMarkdownViewer.Name = "btnOpenMarkdownViewer";
            btnOpenMarkdownViewer.Size = new Size(343, 67);
            btnOpenMarkdownViewer.TabIndex = 0;
            btnOpenMarkdownViewer.Text = "Example 1: Open with Sample Content";
            btnOpenMarkdownViewer.UseVisualStyleBackColor = false;
            btnOpenMarkdownViewer.Click += btnOpenMarkdownViewer_Click;
            // 
            // btnOpenFromDatabase
            // 
            btnOpenFromDatabase.BackColor = Color.FromArgb(46, 204, 113);
            btnOpenFromDatabase.FlatAppearance.BorderSize = 0;
            btnOpenFromDatabase.FlatStyle = FlatStyle.Flat;
            btnOpenFromDatabase.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOpenFromDatabase.ForeColor = Color.White;
            btnOpenFromDatabase.Location = new Point(23, 120);
            btnOpenFromDatabase.Margin = new Padding(3, 4, 3, 4);
            btnOpenFromDatabase.Name = "btnOpenFromDatabase";
            btnOpenFromDatabase.Size = new Size(343, 67);
            btnOpenFromDatabase.TabIndex = 1;
            btnOpenFromDatabase.Text = "Example 2: Open from Database";
            btnOpenFromDatabase.UseVisualStyleBackColor = false;
            btnOpenFromDatabase.Click += btnOpenFromDatabase_Click;
            // 
            // btnOpenFromTextBox
            // 
            btnOpenFromTextBox.BackColor = Color.FromArgb(155, 89, 182);
            btnOpenFromTextBox.FlatAppearance.BorderSize = 0;
            btnOpenFromTextBox.FlatStyle = FlatStyle.Flat;
            btnOpenFromTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOpenFromTextBox.ForeColor = Color.White;
            btnOpenFromTextBox.Location = new Point(23, 213);
            btnOpenFromTextBox.Margin = new Padding(3, 4, 3, 4);
            btnOpenFromTextBox.Name = "btnOpenFromTextBox";
            btnOpenFromTextBox.Size = new Size(343, 67);
            btnOpenFromTextBox.TabIndex = 2;
            btnOpenFromTextBox.Text = "Example 3: Open from TextBox Below";
            btnOpenFromTextBox.UseVisualStyleBackColor = false;
            btnOpenFromTextBox.Click += btnOpenFromTextBox_Click;
            // 
            // txtMarkdownInput
            // 
            txtMarkdownInput.Font = new Font("Consolas", 9.75F);
            txtMarkdownInput.Location = new Point(34, 453);
            txtMarkdownInput.Margin = new Padding(3, 4, 3, 4);
            txtMarkdownInput.Multiline = true;
            txtMarkdownInput.Name = "txtMarkdownInput";
            txtMarkdownInput.ScrollBars = ScrollBars.Vertical;
            txtMarkdownInput.Size = new Size(845, 359);
            txtMarkdownInput.TabIndex = 3;
            txtMarkdownInput.Text = "# Your Markdown Here\r\n\r\n## Try editing this!\r\n\r\nWrite your **markdown** content here and click the button above to preview it.\r\n\r\n- Item 1\r\n- Item 2\r\n- Item 3";
           // txtMarkdownInput.TextChanged += this.txtMarkdownInput_TextChanged;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(29, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(459, 37);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "MarkdownViewer Usage Examples";
            //lblTitle.Click += this.lblTitle_Click;
            // 
            // lblInputLabel
            // 
            lblInputLabel.AutoSize = true;
            lblInputLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblInputLabel.ForeColor = Color.FromArgb(44, 62, 80);
            lblInputLabel.Location = new Point(34, 413);
            lblInputLabel.Name = "lblInputLabel";
            lblInputLabel.Size = new Size(287, 25);
            lblInputLabel.TabIndex = 5;
            lblInputLabel.Text = "Enter your markdown content:";
          //  lblInputLabel.Click += this.lblInputLabel_Click;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.FromArgb(236, 240, 241);
            panelButtons.Controls.Add(btnOpenMarkdownViewer);
            panelButtons.Controls.Add(btnOpenFromDatabase);
            panelButtons.Controls.Add(btnOpenFromTextBox);
            panelButtons.Location = new Point(34, 80);
            panelButtons.Margin = new Padding(3, 4, 3, 4);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(846, 307);
            panelButtons.TabIndex = 6;
            panelButtons.Paint += panelButtons_Paint;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(914, 840);
            Controls.Add(panelButtons);
            Controls.Add(lblInputLabel);
            Controls.Add(lblTitle);
            Controls.Add(txtMarkdownInput);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MarkdownViewer Example - Form2";
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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

