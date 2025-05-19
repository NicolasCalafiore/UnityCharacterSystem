using Assets.Main.Scripts.ActivitySystem.Missions.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Main.Scripts.ActivitySystem.Missions.Missions
{
    internal class WalkToRandom : IMission
    {
        int minRangeX;
        int maxRangeX;
        int minRangeZ;
        int maxRangeZ;
        Vector3 newPosition;
        public WalkToRandom(int maxRangeX, int maxRangeZ, int minRangeX = 0, int minRangeZ = 0)
        {
            this.minRangeX = minRangeX;
            this.maxRangeX = maxRangeX;
            this.minRangeZ = minRangeZ;
            this.maxRangeZ = maxRangeZ;
        }

        public bool Completed { get; set; } = false;
        public bool InProgress { get; set; } = false;

        public bool missionFailed { get; set; } = false;
        public void StartMission(GameObject charObj)
        {
            int randX = UnityEngine.Random.Range(minRangeX, maxRangeX);
            int randZ = UnityEngine.Random.Range(minRangeZ, maxRangeZ);
            InProgress = true;
            NavMeshAgent navMeshAgent = charObj.GetComponent<NavMeshAgent>();
            newPosition = charObj.transform.position + new Vector3(randX, 0, randZ);
            navMeshAgent.SetDestination(newPosition);
        }
        public bool isMissionCompleted(GameObject charObj)
        {
            NavMeshAgent navMeshAgent = charObj.GetComponent<NavMeshAgent>();

            if (!navMeshAgent.pathPending &&
                navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance &&
                (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f))
            {
                Completed = true;
                InProgress = false;
                return true;
            }

            return false;
        }

        public void Tick(GameObject charObj)
        {
            Debug.Log("WalkToRandom Tick");
        }

        public float CheckProgress(GameObject charObj)
        {
            NavMeshAgent navMeshAgent = charObj.GetComponent<NavMeshAgent>();

            if (navMeshAgent == null)
            {
                Debug.LogError("NavMeshAgent component is missing on the GameObject.");
                return 0f;
            }

            // Calculate the total distance from the starting position to the target position
            float totalDistance = Vector3.Distance(navMeshAgent.transform.position, newPosition);

            // Calculate the remaining distance to the target position
            float remainingDistance = navMeshAgent.remainingDistance;

            // If the remaining distance is less than or equal to the stopping distance, return 1 (completed)
            if (remainingDistance <= navMeshAgent.stoppingDistance)
            {
                return 1f;
            }

            // Calculate progress as a fraction of the total distance
            float progress = 1f - (remainingDistance / totalDistance);

            // Clamp progress to ensure it stays between 0 and 1
            return Mathf.Clamp(progress, 0f, 1f);
        }

    }
}
