// dllmain.cpp : 定义 DLL 应用程序的入口点。
#include "pch.h"

#include "HookProc.h"
#include <cstdlib>

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
	wchar_t ws[203];
void StartupHook(void)
{
	DWORD dwPID;
	HMODULE h = GetModuleHandleW(L"ProcHook.dll");
	HINSTANCE hi= LoadLibrary(TEXT(".\\HookProc.dll"));
	hThis = SetWindowsHookExW(WH_GETMESSAGE, ProcessClose,hi ,0 /*GetWindowThreadProcessId(FindWindow(NULL, L"pm_client"), &dwPID)*/);
	long long n = (long long) hThis;
	int i = 0;
	if (n == 0) {
		ws[i++] = L'e';
		if (hi == NULL)ws[i++] = L'x';
		n = GetLastError();
	}
	for (;n != 0;n /= 10) {
		ws[i++] = '0' + n % 10;
	}
	ws[i++] = '\0';
	
	MessageBoxW(FindWindow(NULL, L"pm_client"), ws, L"WORLD", MB_OK);
}

void CloseHook(void)
{
	UnhookWindowsHookEx(hThis);
}
#include <fstream>
void ProcessHookUp()
{
	DWORD proId = GetCurrentProcessId();
	HWND hWnd = FindWindow(NULL, L"pm_client");
	std::ofstream x("C:\\mylog.txt",std::ios::app);
	x << proId << "\n" << hWnd << "\n" << std::endl;
	x.flush();
	x.close();
	if (hWnd)
	{
		PostMessage(hWnd, WM_USER + 7, 0, proId);
	}

}

void ProcessHookDelete()
{
	DWORD proId = GetCurrentProcessId();
}
