using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Main.Scripts.StructuresSystem
{
    
    internal abstract class Structure: MonoBehaviour
    {

        public List<Character> occupants { get; set; }
        public int totalCapacity { get; set; }
        public int currentOccupantNum { get; set; }
        public bool AddOccupant(Character charac)
        {
            if (currentOccupantNum < totalCapacity)
            {
                currentOccupantNum++;
                occupants.Add(charac);
                return true;
            }
            return false;
        }
        public void OccupantIsLeaving(Character charac)
        {
            if (currentOccupantNum > 0)
            {
                currentOccupantNum--;
                occupants.Remove(charac);
            }
        }
        public bool isFull()
        {
            if (currentOccupantNum >= totalCapacity)
            {
                return true;
            }
            return false;
        }
    }
}
