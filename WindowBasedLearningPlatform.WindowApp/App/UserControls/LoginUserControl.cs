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
            FormDesignService.RoundPanel(iconPanel, 80);
        }

    }
}
