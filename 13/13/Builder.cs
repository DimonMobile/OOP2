using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace _13
{
    class Builder : IBuilder
    {
        public UIElement CreateBackgroundItem()
        {
            Rectangle rect = new Rectangle();
            rect.Width = 200;
            rect.Height = 200;
            rect.Fill = new SolidColorBrush(Colors.Purple);
            rect.VerticalAlignment = VerticalAlignment.Top;
            rect.HorizontalAlignment = HorizontalAlignment.Left;
            return rect;
        }

        public UIElement CreateForegroundItem()
        {
            Rectangle rect = new Rectangle();
            rect.Width = 50;
            rect.Height = 50;
            rect.Fill = new SolidColorBrush(Colors.Yellow);
            rect.RadiusX = 25; rect.RadiusY = 25;
            rect.VerticalAlignment = VerticalAlignment.Top;
            rect.HorizontalAlignment = HorizontalAlignment.Left;
            return rect;
        }
    }
}
