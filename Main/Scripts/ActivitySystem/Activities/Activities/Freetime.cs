using Assets.Main.Scripts.ActivitySystem.Activities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Main.Scripts.ActivitySystem.Activities.Activities
{
    internal class Freetime : ICharacterActivity
    {
        public List<ActivityTasks> tasksToDoInOrder => new List<ActivityTasks>();


        public Freetime() { }

        public void Tick()
        {

        }

        public bool StartNextTask()
        {
             
            return false;
        }

        public void ActivityTick()
        {

        }
    }
}
