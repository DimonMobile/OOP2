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
    class Director : IDirector
    {
        private IBuilder m_builder;
        private List<UIElement> m_result;

        public Director(IBuilder builder)
        {
            m_builder = builder;
        }

        public void CreateComplexItem(double x, double y)
        {
            Rectangle backgroundItem = m_builder.CreateBackgroundItem() as Rectangle;
            Rectangle foregroundItem = m_builder.CreateForegroundItem() as Rectangle;

            Thickness backgroundMargin = backgroundItem.Margin;
            backgroundMargin.Left = x;
            backgroundMargin.Top = y;
            backgroundItem.Margin = backgroundMargin;

            Thickness foregroundMargin = foregroundItem.Margin;
            foregroundMargin.Left = x + 50;
            foregroundMargin.Top = y + 50;
            foregroundItem.Margin = foregroundMargin;

            m_result = new List<UIElement>();
            m_result.Add(backgroundItem);
            m_result.Add(foregroundItem);
        }

        public List<UIElement> GetResult()
        {
            return m_result;
        }
    }
}
