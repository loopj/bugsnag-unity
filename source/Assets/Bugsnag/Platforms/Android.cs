#if UNITY_ANDROID

using System;
using System.Diagnostics;
using UnityEngine;

namespace Bugsnag.Platforms
{
    internal class Android : IPlatform
    {
        private static readonly string BUGSNAG_CLASS = "com.bugsnag.android.Client";

        private AndroidJavaObject bugsnagClient;

        public string AppVersion
        {
            set {
                getClient().Call ("setAppVersion", value);
            }
        }

        public string Context
        {
            set {
                getClient().Call ("setContext", value);
            }
        }

        public string Endpoint
        {
            set {
                getClient().Call ("setEndpoint", value);
            }
        }

        public string ReleaseStage
        {
            set {
                getClient().Call ("setReleaseStage", value);
            }
        }

        public string UserId
        {
            set {
                getClient().Call ("setUserId", value);
            }
        }

        public string UserEmail
        {
            set {
                getClient().Call ("setUserEmail", value);
            }
        }

        public string UserName
        {
            set {
                getClient().Call ("setUserName", value);
            }
        }

        public void Init (string apiKey)
        {
            // Get the current Activity
            AndroidJavaClass unityPlayerClass = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = unityPlayerClass.GetStatic<AndroidJavaObject> ("currentActivity");

            // Construct a Bugsnag Android Client
            bugsnagClient = new AndroidJavaObject (BUGSNAG_CLASS, activity, apiKey);
        }

        public void Notify (String errorClass, String message, StackFrame[] stacktrace, Severity severity, MetaData metaData)
        {
            // Convert stack frames into Java style
            IntPtr? stackframeArrayObject = null;
            for (int i = 0; i < stacktrace.Length; i++) {
                StackFrame frame = stacktrace[i];

                string className = frame.GetMethod().DeclaringType.FullName;
                string methodName = frame.GetMethod().Name;
                string fileName = frame.GetFileName();
                int lineNumber = frame.GetFileLineNumber();

                AndroidJavaObject frameObject = new AndroidJavaObject ("java.lang.StackTraceElement", className, methodName, fileName, lineNumber);
                if(stackframeArrayObject == null) {
                    stackframeArrayObject = AndroidJNI.NewObjectArray(stacktrace.Length, frameObject.GetRawClass(), frameObject.GetRawObject());
                } else {
                    AndroidJNI.SetObjectArrayElement((IntPtr)stackframeArrayObject, i, frameObject.GetRawObject());
                }
            }

            // Build the arguments
            jvalue[] args =  new jvalue[3];
            args[0] = new jvalue() { l = AndroidJNI.NewStringUTF(errorClass) };
            args[1] = new jvalue() { l = AndroidJNI.NewStringUTF(message) };
            args[2] = new jvalue() { l = (IntPtr)stackframeArrayObject };

            // Call Android's notify method
            IntPtr clientConstructorId = AndroidJNI.GetMethodID(getClient().GetRawClass(), "notify", "(Ljava/lang/String;Ljava/lang/String;[Ljava/lang/StackTraceElement;)V");
            AndroidJNI.CallObjectMethod(getClient().GetRawObject(), clientConstructorId, args);
        }

        private AndroidJavaObject getClient ()
        {
            if (bugsnagClient == null) {
                throw new InvalidOperationException("You must call Bugsnag.Init before any other Bugsnag methods");
            }

            return bugsnagClient;
        }
    }
}


#endif
