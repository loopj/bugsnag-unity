using System;
using UnityEngine;

namespace Bugsnag
{
    public class GameObject : MonoBehaviour
    {
        public string BugsnagApiKey = "";

        void Awake() {
            DontDestroyOnLoad(this);

            if(String.IsNullOrEmpty(BugsnagApiKey)) {
                UnityEngine.Debug.LogError("You must set your Bugsnag API key in your Bugsnag GameObject!");
            } else {
                Bugsnag.Client.Init(BugsnagApiKey);
                Bugsnag.Client.Context = Application.loadedLevelName;
            }
        }

        void OnEnable () {

        }

        void OnDisable () {

        }

        void OnLevelWasLoaded(int level) {
            Bugsnag.Client.Context = Application.loadedLevelName;
        }
    }
}
