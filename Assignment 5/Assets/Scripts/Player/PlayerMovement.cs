using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;

    public float speed = 40f;
    float horizontalMove = 0f;

    bool jump = false;
    public bool immortal = false;

    public bool copperKeyObtained = false;
    public bool silverKeyObtained = false;
    public bool goldenKeyObtained = false;

    public GameObject keyTextPanel;

    void Update() {

       horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("Vertical")) {
            jump = true;
            animator.SetBool("Jump", true);
        }
    }

   public void OnLanding() {
        animator.SetBool("Jump", false);
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    private void OnCollisionEnter2D(Collision2D col) {

        switch(col.gameObject.tag) {
            case "Enemy":
                if(!immortal) {
                    Debug.Log("You were killed by a: " + col.gameObject.name);
                    StartCoroutine(Die());
                }
                break;

            case "PowerUp":
                if (col.gameObject.name == "immortalityApple") {
                    StartCoroutine(immortalPU());
                }

                if (col.gameObject.name == "SpeedNugget") {
                    StartCoroutine(SpeedPU());
                }

                Debug.Log(col.gameObject.name + " Aquired");
                Destroy(col.gameObject);
                break;

            case "Door":
            Scenemanager.instance.NextScene();
                break;

            case "LockedDoor":
                if(copperKeyObtained && silverKeyObtained && goldenKeyObtained) {
                    Scenemanager.instance.NextScene();
                } else {
                    //   StartCoroutine(MissingKeys());
                    Scenemanager.instance.RestartCurrentLevel();
                }
                break;
            case "HeadBox":
                Debug.Log("HeadShot");
                Destroy(col.gameObject.GetComponentInParent<Transform>());
                break;

            case "Spikes":
                StartCoroutine(Die());
                break;
        }

        switch(col.gameObject.name) {
            case "Copper Key":
                copperKeyObtained = true;
                Destroy(col.gameObject);
                break;

            case "Silver Key":
                silverKeyObtained = true;
                Destroy(col.gameObject);
                break;

            case "Golden Key":
                goldenKeyObtained = true;
                Destroy(col.gameObject);
                break;
        }
    }

    IEnumerator MissingKeys() {
        keyTextPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        Scenemanager.instance.RestartCurrentLevel();
    }

    IEnumerator SpeedPU() {
        Debug.Log("Speed Demon!");
        speed = 70f;
        yield return new WaitForSeconds(5f);
        Debug.Log("Regular Slowpoke!");
        speed = 40f;

    }

    IEnumerator immortalPU() {
        Debug.Log("You are now IMMORTAL!");
        immortal = true;
        yield return new WaitForSeconds(5f);
        Debug.Log("You are no longer IMMORTAL!");
        immortal = false;
    }

    public IEnumerator Die() {        
        animator.SetBool("Dead", true);
        enabled = false;
        yield return new WaitForSeconds(3f);
        Scenemanager.instance.RestartGame();
    }
}
