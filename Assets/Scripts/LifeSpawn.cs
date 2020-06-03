using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpawn : MonoBehaviour
{
    public float speed = 3.0f;
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

        Vector3 moveDirection = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, 0);
        transform.position = moveDirection;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.IncrementLife();
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
