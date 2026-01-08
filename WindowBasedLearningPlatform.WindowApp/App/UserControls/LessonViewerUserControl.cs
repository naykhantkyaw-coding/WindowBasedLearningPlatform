using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowBasedLearningPlatform.WindowApp.Features.Lessons;
using WindowBasedLearningPlatform.WindowApp.Models.LessonsModel;
using static System.Collections.Specialized.BitVector32;

namespace WindowBasedLearningPlatform.WindowApp.App.UserControls
{
    public partial class LessonViewerUserControl : UserControl
    {
        private string _language;
        public LessonViewerUserControl(string language)
        {
            InitializeComponent();
            _language = language;
            btn_menuTitle.Text = _language;
            LoadSidebar();
           
        }

        private void LoadSidebar()
        {
            menuPanel.Controls.Clear();
            List<SectionResponseModel> model = new List<SectionResponseModel>();
            var result = SelectedLessons.LoadSidebar(_language);

            Button titleButton = new Button();
            titleButton.Text =_language;
            titleButton.Width = menuPanel.Width - 10;
            titleButton.Height = 77;
            titleButton.Location = new Point(5, 10);
            titleButton.TextAlign = ContentAlignment.MiddleCenter;
            titleButton.Dock = DockStyle.Top;
            titleButton.FlatStyle = FlatStyle.Flat;
            titleButton.FlatAppearance.BorderSize = 0;
            titleButton.BackColor = Color.FromArgb(30, 30, 30);
            titleButton.ForeColor = Color.White;
            titleButton.Font = new Font("Segoe UI", 11);

            menuPanel.Controls.Add(titleButton);

            if (result.Count > 0)
            {
                foreach (var sec in result)
                {
                    Button btn = new Button();
                    btn.Text = sec.SectionName;
                    btn.Tag = sec.SectionId;
                    btn.Dock = DockStyle.Top;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Height = 50;
                    btn.ForeColor = Color.White;
                    btn.BackColor = Color.FromArgb(30, 30, 30);
                    btn.TextAlign = ContentAlignment.MiddleLeft;
                    btn.Font = new Font("Segoe UI", 11);
                    btn.Click += SectionButton_Click;

                    menuPanel.Controls.Add(btn);
                    menuPanel.Controls.SetChildIndex(btn, 0);
                }

            }
        }

        private void SectionButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            string sectionId = btn.Tag.ToString();

            //  LoadLessons(sectionId);
        }
    }
}
