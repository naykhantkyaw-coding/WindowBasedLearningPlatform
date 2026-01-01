using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowBasedLearningPlatform.WindowApp.Models.UserModel;
using WindowBasedLearningPlatform.WindowApp.Services;

namespace WindowBasedLearningPlatform.WindowApp.App.UserControls
{
    public partial class ProfileUserControl : UserControl
    {
        public ProfileUserControl(UserResponseModel model)
        {
            InitializeComponent();
            FormDesignService.RoundPanel(panelProfileCard, 20);
            FormDesignService.RoundPanel(panelAvata, 5);
            FormDesignService.RoundPanel(panelCourse, 5);
            FormDesignService.RoundPanel(panelHour, 5);
            FormDesignService.RoundPanel(panelScore, 5);

            lblAvatar.Parent = panelAvata;
            lblAvatar.BackColor = Color.Transparent;
            char avat = char.ToUpper(model.UserName[0]);
            lblAvatar.Text = avat.ToString();
            lblUserName.Text = model.UserName;
            lblCreatedDate.Text = model.CreatedDateTime.ToShortDateString();

            int course = 0;
            double hour = 0;
            int quiz = 0;

            lblCourse.Text = course.ToString();
            lblHour.Text = hour.ToString("0.0");
            lblQuizScore.Text = quiz.ToString() + "%";

        }

    }
}
