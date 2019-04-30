using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace _13
{
    class RectItemAdapter
    {
        private Rectangle m_element;
        public RectItemAdapter(Rectangle element)
        {
            m_element = element;
        }
        public RectItemAdapter(UIElement element)
        {
            m_element = element as Rectangle;
        }
        public double X
        {
            get
            {
                return m_element.Margin.Left;
            }
            set
            {
                Thickness margin = m_element.Margin;
                margin.Left = value;
                m_element.Margin = margin;
            }
        }
        public double Y
        {
            get { return m_element.Margin.Top; }
            set
            {
                Thickness margin = m_element.Margin;
                margin.Top = value;
                m_element.Margin = margin;
            }
        }
    }
}
