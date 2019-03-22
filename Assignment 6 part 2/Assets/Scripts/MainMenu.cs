using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


    [SerializeField] Text highscoreText;
    
    void Start() {
        highscoreText.text = "Highscore: " + (int)PlayerPrefs.GetFloat("Highscore");
    }

    public void ToGame() {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
