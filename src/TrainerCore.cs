```csharp
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

public class TrainerCore
{
    private const string GameProcessName = "GameName"; // Replace with your game's process name
    private Process gameProcess;
    private IntPtr processHandle;

    // Static addresses
    private static readonly IntPtr FPS_ADDRESS = (IntPtr)0x00AABBCC; // Replace with actual address

    public bool IsGameRunning()
    {
        return gameProcess != null && !gameProcess.HasExited;
    }

    public bool AttachToProcess()
    {
        gameProcess = Process.GetProcessesByName(GameProcessName).FirstOrDefault();

        if (gameProcess == null)
            return false;

        processHandle = OpenProcess(ProcessAccessFlags.VirtualMemoryRead | ProcessAccessFlags.VirtualMemoryWrite, false, gameProcess.Id);
        return processHandle != IntPtr.Zero;
    }

    public float ReadFloat(IntPtr address)
    {
        float value;
        ReadProcessMemory(processHandle, address, out value, Marshal.SizeOf(typeof(float)), out _);
        return value;
    }

    public void WriteFloat(IntPtr address, float value)
    {
        WriteProcessMemory(processHandle, address, ref value, Marshal.SizeOf(typeof(float)), out _);
    }

    public int ReadInt(IntPtr address)
    {
        int value;
        ReadProcessMemory(processHandle, address, out value, Marshal.SizeOf(typeof(int)), out _);
        return value;
    }

    public void WriteInt(IntPtr address, int value)
    {
        WriteProcessMemory(processHandle, address, ref value, Marshal.SizeOf(typeof(int)), out _);
    }

    [DllImport("kernel32.dll")]
    private static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, int processId);

    [DllImport("kernel32.dll")]
    private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, out float lpBuffer, int dwSize, out int lpNumberOfBytesRead);

    [DllImport("kernel32.dll")]
    private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, out int lpBuffer, int dwSize, out int lpNumberOfBytesRead);

    [DllImport("kernel32.dll")]
    private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref float lpBuffer, int dwSize, out int lpNumberOfBytesWritten);

    [DllImport("kernel32.dll")]
    private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref int lpBuffer, int dwSize, out int lpNumberOfBytesWritten);

    [Flags]
    private enum ProcessAccessFlags : uint
    {
        VirtualMemoryRead = 0x0010,
        VirtualMemoryWrite = 0x0020,
    }
}
```