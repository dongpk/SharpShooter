using Cinemachine;
using StarterAssets;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] CinemachineVirtualCamera playerFollowCamera;
    [SerializeField] GameObject zoomVignette;


    Animator animator;
    StarterAssetsInputs starterAssetsInputs;
    FirstPersonController firstPersonController;
    Weapon currentWeapon;


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
        currentWeapon = GetComponentInChildren<Weapon>();
    }
    // Update is called once per frame
    void Update()
    {
        HandleShoot();
        HandleZoom();

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
        this.weaponSO = weaponSO;
    }
    void HandleShoot()
    {
        timeToShoot += Time.deltaTime;

        if (!starterAssetsInputs.shoot) return;

        if (timeToShoot >= weaponSO.FireRate)
        {
            currentWeapon.Shoot(weaponSO);
            animator.Play(SHOT_STRING, 0, 0f);
            timeToShoot = 0f;
        }

        if (!weaponSO.IsAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }
        // starterAssetsInputs.ShootInput(false);      
    }

    void HandleZoom()
    {
        if (!weaponSO.CanZoom) return;

        if (starterAssetsInputs.zoom)
        {
            // Debug.Log("Zoommmm");
            playerFollowCamera.m_Lens.FieldOfView = weaponSO.ZoomAmount;
            zoomVignette.SetActive(true);
            firstPersonController.ChangeRoatationSpeed(weaponSO.ZoomRotationSpeed);
        }
        else
        {
            // Debug.Log("deo zoom " );    
            playerFollowCamera.m_Lens.FieldOfView = defaultFOV;
            zoomVignette.SetActive(false);
            firstPersonController.ChangeRoatationSpeed(defaultRotationSpeed);


        }
    }
}
