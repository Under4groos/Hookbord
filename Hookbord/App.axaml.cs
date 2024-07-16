using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Hookbord.ViewModels;
using Hookbord.Views;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Hookbord;

public partial class App : Application
{

    public override void Initialize()
    {
        foreach (string item in new string[] {
            System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
            System.IO.Directory.GetCurrentDirectory(),
            Environment.CurrentDirectory,
            System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase),




        })
        {
            Debug.WriteLine(item);
        }

        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
