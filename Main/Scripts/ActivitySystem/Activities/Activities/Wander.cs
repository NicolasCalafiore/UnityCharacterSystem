using Assets.Main.Scripts.ActivitySystem.Activities.Core;
using Assets.Main.Scripts.ActivitySystem.Missions.Missions;
using Assets.Main.Scripts.ActivitySystem.Tasks.Tasks.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Main.Scripts.ActivitySystem.Activities.Activities
{
    internal class Wander : IActivity
    {
        public List<ActivityTaskContainer> tasksToDoInOrder => new List<ActivityTaskContainer>();
        public bool IsCompleted { get; set; } = false;
        public bool isInProgress { get; set; } = false;
        public bool isStarted { get; set; } = false;


        public Wander() {
 
        }

        public void Start()
        {
            ActivityTaskContainer ATC = new ActivityTaskContainer();
            Wandering W = new Wandering();
            ATC.AddStructuredTask(W);

            tasksToDoInOrder.Add(ATC);

            tasksToDoInOrder[0].Start();
        }
        public void Tick(GameObject charObj)
        {
            Debug.Log("Wander Tick");
            tasksToDoInOrder[0].Tick(charObj);
        }


        public bool StartNextTask()
        {
            tasksToDoInOrder.RemoveAt(0);
            if (tasksToDoInOrder.Count < 0)
            {
                IsCompleted = true;
                return false;
            }
            return false;
        }


    }
}
