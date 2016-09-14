using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace WpfNotifyIcon
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TaskbarIcon tb;
        private UTMPopup popup;

       


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //create the notifyicon (it's a resource declared in NotifyIconResources.xaml
            tb = (TaskbarIcon)FindResource("MyNotifyIcon");

            popup = new UTMPopup();

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            string text = Clipboard.GetText();
            Uri uriResult;
            bool result = Uri.TryCreate(text, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (result && popup.IsOpen == false && popup.IgnoredURL!=text)
            {
                popup.urlTextBox.Text = text;
                popup.IsOpen = true;
            }
           
        }

    

        private void Paste_CanExecuteChanged(object sender, EventArgs e)
        {
            //ourVariable = Clipboard.ContainsText();
            Debug.WriteLine("Clipboard->" + Clipboard.GetText());
        }


        //protected void HookManager_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        //{
           
        //    Debug.WriteLine(string.Format("KeyPress - {0}\n", e.KeyChar));
        //}



        //protected void HookManager_MouseClick(object sender, EventArgs e)
        //{
        //    //textBoxLog.Text += (string.Format("MouseClick - {0}\n", e.Button));

        //    Object o = e.GetType();
        //    Gma.UserActivityMonitor.MouseEventExtArgs meea = (Gma.UserActivityMonitor.MouseEventExtArgs)e;
        //    counter++;


        //    Debug.WriteLine("A click:" + meea.Button + " Count:" +counter);
        //    Debug.WriteLine("Sender:" + sender);
            

        //    if (rightButtonPressed)
        //    {
        //        Debug.WriteLine("Another click");
        //        if (!popup.IsOpen)
        //            popup.IsOpen = true;
        //    }

           
        //   if  (meea.Button.Equals("Right"))
        //    {
        //        rightButtonPressed = true;
        //    }

          
            
           

        //}


        protected override void OnExit(ExitEventArgs e)
        {
            tb.Dispose(); //the icon would clean up automatically, but this is cleaner
            base.OnExit(e);
        }
    }
}
