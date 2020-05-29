using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    public int amountOfEnemies;
    public int amountOfLifes;
    public GameObject[] enemy;
    public List<EnemySpawn> enemiesSpawn;
    public GameObject[] life;
    public List<LifeSpawn> lifesSpawn;


    void Start()
    {
        SpawnPositionEnemies();

        SpawnPositionLifes();

        StartCoroutine(SpawnRandomEnemies());

        StartCoroutine(SpawnRandomLifes());

    }


    void SpawnPositionEnemies()
    {
        int index = 0;
        for (int i = 0; i < enemy.Length * amountOfEnemies; i++)
        {
            GameObject obj = Instantiate(enemy[index], transform.position, Quaternion.identity);
            obj.SetActive(false);
            enemiesSpawn.Add(obj.GetComponent<EnemySpawn>());

            index++;
            if (index == enemy.Length)
            {
                index = 0;
            }
        }
    }

    void SpawnPositionLifes()
    {
        int index = 0;
        for (int i = 0; i < life.Length * amountOfLifes; i++)
        {
            GameObject obj = Instantiate(life[index], transform.position, Quaternion.identity);
            obj.SetActive(false);
            lifesSpawn.Add(obj.GetComponent<LifeSpawn>());

            index++;
            if (index == life.Length)
            {
                index = 0;
            }
        }
    }

    IEnumerator SpawnRandomEnemies()
    {
        yield return new WaitForSeconds(0.3f);

        int index = Random.Range(0, enemiesSpawn.Count);

        while (true)
        {
            EnemySpawn enemy = enemiesSpawn[index];

            if (!enemy.gameObject.activeInHierarchy)
            {
                enemiesSpawn[index].gameObject.SetActive(true);
                float x = Random.Range(-10f, 10f);
                enemiesSpawn[index].transform.position = new Vector3(x, 7, 0);
                break;
            }
            else
            {
                index = Random.Range(0, enemiesSpawn.Count);
            }
        }
        StartCoroutine(SpawnRandomEnemies());
    }

    IEnumerator SpawnRandomLifes()
    {
        yield return new WaitForSeconds(1.5f);

        int index = Random.Range(0, lifesSpawn.Count);

        while (true)
        {
            LifeSpawn life = lifesSpawn[index];

            if (!life.gameObject.activeInHierarchy)
            {
                lifesSpawn[index].gameObject.SetActive(true);
                float x = Random.Range(-10f, 10f);
                lifesSpawn[index].transform.position = new Vector3(x, 7, 0);
                break;
            }
            else
            {
                index = Random.Range(0, lifesSpawn.Count);
            }
        }
        StartCoroutine(SpawnRandomLifes());
    }
}
