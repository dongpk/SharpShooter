using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float radius = 1.5f;
    [SerializeField] int damage = 3;

    /// <summary>
    /// hiển thị vòng tròn bán kính trong scene viewview
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


    /// <summary>
    /// Gọi hàm Explode khi đối tượng được khởi tạo,
    /// kích nổ 1 lần duy nhất khi đối tượng được tạo ra.
    /// </summary>
    void Start()
    {
        Explode();
    }
    void Explode()
    {
        // tạo quả cầu ảo với cùng bán kính để truy vấn tất cả Collider ở bên trong.
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hitCollider in hitColliders)
        {
            PlayerHealth playerHealth = hitCollider.GetComponent<PlayerHealth>();
            if (!playerHealth) continue;
            playerHealth.TakeDamage(damage);
            break;
        }
        
    }
}
