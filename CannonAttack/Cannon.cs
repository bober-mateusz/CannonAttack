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
    }
}
