using UnityEngine;

public class EnemyHealth : MonoBehaviour
{


    [SerializeField] int startingHealth = 3;
    [SerializeField] GameObject robotExplosionVFX;
    int currentHealth;
    void Awake()
    {
        currentHealth = startingHealth;
    }
   
    //ham nay se duoc goi khi enemy bi sat thuong
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
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
