using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    public float speed = 10.0f;
    private GameManager gamemanager;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    public int lifeCount = 100;
    public AudioSource audioincrementlife;
    public AudioSource audiodecrementlife;
    public HealthBar healthBar;



    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        healthBar.SetMaxHealth(100);

    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        if (lifeCount > 0)
        {
            float positionx = (rb.position.x + movement.x * Time.deltaTime * speed);
            Vector2 newPosition = new Vector2(Mathf.Clamp(positionx, -10, 10), -5);
            rb.MovePosition(newPosition);
        }
    }


    public void IncrementLife()
    {
        if (lifeCount < 100 && lifeCount > 0)
        {
            lifeCount += 25;
            healthBar.SetHealth(lifeCount);
            audioincrementlife.Play(0);
        }

    }

    public void DecrementLife()
    {
        if (lifeCount > 0)
        {
            lifeCount -= 10;
            healthBar.SetHealth(lifeCount);
            audiodecrementlife.Play(0);
        }
        else
        {
            Debug.Log("Die");
        }
    }
}

