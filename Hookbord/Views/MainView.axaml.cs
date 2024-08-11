using Avalonia.Controls;
using Hookbord.Model;

namespace Hookbord.Views;

public partial class MainView : UserControl
{


    public MainView()
    {
        InitializeComponent();

        Loaded += MainView_Loaded;

        btn_registration.Click += Btn_registration_Click;
        btn_new.Click += Btn_new_Click;
        btn_clear.Click += (o, e) =>
        {
            Imports.ClearKeys();
        };
    }

    private void Btn_new_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _l.Children.Add(new ucKey());
    }

    private void Btn_registration_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Imports.ClearKeys();
        foreach (ucKey item in _l.Children)
        {
            item.RegistrationWinApiKey();
        }
    }

    private void MainView_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _l.Children.Add(new ucKey());


    }
}
