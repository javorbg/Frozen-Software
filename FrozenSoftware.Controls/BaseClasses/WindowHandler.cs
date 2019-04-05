using FrozenSoftware.Controls;
using System;
using System.Collections.Generic;
using System.Windows;
using Unity;

namespace FrozenSoftware
{
    public class WindowHandler
    {
        private static WindowHandler windowHandler;
        private List<Window> windowList = new List<Window>();

        private WindowHandler()
        {
        }

        public static WindowHandler WindowHandlerInstance
        {
            get
            {
                if (windowHandler == null)
                    windowHandler = new WindowHandler();

                return windowHandler;
            }
        }

        public bool ShowWindow(int? entityId, ActionType actionType, Type windowType, IUnityContainer unityContainer, List<object> additionalData = null)
        {
            Window window = unityContainer.Resolve(windowType) as Window;
            Window paret;
            if (windowList.Count == 0)
            {
                paret = Application.Current.Windows[0];
                windowList.Add(window);
                window.Owner = paret;
            }
            else
            {
                int lastIndnex = windowList.Count - 1;
                paret = windowList[lastIndnex];
                windowList.Add(window);
                window.Owner = paret;
            }

            BaseFormViewModel windowVewiModel = window.DataContext as BaseFormViewModel;
            windowVewiModel.Close = window.Close;
            windowVewiModel.Initialize(entityId, actionType, additionalData);
            window.ShowDialog();
            windowList.Remove(window);

            return windowVewiModel.DialogResult;
        }

        public void ShowMessage(string message, IUnityContainer unityContainer, string title = null, object icon = null)
        {
            ShowDialogWindow(message, typeof(MessageWindow), unityContainer, title, icon);
        }

        public bool? ShowConfirm(string message, IUnityContainer unityContainer, string title = null, object icon = null)
        {
            return ShowDialogWindow(message, typeof(ConfirWindow), unityContainer, title, icon);
        }

        private bool? ShowDialogWindow(string message, Type windowType, IUnityContainer unityContainer, string title, object icon)
        {
            int count = Application.Current.Windows.Count;
            Window paret = Application.Current.Windows[count - 1];

            Window dialog = unityContainer.Resolve(windowType) as Window;
            BaseDialogWindowViewModel viewModel = dialog.DataContext as BaseDialogWindowViewModel;

            viewModel.Message = message;
            if (title != null)
                viewModel.Title = title;

            if (icon != null)
                viewModel.Icon = icon;

            dialog.Owner = paret;
            return dialog.ShowDialog();
        }
    }
}
