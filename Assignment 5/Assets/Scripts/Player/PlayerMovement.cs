using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;

    public float speed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool immortal = false;
    
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
        if (col.gameObject.tag == "Enemy" && !immortal) {
            Debug.Log("You were killed by a: " + col.gameObject.name);
            Die();
        }

        if (col.gameObject.tag == "PowerUp") {

            if (col.gameObject.name == "immortalityApple") {
                StartCoroutine(immortalPU());
            }

            if(col.gameObject.name == "SpeedNugget") {
                StartCoroutine(SpeedPU());
            }

            Debug.Log(col.gameObject.name + " Aquired");
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Door")  {
            Scenemanager.instance.NextScene();
        }

        if(col.gameObject.tag == "HeadBox") {
            Debug.Log("HeadShot");
            Destroy(col.gameObject.GetComponentInParent<Transform>());
        }
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

    public void Die() {        
        animator.SetBool("Dead", true);
        enabled = false;
    }
}
