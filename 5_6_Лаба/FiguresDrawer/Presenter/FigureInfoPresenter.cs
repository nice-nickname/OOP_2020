using FiguresDrawer.Presenter.Events;
using FiguresDrawer.View;
using System;

namespace FiguresDrawer.Presenter
{
	public class FigureInfoPresenter : IPresenter
	{
		private IFigureInfoPresenterView _view;

		public event Action<IPresenter, EventArgs> SendData;

		public FigureInfoPresenter(IFigureInfoPresenterView view)
		{
			_view = view;
		}

		public void ReceiveData(IPresenter sender, EventArgs args)
		{
			if (args is FigureDrawnEventArgs)
			{
				var fargs = args as FigureDrawnEventArgs;

				var center = fargs.CurrentFigure.Adapter.GetRawCenter();
				_view.SetCenterInfo(center);
				_view.SetPoints(fargs.CurrentFigure.Adapter.GetRawPoints());

				try
				{
					var area = fargs.CurrentFigure.Adapter.GetArea();
					var perimeter = fargs.CurrentFigure.Adapter.GetPerimeter();

					_view.SetPerimeterInfo(perimeter);
					_view.SetAreaInfo(area);
				}
				catch (Exception)
				{
					_view.SetPerimeterInfo(double.NaN);
					_view.SetAreaInfo(double.NaN);
				}
			}
			else
			{
				throw new ArgumentException("invalid event args type '" + args.GetType().Name + "' sended");
			}
		}
	}
}
