using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float speed = 6.0f;
    private float moviment = 0;
    public bool colliderScreen = false;
    private Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

    }

    void Update()
    {
        if (gameObject == null)
        {
            return;
        }
        moviment += Time.deltaTime;

        if (moviment > 0.6f)
        {
            // Random... esquerda, centro, direita
            // float x = Random.Range(0f, 100f);
            if (colliderScreen == false)
            {
                if (transform.position.x < 8)
                {
                    transform.position += new Vector3(2, 0, 0);
                }
            }
            else
            {
                if (transform.position.x > -8)
                {
                    transform.position += new Vector3(-2, 0, 0);
                }
            }

            moviment = 0;
        }

        Vector3 moveDirection = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, 0);
        transform.position = moveDirection;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.DecrementLife();
            gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "ColliderRight")
        {
            colliderScreen = true;
            Debug.Log("trigger right");
        }
        else if (other.gameObject.tag == "ColliderLeft")
        {
            colliderScreen = false;
            Debug.Log("trigger left");
        }
        else if (other.gameObject.tag == "ColliderDown")
        {
            colliderScreen = true;
            if (gameObject != null)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
