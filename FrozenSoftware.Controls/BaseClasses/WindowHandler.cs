using FrozenSoftware.Controls;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Unity;

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

        public bool ShowWindow(int? entityId, ActionType actionType, Type windowType, IUnityContainer unityContainer, List<object> additionalData = null)
        {
            int count = Application.Current.Windows.Count;
            Window paret = Application.Current.Windows[count - 1];
            Window window = unityContainer.Resolve(windowType) as Window;
            window.Owner = paret;
            BaseFormViewModel windowVewiModel = window.DataContext as BaseFormViewModel;
            windowVewiModel.Close = window.Close;
            windowVewiModel.Initialize(entityId, actionType, additionalData);
            window.ShowDialog();

            return windowVewiModel.DialogResult;
        }
    }
}
