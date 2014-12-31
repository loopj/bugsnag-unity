using System;
using UnityEngine;

namespace Bugsnag
{
    public class Bugsnag : MonoBehaviour {
        public static void Init (string apiKey)
        {
            getClient().Init(apiKey);
        }

        public static void Notify (Exception exception)
        {
            getClient().Notify(exception);
        }

        private static Clients.IClient getClient()
        {
            #if UNITY_EDITOR
            return new Clients.DummyClient();
            #elif UNITY_ANDROID
            return new Clients.AndroidClient();
            #else
            return new Clients.DummyClient();
            #endif
        }
    }
}
