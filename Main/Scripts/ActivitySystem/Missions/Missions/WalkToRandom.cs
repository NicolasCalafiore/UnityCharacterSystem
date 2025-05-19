// Assets/Main/Scripts/ActivitySystem/Missions/Missions/WalkToRandom.cs
using UnityEngine;
using UnityEngine.AI;
using Assets.Main.Scripts.ActivitySystem.Missions.Core;

namespace Assets.Main.Scripts.ActivitySystem.Missions.Missions
{
    internal class WalkToRandom : IMission
    {
        int minX, maxX, minZ, maxZ;
        NavMeshAgent agent;
        Vector3 destination;
        float totalDistance;

        public bool Completed { get; set; } = false;
        public bool InProgress { get; set; } = false;
        public bool missionFailed { get; set; } = false;

        public WalkToRandom(int minX, int maxX, int minZ, int maxZ, NavMeshAgent agent)
        {
            this.minX = minX;
            this.maxX = maxX;
            this.minZ = minZ;
            this.maxZ = maxZ;
            this.agent = agent;
        }

        public void StartMission(GameObject charObj)
        {
            if (InProgress) return;
            agent = charObj.GetComponent<NavMeshAgent>();
            var pos = charObj.transform.position;
            destination = new Vector3(
                Random.Range(minX, maxX),
                pos.y,
                Random.Range(minZ, maxZ)
            );

            agent.SetDestination(destination);
            totalDistance = Vector3.Distance(pos, destination);
            InProgress = true;
        }

        public bool isMissionCompleted(GameObject charObj)
        {
            if (!InProgress) return false;
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                Completed = true;
                InProgress = false;
                return true;
            }
            return false;
        }

        public void Tick(GameObject charObj)
        {
            // NavMeshAgent drives itself—you could add animation here
        }

        public float CheckProgress(GameObject charObj)
        {
            if (Completed) return 1f;
            float remaining = Vector3.Distance(charObj.transform.position, destination);
            return Mathf.Clamp01(1f - (remaining / totalDistance));
        }
    }
}
