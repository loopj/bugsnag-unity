using System;
using UnityEngine;

namespace Bugsnag.Platforms
{
    internal class Dummy : IPlatform
    {
        public void Init (string apiKey)
        {
            Debug.Log ("Dummy#Init");
        }

        public void Notify (Exception exception)
        {
            Debug.Log ("Dummy#Notify");
        }

        public void Notify (Exception exception, Severity severity)
        {
            Debug.Log ("Dummy#Notify");
        }

        public void Notify (Exception exception, MetaData metaData)
        {
            Debug.Log ("Dummy#Notify");
        }

        public void Notify (Exception exception, Severity severity, MetaData metaData)
        {
            Debug.Log ("Dummy#Notify");
        }

        public string AppVersion
        {
            set {
                Debug.Log ("Dummy#AppVersion#set");
            }
        }
    }
}
