#pragma once
struct KeyHook {
    int key;
    int key_replace;
    int Error;
    int Key_char;
};
struct MouseHook {
    int x;
    int y;

};

#pragma region define
#ifdef __cplusplus
extern "C"
{

#endif
#define DLL __declspec(dllexport)
    typedef int(__stdcall* __key_down)(KeyHook);
    DLL void __cell_function(__key_down);


    typedef int(__stdcall* __mouse)(MouseHook);
    DLL void __cell_function_mouse(__mouse);

#ifdef __cplusplus
}
#endif
#pragma endregion