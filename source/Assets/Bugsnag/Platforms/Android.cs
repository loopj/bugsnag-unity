#if UNITY_ANDROID

using System;
using System.Diagnostics;
using UnityEngine;

namespace Bugsnag.Platforms
{
    internal class Android : IPlatform
    {
        private AndroidJavaObject androidClient;

        public Android (string apiKey)
        {
            // Get the current Activity
            AndroidJavaClass unityPlayerClass = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = unityPlayerClass.GetStatic<AndroidJavaObject> ("currentActivity");

            // Construct a Bugsnag Android Client
            androidClient = new AndroidJavaObject ("com.bugsnag.android.Client", activity, apiKey);
        }

        public string AppVersion
        {
            set {
                androidClient.Call ("setAppVersion", value);
            }
        }

        public string Context
        {
            set {
                androidClient.Call ("setContext", value);
            }
        }

        public string Endpoint
        {
            set {
                androidClient.Call ("setEndpoint", value);
            }
        }

        public string ReleaseStage
        {
            set {
                androidClient.Call ("setReleaseStage", value);
            }
        }

        public string UserId
        {
            set {
                androidClient.Call ("setUserId", value);
            }
        }

        public string UserEmail
        {
            set {
                androidClient.Call ("setUserEmail", value);
            }
        }

        public string UserName
        {
            set {
                androidClient.Call ("setUserName", value);
            }
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
            jvalue[] args =  new jvalue[3] {
                new jvalue() { l = AndroidJNI.NewStringUTF(errorClass) },
                new jvalue() { l = AndroidJNI.NewStringUTF(message) },
                new jvalue() { l = (IntPtr)stackframeArrayObject }
            };

            // Call Android's notify method
            IntPtr clientConstructorId = AndroidJNI.GetMethodID(androidClient.GetRawClass(), "notify", "(Ljava/lang/String;Ljava/lang/String;[Ljava/lang/StackTraceElement;)V");
            AndroidJNI.CallObjectMethod(androidClient.GetRawObject(), clientConstructorId, args);
        }
    }
}

#endif
