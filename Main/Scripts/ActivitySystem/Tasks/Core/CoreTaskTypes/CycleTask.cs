using Assets.Main.Scripts.ActivitySystem.Missions.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Main.Scripts.ActivitySystem.Tasks.Tasks
{
    interface ICycleTask : IActivityTaskStructure
    {
        bool isOnPrecycle { get; set; }
        bool isOnPostcycle { get; set; }
        bool isOnCycle { get; set; }
        List<IMission> missionsPreCycle { get; }
        List<IMission> missionsPostCycle { get; }
        List<IMission> missionsCycle { get; }
        int cycleCounter { get; set; }

        void CheckCycleExitConditions();
        void AddPreCycleMission(IMission mission);
        void AddPostCycleMission(IMission mission);
        void AddCycleMission(IMission mission);
    }
}
 