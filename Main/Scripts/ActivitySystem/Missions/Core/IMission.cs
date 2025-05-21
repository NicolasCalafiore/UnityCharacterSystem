using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Main.Scripts.ActivitySystem.Missions.Core
{
    internal interface IMission
    {
        bool Completed { get; set; }
        bool InProgress { get; set; }
        void StartMission(GameObject charObj);
        bool isMissionCompleted(GameObject charObj);
        void Tick(GameObject charObj);
    }
}
