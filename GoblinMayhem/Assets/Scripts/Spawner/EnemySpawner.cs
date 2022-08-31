using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    public int enemyIndex;
    public float enemyAmount;

    public GameObject[] enemyPrefabs;

    private GameObject EnemyGroup;
    private GameObject enemy;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            SpawningEnemy();
        }
    }
    public void SpawningEnemy()
    {
        if (gameObject.transform.childCount <= 0)
        {
            EnemyGroup = new GameObject();                                              //Makes New GameObject called EnemyGroup
            EnemyGroup.transform.parent = GameObject.Find("EnemySpawner").transform;         //Makes New GameObject be a child of EnemySpawner gameobject
            EnemyGroup.name = "EnemyType" + ": " + enemyPrefabs[enemyIndex].name;    //Renames the new gameobject to group of the specific enemy name);
        }

        for (int i = 0; i <= enemyAmount; i++)
        {
            int rnd = Random.Range(0, 3);

            enemy = Instantiate(
                enemyPrefabs[rnd], new Vector3(Random.Range(-40, 40),Random.Range(-30, 30),0), Quaternion.identity);
            enemy.name = enemyPrefabs[rnd].name;
            enemy.transform.parent = GameObject.Find(EnemyGroup.name).transform;            //Makes the instantiated enemy a child of its group object
        }


    }
}
