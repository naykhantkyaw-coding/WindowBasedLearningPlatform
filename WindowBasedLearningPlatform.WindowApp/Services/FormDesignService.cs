using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowBasedLearningPlatform.WindowApp.Services
{
    public class FormDesignService
    {
        public static void CenterForm(Panel panelName, Control controlName)
        {
            panelName.Left = (controlName.ClientSize.Width - panelName.Width) / 2;
            panelName.Top = (controlName.ClientSize.Height - panelName.Height) / 2;
        }
        public static void RoundPanel(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(panel.Width - radius, panel.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, panel.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            panel.Region = new Region(path);
        }
        
        public static void SetupModernButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.Transparent;
            btn.ForeColor = Color.White;

            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;

            btn.MouseEnter += (s, e) => {
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.White;
            };

            btn.MouseLeave += (s, e) => {
                btn.FlatAppearance.BorderSize = 0;
            };

            btn.MouseDown += (s, e) => {
                btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            };
        }
    }
}
