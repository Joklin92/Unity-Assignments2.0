using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour {

    public GameObject[] chunkPrefabs;

    private List<GameObject> activeChunks;

    private Transform playerTransform;

    private float spawnZ = -5f;
    private float spawnY = -1.5f;
    private float chunkLength = 40f;
    private float safeZone = 25f;

    private int amountOfChunksOnScreen = 7;
    private int lastPrefabIndex = 0;

    void Start() {
        activeChunks = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amountOfChunksOnScreen; i++) {
            if (i < 2)
                SpawnTile(0);
            else
                SpawnTile();
        }
    }

    void Update() {
        if (playerTransform.position.z - safeZone > (spawnZ - amountOfChunksOnScreen * chunkLength)) {
            SpawnTile();
            DeleteTile();
        }
    }

    void SpawnTile(int prefabIndex = -1) {
        GameObject go;

        if (prefabIndex == -1)
            go = Instantiate(chunkPrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(chunkPrefabs[prefabIndex]) as GameObject;

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += chunkLength;
        activeChunks.Add(go);
    }

    private void DeleteTile() {
        Destroy(activeChunks[0]);
        activeChunks.RemoveAt(0);
    }

    private int RandomPrefabIndex() {
        if (chunkPrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;

        while (randomIndex == lastPrefabIndex) {
            randomIndex = Random.Range(0, chunkPrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
