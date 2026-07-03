using UnityEngine;

public static class DLog
{
    // [Conditional("ENABLE_LOG")]
    public static void Log(string msg, params object[] para)
    {
#if ENABLE_LOG
        UnityEngine.Debug.LogFormat(msg, para);  
#endif
    }
    
    // [Conditional("ENABLE_LOG")]
    public static void Log(string msg, Color color)
    {
#if ENABLE_LOG
        UnityEngine.Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{msg}</color>");
#endif
    }
    // [Conditional("ENABLE_LOG")]
    public static void Log(string msg)
    {
#if ENABLE_LOG
        UnityEngine.Debug.Log(msg);
#endif
    }

    // [Conditional("ENABLE_LOG")]
    public static void Warning(string msg, params object[] para)
    {
#if ENABLE_LOG
        UnityEngine.Debug.LogWarningFormat(msg, para);
#endif
    }
    // [Conditional("ENABLE_LOG")]
    public static void Warning(string msg)
    {
        // string detail = $"{Time.frameCount}, {Time.realtimeSinceStartup}";
        // UnityEngine.Debug.LogWarning($"{detail} -> " + msg);
#if ENABLE_LOG
        UnityEngine.Debug.LogWarning(msg);
#endif
    }

    // [Conditional("ENABLE_LOG")]
    public static void Error(string msg, params object[] para)
    {
#if ENABLE_LOG
        UnityEngine.Debug.LogErrorFormat(msg, para);
#endif
    }
    // [Conditional("ENABLE_LOG")]
    public static void Error(string msg)
    {
#if ENABLE_LOG
        UnityEngine.Debug.LogError(msg);  
#endif
    }
}
