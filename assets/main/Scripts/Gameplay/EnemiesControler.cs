using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesControler : MonoBehaviour{
    public float speed = 2;
    public float aggroSpeed = 2;
    public bool isTrigger = false;

    public float moveSpeed = 5f;

    private float xScale;
    private GameObject player;

    private RaycastHit2D hit;

    private Rigidbody2D rigidbody2d;
    private Vector2 moveInput;
    public int DamageOnCollision = 20;

    float duree;
    int direction;

    private void Start(){
        rigidbody2d = GetComponent<Rigidbody2D>();
        xScale = Mathf.Abs(transform.localScale.x);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update(){

        // Get the position of your player
        Vector2 playerPosition = transform.position;

        // Get the direction of the raycast
        Vector2 rayDirection = Vector2.right;

        if (isTrigger == false){
            if (duree < 0){
                duree = UnityEngine.Random.Range(1, 3);
                direction = UnityEngine.Random.Range(0, 2);
                GetComponent<Rigidbody2D>().gravityScale = -GetComponent<Rigidbody2D>().gravityScale;
                transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
            }else{
                if (direction == 0){
                    transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
                    moveInput = new Vector2(1, 0);
                    moveInput = moveInput * moveSpeed;
                }else{
                    transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
                    moveInput = new Vector2(-1, 0);
                    moveInput = moveInput.normalized * moveSpeed;
                }
                duree = duree - Time.deltaTime;
            }
            Debug.DrawRay(transform.position, -transform.up * 2, Color.red);
        }else{
            moveInput = (player.transform.position - gameObject.transform.position).normalized * aggroSpeed;
        }
    }

    private void FixedUpdate(){
        rigidbody2d.velocity = moveInput;
    }

    public void getTrigger(){
        isTrigger = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(DamageOnCollision);
        }
    }
}


