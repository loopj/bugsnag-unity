using System;
using UnityEngine;

namespace Bugsnag.Platforms
{
    internal class Dummy : IPlatform
    {
        public string AppVersion
        {
            set {
                Debug.Log ("Dummy#AppVersion#set");
            }
        }

        public string Context
        {
            set {
                Debug.Log ("Dummy#Context#set");
            }
        }

        public string Endpoint
        {
            set {
                Debug.Log ("Dummy#Endpoint#set");
            }
        }

        public string ReleaseStage
        {
            set {
                Debug.Log ("Dummy#ReleaseStage#set");
            }
        }

        public string UserId
        {
            set {
                Debug.Log ("Dummy#UserId#set");
            }
        }

        public string UserEmail
        {
            set {
                Debug.Log ("Dummy#UserEmail#set");
            }
        }

        public string UserName
        {
            set {
                Debug.Log ("Dummy#UserName#set");
            }
        }

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
    }
}
