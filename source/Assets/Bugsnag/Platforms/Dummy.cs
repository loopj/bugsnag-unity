using System;
using UnityEngine;

namespace Bugsnag.Platforms
{
    internal class Dummy : IPlatform
    {
        public void Init (string apiKey)
        {
            Debug.Log ("DummyClient#Init");
        }

        public void Notify(Exception exception)
        {
            Debug.Log ("DummyClient#Notify");
        }
    }
}
