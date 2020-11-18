using System.Windows.Forms;

namespace FiguresDrawer.App
{
	public class ViewPresenterPair
	{
		public Form View { get; }
		public IPresenter Presenter { get; }

		public ViewPresenterPair(Form view, IPresenter presenter, IPresenter sender)
		{
			View = view ?? throw new System.ArgumentNullException(nameof(view));
			Presenter = presenter ?? throw new System.ArgumentNullException(nameof(presenter));
			
			if (sender != null)
			{
				sender.SendData += presenter.ReceiveData;
			}
		}
	}
}
