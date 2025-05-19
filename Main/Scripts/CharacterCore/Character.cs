using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Brain brain;
    [SerializeField] public string ActivityName = "None";
    [SerializeField] public static bool isDebug = true;

    private float simSecondAccumulator = 0;
    private int secondsPerBrainTick = 5;

    void Start()
    {
        brain = new Brain();
    }

    // Update is called once per frame
    void Update()
    {

        simSecondAccumulator += Time.deltaTime;

        while (simSecondAccumulator >= secondsPerBrainTick)
        {
            brain.BrainTick(gameObject);
            simSecondAccumulator -= secondsPerBrainTick;
        }

    }
}
