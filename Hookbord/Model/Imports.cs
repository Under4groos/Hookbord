using System.Runtime.InteropServices;

namespace Hookbord.Model
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct KeyHook
    {
        public int key;
        public int key_replace;
        public int Error;
        public override string ToString()
        {
            return $"{key}:{key_replace} - Error: {Error}";
        }
    }
    public static partial class Imports
    {
        [LibraryImport("lib_win10-11_hook.dll", SetLastError = true, StringMarshalling = StringMarshalling.Utf16, EntryPoint = "AddNewKey")]
        internal static partial void AddNewKey(int key, int keybind);

        [LibraryImport("lib_win10-11_hook.dll", SetLastError = true, StringMarshalling = StringMarshalling.Utf16, EntryPoint = "CountKeys")]
        internal static partial int CountKeys();

        [LibraryImport("lib_win10-11_hook.dll", SetLastError = true, StringMarshalling = StringMarshalling.Utf16, EntryPoint = "GetKey")]
        internal static partial KeyHook GetKey(int key_id);


        [LibraryImport("lib_win10-11_hook.dll", SetLastError = true, StringMarshalling = StringMarshalling.Utf16, EntryPoint = "RemoveKey")]
        internal static partial int RemoveKey(int key);
    }
}

