using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using Unity;
using Unity.Resolution;
using System.Linq;

namespace FrozenSoftware
{
    public class WindowHandler
    {
        private static WindowHandler windowHandler;

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

        public bool ShowWindow(int? entityId, ActionType actionType, Type windowType, IUnityContainer unityContainer, string parentName, List<object> additionalData = null)
        {
            Window window = unityContainer.Resolve(windowType) as Window;

            Window paret = Application.Current.MainWindow;

            if (parentName.Contains("Form"))
                paret = GetParentWindowBy(parentName, paret);

            BaseFormViewModel windowVewiModel = window.DataContext as BaseFormViewModel;
            windowVewiModel.Close = window.Close;
            ParameterOverride contructorParameter = new ParameterOverride("baseUrl", FrozenSoftwareWebApiClient.BaseApiUrl);
            windowVewiModel.ApiClient = unityContainer.Resolve<FrozenSoftwareWebApiClient>(contructorParameter);
            windowVewiModel.Initialize(entityId, actionType, additionalData);
            window.ShowDialog();

            return windowVewiModel.DialogResult;
        }

        public void ShowMessage(string message, string parentName, IUnityContainer unityContainer, string title = null, object icon = null)
        {
            ShowDialogWindow(message, typeof(MessageWindow), parentName, unityContainer, title, icon);
        }

        public bool? ShowConfirm(string message, string parentName, IUnityContainer unityContainer, string title = null, object icon = null)
        {
            return ShowDialogWindow(message, typeof(ConfirWindow), parentName, unityContainer, title, icon);
        }

        private bool? ShowDialogWindow(string message, Type windowType, string parentName, IUnityContainer unityContainer, string title, object icon)
        {
            Window paret = Application.Current.MainWindow;

            if (parentName.Contains("Form"))
                paret = GetParentWindowBy(parentName, paret);

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

        private Window GetParentWindowBy(string parentName, Window paret)
        {

            foreach (Window item in Application.Current.Windows)
            {
                string windowTypeName = item.GetType().Name;
                if (parentName.Contains(windowTypeName))
                {
                    paret = item;
                    break;
                }
            }

            return paret;
        }
    }
}
