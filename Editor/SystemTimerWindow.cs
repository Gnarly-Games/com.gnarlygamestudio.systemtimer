using System;
using System.Globalization;
using UnityEditor;

#if UNITY_6000_3_OR_NEWER
using UnityEditor.Toolbars;
#endif

using UnityEngine;

namespace Gnarly.Timer.Editor
{
    public class SystemTimerWindow : EditorWindow
    {
        public static void ShowWindow()
        {
            var window = GetWindow<SystemTimerWindow>("System Timer");
            window.minSize = new Vector2(300, 180);
            window.Show();
        }

        private void OnGUI()
        {
            GUILayout.Space(10);
            
            using (new GUILayout.VerticalScope(EditorStyles.helpBox))
            {
                GUILayout.Label($"{SystemTimer.Now.ToString(CultureInfo.InvariantCulture)}", EditorStyles.boldLabel);
                GUILayout.Label($"{SystemTimer.Now.DayOfWeek}", EditorStyles.miniLabel);
            }

            GUILayout.Space(10);

            DrawOffsetControl("Days", SystemTimer.DayOffset, v => SystemTimer.DayOffset = v);
            DrawOffsetControl("Hours", SystemTimer.HourOffset, v => SystemTimer.HourOffset = v);
            DrawOffsetControl("Minutes", SystemTimer.MinuteOffset, v => SystemTimer.MinuteOffset = v);

            GUILayout.Space(20);

            if (GUILayout.Button("Reset Timer", GUILayout.Height(30)))
            {
                SystemTimer.DayOffset = 0;
                SystemTimer.HourOffset = 0;
                SystemTimer.MinuteOffset = 0;

#if UNITY_6000_3_OR_NEWER
                MainToolbar.Refresh("Gnarly/System Timer");
#endif
            }
        }

        private void DrawOffsetControl(string label, int value, Action<int> onValueChanged)
        {
            using (new GUILayout.HorizontalScope())
            {
                GUILayout.Label(label, GUILayout.Width(60));
                GUILayout.Label(value.ToString(), EditorStyles.boldLabel, GUILayout.Width(40));

                if (GUILayout.Button("-", GUILayout.Width(30)))
                {
                    onValueChanged(value - 1);
#if UNITY_6000_3_OR_NEWER
                    MainToolbar.Refresh("Gnarly/System Timer");
#endif
                }

                if (GUILayout.Button("+", GUILayout.Width(30)))
                {
                    onValueChanged(value + 1);
#if UNITY_6000_3_OR_NEWER
                    MainToolbar.Refresh("Gnarly/System Timer");
#endif
                }
            }
        }
        
        // Ensure the window repaints to show ticking time if open
        private void OnInspectorUpdate()
        {
            Repaint();
        }
    }
}