using System;
using UnityEngine;

namespace Bugsnag
{
    public class Client {
        public static void Init (string apiKey)
        {
            getBridge().Init(apiKey);
        }

        public static void Notify (Exception exception)
        {
            getBridge().Notify(exception);
        }

        public string AppVersion
        {
            set {
                getBridge().AppVersion = value;
            }
        }

        private static Platforms.IPlatform getBridge ()
        {
            #if UNITY_EDITOR
            return new Platforms.Dummy();
            #elif UNITY_ANDROID
            return new Platforms.Android();
            #elif UNITY_IPHONE
            return new Platforms.Dummy();
            #else
            return new Platforms.Dummy();
            #endif
        }
    }
}
