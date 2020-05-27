using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float speed = 6.0f;
    private float moviment = 0;
    public bool colliderScreen = false;
    private GameManager gamemanager;

    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    void Update()
    {   
        if (gameObject == null)
        {
            return;
        }
        moviment += Time.deltaTime;

        if(moviment > 0.5f){
            if (colliderScreen == false)
            {
                transform.position += new Vector3(2, 0, 0);
                moviment = 0;
            }else
            {
                transform.position += new Vector3(-2, 0, 0);
                moviment = 0;
            }
        }

        Vector3 moveDirection = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, 0); 
        transform.position = moveDirection;
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "ColliderRight"){
            colliderScreen = true;
            transform.position += new Vector3(0, -1, 0);
        }else if (other.gameObject.tag == "ColliderLeft"){
            colliderScreen = false;
            transform.position += new Vector3(0, -1, 0);
        }
        else if (other.gameObject.tag == "ColliderDown")
        {
            colliderScreen = true;
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
            
        }
        else if(other.gameObject.tag == "Player")
        {
            gamemanager.DecrementLife();
            Destroy(gameObject);
        }
    }
}
