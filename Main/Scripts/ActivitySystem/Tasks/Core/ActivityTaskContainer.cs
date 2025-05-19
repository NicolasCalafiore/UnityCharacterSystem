// Assets/Main/Scripts/ActivityTaskContainer.cs
using System.Collections.Generic;
using UnityEngine;

public class ActivityTaskContainer
{
    public List<IActivityTaskStructure> StructuredTasks { get; set; }
        = new List<IActivityTaskStructure>();

    public bool IsCompleted { get; set; } = false;
    public bool isInProgress { get; set; } = false;
    public bool isStarted { get; set; } = false;

    public void Start()
    {
        if (isStarted) return;
        isStarted = true;
        isInProgress = true;

        if (StructuredTasks.Count > 0)
            StructuredTasks[0].Start();
        else
            IsCompleted = true;
    }

    public void Tick(GameObject charObj)
    {
        if (!isStarted) Start();
        if (IsCompleted) return;

        var current = StructuredTasks[0];
        current.Tick(charObj);

        if (current.IsCompleted)
        {
            StructuredTasks.RemoveAt(0);
            if (StructuredTasks.Count > 0)
                StructuredTasks[0].Start();
            else
                IsCompleted = true;
        }
    }

    public void CheckProgress() { /* optional */ }
}
