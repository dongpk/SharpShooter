using StarterAssets;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject hitVFXPrefab;
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] int damegeAmount = 1;
    StarterAssetsInputs starterAssetsInputs;

    const string SHOT_STRING = "Shoot";
    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }
    // Update is called once per frame
    void Update()
    {
       HandleShoot();
        
    }

    void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return ;
        muzzleFlash.Play();
        animator.Play(SHOT_STRING,0,0f);
        starterAssetsInputs.ShootInput(false);
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Instantiate(hitVFXPrefab, hit.point, quaternion.identity);

            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(damegeAmount);
            // if(enemyHealth)
            // {
            //     enemyHealth.TakeDamage(damegeAmount);
            // }
            
        }

       
    }
}
