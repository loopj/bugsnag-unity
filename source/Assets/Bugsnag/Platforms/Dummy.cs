using System;
using System.Diagnostics;
using UnityEngine;

namespace Bugsnag.Platforms
{
    internal class Dummy : IPlatform
    {
        public Dummy (string apiKey)
        {
            UnityEngine.Debug.Log ("Dummy#Init");
        }

        public string AppVersion
        {
            set {
                UnityEngine.Debug.Log ("Dummy#AppVersion#set");
            }
        }

        public string Context
        {
            set {
                UnityEngine.Debug.Log ("Dummy#Context#set");
            }
        }

        public string Endpoint
        {
            set {
                UnityEngine.Debug.Log ("Dummy#Endpoint#set");
            }
        }

        public string ReleaseStage
        {
            set {
                UnityEngine.Debug.Log ("Dummy#ReleaseStage#set");
            }
        }

        public string UserId
        {
            set {
                UnityEngine.Debug.Log ("Dummy#UserId#set");
            }
        }

        public string UserEmail
        {
            set {
                UnityEngine.Debug.Log ("Dummy#UserEmail#set");
            }
        }

        public string UserName
        {
            set {
                UnityEngine.Debug.Log ("Dummy#UserName#set");
            }
        }

        public void Notify (String errorClass, String message, StackFrame[] stacktrace, Severity severity, MetaData metaData)
        {
            UnityEngine.Debug.Log ("Dummy#Notify");
        }
    }
}
