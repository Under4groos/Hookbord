// dllmain.cpp : Определяет точку входа для приложения DLL.
#include "KeyHook.h"
#include <vector>
#include <windows.h>
#include "Keyboard.h"

std::vector<KeyHook> Keys{};
HHOOK _keyboardhook_thread{ NULL };
KBDLLHOOKSTRUCT* _kbd_Struct;
__key_down key_down_event;


DLL void __cell_function(__key_down kd) {
	key_down_event = kd;
	std::cout << (int)key_down_event << std::endl;
}

extern "C" __declspec(dllexport) void AddNewKey(int key, int keybind) {

	Keys.push_back({ key , keybind , 0 });
}
extern "C" __declspec(dllexport) int CountKeys() {

	return Keys.size();
}
extern "C" __declspec(dllexport) int RemoveKey(int key) {

	if (Keys.size() > 0 && key < Keys.size()) {
		Keys.erase(Keys.begin() + key);
		return 1;
	}
	return 0;
}
extern "C" __declspec(dllexport) KeyHook GetKey(int key_id) {
	if (Keys.size() > 0 && key_id < Keys.size()) {
		return Keys[key_id];
	}
	return { 0,0,-1 };
}

LRESULT CALLBACK _keyboard_hook(const int code, const WPARAM wParam, const LPARAM lParam) {
	if (wParam == WM_KEYDOWN)
	{
		_kbd_Struct = (KBDLLHOOKSTRUCT*)lParam;
		VirtKeyPrintString(_kbd_Struct);

		if (key_down_event) {
			KeyHook kh{};
			kh.key = _kbd_Struct->vkCode;
			kh.Key_char = VirtKeyToAscii_str(_kbd_Struct);
			key_down_event(kh);
			 
		}
		for (KeyHook n : Keys) {
			if (n.Error == -1)
				continue;
			if (_kbd_Struct->vkCode == n.key) {
				n.Key_char = VirtKeyToAscii_str(_kbd_Struct);
				SendInputDWORD(n.key_replace);


				
				return 1;
			}

		}
	}


	return CallNextHookEx(_keyboardhook_thread, code, wParam, (LPARAM)(_kbd_Struct));
}
void BindStdHandlesToConsole()
{
	FILE* fDummy;
	freopen_s(&fDummy, "CONIN$", "r", stdin);
	freopen_s(&fDummy, "CONOUT$", "w", stderr);
	freopen_s(&fDummy, "CONOUT$", "w", stdout);

	// Note that there is no CONERR$ file
	HANDLE hStdout = CreateFile("CONOUT$", GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE,
		NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
	HANDLE hStdin = CreateFile("CONIN$", GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE,
		NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);

	SetStdHandle(STD_OUTPUT_HANDLE, hStdout);
	SetStdHandle(STD_ERROR_HANDLE, hStdout);
	SetStdHandle(STD_INPUT_HANDLE, hStdin);

	//Clear the error state for each of the C++ standard stream objects. 
	std::wclog.clear();
	std::clog.clear();
	std::wcout.clear();
	std::cout.clear();
	std::wcerr.clear();
	std::cerr.clear();
	std::wcin.clear();
	std::cin.clear();
}


void Init(HMODULE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved) {
	_keyboardhook_thread = SetWindowsHookEx(WH_KEYBOARD_LL, _keyboard_hook, NULL, 0);
}
BOOL APIENTRY DllMain(HMODULE hModule,
	DWORD  ul_reason_for_call,
	LPVOID lpReserved
)
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
		AllocConsole();
		BindStdHandlesToConsole();



		Init(hModule, ul_reason_for_call, lpReserved);
		break;
	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
	case DLL_PROCESS_DETACH:
		break;
	}
	return TRUE;
}

