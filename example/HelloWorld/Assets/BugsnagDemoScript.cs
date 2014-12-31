using System;
using UnityEngine;
using Bugsnag;

public class BugsnagDemoScript : MonoBehaviour
{
    void OnGUI()
    {
        // Puts some basic buttons onto the screen.
        GUI.skin.button.fontSize = (int) (0.05f * Screen.height);

        Rect requestBannerRect = new Rect(0.1f * Screen.width, 0.05f * Screen.height,
        0.8f * Screen.width, 0.1f * Screen.height);
        if (GUI.Button(requestBannerRect, "Notify Bugsnag"))
        {
            NotifyBugsnag();
        }
    }

    private void NotifyBugsnag()
    {
        Bugsnag.Client.Notify(new InvalidOperationException("Non-fatal"));
    }
}
