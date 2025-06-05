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

    /// <summary>
    /// khởi tạo vòng lặp để bắn projectile về phía player
    /// cứ sau fireRate giây sẽ bắn một projectile về phía player
    /// </summary>
    /// <returns></returns>
    IEnumerator FireRoutine()
    {
        // đảm bảo rằng player còn sống
        while (player)
        {
            // Fire the projectile
            yield return new WaitForSeconds(fireRate);
            Projectile newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position,
                                                 Quaternion.identity).GetComponent<Projectile>();
            //hướng bay của projectile sẽ hướng về player
            newProjectile.transform.LookAt(playerTargetPoint);
            newProjectile.Init(damage);
        }   
    }

    void Update()
    {
        //xoay đầu của turret về phía player
        turretHead.LookAt(playerTargetPoint.position);
    }
}
