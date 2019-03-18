using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour {

    public static Scenemanager instance;

    void Awake() {

        instance = this;

        DontDestroyOnLoad(instance);
    }

    public void NextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame() {
        Application.Quit();
    }

}
