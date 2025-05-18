using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 3;
   
    int currentHealth;
    void Awake()
    {
        currentHealth = startingHealth;
    }
   
    //ham nay se duoc goi khi playeer bi sat thuong
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(amount+" damage taken, current health: " + currentHealth);
        //xoa player neu player bi tieu diet
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
