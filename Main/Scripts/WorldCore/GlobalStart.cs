using UnityEngine;

public class GlobalStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Load the prefab from the Resources folder
        GameObject characterPrefab = Resources.Load<GameObject>("Prefabs/Character");

        if (characterPrefab != null)
        {
            // Instantiate the prefab at position (0, 0, 0) with no rotation
            Instantiate(characterPrefab, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Character prefab not found in Resources/Prefabs!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
