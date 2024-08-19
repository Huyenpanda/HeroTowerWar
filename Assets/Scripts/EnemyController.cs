using TMPro;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public TextMeshPro playerText;
    public TextMeshPro enemyText;
    [SerializeField] private float attackRange = 2f;
    public void Attack()
    {
        
    }
    


    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
