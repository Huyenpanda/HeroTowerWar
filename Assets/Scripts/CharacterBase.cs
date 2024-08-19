using System.Collections;
using TMPro;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    public merge _merge;
    public GameObject player;
    public GameObject enemy;
    public TextMeshProUGUI playerText;
    public TextMeshProUGUI enemyText;
    public int point;
    public TextMeshProUGUI pointText;
    [SerializeField] private float attackRange = 2f;


    public virtual void MergePoint()
    {

    }

    public virtual void SetPoint(int _point)
    {
        point = _point;
        pointText.text = point.ToString();
    }

    public virtual void AddPoint(int val)
    {
        point += val;
        pointText.text = point.ToString();
    }

    public virtual void Move()
    {

    }

    public virtual void Attack()
    {
        float distance = Vector3.Distance(transform.position, enemy.transform.position);
        if (distance <= attackRange)
        {
            // Chỉ thực hiện Raycast nếu khoảng cách đủ gần
            RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.right, 10f);

            if (ray.collider != null && ray.collider.CompareTag("Enemy"))
            {
                // Đảm bảo rằng đối tượng va chạm với enemy là player
                if (ray.collider.gameObject == player)
                {
                    int playerScore = int.Parse(playerText.text);
                    int enemyScore = int.Parse(enemyText.text);

                    Debug.Log("Collider hit: " + ray.collider.name);

                    if (playerScore >= enemyScore)
                    {
                        // Di chuyển enemy đến vị trí mới và xoay nó
                        ray.collider.transform.position = new Vector3(1f, 0.4f, 0f);
                        ray.collider.transform.Rotate(0f, 0f, -85f);
                        Debug.Log("Wins!");
                    }
                    else
                    {
                        // Xoay player nếu player thua
                        ray.collider.gameObject.transform.Rotate(0f, 0f, 90f);
                        Debug.Log("Lose!");
                    }
                }
            }
        }
    }

    public virtual void Died()
    {

    }

}
