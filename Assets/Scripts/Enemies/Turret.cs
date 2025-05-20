using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField ] GameObject projectilePrefab;
    [SerializeField] Transform turretHead;
    [SerializeField] Transform playerTargetPoint;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] float fireRate = 3f;
    [SerializeField] int damage =1;

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
            Projectile newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity).GetComponent<Projectile>();
            newProjectile.transform.LookAt(playerTargetPoint);
            newProjectile.Init(damage);
        }   
    }

    void Update()
    {
        turretHead.LookAt(playerTargetPoint.position);
    }
}
