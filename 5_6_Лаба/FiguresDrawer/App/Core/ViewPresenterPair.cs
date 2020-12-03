using System.Windows.Forms;

namespace FiguresDrawer.App
{
	public class ViewPresenterPair : System.IDisposable
	{
		public Form View { get; }
		public IPresenter Presenter { get; }
		public IPresenter Sender { get; }

		public ViewPresenterPair(Form view, IPresenter presenter, IPresenter sender)
		{
			View = view ?? throw new System.ArgumentNullException(nameof(view));
			Presenter = presenter ?? throw new System.ArgumentNullException(nameof(presenter));

			if (sender != null)
			{
				sender.SendData += presenter.ReceiveData;
				Sender = sender;
			}
		}

		public void Dispose()
		{
			if (Sender != null)
			{
				Sender.SendData -= Presenter.ReceiveData;
			}
		}
	}
}
