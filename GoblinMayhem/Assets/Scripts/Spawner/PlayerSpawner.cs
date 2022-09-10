using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject gunPrefab;

    void Start()
    {
        SpawnPlayer();
    }

    void Update()
    {

    }

    public void SpawnPlayer()
    {
        GameObject player = Instantiate(playerPrefab, new Vector3(Random.Range(-40, 40), Random.Range(-30, 30), 0), Quaternion.identity);
        player.transform.parent = GameObject.Find("PlayerSpawner").transform;
        player.name = "Player";
    }

    public void SpawnGun()
    {
        GameObject gun = Instantiate(gunPrefab, new Vector3(Random.Range(-40, 40), Random.Range(-30, 30), 0), Quaternion.identity);
        gun.transform.parent = GameObject.Find("PlayerSpawner").transform;
        gun.name = "Gun";
    }
}
