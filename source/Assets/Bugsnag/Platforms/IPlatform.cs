using System;

namespace Bugsnag.Platforms
{
    public interface IPlatform
    {
        void Init (string apiKey);

        void Notify (Exception exception);
        void Notify (Exception exception, Severity severity);
        void Notify (Exception exception, MetaData metaData);
        void Notify (Exception exception, Severity severity, MetaData metaData);

        string AppVersion
        {
            set;
        }
    }
}
