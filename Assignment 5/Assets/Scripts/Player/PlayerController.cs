using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    public static PlayerController instance;
    public Animator animator;

    public Rigidbody2D playerBody;

    private int health;
    public float speed = 10f;
    public float horizontalMove = 0f; 
    
    void Awake() {
        if(instance != null) {
            instance = this;
        }
    }

    void Start() {
        playerBody = GetComponent<Rigidbody2D>();
    }
    
    void Update() {

        //   if (canMove) {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

          //  playerBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;
        playerBody.velocity = new Vector2(horizontalMove, Input.GetAxisRaw("Vertical") * speed);
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); 
/*  
        } else {
            playerBody.velocity = Vector2.zero;
        }*/


        if (Input.GetKeyDown("left") || Input.GetKeyDown("a")) {
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

        if(Input.GetKeyDown(KeyCode.K)) {
            Die();
        }

    }

    private void OnCollisionEnter(Collision col) {
        if(col.gameObject.name == "Enemy") {
            Die();
        }
    }

    void Die() {
        Debug.Log("Die");

        animator.SetBool("Dead", true);
        this.enabled = false;

    }

}
