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

    public void LoadMenu() {
        SceneManager.LoadScene(0);
    }

    public void RestartGame() {
        SceneManager.LoadScene(1);
    }

    public void RestartCurrentLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame() {
        Application.Quit();
    }

}
