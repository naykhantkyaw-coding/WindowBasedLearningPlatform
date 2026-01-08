using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowBasedLearningPlatform.WindowApp.App.UserControls
{
    public partial class LessonViewerUserControl : UserControl
    {
        private string _language;
        public LessonViewerUserControl(string language)
        {
            InitializeComponent();
            _language = language;
        }
    }
}
