using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
    
    public GameObject player;
    public GameObject spawnPoint;

    public void SpawnPlayer() {
        spawnPoint = GameObject.FindGameObjectWithTag("PlayerSpawn");
        Instantiate(player, spawnPoint.transform);
    }

}
