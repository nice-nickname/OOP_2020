using System.Collections;
using System.Windows.Forms;

namespace FiguresDrawer.Presenter.Drawing
{
	public class FigureDrawerContainer
	{
		private ListBox.ObjectCollection _collection;

		public static FigureDrawerContainer Instance { get; private set; } = null;

		public FigureDrawerContainer(ListBox parent)
		{
			if (Instance != null)
			{
				return;
			}

			_collection = new ListBox.ObjectCollection(parent);
			Instance = this;
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

		public IEnumerable GetEnumerable()
		{
			return _collection;
		}

		public void CopyValuesToCollection(ListBox.ObjectCollection other)
		{
			other.AddRange(_collection);
		}
	}
}
