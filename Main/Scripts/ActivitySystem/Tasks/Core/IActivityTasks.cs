using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Main.Scripts
{
    internal interface IActivityTasks
    {

        public bool isCompleted();
        public bool isStarted();
        public void Start();
    }
}
