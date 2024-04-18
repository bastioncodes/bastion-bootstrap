namespace Bastion.Core.Tests.Editor
{
    public class TestModel
    {
        public string Name { get; }

        public TestModel()
        {
            Name = "Default";
        }

        public TestModel(string name)
        {
            Name = name;
        }
    }
}