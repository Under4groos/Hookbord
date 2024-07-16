using Avalonia;
using Avalonia.ReactiveUI;
using System;
using System.Diagnostics;
using System.IO;

namespace Hookbord.Desktop;

internal class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {




        BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);
    }


    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI();
}
