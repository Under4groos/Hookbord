using Avalonia.Controls;
using Hookbord.Model;

namespace Hookbord;

public partial class ucKey : UserControl
{
    __key_down KeyDownEnv;
    public bool IsFocus { get; set; } = false;
    public bool IsChanged { get; set; } = false;
    public bool IsChanged_repl { get; set; } = false;


    KeyHook __KeyHook, __KeyHook_repl;
    public ucKey()
    {
        InitializeComponent();
        KeyDownEnv = (KeyHook kh) =>
        {


            if (IsChanged_repl)
            {
                _key_repl.Content = $"{(char)kh.Key_char}";

                IsChanged_repl = false;
                _button_repl.IsVisible = !IsChanged_repl;
                __KeyHook_repl = kh;
            }

            if (IsChanged)
            {
                _keyname.Content = $"{(char)kh.Key_char}";

                IsChanged = false;
                _button.IsVisible = !IsChanged;
                __KeyHook = kh;
            }

        };


        //this.PointerEntered += (o, e) =>
        //{
        //    IsFocus = true;
        //};
        //this.PointerExited += (o, e) =>
        //{
        //    IsFocus = false;
        //};
        this.Loaded += UcKey_Loaded;

        _button.Click += _button_Click;
        _button_repl.Click += _button_repl_Click;
    }

    public void RegistrationWinApiKey()
    {
        if (!__KeyHook_repl.Equals(null) && !__KeyHook.Equals(null))
        {

            Imports.AddNewKey(__KeyHook_repl.key, __KeyHook.key);
        }
    }

    private void _button_repl_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        IsChanged_repl = true;
        _button_repl.IsVisible = !IsChanged_repl;
    }

    private void _button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        IsChanged = true;
        _button.IsVisible = !IsChanged;
    }

    private void UcKey_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        this.InitKeyboardChecked();
    }

    public void InitKeyboardChecked()
    {
        App.KeyKookEvents.Add(KeyDownEnv);
    }
}