﻿using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMotor))]
public class Score : MonoBehaviour {

    private float score = 0f;

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 60;

    private bool isDead = false;

    public Text scoreText;
    public DeathMenu deathMenu;

    void Update() {

        if (isDead)
            return;

        if (score >= scoreToNextLevel) LevelUp();

        score += Time.deltaTime * difficultyLevel;
        scoreText.text = ((int)score).ToString();
    }

   void LevelUp() {

        if (difficultyLevel == maxDifficultyLevel) return;

        scoreToNextLevel *= 2;
        difficultyLevel++;

        GetComponent<PlayerMotor>().SetSpeed(difficultyLevel);

        Debug.Log(difficultyLevel);
    }

    public void OnDeath() {
        isDead = true;
        if(PlayerPrefs.GetFloat("Highscore") < score)
        PlayerPrefs.SetFloat("Highscore", score);
        deathMenu.ToggleEndMenu(score);
    }
}
