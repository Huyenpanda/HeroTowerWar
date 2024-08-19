using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Vector3 mousePosition;
    public GameObject player;
    public GameObject enemy;
    public TextMeshPro playerText;
    public TextMeshPro enemyText;
    [SerializeField] private float attackRange =  2f;
    private Vector3 originalPosition; 
    private Vector3 originalTextPosition;
    private EnemyController enemyController;

    private void Start()
    {
        originalPosition = transform.position;
        originalTextPosition = playerText.transform.position;

        enemyController = enemy.GetComponent<EnemyController>();
    }

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        newPosition.z = originalPosition.z; // giữ nguyên giá trị trục Z để tránh di chuyển vào trục Z
        transform.position = newPosition;
        playerText.transform.position = newPosition + new Vector3(0, 1, 0); // Cập nhật vị trí của playerText
    }

    private void OnMouseUp()
    {
        float distance = Vector3.Distance(transform.position, enemy.transform.position);
        if (distance <= attackRange)
        {
            // Đặt vị trí của player trước mặt enemy
            Vector3 attackPosition = enemy.transform.position - new Vector3(1.5f, 0, 0);
            transform.position = attackPosition;
            playerText.transform.position = attackPosition + new Vector3(0, 1, 0); // Cập nhật vị trí của playerText
        }
        else
        {
            // Trở về vị trí ban đầu
            transform.position = originalPosition;
            playerText.transform.position = originalTextPosition;
        }
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, enemy.transform.position);
        if (distance <= attackRange && Input.GetMouseButtonUp(0))
        {
            enemyController.Attack();
        }
    }


    
}
