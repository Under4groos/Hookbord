using Avalonia.Controls;
using Hookbord.Model;
using System;

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
        Imports.__cell_function((i) =>
        {
            Console.WriteLine($"----- {(char)i.Key_char}");
        });
        Imports.AddNewKey(0xAD, 90);

        for (int i = 0; i < 5; i++)
        {
            Imports.AddNewKey(123123, i);
        }




        //for (int i = 0; i < Imports.CountKeys() + 10; i++)
        //{
        //    KeyHook str_ = Imports.GetKey(i);
        //    Debug.WriteLine(str_);
        //    Console.WriteLine(str_);
        //}



        //for (int i = 0; i < Imports.CountKeys() + 10; i++)
        //{
        //    KeyHook str_ = Imports.GetKey(i);
        //    Debug.WriteLine(str_);
        //    Console.WriteLine(str_);
        //}
    }
}
