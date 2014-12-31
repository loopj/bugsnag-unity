using System;
using UnityEngine;

namespace Bugsnag
{
    public class Client {
        private static Platforms.IPlatform bridge;

        public static string AppVersion
        {
            set {
                getBridge().AppVersion = value;
            }
        }

        public static string Context
        {
            set {
                getBridge().Context = value;
            }
        }

        public static string Endpoint
        {
            set {
                getBridge().Endpoint = value;
            }
        }

        public static string ReleaseStage
        {
            set {
                getBridge().ReleaseStage = value;
            }
        }

        public static string UserId
        {
            set {
                getBridge().UserId = value;
            }
        }

        public static string UserEmail
        {
            set {
                getBridge().UserEmail = value;
            }
        }

        public static string UserName
        {
            set {
                getBridge().UserName = value;
            }
        }

        public static void Init (string apiKey)
        {
            getBridge().Init(apiKey);
        }

        public static void Notify (Exception exception)
        {
            getBridge().Notify(exception);
        }

        public static void Notify (Exception exception, Severity severity)
        {
            getBridge().Notify(exception, severity);
        }

        public static void Notify (Exception exception, MetaData metaData)
        {
            getBridge().Notify(exception, metaData);
        }

        public static void Notify (Exception exception, Severity severity, MetaData metaData)
        {
            getBridge().Notify(exception, severity, metaData);
        }

        private static Platforms.IPlatform getBridge ()
        {
            if (bridge == null) {
                #if UNITY_EDITOR
                bridge = new Platforms.Dummy();
                #elif UNITY_ANDROID
                bridge = new Platforms.Android();
                #elif UNITY_IPHONE
                bridge = new Platforms.Dummy();
                #else
                bridge = new Platforms.Dummy();
                #endif
            }

            return bridge;
        }
    }
}
