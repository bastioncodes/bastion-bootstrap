using Bastion.Theme;

namespace Bastion.Logging
{
    public interface ILoggable
    {
        bool EnableLogging => true;
        string LogName => string.Empty;
        string LogColor => Color.Sky;
        string LogChannel => "Default";
    }
}