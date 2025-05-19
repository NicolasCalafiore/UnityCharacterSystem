// Assets/Main/Scripts/CharacterCore/Character.cs
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Brain brain;

    [SerializeField] public string ActivityName = "None";
    [SerializeField] public static bool isDebug = true;

    private float simSecondAccumulator = 0f;
    private int secondsPerBrainTick = 5;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        brain = new Brain();
    }

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
