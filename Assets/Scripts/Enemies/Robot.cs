using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    FirstPersonController player;
    NavMeshAgent agent;

    const string PLAYER_STRING = "Player";
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    void Start()
    {
        // tìm kiếm đối tượng FirstPersonController(player) trong scene
        player = FindFirstObjectByType<FirstPersonController>();

    }
    /// <summary>
    /// cập nhật vị trí của player
    /// </summary>
    void Update()
    {
        if(!player) return;
        agent.SetDestination(player.transform.position);
    }

    //ham nay se duoc goi khi enemy va player va cham
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
            enemyHealth.SelfDestruct();
         
        }
    }
}
