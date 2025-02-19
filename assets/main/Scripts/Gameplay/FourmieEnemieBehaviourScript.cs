using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourmieEnemieBehaviourScript : MonoBehaviour{

    //values of speed choose in the software
    public float speed;

    public int DamageOnCollision = 20;

    //componante that manage physics
    private Rigidbody2D rb;

    //store the input's values
    private Vector2 moveInput;
    float duree;
    int direction;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        
        if (duree<0){
            duree = Random.Range(1, 3);
            direction = Random.Range(0, 2);
            print(direction);
            print("<0");
        }else{
            if (direction == 0){
                moveInput = new Vector2(Random.Range(1, 5), 0);
            }else{
                moveInput = new Vector2(Random.Range(-5, -1), 0);
            }
            duree = duree - Time.deltaTime;
        }
    }

    private void FixedUpdate(){
        rb.velocity = moveInput * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.CompareTag("Player")){
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(DamageOnCollision);
        }
    }
}
