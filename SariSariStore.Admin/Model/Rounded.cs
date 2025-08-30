using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SariSariStore.Admin.Model
{
    public class Rounded
    {
        public void MakePanelRounded(Panel panel, int cornerRadius)
        {

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(panel.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(panel.Width - cornerRadius, panel.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(0, panel.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseAllFigures();
            panel.Region = new System.Drawing.Region(path);
        }

     

        //public void RoundForm(int cornerRadius)
        //{
        //    GraphicsPath path = new GraphicsPath();

        //    if (cornerRadius > 0)
        //    {
        //        path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90); // Top-left
        //        path.AddArc(Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90); // Top-right
        //        path.AddArc(Width - cornerRadius, Height - cornerRadius, cornerRadius, cornerRadius, 0, 90); // Bottom-right
        //        path.AddArc(0, Height - cornerRadius, cornerRadius, cornerRadius, 90, 90); // Bottom-left
        //    }
        //    else
        //    {
        //        path.AddRectangle(new Rectangle(0, 0, Width, Height));
        //    }

        //    path.CloseAllFigures();
        //    this.Region = new Region(path);
        //}

        public int cornerRadius = 30;

        // Fixed RoundForm method - now accepts width and height parameters
        public Region RoundForm(int cornerRadius, int width, int height)
        {
            GraphicsPath path = new GraphicsPath();

            if (cornerRadius > 0)
            {
                path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90); // Top-left
                path.AddArc(width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90); // Top-right
                path.AddArc(width - cornerRadius, height - cornerRadius, cornerRadius, cornerRadius, 0, 90); // Bottom-right
                path.AddArc(0, height - cornerRadius, cornerRadius, cornerRadius, 90, 90); // Bottom-left
            }
            else
            {
                path.AddRectangle(new Rectangle(0, 0, width, height));
            }

            path.CloseAllFigures();
            return new Region(path);
        }
    }
}
