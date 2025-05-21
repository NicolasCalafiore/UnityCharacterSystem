using UnityEngine;

public interface IMissionSequence
{
    bool IsCompleted { get; set; }
    bool IsInProgress { get; set; }
    bool IsStarted { get; set; }
    void Start();
    void Tick(GameObject charObj);
}
