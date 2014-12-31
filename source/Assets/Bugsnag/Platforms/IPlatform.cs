using System;

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

        void Init (string apiKey);

        void Notify (Exception exception);
        void Notify (Exception exception, Severity severity);
        void Notify (Exception exception, MetaData metaData);
        void Notify (Exception exception, Severity severity, MetaData metaData);
    }
}
