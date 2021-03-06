﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    [SerializeField] private Text scoreText;
    [SerializeField] private Image backgroundImage;

    private bool isShown = false;

    private float transition = 0f;

    void Start() {
        gameObject.SetActive(false);
    }


    void Update() {

        if (!isShown)
            return;

        transition += Time.deltaTime;
        backgroundImage.color = Color.Lerp(new Color(0,0,0,0), Color.black, transition);
    }

    public void ToggleEndMenu(float score) {
        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
        isShown = true;
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu() {
        SceneManager.LoadScene("Menu");
        StartCoroutine(CallAd());
    }

    IEnumerator CallAd() {
        yield return new WaitForSeconds(1f);

        int rnd = Random.Range(1, 21);
        Debug.Log(rnd);

        if (rnd <= 3) {
            AdController.instance.ShowBannerAd();
        } else if (rnd <= 9) {
            AdController.instance.ShowSceneSwitchAd();
        } else if (rnd <= 15) {
            AdController.instance.ShowVideoOrInterstitialAd();
        }
    }
}
