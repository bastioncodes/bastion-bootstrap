namespace SebastianFeistl.Winky.Logging
{
    public interface ILoggable
    {
        public bool EnableLogging => false;
        public string LogChannel => "Default";
    }
}