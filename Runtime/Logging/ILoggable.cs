namespace Bastion.Logging
{
    public interface ILoggable
    {
        bool EnableLogging => true;
        string LogName => string.Empty;
        string LogColor => LoggableColor.Sky;
        string LogChannel => "Default";
    }
}