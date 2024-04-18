namespace Bastion.Core.Extensions
{
    public abstract class Model<TData> where TData : Data
    {
        public TData Data { get; protected set; }
    }
}