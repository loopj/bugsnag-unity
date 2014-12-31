#if UNITY_ANDROID

using System;
using UnityEngine;

namespace Bugsnag.Platforms
{
    internal class Android : IPlatform
    {
        private static readonly string BUGSNAG_CLASS = "com.bugsnag.android.Client";

        private AndroidJavaObject bugsnagClient;
        
        public void Init (string apiKey)
        {
            Debug.Log ("Android#Init");

            // Get the current Activity
            AndroidJavaClass unityPlayerClass = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = unityPlayerClass.GetStatic<AndroidJavaObject> ("currentActivity");

            // Construct a Bugsnag Android Client
            bugsnagClient = new AndroidJavaObject (BUGSNAG_CLASS, activity, apiKey);
        }

        public void Notify(Exception exception)
        {
            Debug.Log ("Android#Notify");

            // TODO: Work out which format to pass stacktraces in
            // bugsnagClient.Call("notify", "Class", "Message")
        }

        public void Notify (Exception exception, Severity severity)
        {
            Debug.Log ("Android#Notify");
        }

        public void Notify (Exception exception, MetaData metaData)
        {
            Debug.Log ("Android#Notify");
        }

        public void Notify (Exception exception, Severity severity, MetaData metaData)
        {
            Debug.Log ("Android#Notify");
        }

        public string AppVersion
        {
            set {
                bugsnagClient.Call ("setAppVersion", value);
            }
        }

        private AndroidJavaObject getClient ()
        {
            if (bugsnagClient == null) {
                throw new InvalidOperationException("You must call Bugsnag.Init before any other Bugsnag methods");
            }

            return bugsnagClient;
        }
    }
}


#endif
