using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    public static PlayerController instance;
    public Animator animator;

    public Rigidbody2D rb;

    private int health;
    public float speed = 10f;
    public float horizontalMove = 0f;
    bool isMoving;

    void Awake() {
        if(instance != null) {
            instance = this;
        }
   //     cameraRotation = transform.rotation;
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update() {
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        
        if(horizontalMove < 0 && isMoving) {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
         rb.velocity = new Vector2(horizontalMove, Input.GetAxisRaw("Vertical") * speed);
        //rb.velocity = new Vector2(horizontalMove, 0);
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));   


    }

    private void OnTriggerEnter2D(Collider2D col) {

    }


    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Enemy") {
            Debug.Log("You were killed by a: " + col.gameObject.name);
            Die();
        }

        if (col.gameObject.tag == "PowerUp") {
            Debug.Log(col.gameObject.name +" Aquired");
            Destroy(col.gameObject);
        }

        if(col.gameObject.tag == "Door") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void Die() {
        animator.SetBool("Dead", true);
        enabled = false;
    }

}
