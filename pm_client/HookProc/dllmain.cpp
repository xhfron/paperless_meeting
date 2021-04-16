// dllmain.cpp : 定义 DLL 应用程序的入口点。
#include "pch.h"

#include "HookProc.h"

extern "C"
{
	__declspec(dllexport)
		void StartupHook(void);

	__declspec(dllexport)
		void CloseHook(void);

	void ProcessHookUp();

	void ProcessHookDelete();
}

int count = 0;

BOOL APIENTRY DllMain(HMODULE hModule,
	DWORD  ul_reason_for_call,
	LPVOID lpReserved) {
	switch (ul_reason_for_call) {
	case DLL_PROCESS_ATTACH:
		ProcessHookUp();
		break;
	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
		break;
	case DLL_PROCESS_DETACH:
		ProcessHookDelete();
		break;
	}
	return TRUE;
}

HHOOK hThis = NULL;

LRESULT CALLBACK ProcessClose(int nCode, WPARAM wParam, LPARAM lParam)
{
	return CallNextHookEx(hThis, nCode, wParam, lParam);
}

void StartupHook(void)
{
	hThis = SetWindowsHookExW(WH_GETMESSAGE, ProcessClose, GetModuleHandleW(L"ProcHook.dll"), 0);
}

void CloseHook(void)
{
	UnhookWindowsHookEx(hThis);
}

void ProcessHookUp()
{
	DWORD proId = GetCurrentProcessId();
	HWND hWnd = FindWindow(NULL, L"pm_client");
	if (hWnd)
	{
		PostMessage(hWnd, WM_USER + 7, 0, proId);
	}

}

void ProcessHookDelete()
{
	DWORD proId = GetCurrentProcessId();
}
