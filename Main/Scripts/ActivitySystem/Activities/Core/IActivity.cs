using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Main.Scripts.ActivitySystem.Activities.Core
{
    public interface IActivity
    {
        List<RoutineExecutor> tasksToDoInOrder { get; }
        bool IsCompleted { get; set; }
        bool isInProgress { get; set; }
        bool isStarted { get; set; }

        public void Start();
        public void Tick(GameObject charObj);

        public string GetActivityName()
        {
            return this.GetType().Name;
        }
    }
}
