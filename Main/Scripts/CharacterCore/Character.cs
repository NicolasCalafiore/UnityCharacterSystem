using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Brain brain;
    [SerializeField] public string ActivityName = "None";

    private float simSecondAccumulator = 0;
    private int secondsPerBrainTick = 5;

    void Start()
    {
        brain = new Brain();

        navMeshAgent = GetComponent<NavMeshAgent>();    
        Vector3 newPosition = transform.position + new Vector3(2, 0, 0);
        navMeshAgent.SetDestination(newPosition);

    }

    // Update is called once per frame
    void Update()
    {

        simSecondAccumulator += Time.deltaTime;

        while (simSecondAccumulator >= secondsPerBrainTick)
        {
            brain.BrainTick(this);
            simSecondAccumulator -= secondsPerBrainTick;
        }

    }
}
