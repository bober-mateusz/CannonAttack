using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CannonAttack;
namespace CannonAttackTest
{
    

    [TestFixture]
    public class TestClass
    {
        [Test]
        public void CannonIDValid()
        {
            Cannon cannon = new Cannon();
            Assert.IsNotNull(cannon.ID);
        }
        [Test]
        public void TestCannonMultipleInstances()
        {
            Cannon cannon = new Cannon();
            Cannon cannon2 = new Cannon();
            Assert.IsTrue(cannon == cannon2);
        }

    }


}

