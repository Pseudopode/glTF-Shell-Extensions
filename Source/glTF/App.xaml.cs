using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace glTF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var command = e.Args[0];
            switch (command)
            {
                case "Pack":
                    {
                        new PackWindow(e.Args[1]);
                        break;
                    }
                case "Unpack":
                    {
                        //Console.WriteLine(e.Args[1]);
                        //Debug.WriteLine(e.Args[1]);
                        var window = new UnpackWindow(e.Args[1], e.Args[2]);
                        //window.ShowDialog();

                        break;
                    }
            }

            this.Shutdown();
        }
    }
}
