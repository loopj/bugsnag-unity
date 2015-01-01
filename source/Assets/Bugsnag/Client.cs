using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Bugsnag
{
    public class Client
    {
        private static Platforms.IPlatform platform;

        public static string AppVersion
        {
            set {
                GetPlatform().AppVersion = value;
            }
        }

        public static string Context
        {
            set {
                GetPlatform().Context = value;
            }
        }

        public static string Endpoint
        {
            set {
                GetPlatform().Endpoint = value;
            }
        }

        public static string ReleaseStage
        {
            set {
                GetPlatform().ReleaseStage = value;
            }
        }

        public static string UserId
        {
            set {
                GetPlatform().UserId = value;
            }
        }

        public static string UserEmail
        {
            set {
                GetPlatform().UserEmail = value;
            }
        }

        public static string UserName
        {
            set {
                GetPlatform().UserName = value;
            }
        }

        public static void Init (string apiKey)
        {
            #if UNITY_EDITOR
            platform = new Platforms.Dummy(apiKey);
            #elif UNITY_ANDROID
            platform = new Platforms.Android(apiKey);
            #elif UNITY_IPHONE
            platform = new Platforms.Dummy(apiKey);
            #else
            platform = new Platforms.Dummy(apiKey);
            #endif

            // Set the release stage
            if(UnityEngine.Debug.isDebugBuild) {
                ReleaseStage = "development";
            } else {
                ReleaseStage = "production";
            }
        }

        public static void Notify(Exception exception)
        {
            Notify(exception, Severity.Warning, null);
        }

        public static void Notify(Exception exception, Severity severity)
        {
            Notify(exception, severity, null);
        }

        public static void Notify(Exception exception, MetaData metaData)
        {
            Notify(exception, Severity.Warning, metaData);
        }

        public static void Notify(Exception exception, Severity severity, MetaData metaData)
        {
            // Exception must be present
            if(exception == null) {
                return;
            }

            // Get or generate the stacktrace
            StackFrame[] stacktrace;
            if(exception.StackTrace != null) {
                stacktrace = new StackTrace(exception, true).GetFrames();
            } else {
                stacktrace = GenerateStackTrace();
            }

            GetPlatform().Notify(exception.GetType().ToString(), exception.Message, stacktrace, severity, metaData);
        }

        private static Platforms.IPlatform GetPlatform()
        {
            if (platform == null) {
                throw new InvalidOperationException("You must call Bugsnag.Init before any other Bugsnag methods");
            }

            return platform;
        }

        private static StackFrame[] GenerateStackTrace()
        {
            // Get the current callstack
            StackTrace stacktrace = new StackTrace(true);

            // Filter out any frames in the Bugsnag namespace
            List<StackFrame> frameList = new List<StackFrame>();
            foreach(StackFrame frame in stacktrace.GetFrames()) {
                string ns = frame.GetMethod().DeclaringType.Namespace;
                if(ns == null || !ns.Split('.')[0].Equals("Bugsnag")) {
                    frameList.Add(frame);
                }
            }

            return frameList.ToArray();
        }
    }
}
