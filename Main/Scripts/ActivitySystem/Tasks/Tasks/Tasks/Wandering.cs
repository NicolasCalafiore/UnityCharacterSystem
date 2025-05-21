// Assets/Main/Scripts/ActivitySystem/Tasks/Tasks/Tasks/Wandering.cs
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Assets.Main.Scripts.ActivitySystem.Missions.Core;
using Assets.Main.Scripts.ActivitySystem.Missions.Missions;

namespace Assets.Main.Scripts.ActivitySystem.Tasks.Tasks.Tasks
{
    internal class Wandering : IMissionSequence
    {
        public List<IMission> MissionsToDoInOrder { get; } = new List<IMission>();
        public bool IsCompleted { get; set; } = false;
        public bool IsInProgress { get; set; } = false;
        public bool IsStarted { get; set; } = false;

        public bool Completed() => IsCompleted;
        public bool Started() => IsStarted;
        public bool InProgress() => IsInProgress;

        public void Start()
        {
            if (IsStarted) return;
            IsStarted = true;
            IsInProgress = true;

            // for example: two random‐walk missions
            // you can parameterize ranges however you like
            var agent = GameObject.FindObjectOfType<NavMeshAgent>();
            MissionsToDoInOrder.Add(new WalkToRandom(-10, 10, -10, 10, agent));
            MissionsToDoInOrder.Add(new WalkToRandom(-5, 5, -5, 5, agent));

            // kick off the first mission
            MissionsToDoInOrder[0].StartMission(agent.gameObject);
        }

        public void Tick(GameObject charObj)
        {
            if (!IsStarted) Start();
            if (IsCompleted) return;

            var current = MissionsToDoInOrder[0];
            current.Tick(charObj);

            if (current.isMissionCompleted(charObj))
            {
                MissionsToDoInOrder.RemoveAt(0);

                if (MissionsToDoInOrder.Count > 0)
                    MissionsToDoInOrder[0].StartMission(charObj);
                else
                {
                    IsCompleted = true;
                    IsInProgress = false;
                }
            }
        }

        public void CheckProgress() { /* optional */ }
    }
}
