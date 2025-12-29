using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowBasedLearningPlatform.WindowApp.Services;

namespace WindowBasedLearningPlatform.WindowApp.App.UserControls
{
    public partial class LoginUserControl : UserControl
    {
        public LoginUserControl()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(15, 23, 42);
            FormDesignService.CenterForm(loginPanel, this);
            FormDesignService.RoundPanel(loginPanel, 20);
            FormDesignService.RoundPanel(panelUserName, 5);
            FormDesignService.RoundPanel(panelPassword, 5);
            FormDesignService.RoundPanel(panelButton, 5);
            FormDesignService.RoundPanel(iconPanel, 80);

            iconLabel.Parent = iconPanel;
            iconLabel.BackColor = Color.Transparent;


            txtUserName.BackColor = panelUserName.BackColor;
            txtPassword.BackColor = panelPassword.BackColor;
            btnLogin.BackColor = Color.Transparent;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnLogin.FlatAppearance.MouseDownBackColor = Color.Transparent;


        }
    }
}
