// Assets/Main/Scripts/CharacterCore/Brain.cs
using Assets.Main.Scripts.ActivitySystem.Activities.Core;
using Assets.Main.Scripts.ActivitySystem.Activities.Activities;
using UnityEngine;

public class Brain
{
    IActivity curr_activity = null;

    public void BrainTick(GameObject charObj)
    {
        if (curr_activity == null || curr_activity.IsCompleted)
            SetActivity(charObj);

        if (!curr_activity.isStarted)
            curr_activity.Start();

        curr_activity.Tick(charObj);
    }

    public void SetActivity(GameObject charObj)
    {
        curr_activity = new Wander();
        Character c = charObj.GetComponent<Character>();
        c.ActivityName = curr_activity.GetActivityName();
        curr_activity.IsCompleted = false;
        curr_activity.isInProgress = false;
        curr_activity.isStarted = false;
        curr_activity.Start();
    }
}
