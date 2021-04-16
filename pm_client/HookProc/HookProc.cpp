#include "pch.h"
/*
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
*/
