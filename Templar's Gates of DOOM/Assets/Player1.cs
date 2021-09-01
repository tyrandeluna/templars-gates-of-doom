using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    public static float healthAmount = 1;
    public static bool statusDeath = false;
    public float restartLevelDelay = 1f;

    Vector2 movement;

    void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

    void Update() {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);

        if (healthAmount <= 0) {
            Destroy(gameObject);
            statusDeath = true;
            GameManager.instance.GameOver();
            timer.stopTime = true;
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals("Bullet") || col.gameObject.tag.Equals("Enemy")) {
			healthAmount -= 0.3f; 
        }

        if(col.tag == "Exit") {
            Invoke("Restart", restartLevelDelay);
            enabled = false;
        }
	}

    private void Restart() {
        Application.LoadLevel(Application.loadedLevel);
    }
}
