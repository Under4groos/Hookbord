using Avalonia.Controls;
using Hookbord.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

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
        App.List_keyboardKeyHook_ARTCs.Clear();
        foreach (ucKey item in _l.Children)
        {
            item.RegistrationWinApiKey();
            App.List_keyboardKeyHook_ARTCs.Add(item.keyboardKeyHook_ARTC);
        }
        try
        {
            string json = JsonConvert.SerializeObject(App.List_keyboardKeyHook_ARTCs);


            File.WriteAllText("____keybind.json", json);
        }
        catch (System.Exception)
        {


        }

    }

    private void MainView_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

        try
        {
            var json_obj = JsonConvert.DeserializeObject<List<KeyboardKeyHook_ARTC>>(File.ReadAllText("____keybind.json"));
            if (json_obj != null)
            {
                App.List_keyboardKeyHook_ARTCs = json_obj;

                foreach (var item in App.List_keyboardKeyHook_ARTCs)
                {
                    var key__ = new ucKey();
                    key__.set_bind(0, item.__KeyHook_repl);
                    key__.set_bind(1, item.__KeyHook);
                    _l.Children.Add(key__);
                }

            }


        }
        catch (System.Exception)
        {


        }

    }
}
