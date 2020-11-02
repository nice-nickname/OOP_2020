using FiguresDrawer.Presenter.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace FiguresDrawer.Model
{
	public class FigureDrawerContainer
	{
		private ListBox.ObjectCollection _collection;

		public static FigureDrawerContainer Instance { get; private set; }

		private bool _inited = false;

		public FigureDrawerContainer(ListBox parent)
		{
			if (_inited)
			{
				return;
			}

			_collection = new ListBox.ObjectCollection(parent);
			Instance = this;
			_inited = true;
		}

		public void Add(FigureDrawer figureDrawer)
		{
			_collection.Add(figureDrawer);
		}

		public void Remove(int index)
		{
			if (index < 0 || index >= _collection.Count)
			{
				return;
			}

			_collection.Remove(index);
		}
	
		public ListBox.ObjectCollection GetCollection()
		{ 
			return _collection;
		}
	}
}
