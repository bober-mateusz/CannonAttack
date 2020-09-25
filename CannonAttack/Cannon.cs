using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonAttack
{
    public sealed class Cannon
    {
        private readonly string CANNONID = "Human";

        private string CannonID;
        public static readonly int MAXANGLE = 90;
        public static readonly int MINANGLE = 1;

        public string ID
        {
            get
            {
                return (string.IsNullOrWhiteSpace(CannonID)) ? CANNONID : CannonID;
            }
            set
            {
                CannonID = value;
            }
        }


        private static Cannon cannonSingletonInstance;
        static readonly object padlock = new object();
        private Cannon()
        {

        }

        public static Cannon GetInstance()
        {
            lock (padlock)
            {
                if (cannonSingletonInstance == null)
                {
                    cannonSingletonInstance = new Cannon();
                }
                return cannonSingletonInstance;
            }
        }


        public Tuple<bool,string> shoot(int angle, int velocity)
        {
            if (angle > MAXANGLE || angle < MINANGLE)
            {
                return Tuple.Create(false, "Angle Incoorect");
            }
            return Tuple.Create(true, "Angle OK");
            
        }

    }
}
