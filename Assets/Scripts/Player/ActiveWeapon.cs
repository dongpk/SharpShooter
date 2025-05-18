using Cinemachine;
using StarterAssets;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO startingWeapon;
    
    [SerializeField] CinemachineVirtualCamera playerFollowCamera;
    [SerializeField] Camera weaponCamera;

    [SerializeField] GameObject zoomVignette;
    [SerializeField] TMP_Text ammoText;

    WeaponSO currentWeaponSO;
    Animator animator;
    StarterAssetsInputs starterAssetsInputs;
    FirstPersonController firstPersonController;
    Weapon currentWeapon;
    int currentAmmo;

    const string SHOT_STRING = "Shoot";
    float timeToShoot = 0f;
    float defaultFOV;
    float defaultRotationSpeed;
    void Awake()
    {

        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        animator = GetComponentInParent<Animator>();
        defaultFOV = playerFollowCamera.m_Lens.FieldOfView;
        defaultRotationSpeed = firstPersonController.RotationSpeed;
    }
    void Start()
    {
        WeaponSwitch(startingWeapon);
        AdjustAmmo(currentWeaponSO.MagazineSize);
    }
    // Update is called once per frame
    void Update()
    {
        HandleShoot();
        HandleZoom();

    }
    public void AdjustAmmo(int amount)
    {
        currentAmmo += amount;

        if (currentAmmo > currentWeaponSO.MagazineSize)
        {
            currentAmmo = currentWeaponSO.MagazineSize;
        }

        ammoText.text = currentAmmo.ToString("D2");       
    }
    public void WeaponSwitch(WeaponSO weaponSO)
    {
        // Debug.Log("Player da nhat " + weaponSO.name);
        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }

        Weapon newWeapon = Instantiate(weaponSO.weaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        this.currentWeaponSO = weaponSO;
        AdjustAmmo(currentWeaponSO.MagazineSize);
    }
    void HandleShoot()
    {
        timeToShoot += Time.deltaTime;

        if (!starterAssetsInputs.shoot) return;

        if (timeToShoot >= currentWeaponSO.FireRate && currentAmmo > 0)
        {
            currentWeapon.Shoot(currentWeaponSO);
            animator.Play(SHOT_STRING, 0, 0f);
            timeToShoot = 0f;
            AdjustAmmo(-1);
        }

        if (!currentWeaponSO.IsAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }
        // starterAssetsInputs.ShootInput(false);      
    }

    void HandleZoom()
    {
        if (!currentWeaponSO.CanZoom) return;

        if (starterAssetsInputs.zoom)
        {
            // Debug.Log("Zoommmm");
            playerFollowCamera.m_Lens.FieldOfView = currentWeaponSO.ZoomAmount;
            weaponCamera.fieldOfView = currentWeaponSO.ZoomAmount;
            zoomVignette.SetActive(true);
            firstPersonController.ChangeRoatationSpeed(currentWeaponSO.ZoomRotationSpeed);
        }
        else
        {
            // Debug.Log("deo zoom " );    
            playerFollowCamera.m_Lens.FieldOfView = defaultFOV;
            weaponCamera.fieldOfView = defaultFOV;

            zoomVignette.SetActive(false);
            firstPersonController.ChangeRoatationSpeed(defaultRotationSpeed);


        }
    }
}
