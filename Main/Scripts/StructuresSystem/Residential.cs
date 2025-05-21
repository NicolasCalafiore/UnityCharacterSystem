using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Main.Scripts.StructuresSystem
{
    internal class Residential : Structure
    {
        public List<Character> occupants { get; set; }
        public int totalCapacity { get; set; }
        public int currentOccupantNum { get; set; }
        public Residential()
        {

        }

        void Start()
        {

        }


    }
}
