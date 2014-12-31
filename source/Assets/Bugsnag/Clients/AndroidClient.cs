#if UNITY_ANDROID

using System;
using UnityEngine;

namespace Bugsnag.Clients
{
    internal class AndroidClient : IClient
    {
        private static readonly string BUGSNAG_CLASS = "com.bugsnag.android.Bugsnag";

        private AndroidJavaClass mBugsnagPlugin;

        public void Init (string apiKey)
        {
            Debug.Log ("AndroidClient#Init");
            // AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
            // AndroidJavaObject objActivity = cls_UnityPlayer.GetStatic<AndroidJavaObject> ("currentActivity");
            //
            // mBugsnagPlugin = new AndroidJavaClass (BUGSNAG_CLASS);
            // if (mBugsnagPlugin == null) {
            //     System.Console.Write ("Bugsnag Android failed to initialize, couldn't load class " + BUGSNAG_CLASS);
            //     return;
            // }
            //
            // mBugsnagPlugin.CallStatic ("init", objActivity, apiKey);
        }

        public void Notify(Exception exception)
        {
            Debug.Log ("AndroidClient#Notify");
        }
    }
}


#endif
