using System;

namespace FiguresDrawer
{
	// Empty interface for all presenters for correct FormFactory working
	public interface IPresenter
	{
		event Action<IPresenter, EventArgs> SendData;
		void ReceiveData(IPresenter sender, EventArgs args);
	}
}
