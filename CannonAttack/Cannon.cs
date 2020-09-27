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
        private readonly int MAXVELOCITY = 30000000;
        private readonly int MAXDISTANCEOFTARGET = 20000;
        private int distanceOfTarget;
        private readonly double GRAVITY = 9.8;
        private readonly int BURSTRADIUS = 50;
        private int shots;


        public void Reset()
        {
            shots = 0;
        }
        public int DistanceOfTarget
        {
            get { return distanceOfTarget; }
            set { distanceOfTarget = value; }
        }
        public int Shots
        {
            get
            {
                return shots;
            }
        }
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
            Random r = new Random();
            SetTarget(r.Next(MAXDISTANCEOFTARGET));
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
                return Tuple.Create(false, "Angle Incorrect");
            }
            if (velocity > MAXVELOCITY)
            {
                return Tuple.Create(false, "Velocity of the cannon cannot travel faster than the speed of light");
            }
            string message;
            bool hit;
            int distanceOfShot = CalculateDistanceOfCannonShot(angle, velocity);
            if (distanceOfShot.WithinRange(this.distanceOfTarget, BURSTRADIUS))
            {
                message = String.Format("Hit - {0} Shot(s)",shots);
                hit = true;
            }
            else
            {
                message = String.Format("Missed Cannonball landed at {0} Meters", distanceOfShot);
                hit = false;
            }
            shots++;
            return Tuple.Create(hit, message);
        }

        public int CalculateDistanceOfCannonShot(int angle, int velocity)
        {
            int time = 0;
            double height = 0;
            double distance = 0;
            double angleInRadians = (3.1415926536 / 180) * angle;
            while (height >= 0)
            {
                time++;
                distance = velocity * Math.Cos(angleInRadians) * time;
                height = (velocity * Math.Sin(angleInRadians) * time) - (GRAVITY * Math.Pow(time, 2)) / 2;
            }
            return (int)distance;
        }

        public void SetTarget(int distanceOfTarget)
        {
            if(!distanceOfTarget.Between(0, MAXDISTANCEOFTARGET))
            {
                throw new ApplicationException(String.Format("Target distance must be between 1 and {0} meters", MAXDISTANCEOFTARGET));
            }
            this.distanceOfTarget = distanceOfTarget;
        }


       
    }
}
