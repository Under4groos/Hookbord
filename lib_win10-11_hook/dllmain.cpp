// dllmain.cpp : Определяет точку входа для приложения DLL.
#include "KeyHook.h"
#include <vector>
#include <windows.h>
std::vector<KeyHook> Keys{};



extern "C" __declspec(dllexport) void AddNewKey(int key , int keybind) {

    Keys.push_back({ key , keybind , 0 });
}
extern "C" __declspec(dllexport) int CountKeys() {

    return Keys.size();
}
extern "C" __declspec(dllexport) KeyHook GetKey(int key_id) {
    if (Keys.size() > 0 && key_id < Keys.size()) {
        return Keys[key_id];
    }
    return {0,0,-1};
}



extern "C" __declspec(dllexport) int SetHWNDMainWindow(int _HWND) {
 
    return _HWND;
}


void Init(HMODULE hModule,  DWORD  ul_reason_for_call,LPVOID lpReserved) {

}
BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:

        Init(hModule , ul_reason_for_call , lpReserved);
        break;
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

