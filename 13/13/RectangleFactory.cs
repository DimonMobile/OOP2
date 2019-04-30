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
    class RectangleFactory : AbstractFactory
    {
        public override UIElement CreateBlue()
        {
            Rectangle rect = new Rectangle();
            rect.Width = Settings.Instance.GetDefaultWidth();
            rect.Height = Settings.Instance.GetDefaultHeight();
            rect.Fill = new SolidColorBrush(Colors.Blue);
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
            rect.VerticalAlignment = VerticalAlignment.Top;
            rect.HorizontalAlignment = HorizontalAlignment.Left;
            return rect;
        }
    }
}
