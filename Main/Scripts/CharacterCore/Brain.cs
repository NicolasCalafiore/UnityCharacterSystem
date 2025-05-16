using Assets.Main.Scripts.ActivitySystem.Activities.Activities;
using Assets.Main.Scripts.ActivitySystem.Activities.Core;
using UnityEngine;

public class Brain
{
    ICharacterActivity curr_activity = null;
    int curr_tick = 0;
    int ticks_per_activity = 5; // How many ticks before the activity is done

    public Brain(){}

    public void BrainTick(Character character)
    {

        curr_tick++;
        if (curr_tick >= ticks_per_activity)
            curr_activity.ActivityTick();

        if (curr_activity == null)
            SetActivity(character);

    }

    public void ActivityTick(ICharacterActivity activity)
    {
        activity.Tick();
    }

    public void SetActivity(Character character)
    {
        if(Calendar.hours > 1)
            curr_activity = new Freetime();

        character.ActivityName = curr_activity.GetActivityName();


    }

}
