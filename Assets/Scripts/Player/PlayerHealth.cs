using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] int startingHealth = 3;
    [SerializeField] CinemachineVirtualCamera deathVirtualCamera;
    [SerializeField] Transform weaponCamera;
    [SerializeField] Image[] shieldBar;
    [SerializeField] GameObject gameOverContainer;
    [SerializeField] TakeDamageEffect takeDamageEffect;
    int currentHealth;
    int gameoverVirualCameraPriority = 20;

    void Awake()
    {
        currentHealth = startingHealth;
        AdjustShieldUI();
       
    }

    //ham nay se duoc goi khi playeer bi sat thuong
    public void TakeDamage(int amount)
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.takeDamage);
        currentHealth -= amount;
        
        // Debug.Log(amount+" damage taken, current health: " + currentHealth);
        AdjustShieldUI();

        if (takeDamageEffect != null)
        {
            takeDamageEffect.Play();
        }
        //xoa player neu player bi tieu diet
        if (currentHealth <= 0)
        {
            PlayerGameOver();
        }
    }

    void PlayerGameOver()
    {
        weaponCamera.parent = null;
        deathVirtualCamera.Priority = gameoverVirualCameraPriority;
        gameOverContainer.SetActive(true);
        StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
        starterAssetsInputs.SetCursorState(false);
        Destroy(this.gameObject);
    }

    void AdjustShieldUI()
    {
       for (int i = 0; i < shieldBar.Length; i++)
       {
            if (i < currentHealth)
            {
                shieldBar[i].gameObject.SetActive(true);
            }
            else
            {
                shieldBar[i].gameObject.SetActive(false);
            }
       }
    }
}
