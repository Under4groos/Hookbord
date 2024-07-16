#pragma once
struct KeyHook {
    int key;
    int key_replace;
    int Error;
    int Key_char;
};


#pragma region define
#ifdef __cplusplus
extern "C"
{

#endif
#define DLL __declspec(dllexport)
    typedef int(__stdcall* __key_down)(KeyHook);
    DLL void __cell_function(__key_down);
#ifdef __cplusplus
}
#endif
#pragma endregion