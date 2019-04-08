using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {


    [SerializeField] Text highscoreText;
    
    void Start() {
        StartCoroutine(CallAd());
        highscoreText.text = "Highscore: " + (int)PlayerPrefs.GetFloat("Highscore");
    }

    public void ToGame() {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame() {
        Application.Quit();
    }

    IEnumerator CallAd() {
        yield return new WaitForSeconds(2f);

        AdController.instance.ShowBannerAd();

    }
}
