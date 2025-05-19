using Assets.Main.Scripts.ActivitySystem.Missions.Core;
using Assets.Main.Scripts.ActivitySystem.Missions.Missions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Main.Scripts.ActivitySystem.Tasks.Tasks.Tasks
{
    internal class Wandering : ILinearTask
    {
        public List<IMission> MissionsToDoInOrder { get; set; } = new List<IMission>();
        public bool IsCompleted { get; set; }
        public bool IsInProgress { get; set; }
        public bool IsStarted { get; set; }
        public bool MissionCompleted { get; set; } = false;
        public bool MissionStarted { get; set; } = false;
        public bool Completed() => IsCompleted;
        public bool Started() => IsStarted;
        public bool InProgress() => IsInProgress; 

        public Wandering()
        {
            MissionsToDoInOrder.Add(new WalkToRandom(5, 5));
        }

        public void Start()
        {
            IsStarted = true;
            IsInProgress = true;
            IsCompleted = false;
        }

        public void Tick(GameObject charObj)
        {
            Debug.Log("Wandering Tick");
            if (!IsStarted || IsCompleted)
                return;

            if ((MissionCompleted || !MissionStarted) && MissionsToDoInOrder.Count != 0)
                MissionsToDoInOrder[0].StartMission(charObj);

            if (MissionsToDoInOrder[0].isMissionCompleted(charObj))
            {
                MissionCompleted = true;
                MissionsToDoInOrder.RemoveAt(0);
                MissionStarted = false;
            }

            if (MissionsToDoInOrder.Count == 0)
            {
                IsCompleted = true;
                IsInProgress = false;
                IsStarted = false;
            }

        }

        public void CheckProgress()
        {
            // Logic for checking progress  
        }

    }
}
