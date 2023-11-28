using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace usertests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = "Paliompempoulhs";
            var createdUser = User.Create("Paliompempoulhs");
            Assert.IsTrue(createdUser != null);
            Assert.AreEqual(name, createdUser.Name);
            Assert.IsFalse(createdUser == null);
            Assert.AreNotEqual("Paliompempaki", createdUser.Name);
        }
    }
}
