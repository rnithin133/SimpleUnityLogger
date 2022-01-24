using System;
using UnityEngine;
using Object = UnityEngine.Object;

public static class SimpleLogger {
    public static string Color(this string myStr, string color) {
        return $"<color={color}>{myStr}</color>";
    }

    private static void DoLog(Action<string, Object> logFunction, string prefix, Object myObj, params object[] msg) {
#if UNITY_EDITOR
        string name = (myObj ? myObj.name : "NullObject").Color("lightblue");
        logFunction($"{prefix}[{name}]: {String.Join("; ", msg)}\n ", myObj);
#endif
    }

    private static void DoLog(Action<string> logFunction, string prefix, params object[] msg) {
#if UNITY_EDITOR
        // string name = (myObj ? myObj.name : "NullObject").Color("lightblue");
        logFunction($"{prefix}: {String.Join("; ", msg)}\n ");
#endif
    }

    public static void Log(params object[] msg) {
        DoLog((s) => Debug.Log(s), "", msg);
    }

    /// <summary>
    /// Debug.Log()
    /// </summary>
    /// <param name="myObj"> object name</param>
    /// <param name="msg"> prints message</param>
    public static void Log(this Object myObj, params object[] msg) {
        DoLog((s, o) => Debug.Log(s, o), "", myObj, msg);
    }

    public static void LogError(this Object myObj, params object[] msg) {
        // DoLog(Debug.LogError, "<!>".Color("red"), myObj, msg);
        DoLog((s, o) => Debug.LogError(s, o), "!".Color("red"), myObj, msg);
    }

    public static void LogWarning(this Object myObj, params object[] msg) {
        DoLog(Debug.LogWarning, "⚠️".Color("yellow"), myObj, msg);
    }

    public static void LogSuccess(this Object myObj, params object[] msg) {
        DoLog(Debug.Log, "☻".Color("green"), myObj, msg);
    }
}
