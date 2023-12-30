using UnityEngine;

public class ObjectInstantiation : MonoBehaviour
{
    public GameObject objectToInstantiate; 
    public Transform[] spawnPoints; 

    public int numberOfObjects = 10; 

    void Start()
    {
        InstantiateObjects();
    }

    void InstantiateObjects()
    {
        if (objectToInstantiate == null || spawnPoints.Length == 0)
        {
            Debug.LogError("Please assign the object prefab and spawn points array in the Inspector.");
            return;
        }

        if (numberOfObjects > spawnPoints.Length)
        {
            Debug.LogWarning("Number of objects to instantiate is greater than the number of spawn points. Adjust accordingly.");
        }

        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition = GetRandomSpawnPoint();
            Instantiate(objectToInstantiate, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomSpawnPoint()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        return spawnPoints[randomIndex].position;
    }
}
