using Avalonia.Controls;
using Hookbord.Model;
using System.Diagnostics;

namespace Hookbord.Views;

public partial class MainView : UserControl
{


    public MainView()
    {
        InitializeComponent();

        Loaded += MainView_Loaded;
    }

    private void MainView_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

        for (int i = 0; i < 25; i++)
        {
            Imports.AddNewKey(i, i * 2);
        }



        for (int i = 0; i < Imports.CountKeys() + 10; i++)
        {
            KeyHook str_ = Imports.GetKey(i);
            Debug.WriteLine(str_);
        }

    }
}
