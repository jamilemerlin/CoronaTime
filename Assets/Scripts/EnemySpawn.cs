using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float speed = 6.0f;
    private float movement = 0;
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
        movement += Time.deltaTime;

        if (movement > 0.6f)
        {
            float x = Random.Range(0f, 100f);
            if (x <= 40)
            {
                if (transform.position.x > -9)
                {
                    transform.position += new Vector3(-1, 0, 0);
                }
            }
            else if (x >= 60)
            {
                if (transform.position.x < 9)
                {
                    transform.position += new Vector3(1, 0, 0);
                }
            }

            movement = 0;
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

        else if (other.gameObject.tag == "ColliderDown")
        {
            if (gameObject != null)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
