using Assets.Main.Scripts.ActivitySystem.Activities.Activities;
using Assets.Main.Scripts.ActivitySystem.Activities.Core;
using UnityEngine;

public class Brain
{
    IActivity curr_activity = null;
    int curr_tick = 0;
    int ticks_per_activity = 2; // How many ticks before the activity is done

    public Brain(){}

    public void BrainTick(GameObject charObj)
    {
        if(Character.isDebug)
            Debug.Log("Brain Tick");

        curr_tick++;

        if (curr_activity == null)
            SetActivity(charObj);

        if (curr_tick % ticks_per_activity == 0 && curr_activity != null)
            curr_activity.Tick(charObj);

 

    }

    public void SetActivity(GameObject charObj)
    {
        if(Calendar.hours > 1)
            curr_activity = new Wander();

        charObj.GetComponent<Character>().ActivityName = curr_activity.GetActivityName();

        curr_activity.Start();
    }

}
