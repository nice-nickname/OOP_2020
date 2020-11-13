using FiguresDrawer.Presenter.Drawing;
using FiguresDrawer.Presenter.Events;
using FiguresDrawer.View;
using System;
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
			_settings.DrawerSettings.DrawCenterNeeded = _view.DrawCenterCheckBox().Checked;
			_settings.DrawerSettings.DrawVerticesNeeded = _view.DrawVerticesCheckBox().Checked;

			_settings.TypesToDraw.Clear();

			foreach (var item in _checkedList.CheckedItems)
			{
				_settings.TypesToDraw.Add(item as Type);
			}
		}

		public void ReceiveData(IPresenter sender, EventArgs args)
		{
			if (args is FigureDrawnEventArgs)
			{
				_settings = (args as FigureDrawnEventArgs).Settings;

				_checkedList.Items.AddRange(_settings.Types);

				for (int i = 0; i < _settings.Types.Length; i++)
				{
					Type type = _settings.Types[i];
					if (_settings.TypesToDraw.Contains(type))
					{
						_checkedList.SetItemChecked(i, true);
					}
				}

				_view.DrawVerticesCheckBox().Checked = _settings.DrawerSettings.DrawVerticesNeeded;
				_view.DrawCenterCheckBox().Checked = _settings.DrawerSettings.DrawCenterNeeded;
			}
			else
			{
				throw new ArgumentException("invalid event args '" + args.GetType().Name + "' sended");
			}
		}
	}
}
