using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowBasedLearningPlatform.WindowApp.App.UI_Elements
{
    public partial class HorizentalGradientPanelHelper : Panel
    {
        public Color ColorTop { get; set; }
        public Color ColorBottom { get; set; }

        public HorizentalGradientPanelHelper()
        {
            // CRITICAL: Tells WinForms "I will paint myself, don't paint the background for me"
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.DoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint, true);

            this.UpdateStyles();

            // Default Colors
            ColorTop = ColorTranslator.FromHtml("#DB2777");
            ColorBottom = ColorTranslator.FromHtml("#9333EA");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle, this.ColorTop, this.ColorBottom, 45F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }

            // Do NOT call base.OnPaint(e) if you want to ensure the background isn't overwritten
            // But we DO need to paint children (buttons), which WinForms handles separately.
        }
    }
}
