// Assets/Main/Scripts/ActivitySystem/Activities/Activities/Wander.cs
using System.Collections.Generic;
using UnityEngine;
using Assets.Main.Scripts.ActivitySystem.Activities.Core;
using Assets.Main.Scripts.ActivitySystem.Tasks.Tasks.Tasks;

namespace Assets.Main.Scripts.ActivitySystem.Activities.Activities
{
    internal class Wander : IActivity
    {
        public List<RoutineExecutor> tasksToDoInOrder { get; } = new List<RoutineExecutor>();
        public bool IsCompleted { get; set; } = false;
        public bool isInProgress { get; set; } = false;
        public bool isStarted { get; set; } = false;

        public void Start()
        {
            if (isStarted) return;
            isStarted = true;
            isInProgress = true;

            var container = new RoutineExecutor();

            container.MissionSequences.Add(new Wandering());
            tasksToDoInOrder.Add(container);

            container.Start();
        }

        public void Tick(GameObject charObj)
        {
            if (!isStarted) Start();
            if (IsCompleted) return;

            var container = tasksToDoInOrder[0];
            container.Tick(charObj);

            if (container.IsCompleted)
            {
                tasksToDoInOrder.RemoveAt(0);
                if (tasksToDoInOrder.Count == 0)
                {
                    IsCompleted = true;
                    isInProgress = false;
                }
            }
        }
    }
}
