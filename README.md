# System Timer

**System Timer** is a lightweight Unity package that provides the easiest way to manipulate date and time within the Unity Editor.

## Features

- **Toolbar Integration**: Access timer controls directly from the Unity Editor toolbar.
- **Easy Time Manipulation**: Add or subtract days, hours, and minutes with a simple UI.
- **Persistent Settings**: Time offsets are saved in `EditorPrefs`, maintaining your test state between sessions.
- **Runtime & Editor Support**: Designed to work seamlessly in the Editor while falling back to system time in builds.

## Usage

### In Code

To use the System Timer, simply replace `DateTime.Now` with `SystemTimer.Now` in your scripts.

```csharp
using Gnarly.Timer; // Ensure you have the correct namespace usage

public class DailyReward : MonoBehaviour
{
    void CheckReward()
    {
        // Use SystemTimer.Now instead of DateTime.Now
        if (SystemTimer.Now.Hour >= 20)
        {
            Debug.Log("It's time for your daily reward!");
        }
    }
}
```

- **In the Editor**: `SystemTimer.Now` returns `DateTime.Now` plus any offsets you've applied via the tools.
- **In Builds**: `SystemTimer.Now` compiles directly to `DateTime.Now`, ensuring zero overhead or logic changes in your released game.

### In the Editor

Once installed, you will see the System Timer controls in the Unity Editor toolbar (usually at the top of the window).

- **Current Simulated Time**: Displays the current time including offsets.
- **+ / - Buttons**: Adjust Days, Hours, and Minutes.
- **Reset**: Quickly reset all offsets to zero.
