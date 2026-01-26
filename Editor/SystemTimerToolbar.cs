#if UNITY_6000_3_OR_NEWER
using UnityEditor;
using UnityEditor.Toolbars;
using UnityEngine;

namespace Gnarly.Timer.Editor
{
    [InitializeOnLoad]
    public static class SystemTimerToolbar
    {
        private const string TimerPath = "Gnarly/System Timer";
        private static double _lastUpdate;

        static SystemTimerToolbar()
        {
            EditorApplication.update += OnUpdate;
        }

        private static void OnUpdate()
        {
            // Refresh the UI every second to keep the clock accurate
            if (EditorApplication.timeSinceStartup - _lastUpdate > 1.0f)
            {
                _lastUpdate = EditorApplication.timeSinceStartup;
                MainToolbar.Refresh(TimerPath); 
            }
        }

        [MainToolbarElement(TimerPath, defaultDockPosition = MainToolbarDockPosition.Left)]
        public static MainToolbarElement TimerButton()
        {
            var timeString = $"{SystemTimer.Now:MM/dd/yyyy HH:mm}";
            var tooltip = $"Current simulated time. {SystemTimer.Now.DayOfWeek}";
            
            // Using a clock icon, or fallback to simple text if icon missing
            var icon = EditorGUIUtility.IconContent("d_TimelineAsset Icon").image as Texture2D;
            
            var content = new MainToolbarContent(timeString, icon, tooltip);

            return new MainToolbarButton(content, OnTimerClicked);
        }

        private static void OnTimerClicked()
        {
            SystemTimerWindow.ShowWindow();
        }
    }
}
#endif