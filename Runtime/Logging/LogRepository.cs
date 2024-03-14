using SebastianFeistl.Winky.Core;

namespace SebastianFeistl.Winky.Logging
{
    public class LogRepository : Repository<int, LogData>
    {
        public int Incrementer { get; private set; }

        public void Add(LogData model)
        {
            var id = GetIncrementedId();
            
            Add(id, model);
        }

        private int GetIncrementedId()
        {
            Incrementer++;
            
            return Incrementer;
        }
    }
}