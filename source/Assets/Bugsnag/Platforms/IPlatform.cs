using System;
using System.Diagnostics;

namespace Bugsnag.Platforms
{
    public interface IPlatform
    {
        string AppVersion
        {
            set;
        }

        string Context
        {
            set;
        }

        string Endpoint
        {
            set;
        }

        string ReleaseStage
        {
            set;
        }

        string UserId
        {
            set;
        }

        string UserEmail
        {
            set;
        }

        string UserName
        {
            set;
        }

        void Notify (String errorClass, String message, StackFrame[] stacktrace, Severity severity, MetaData metaData);
    }
}
