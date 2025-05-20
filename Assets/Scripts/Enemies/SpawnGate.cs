using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
   [SerializeField] GameObject robotPrefab;
   [SerializeField] float spawnTime = 5f;
   [SerializeField] Transform spawnPoint;

    PlayerHealth player;

    void Start()
    {
        // Start the spawn routine
        StartCoroutine(SpawnRoutine());
    }
   

    IEnumerator SpawnRoutine()
    {
        while ()
        {
            Instantiate(robotPrefab, spawnPoint.position, transform.rotation);
            yield return new WaitForSeconds(spawnTime);
        }
        
    }
   
}
