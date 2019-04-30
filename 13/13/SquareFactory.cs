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
    class SquareFactory : AbstractFactory
    {
        public override UIElement CreateBlue()
        {
            Rectangle rect = new Rectangle();
            rect.Width = Settings.Instance.GetDefaultWidth();
            rect.Height = Settings.Instance.GetDefaultHeight();
            rect.Fill = new SolidColorBrush(Colors.Blue);
            rect.RadiusX = 50; rect.RadiusY = 50;
            rect.VerticalAlignment = VerticalAlignment.Top;
            rect.HorizontalAlignment = HorizontalAlignment.Left;
            return rect;
        }

        public override UIElement CreateRed()
        {
            Rectangle rect = new Rectangle();
            rect.Width = Settings.Instance.GetDefaultWidth();
            rect.Height = Settings.Instance.GetDefaultHeight();
            rect.Fill = new SolidColorBrush(Colors.Red);
            rect.RadiusX = Settings.Instance.GetDefaultWidth() / 2.0;
            rect.RadiusY = Settings.Instance.GetDefaultHeight() / 2.0;
            rect.VerticalAlignment = VerticalAlignment.Top;
            rect.HorizontalAlignment = HorizontalAlignment.Left;
            return rect;
        }
    }
}
