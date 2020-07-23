using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    [SerializeField]
    int rate = 2;
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", rate, rate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector3 rdmPosition = new Vector3(Random.Range(-9, 9), 5, 1);

        if (enemies.Length > 0)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length - 1)], rdmPosition, Quaternion.identity);        }
        }
}z
