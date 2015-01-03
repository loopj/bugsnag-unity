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
                System.Console.Write("[Bugsnag] You must set your API key in your Bugsnag GameObject!");
            } else {
                Bugsnag.Client.Init(BugsnagApiKey);
                Bugsnag.Client.Context = Application.loadedLevelName;
            }
        }

        void OnEnable() {

        }

        void OnDisable() {

        }

        void OnLevelWasLoaded(int level) {
            Bugsnag.Client.Context = Application.loadedLevelName;
        }
    }
}
