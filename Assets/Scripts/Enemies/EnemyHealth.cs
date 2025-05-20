using UnityEngine;

public class EnemyHealth : MonoBehaviour
{


    [SerializeField] int startingHealth = 3;
    [SerializeField] GameObject robotExplosionVFX;
    int currentHealth;

    GameManager gameManager;
    void Awake()
    {
        currentHealth = startingHealth;
    }
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.AjustEnemiesLeftText(1);
    }
    //ham nay se duoc goi khi enemy bi sat thuong
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            gameManager.AjustEnemiesLeftText(-1);
            SelfDestruct();
        }
    }
    
 
    //ham nay se duoc goi khi enemy bi tieu diet
    public void SelfDestruct()
    {
        Instantiate(robotExplosionVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
