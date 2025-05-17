using System;
using UnityEngine;

namespace TEngine
{
    public sealed partial class Debugger
    {
        private sealed class PathInformationWindow : ScrollableDebuggerWindowBase
        {
            protected override void OnDrawScrollableWindow()
            {
                GUILayout.Label("<b>Path Information</b>");
                GUILayout.BeginVertical("box");
                {
                    DrawItem("Current Directory", Utility.PathUtils.GetRegularPath(Environment.CurrentDirectory));
                    DrawItem("Data Path", Utility.PathUtils.GetRegularPath(Application.dataPath));
                    DrawItem("Persistent Data Path", Utility.PathUtils.GetRegularPath(Application.persistentDataPath));
                    DrawItem("Streaming Assets Path", Utility.PathUtils.GetRegularPath(Application.streamingAssetsPath));
                    DrawItem("Temporary Cache Path", Utility.PathUtils.GetRegularPath(Application.temporaryCachePath));
#if UNITY_2018_3_OR_NEWER
                    DrawItem("Console Log Path", Utility.PathUtils.GetRegularPath(Application.consoleLogPath));
#endif
                }
                GUILayout.EndVertical();
            }
        }
    }
}
