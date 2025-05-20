using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField ] GameObject projectilePrefab;
    [SerializeField] Transform turretHead;
    [SerializeField] Transform playerTargetPoint;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] float fireRate = 3f;

    PlayerHealth player;


    void Start()
    {
        player = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(FireRoutine());
    }

    IEnumerator FireRoutine()
    {
        while (player)
        {

            // Fire the projectile
            yield return new WaitForSeconds(fireRate);
            Instantiate(projectilePrefab, projectileSpawnPoint.position, turretHead.rotation);
        }
    }

    void Update()
    {
        turretHead.LookAt(playerTargetPoint.position);
    }
}
