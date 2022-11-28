using System;
using UnityEngine;
using Object = UnityEngine.Object;

[Flags]
public enum SimpleLogType : byte {
    None = 0,
    Log = 1,
    LogWarning = 2,
    LogError = 4,
    LogSuccess = 8
}

public static class SimpleLogger {
    public static SimpleLogType EnabledLogType;

    static SimpleLogger() {
        Debug.Log("Simple Logger Enabled EnabledLogType = " + EnabledLogType);
    }

    public static void EnableLogger(SimpleLogType logType) {
        EnabledLogType = logType;
    }

    private static string Color(this string myStr, string color) {
        return $"<color={color}>{myStr}</color>";
    }

    private static void DoLog(Action<string, Object> logFunction, Object myObj, params object[] msg) {
        string name = (myObj ? myObj.name : "Null").Color("lightblue");
        logFunction($"[{name}]: {string.Join("; ", msg)}\n ", myObj);
    }

    private static void DoLog(Action<string> logFunction, params object[] msg) {
        logFunction("[" + "Null".Color("lightblue") + "]: " + $"{string.Join("; ", msg)}\n ");
    }

    public static void Log(params object[] msg) {
        if ((EnabledLogType & SimpleLogType.Log) == 0)
            return;
        DoLog(Debug.Log, msg);
    }

    public static void LogWarning(params object[] msg) {
        if ((EnabledLogType & SimpleLogType.LogWarning) == 0)
            return;
        DoLog(Debug.LogWarning, msg);
    }

    public static void LogError(params object[] msg) {
        if ((EnabledLogType & SimpleLogType.LogError) == 0)
            return;
        DoLog(Debug.LogError, msg);
    }

    public static void LogSuccess(params object[] msg) {
        if ((EnabledLogType & SimpleLogType.LogSuccess) == 0)
            return;
        DoLog(Debug.Log, msg);
    }

    /// <param name="myObj"> object name</param>
    /// <param name="msg"> prints message</param>
    public static void Log(this Object myObj, params object[] msg) {
        if ((EnabledLogType & SimpleLogType.Log) == 0)
            return;
        DoLog(Debug.Log, myObj, msg);
    }

    public static void LogWarning(this Object myObj, params object[] msg) {
        if ((EnabledLogType & SimpleLogType.LogWarning) == 0)
            return;
        DoLog(Debug.LogWarning, myObj, msg);
    }

    public static void LogError(this Object myObj, params object[] msg) {
        if ((EnabledLogType & SimpleLogType.LogError) == 0)
            return;
        DoLog(Debug.LogError, myObj, msg);
    }

    public static void LogSuccess(this Object myObj, params object[] msg) {
        if ((EnabledLogType & SimpleLogType.LogSuccess) == 0)
            return;
        DoLog(Debug.Log, myObj, msg);
    }
}