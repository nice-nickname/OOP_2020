using System.Windows.Forms;

namespace FiguresDrawer.App
{
	public class ViewPresenterPair
	{
		public Form View { get; private set; }
		public IPresenter Presenter { get; private set; }

		public ViewPresenterPair(Form view, IPresenter presenter, IPresenter parent = null)
		{
			if (parent != null)
			{
				parent.SendData += presenter.ReceiveData;
			}

			View = view;
			Presenter = presenter;
		}
	}
}
