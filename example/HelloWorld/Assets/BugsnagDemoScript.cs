using System;
using UnityEngine;

public class BugsnagDemoScript : MonoBehaviour
{
    void Awake ()
    {
        Bugsnag.Client.Init("066f5ad3590596f9aa8d601ea89af845");
        Bugsnag.Client.AppVersion = "1.2.3";
    }

    void OnGUI ()
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

    private void NotifyBugsnag ()
    {
        Bugsnag.Client.Notify(new InvalidOperationException("Non-fatal"));
    }
}
