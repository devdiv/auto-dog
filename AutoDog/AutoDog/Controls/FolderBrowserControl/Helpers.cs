using System;
using System.Collections.Generic;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using AutoDog.Views;
using AutoDog.UI.Controls;

namespace AutoDog.Controls.FolderBrowserControl
{
    internal static class Helpers
    {
        // TODO: Remove Helpers class, refactor
        internal static Window GetDefaultOwnerWindow()
        {
            Window defaultWindow = null;

            //TODO: Detect active window and change to that instead
            if (Application.Current != null && Application.Current.MainWindow != null)
            {
                defaultWindow = Application.Current.MainWindow;
            }
            return defaultWindow;
        }

    }
}
