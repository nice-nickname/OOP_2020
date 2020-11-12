using System.Windows.Forms;

namespace FiguresDrawer.App
{
	public class ViewPresenterPair
	{
		public Form View { get; }
		public IPresenter Presenter { get; }

		public ViewPresenterPair(Form view, IPresenter presenter, IPresenter sender)
		{
			if (sender != null)
			{
				sender.SendData += presenter.ReceiveData;
			}

			View = view;
			Presenter = presenter;
		}
	}
}
