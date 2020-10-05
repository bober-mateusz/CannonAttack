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
            Cannon cannon = Cannon.GetInstance();
            Assert.IsNotNull(cannon.ID);
        }
        
        [Test]
        public void TestCannonMultipleInstances()
        {
            Cannon cannon = Cannon.GetInstance();
            Cannon cannon2 = Cannon.GetInstance();
            Assert.IsTrue(cannon == cannon2);
        }

        [Test]
        public void TestCannonShootIncorrectAngle()
        {
            Cannon cannon = Cannon.GetInstance();
            var shot = cannon.shoot(95, 100);
            Assert.IsFalse(shot.Item1);
        }

        [Test]
        public void TestCannonShootVelocityGreaterThanSpeedOfLight()
        {
            Cannon cannon = Cannon.GetInstance();
            var shot = cannon.shoot(45, 300000001);
            Assert.IsFalse(shot.Item1);
        }

        [Test]
        public void TestCannonShootMiss()
        {
            Cannon cannon = Cannon.GetInstance();
            cannon.SetTarget(2000);
            var shot = cannon.shoot(45, 350);
            Assert.IsTrue(shot.Item2 == "Missed Cannonball landed at 12621 Meters");
        }

        [Test]
        public void TestCannonShootHit()
        {
            Cannon cannon = Cannon.GetInstance();
            cannon.Reset();
            cannon.SetTarget(12621);
            var shot = cannon.shoot(45, 350);
            Assert.IsTrue(shot.Item2 == "Hit - 1 Shot(s)");
        }

        [Test]
        public void TestCannonCountShots()
        {
            Cannon cannon = Cannon.GetInstance();
            cannon.Reset();
            cannon.SetTarget(12621);
            var shot = cannon.shoot(45, 350);
            Assert.IsTrue(shot.Item2 == "Hit - 1 Shot(s)", "Number of shots :" + cannon.Shots);
        }
        [Test]
        public void TestCannonMissDistance()
        {
            Cannon cannon = Cannon.GetInstance();
            cannon.SetTarget(12621);
            var shot = cannon.shoot(45, 300);

            Assert.IsTrue(cannon.DistanceFromTarget(cannon.DistanceOfTarget, cannon.CalculateDistanceOfCannonShot(45, 300)) == -3288);



        }
    }


}

