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
    public EndGame endGame;




    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        healthBar.SetMaxHealth(100);
        gameObject.SetActive(true);
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
        audioincrementlife.Play(0);
        if (lifeCount < 100 && lifeCount > 0)
        {
            lifeCount += 25;
            healthBar.SetHealth(lifeCount);
        }

    }

    public void DecrementLife()
    {
        audiodecrementlife.Play(0);
        if (lifeCount > 10)
        {
            lifeCount -= 10;
            healthBar.SetHealth(lifeCount);

        }
        else if (lifeCount <= 10)
        {
            lifeCount = 0;
            healthBar.SetHealth(lifeCount);
            endGame.SetGame();
        }
    }
}

