using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Score))]
public class PlayerMotor : MonoBehaviour {

    private CharacterController controller;

    private Vector3 moveVector;

    private float speed = 5f;
    private float verticalVelocity = 0f;
    private float gravity = 12f;
    private float animationDuration = 2f;
    private float startTime;

    private bool isDead = false;

    void Start() {
        controller = GetComponent<CharacterController>();
        startTime = Time.time;
    }
    
    void Update() {

        if (isDead)
            return;

        if(Time.time - startTime < animationDuration) {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;

        if(controller.isGrounded) {
            verticalVelocity = -0.5f;
        } else {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        moveVector.y = verticalVelocity;

        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
    }

    public void SetSpeed(float modifier) {
        speed = 5f + modifier;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.point.z > transform.position.z + controller.radius)
            Death();        
    }

    private void Death() {
        isDead = true;
        GetComponent<Score>().OnDeath();
    }
}
