using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

    private Transform lookAt;

    private Vector3 startOffset;
    private Vector3 moveVector;
    private Vector3 animationOffset = new Vector3(0,5,5);

    private float transition = 0f;
    private float animationDuration = 2f;
    

    void Start() {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;
    }


    void Update() {
        moveVector = lookAt.position + startOffset;

        moveVector.x = 0;

        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);

        if(transition > 1) {
            transform.position = moveVector;
        } else {
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(lookAt.position + Vector3.up);
        }

    }
}
