using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Main.Scripts
{
    public class ActivityTaskContainer
    {

        public List<IActivityTaskStructure> StructuredTasks { get; set;}
        public bool IsCompleted { get; set; }
        public bool isInProgress { get; set; }
        public bool taskInProgress { get; set; }

        public ActivityTaskContainer(){
            StructuredTasks = new List<IActivityTaskStructure>();
            IsCompleted = false;
            isInProgress = false;
            taskInProgress = false;
        }
        public void Start(){
            StructuredTasks[0].Start();
            taskInProgress = true;
        }
        public void AddStructuredTask(IActivityTaskStructure task)
        {
            StructuredTasks.Add(task);
        }
        public void StartNextTask() {
            StructuredTasks.RemoveAt(0);
            if(StructuredTasks.Count < 0)
            {
                IsCompleted = true;
                return;
            }
        }
        public void Tick(GameObject charObj) {
            StructuredTasks[0].Tick(charObj);
        }
        public void CheckProgress() {}


    }
}
