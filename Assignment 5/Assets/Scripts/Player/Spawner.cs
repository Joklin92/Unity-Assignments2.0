using UnityEngine;

public class Spawner : MonoBehaviour {

    public static Spawner instance;

    public GameObject spawnPoint;
    public GameObject player;


    void Awake() {
        if (instance != null) instance = this;
       // DontDestroyOnLoad(instance);
        Instantiate(player, this.transform);
    }
}
