using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    float horizontalMove = 0f;
    public float speed = 40f;

    private Rigidbody2D rb2d;

    void Start() {

        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {

        float moveHorizontal = Input.GetAxis("Horizontal");


        float moveVertical = Input.GetAxis("Vertical");


        Vector2 movement = new Vector2(moveHorizontal, moveVertical);


        rb2d.AddForce(movement * speed);

    }
}
