using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    public int EnemyID;
    public GameObject[] enemyPrefabs;

    private GameObject EnemyGroup;

    private List<GameObject> A;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            SpawningEnemy();
        }
    }

    public void SpawningEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefabs[EnemyID], new Vector3(Random.Range(-40, 40), Random.Range(-30, 30), 0), Quaternion.identity);
        enemy.name = enemyPrefabs[EnemyID].name;

        EnemyGroup = new GameObject();                                              //Makes New GameObject called EnemyGroup
        EnemyGroup.name = "EnemyType" + ": " + enemyPrefabs[EnemyID].name;    //Renames the new gameobject to group of the specific enemy name);

        EnemyGroup.transform.parent = GameObject.Find("EnemySpawner").transform;         //Makes New GameObject be a child of EnemySpawner gameobject
        enemy.transform.parent = GameObject.Find(EnemyGroup.name).transform;            //Makes the instantiated enemy a child of its group object

        A = new List<GameObject>();

        //for (int i = GameObject.Find("EnemySpawner").Length ; i > 1; i--)
        //{
        //    Destroy(EnemyGroup);
        //}

    }
}
