using System;
using UnityEngine;

namespace Bugsnag
{
    public class GameObject : MonoBehaviour
    {
        public string BugsnagApiKey = "";

        void Awake() {
            DontDestroyOnLoad(this);

            // TODO: Check non-empty api key before init

            Bugsnag.Client.Init(BugsnagApiKey);
            Bugsnag.Client.Context = Application.loadedLevelName;
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
