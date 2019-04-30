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
    class Director : IDirector, IPrototype
    {
        private IBuilder m_builder;
        private List<UIElement> m_result;

        public Director(IBuilder builder)
        {
            m_builder = builder;
        }

        public IPrototype Clone()
        {
            Director newDir = new Director(m_builder);
            newDir.m_result = m_result.Select(item => item).ToList();
            return newDir;
        }

        public void CreateComplexItem(double x, double y)
        {
            Rectangle backgroundItem = m_builder.CreateBackgroundItem() as Rectangle;
            Rectangle foregroundItem = m_builder.CreateForegroundItem() as Rectangle;

            RectItemAdapter backgroundAdapter = new RectItemAdapter(backgroundItem);
            backgroundAdapter.X = x;
            backgroundAdapter.Y = y;

            RectItemAdapter foregroundAdapter = new RectItemAdapter(foregroundItem);
            foregroundAdapter.X = x + 50;
            foregroundAdapter.Y = y + 50;

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
