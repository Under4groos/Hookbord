using Avalonia.Controls;
using Hookbord.Model;

namespace Hookbord;

public partial class ucKey : UserControl
{
    __key_down KeyDownEnv;
    public bool IsFocus { get; set; } = false;
    public bool IsChanged { get; set; } = false;
    public bool IsChanged_repl { get; set; } = false;


    public KeyboardKeyHook_ARTC keyboardKeyHook_ARTC;
    public ucKey()
    {
        InitializeComponent();
        KeyDownEnv = (KeyHook kh) =>
        {


            if (IsChanged_repl)
            {
                set_bind(0, kh);

            }

            if (IsChanged)
            {
                set_bind(1, kh);

            }

        };



        this.Loaded += UcKey_Loaded;

        _button.Click += _button_Click;
        _button_repl.Click += _button_repl_Click;
    }
    public void set_bind(int num, KeyHook kh)
    {
        switch (num)
        {
            case 0:
                _key_repl.Content = $"{(char)kh.Key_char}";

                IsChanged_repl = false;
                _button_repl.IsVisible = !IsChanged_repl;
                keyboardKeyHook_ARTC.__KeyHook_repl = kh;

                break;

            case 1:
                _keyname.Content = $"{(char)kh.Key_char}";

                IsChanged = false;
                _button.IsVisible = !IsChanged;
                keyboardKeyHook_ARTC.__KeyHook = kh;

                break;
            default:
                break;
        }
    }
    public void RegistrationWinApiKey()
    {
        if (!keyboardKeyHook_ARTC.__KeyHook_repl.Equals(null) && !keyboardKeyHook_ARTC.__KeyHook.Equals(null))
        {

            Imports.AddNewKey(keyboardKeyHook_ARTC.__KeyHook_repl.key, keyboardKeyHook_ARTC.__KeyHook.key);
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