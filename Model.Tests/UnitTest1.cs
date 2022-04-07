using NUnit.Framework;

namespace Model.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var model = new Game.Model.Model();
            Assert.AreEqual(0, model.Counter);
            model.Increment();
            Assert.AreEqual(1, model.Counter);
        }
    }
}