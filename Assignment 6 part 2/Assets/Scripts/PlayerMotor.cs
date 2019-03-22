using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Score))]
public class PlayerMotor : MonoBehaviour {

    private CharacterController controller;

    private Vector3 moveVector = Vector3.zero;
    private Vector3 moveDirection = Vector3.zero;

    public float speed = 10f;
    private float verticalVelocity = 0f;
    private float gravity = 12f;
    private float animationDuration = 2f;
    private float jumpSpeed = 8f;

    private bool isDead = false;

    void Start() {
        Time.timeScale = 1;
        controller = GetComponent<CharacterController>();
    }
    
    void Update() {

        if (isDead) { 
            return;
        }
        if (controller.isGrounded) {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, 0.0f, speed);
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetButton("Jump") || Input.GetMouseButtonDown(0)) {
                moveDirection.y = jumpSpeed;
            }
        }
        
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
        
        controller.Move(moveDirection * Time.deltaTime);   

    if (transform.position.y < -3) Death();

    }


    public void SetSpeed(float modifier) {
        speed ++;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        //if (hit.point.z > transform.position.z + 0.3f)
        if (hit.gameObject.tag == "Obstacle")
                Death();        
    }

    private void Death() {
        isDead = true;
        GetComponent<Score>().OnDeath();
        Time.timeScale = 0;
    }
}
