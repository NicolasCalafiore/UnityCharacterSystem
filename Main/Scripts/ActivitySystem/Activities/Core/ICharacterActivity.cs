using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Main.Scripts.ActivitySystem.Activities.Core
{
    public interface ICharacterActivity
    {
        List<ActivityTasks> tasksToDoInOrder { get; }

        public void Tick();

        public bool StartNextTask();

        public void ActivityTick();

        public string GetActivityName()
        {
            return this.GetType().Name;
        }
    }
}
