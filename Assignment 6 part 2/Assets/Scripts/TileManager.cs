using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    private List<GameObject> activeTiles;

    private Transform playerTransform;

    private float spawnZ = -5f;
    private float spawnY = -1.5f;
    private float tileLength = 40f;
    private float safeZone = 25f;

    private int amountOfTilesOnScreen = 7;
    private int lastPrefabIndex = 0;

    void Start() {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amountOfTilesOnScreen; i++) {
            if (i < 2)
                SpawnTile(0);
            else
                SpawnTile();
        }
    }

    void Update() {
        if(playerTransform.position.z - safeZone > (spawnZ-amountOfTilesOnScreen * tileLength)) {
            SpawnTile();
            DeleteTile();
        }
    }

    void SpawnTile(int prefabIndex = -1) {
        GameObject go;

        if (prefabIndex == -1)
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    private void DeleteTile() {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex() {
        if (tilePrefabs.Length <= 1) return 0;

        int randomIndex = lastPrefabIndex;
        
        while(randomIndex == lastPrefabIndex) {
            randomIndex = UnityEngine.Random.Range(0,tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
