using System.Windows.Forms;

namespace FiguresDrawer.App
{
	public class ViewPresenterPair
	{
		private Form _view;
		private IPresenter _presenter;

		public ViewPresenterPair(Form view, IPresenter presenter)
		{
			_view = view;
			_presenter = presenter;
		}

		public Form View { get => _view; }
	}
}
