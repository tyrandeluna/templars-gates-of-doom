using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    private Transform player;
    private GameObject enemy;
    public Animator animator;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    private void Update() {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if(distanceFromPlayer < lineOfSite) {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            animator.SetBool("isWalk", true);
        } else {
            animator.SetBool("isWalk", false);
        }

        if (timer.stopTime) {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
