using UnityEngine;

public class WeaponPickup : Pickup
{
    [SerializeField] WeaponSO weaponSO;

    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
        activeWeapon.WeaponSwitch(weaponSO);
    
    }


    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag(PLAYER_STRING))
    //     {
    //         ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
    //         activeWeapon.WeaponSwitch(weaponSO);
    //         Destroy(this.gameObject);
    //     }
    // }
}
