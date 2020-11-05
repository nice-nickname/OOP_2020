using FiguresDrawer.Model.Figures;
using FiguresDrawer.Presenter.Drawing;
using FiguresDrawer.Presenter.Events;
using FiguresDrawer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FiguresDrawer.Presenter
{
	class FiguresSettingsPresenter : IPresenter
	{
		private IFiguresSettingsView _view;

		private CheckedListBox _checkedList;
		private PlaneSettings _settings;

		public event Action<IPresenter, EventArgs> SendData;

		public FiguresSettingsPresenter(IFiguresSettingsView view)
		{
			_view = view;

			_checkedList = _view.GetCheckedList();

			for (int i = 0; i < _checkedList.Items.Count; i++)
			{
				_checkedList.SetItemChecked(i, true);
			}

			_view.SaveAndExitButton_Click += View_SaveAndExitButton_Click;
		}

		private void View_SaveAndExitButton_Click(object sender, EventArgs e)
		{
			_settings.TypesToDraw.Clear();

			foreach (var item in _checkedList.CheckedItems)
			{
				_settings.TypesToDraw.Add(item as Type);
			}
		}

		public void ReceiveData(IPresenter sender, EventArgs args)
		{
			if (args is DrawingEventArgs)
			{
				_settings = (args as DrawingEventArgs).Settings;

				_checkedList.Items.AddRange(_settings.Types);

				for (int i = 0; i < _settings.Types.Length; i++)
				{
					Type type = _settings.Types[i];
					if (_settings.TypesToDraw.Contains(type))
					{
						_checkedList.SetItemChecked(i, true);
					}
				}
			}
			else
			{
				throw new ArgumentException("invalid event args '" + nameof(args) + "' sended");
			}
		}
	}
}
