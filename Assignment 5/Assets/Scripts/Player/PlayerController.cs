using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;

    private int health;
    public float speed = 10f;
    
    void Awake() {
        if(instance != null) {
            instance = this;
        }
    }

    void Start() {
    }
    
    void Update() {

        if(Input.GetKeyDown("left") || Input.GetKeyDown("a")) {
            //move left
            Debug.Log("Moving left");
        } else if (Input.GetKeyDown("right") || Input.GetKeyDown("d")) {
            //move right
            Debug.Log("Moving right");
        } else if (Input.GetKeyDown("up") || Input.GetKeyDown("w")) {
            //Jump
            Debug.Log("Jumping");
        } else if (Input.GetKeyDown("down") || Input.GetKeyDown("s")) {
            //crouch
            Debug.Log("Crouching");
        }
    }
}
