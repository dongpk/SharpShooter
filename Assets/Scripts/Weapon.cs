

using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LayerMask interactionLayerMask;
    public void Shoot(WeaponSO weaponSO)
    {
        muzzleFlash.Play();
        // Perform raycast to hit target
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit,
                                Mathf.Infinity,interactionLayerMask, QueryTriggerInteraction.Ignore))
        {
            

            Instantiate(weaponSO.HitVFXPrefab, hit.point, Quaternion.identity);

            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(weaponSO.Damage);
        }
    }
   
}
