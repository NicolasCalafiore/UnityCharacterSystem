using UnityEngine;

public class World : MonoBehaviour
{
    public static float ticksPerRealSecond = 1440f;  // 1 day per real-life minute
    float simSecondAccumulator;

    [SerializeField] string time;

    void Update()
    {
        // Add the number of simulated seconds that elapsed this frame
        simSecondAccumulator += Time.deltaTime * ticksPerRealSecond;

        // Process whole-second ticks
        while (simSecondAccumulator >= 1f)
        {
            Calendar.AddSecond();
            simSecondAccumulator -= 1f;
        }

        time = Calendar.GetTimeString();
    }
}
