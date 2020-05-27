using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    public float speed = 15.0f;
    private GameManager gamemanager;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;


    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        if (gamemanager.lifeCount > 0)
        {
            float positionx = (rb.position.x + movement.x * Time.deltaTime * speed);
            Vector2 newPosition = new Vector2(Mathf.Clamp(positionx, -7, 7), -5);
            rb.MovePosition(newPosition);
        }
    }
}

