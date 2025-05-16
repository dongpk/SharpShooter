using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] int damegeAmount = 1;
    StarterAssetsInputs starterAssetsInputs;
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

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(damegeAmount);
            // if(enemyHealth)
            // {
            //     enemyHealth.TakeDamage(damegeAmount);
            // }
            starterAssetsInputs.ShootInput(false);
        }

       
    }
}
