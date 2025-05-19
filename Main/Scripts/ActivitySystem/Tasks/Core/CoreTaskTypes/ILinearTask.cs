using Assets.Main.Scripts.ActivitySystem.Missions.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Main.Scripts
{
    interface ILinearTask : IActivityTaskStructure
    {
        public List<IMission> MissionsToDoInOrder { get; set; }
    }
}
