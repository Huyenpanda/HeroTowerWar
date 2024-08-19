using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

public class merge : MonoBehaviour
{
    private Vector2 mousePosition;
    private float offsetX, offsetY; //
    public static bool mouseButtonReleased; //null
    public PlayerMerge CurrentCharSelect;
    [SerializeField] private LayerMask maskTarget;


    private void OnMouseDown()
    {
        mouseButtonReleased = false; //ko thả chuột
        /*        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x; //
                offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;*/
        
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - offsetX, mousePosition.y - offsetY);
        
    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true;
    }
    private void Update()
    {
        //Vector2 finish;
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.right, 10f, maskTarget);
        //Vector2 direction = (finish - (Vector2)transform.position).normalized;

        if (ray.collider != null)
        {
            Debug.Log(ray.point);
        }
    }
    public void SelectChar()
    {

    }
    public void CheckMerge(PlayerMerge char1, PlayerPrefs char2)
    {

    }
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        string thisGameobjectName;
        string collisionGameobjectName;

        thisGameobjectName = gameObject.name.Substring(0, name.IndexOf("_"));
        collisionGameobjectName = collision.gameObject.name.Substring(0, name.IndexOf("_"));

        if (mouseButtonReleased && thisGameobjectName == "Acorn" && thisGameobjectName == collisionGameobjectName)
        {
            Instantiate(Resources.Load("Oak_Object"), transform.position, Quaternion.identity);
            //mouseButtonReleased = fasle;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (mouseButtonReleased && thisGameobjectName == "Oak" && thisGameobjectName == collisionGameobjectName)
        {
            //mouseButtonReleased = fasle;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

