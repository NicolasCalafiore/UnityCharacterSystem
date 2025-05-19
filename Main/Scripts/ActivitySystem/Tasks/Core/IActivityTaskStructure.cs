using UnityEngine;

public interface IActivityTaskStructure
{
    bool IsCompleted { get; set; }
    bool IsInProgress { get; set; }
    bool IsStarted { get; set; }
    bool Completed();
    bool Started();
    bool InProgress();
    void Start();
    void Tick(GameObject charObj);
    void CheckProgress();
}
