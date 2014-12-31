using System;
using UnityEngine;

namespace Bugsnag
{
    public class Client {
        private static Platforms.IPlatform bridge;

        public static void Init (string apiKey)
        {
            getBridge().Init(apiKey);
        }

        public static void Notify (Exception exception)
        {
            getBridge().Notify(exception);
        }

        public static string AppVersion
        {
            set {
                getBridge().AppVersion = value;
            }
        }

        private static Platforms.IPlatform getBridge ()
        {
            if (bridge == null) {
                #if UNITY_EDITOR
                bridge = new Platforms.Dummy();
                #elif UNITY_ANDROID
                bridge = new Platforms.Android();
                #elif UNITY_IPHONE
                bridge = new Platforms.Dummy();
                #else
                bridge = new Platforms.Dummy();
                #endif
            }

            return bridge;
        }
    }
}
