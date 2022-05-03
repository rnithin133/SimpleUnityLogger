using System;
using UnityEngine;
using Object = UnityEngine.Object;

public static class SimpleLogger {
    public static string Color(this string myStr, string color) {
        return $"<color={color}>{myStr}</color>";
    }

    [Obsolete]
    private static void DoLog(Action<string, Object> logFunction, string prefix, Object myObj, params object[] msg) {
#if UNITY_EDITOR
        string name = (myObj ? myObj.name : "Null").Color("lightblue");
        logFunction($"{prefix}[{name}]: {String.Join("; ", msg)}\n ", myObj);
#endif
    }

    private static void DoLog(Action<string, Object> logFunction, Object myObj, params object[] msg) {
#if UNITY_EDITOR
        string name = (myObj ? myObj.name : "Null").Color("lightblue");
        logFunction($"[{name}]: {String.Join("; ", msg)}\n ", myObj);
#endif
    }

    private static void DoLog(Action<string> logFunction, params object[] msg) {
#if UNITY_EDITOR
        // logFunction($"[Null]{String.Join("; ", msg)}\n ");
        logFunction("[" + "Null".Color("lightblue") + "]: " + $"{String.Join("; ", msg)}\n ");
        // logFunction(msg + "\n ");
#endif
    }

    public static void Log(params object[] msg) {
#if UNITY_EDITOR
        DoLog(Debug.Log, msg);
#endif
    }

    public static void LogWarning(params object[] msg) {
#if UNITY_EDITOR
        DoLog(Debug.LogWarning, msg);
#endif
    }

    public static void LogError(params object[] msg) {
#if UNITY_EDITOR
        DoLog(Debug.LogError, msg);
#endif
    }

    /// <summary>
    /// Debug.Log()
    /// </summary>
    /// <param name="myObj"> object name</param>
    /// <param name="msg"> prints message</param>
    public static void Log(this Object myObj, params object[] msg) {
#if UNITY_EDITOR
        DoLog(Debug.Log, myObj, msg);
#endif
    }

    public static void LogError(this Object myObj, params object[] msg) {
        // DoLog(Debug.LogError, "<!>".Color("red"), myObj, msg);
        // DoLog((s, o) => Debug.LogError(s, o), "!".Color("red"), myObj, msg);
#if UNITY_EDITOR
        DoLog(Debug.LogError, myObj, msg);
#endif
    }

    public static void LogWarning(this Object myObj, params object[] msg) {
#if UNITY_EDITOR
        DoLog(Debug.LogWarning, myObj, msg);
#endif
    }

    public static void LogSuccess(this Object myObj, params object[] msg) {
#if UNITY_EDITOR
        DoLog(Debug.Log, myObj, msg);
#endif
    }
}