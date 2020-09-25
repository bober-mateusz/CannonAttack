using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonAttackTest
{
    using NUnit.Framework;

    [TestFixture]
    public class TestClass
    {
        [Test]
        public void CannonIDValid()
        {
            Cannon cannon = new Cannon();
            Assert.IsNotNull(cannon.ID);
        }
    }
}

