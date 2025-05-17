using StarterAssets;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    
     Animator animator;
    StarterAssetsInputs starterAssetsInputs;
    Weapon currentWeapon;
    const string SHOT_STRING = "Shoot";
    float timeToShoot = 0f;
    void Awake()
    {

        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponentInParent<Animator>();
    }
    void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
    }
    // Update is called once per frame
    void Update()
    {
        timeToShoot += Time.deltaTime;
       HandleShoot();
        
    }

    void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return ;

        if (timeToShoot >= weaponSO.FireRate)
        {
            currentWeapon.Shoot(weaponSO);
            animator.Play(SHOT_STRING, 0, 0f);
            timeToShoot = 0f;
        }
       
        if(!weaponSO.IsAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }
        // starterAssetsInputs.ShootInput(false);
       

       
    }
}
