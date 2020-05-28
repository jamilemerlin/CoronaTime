using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject[] levels;

    void Start()
    {

    }

    void Update()
    {
        if (levels.Length == 2)
        {
            levels[0].transform.position = new Vector3(0, levels[0].transform.position.y - 2f * Time.deltaTime, 0);
            levels[1].transform.position = new Vector3(0, levels[1].transform.position.y - 2f * Time.deltaTime, 0);

            if (levels[0].transform.position.y < -32f)
            {
                levels[0].transform.position = new Vector3(0, 32f, 0);
            }
            if (levels[1].transform.position.y < -32f)
            {
                levels[1].transform.position = new Vector3(0, 32f, 0);
            }
        }
        
    }
}
