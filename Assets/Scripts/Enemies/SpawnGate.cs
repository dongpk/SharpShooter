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
        player = FindFirstObjectByType<PlayerHealth>();
        // Start the spawn routine
        StartCoroutine(SpawnRoutine());
    }
   

    IEnumerator SpawnRoutine()
    {
       
        while (player)
        {
            
            Instantiate(robotPrefab, spawnPoint.position, transform.rotation);
            AudioManager.Instance.PlaySFX(AudioManager.Instance.gate);
            yield return new WaitForSeconds(spawnTime);
        }
        
    }
   
}
