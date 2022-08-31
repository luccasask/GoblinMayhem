using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject PlayerPrefab;

    void Start()
    {
        GameObject player = Instantiate(PlayerPrefab, new Vector3(Random.Range(-40, 40), Random.Range(-30, 30), 0), Quaternion.identity);
        player.transform.parent = GameObject.Find("PlayerSpawner").transform;
        player.name = "Player";
    }

    void Update()
    {
        
    }
}
