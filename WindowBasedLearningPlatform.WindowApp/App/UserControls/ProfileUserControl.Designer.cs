namespace WindowBasedLearningPlatform.WindowApp.App.UserControls
{
    partial class ProfileUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileUserControl));
            lblProfile = new Label();
            panelProfileCard = new Panel();
            lblCreatedDate = new Label();
            lblUserName = new Label();
            label2 = new Label();
            label1 = new Label();
            panelAvata = new Panel();
            lblAvatar = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panelScore = new Panel();
            lblQuizScore = new Label();
            label5 = new Label();
            pictureBox2 = new PictureBox();
            panelCourse = new Panel();
            lblCourse = new Label();
            label3 = new Label();
            pictureBox3 = new PictureBox();
            panelHour = new Panel();
            lblHour = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            panelProfileCard.SuspendLayout();
            panelAvata.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panelScore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelCourse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panelHour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblProfile
            // 
            lblProfile.AutoSize = true;
            lblProfile.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblProfile.ForeColor = Color.White;
            lblProfile.Location = new Point(96, 25);
            lblProfile.Name = "lblProfile";
            lblProfile.Size = new Size(165, 41);
            lblProfile.TabIndex = 0;
            lblProfile.Text = "My Profile";
            // 
            // panelProfileCard
            // 
            panelProfileCard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelProfileCard.BackColor = Color.FromArgb(31, 41, 55);
            panelProfileCard.Controls.Add(lblCreatedDate);
            panelProfileCard.Controls.Add(lblUserName);
            panelProfileCard.Controls.Add(label2);
            panelProfileCard.Controls.Add(label1);
            panelProfileCard.Controls.Add(panelAvata);
            panelProfileCard.Location = new Point(96, 96);
            panelProfileCard.Margin = new Padding(26, 0, 26, 0);
            panelProfileCard.Name = "panelProfileCard";
            panelProfileCard.Padding = new Padding(26, 0, 26, 0);
            panelProfileCard.Size = new Size(738, 120);
            panelProfileCard.TabIndex = 1;
            // 
            // lblCreatedDate
            // 
            lblCreatedDate.AutoSize = true;
            lblCreatedDate.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCreatedDate.ForeColor = Color.White;
            lblCreatedDate.Location = new Point(235, 62);
            lblCreatedDate.Name = "lblCreatedDate";
            lblCreatedDate.Size = new Size(0, 19);
            lblCreatedDate.TabIndex = 6;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.ForeColor = Color.White;
            lblUserName.Location = new Point(220, 40);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(0, 19);
            lblUserName.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(116, 62);
            label2.Name = "label2";
            label2.Size = new Size(109, 19);
            label2.TabIndex = 4;
            label2.Text = "Member Since:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(116, 40);
            label1.Name = "label1";
            label1.Size = new Size(95, 19);
            label1.TabIndex = 2;
            label1.Text = "User Name : ";
            // 
            // panelAvata
            // 
            panelAvata.BackColor = Color.FromArgb(253, 210, 63);
            panelAvata.Controls.Add(lblAvatar);
            panelAvata.Location = new Point(29, 28);
            panelAvata.Margin = new Padding(3, 2, 3, 2);
            panelAvata.Name = "panelAvata";
            panelAvata.Size = new Size(70, 60);
            panelAvata.TabIndex = 3;
            // 
            // lblAvatar
            // 
            lblAvatar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblAvatar.AutoSize = true;
            lblAvatar.BackColor = Color.FromArgb(253, 210, 63);
            lblAvatar.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAvatar.ForeColor = Color.White;
            lblAvatar.Location = new Point(18, 13);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(33, 37);
            lblAvatar.TabIndex = 2;
            lblAvatar.Text = "T";
            lblAvatar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(panelScore, 2, 0);
            tableLayoutPanel1.Controls.Add(panelCourse, 0, 0);
            tableLayoutPanel1.Controls.Add(panelHour, 1, 0);
            tableLayoutPanel1.Location = new Point(96, 272);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(738, 157);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // panelScore
            // 
            panelScore.BackColor = Color.FromArgb(31, 41, 55);
            panelScore.Controls.Add(lblQuizScore);
            panelScore.Controls.Add(label5);
            panelScore.Controls.Add(pictureBox2);
            panelScore.Location = new Point(501, 8);
            panelScore.Margin = new Padding(9, 8, 9, 8);
            panelScore.Name = "panelScore";
            panelScore.Size = new Size(228, 133);
            panelScore.TabIndex = 1;
            // 
            // lblQuizScore
            // 
            lblQuizScore.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblQuizScore.AutoSize = true;
            lblQuizScore.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQuizScore.ForeColor = Color.White;
            lblQuizScore.Location = new Point(102, 61);
            lblQuizScore.Name = "lblQuizScore";
            lblQuizScore.Size = new Size(26, 30);
            lblQuizScore.TabIndex = 6;
            lblQuizScore.Text = "0";
            lblQuizScore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(54, 105);
            label5.Name = "label5";
            label5.Size = new Size(119, 19);
            label5.TabIndex = 5;
            label5.Text = "AVG QUIZ SCORE";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(96, 9);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(38, 39);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // panelCourse
            // 
            panelCourse.BackColor = Color.FromArgb(31, 41, 55);
            panelCourse.Controls.Add(lblCourse);
            panelCourse.Controls.Add(label3);
            panelCourse.Controls.Add(pictureBox3);
            panelCourse.Location = new Point(9, 8);
            panelCourse.Margin = new Padding(9, 8, 9, 8);
            panelCourse.Name = "panelCourse";
            panelCourse.Size = new Size(219, 133);
            panelCourse.TabIndex = 1;
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCourse.ForeColor = Color.White;
            lblCourse.Location = new Point(90, 61);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(26, 30);
            lblCourse.TabIndex = 8;
            lblCourse.Text = "0";
            lblCourse.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(29, 105);
            label3.Name = "label3";
            label3.Size = new Size(151, 19);
            label3.TabIndex = 4;
            label3.Text = "COURSES COMPLETED";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(84, 9);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(40, 39);
            pictureBox3.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // panelHour
            // 
            panelHour.BackColor = Color.FromArgb(31, 41, 55);
            panelHour.Controls.Add(lblHour);
            panelHour.Controls.Add(label4);
            panelHour.Controls.Add(pictureBox1);
            panelHour.Location = new Point(255, 8);
            panelHour.Margin = new Padding(9, 8, 9, 8);
            panelHour.Name = "panelHour";
            panelHour.Size = new Size(219, 133);
            panelHour.TabIndex = 0;
            // 
            // lblHour
            // 
            lblHour.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblHour.AutoSize = true;
            lblHour.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHour.ForeColor = Color.White;
            lblHour.Location = new Point(88, 60);
            lblHour.Name = "lblHour";
            lblHour.Size = new Size(26, 30);
            lblHour.TabIndex = 7;
            lblHour.Text = "0";
            lblHour.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(43, 105);
            label4.Name = "label4";
            label4.Size = new Size(117, 19);
            label4.TabIndex = 5;
            label4.Text = "HOURS LEARNED";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(90, 9);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 39);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // ProfileUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panelProfileCard);
            Controls.Add(lblProfile);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ProfileUserControl";
            Size = new Size(955, 681);
            panelProfileCard.ResumeLayout(false);
            panelProfileCard.PerformLayout();
            panelAvata.ResumeLayout(false);
            panelAvata.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panelScore.ResumeLayout(false);
            panelScore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelCourse.ResumeLayout(false);
            panelCourse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panelHour.ResumeLayout(false);
            panelHour.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProfile;
        private Panel panelProfileCard;
        private Label lblAvatar;
        private Panel panelAvata;
        private Label label2;
        private Label label1;
        private Label lblCreatedDate;
        private Label lblUserName;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelScore;
        private Panel panelCourse;
        private Panel panelHour;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label5;
        private Label label3;
        private Label label4;
        private Label lblQuizScore;
        private Label lblCourse;
        private Label lblHour;
    }
}
