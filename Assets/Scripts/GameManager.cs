using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    public GameObject enemy;
    public GameObject life;
    public float spawnRateEnemy = 0.5f;
    public float spawnRateLife = 3f;
    float randomX;
    float nextSpawnEnemy;
    float nextSpawnLife;
    public int lifeCount = 100;
    public AudioSource audioincrementlife;
    public AudioSource audiodecrementlife;

    void Start()
    {

    }

    void Update()
    {
        if (Time.time > nextSpawnEnemy)
        {
            nextSpawnEnemy = Time.time + spawnRateEnemy;
            Vector3 whereToSpawn = SpawnPosition();
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }

        if (Time.time > nextSpawnLife)
        {
            nextSpawnLife = Time.time + spawnRateLife;
            Vector3 whereToSpawn = SpawnPosition();
            Instantiate(life, whereToSpawn, Quaternion.identity);
        }

    }

    Vector3 SpawnPosition()
    {
        randomX = Random.Range(-7f, 7f);
        return new Vector3(randomX, 7, 0);
    }

    public void IncrementLife()
    {
        if (lifeCount < 100 && lifeCount > 0)
        {
            lifeCount += 10;
            audioincrementlife.Play(0);
        }

    }

    public void DecrementLife()
    {
        if (lifeCount > 0)
        {
            lifeCount -= 20;
            audiodecrementlife.Play(0);
        }
        else
        {
            Debug.Log("Die");
        }
    }
}
