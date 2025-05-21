// Assets/Main/Scripts/ActivityTaskContainer.cs
using System.Collections.Generic;
using UnityEngine;

public class RoutineExecutor
{
    public List<IMissionSequence> MissionSequences { get; set; } = new List<IMissionSequence>();

    public bool IsCompleted { get; set; } = false;
    public bool isInProgress { get; set; } = false;
    public bool isStarted { get; set; } = false;

    public void Start()
    {
        if (isStarted) return;
        isStarted = true;
        isInProgress = true;

        if (MissionSequences.Count > 0)
            MissionSequences[0].Start();
        else
            IsCompleted = true;
    }

    public void Tick(GameObject charObj)
    {
        if (!isStarted) Start();
        if (IsCompleted) return;

        var current = MissionSequences[0];
        current.Tick(charObj);

        if (current.IsCompleted)
        {
            MissionSequences.RemoveAt(0);
            if (MissionSequences.Count > 0)
                MissionSequences[0].Start();
            else
                IsCompleted = true;
        }
    }

}
