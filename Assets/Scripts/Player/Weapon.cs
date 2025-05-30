

using Cinemachine;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LayerMask interactionLayerMask;

    CinemachineImpulseSource impulseSource;

    void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }
    public void Shoot(WeaponSO weaponSO)
    {
        muzzleFlash.Play();
        AudioManager.Instance.PlaySFX(weaponSO.shootSFX);

        impulseSource.GenerateImpulse();
        // Perform raycast to hit target
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit,
                                Mathf.Infinity, interactionLayerMask, QueryTriggerInteraction.Ignore))
        {


            Instantiate(weaponSO.HitVFXPrefab, hit.point, Quaternion.identity);

            EnemyHealth enemyHealth = hit.collider.GetComponentInParent<EnemyHealth>();
            enemyHealth?.TakeDamage(weaponSO.Damage);
        }
    }
   
}
