using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace _13
{
    class RectFactoryDecorator : AbstractFactory
    {
        RectangleFactory m_factory;

        public RectFactoryDecorator(RectangleFactory factory)
        {
            m_factory = factory;
        }

        private UIElement AddCorners(UIElement source)
        {
            Rectangle rect = source as Rectangle;
            rect.RadiusX = 10;
            rect.RadiusY = 10;
            return rect as UIElement;
        }

        public override UIElement CreateBlue()
        {
            return AddCorners(m_factory.CreateBlue());
        }

        public override UIElement CreateRed()
        {
            return AddCorners(m_factory.CreateRed());
        }
    }
}
