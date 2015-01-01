using System;
using UnityEngine;

public class BugsnagDemoScript : MonoBehaviour
{
    void Awake ()
    {
		Bugsnag.Client.Init ("066f5ad3590596f9aa8d601ea89af845");
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
        NotifyChild();
    }

    private void NotifyChild ()
    {
        try {
            throw new InvalidOperationException("Handled");
        } catch (Exception e) {
            Bugsnag.Client.Notify(e);
        }

        Bugsnag.Client.Notify(new InvalidOperationException("Not thrown"));
    }
}
