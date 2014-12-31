using System;
using UnityEngine;

namespace Bugsnag.Clients
{
    internal class DummyClient : IClient
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
