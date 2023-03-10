using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBehaviour : MonoBehaviour
{
    public float speed=2;
    public float aggroSpeed = 2;
    public bool isTrigger = false;

    //componante that manage physics
    private Rigidbody2D rb;
    //getting the player GameObject
   private  GameObject player;

    //store the input's values
    private Vector2 moveInput;
    float duree;
    int direction;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update(){
        if (isTrigger == false) {
            if (duree < 0){
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
        }else{
            moveInput = (player.transform.position - gameObject.transform.position).normalized * aggroSpeed;
        }
    }

    private void FixedUpdate(){
        rb.velocity = moveInput * speed;
    }

    public void getTrigger() {
        isTrigger = true;
    }

}
