using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourmieBehaviourScript : MonoBehaviour
{
    /* // The force which is added when the player jumps
     // This can be changed in the Inspector window
     public float speed = 10f;
     public Vector2 go_left = new Vector2(-4, 0);
     public Vector2 go_right = new Vector2(4, 0);
     public int i = 0;
     void Start()
     {
         GetComponent<Rigidbody2D>().velocity = speed * go_left;
     }

     // Update is called once per frame
     void Update()
     {
         if(i % 2 == 0)
         {
             movedRandomDirection = go_left;
         }
         else
         {
             movedRandomDirection = go_Right;

         }


     }

     // Die by collision
     void OnCollisionEnter2D(Collision2D other)
     {
         GetComponent<Rigidbody2D>().velocity = speed * movedRandomDirection ;
     }

     void Die()
     {
         Application.LoadLevel(Application.loadedLevel);
     }*/

    //values of speed choose in the software
    public float speed;

    //componante that manage physics
    private Rigidbody2D rb;

    //store the input's values
    private Vector2 moveInput;
    float duree;
    int direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        
        if (duree<0)
        {
            duree = Random.Range(1, 3);
            direction = Random.Range(0, 2);
            print(direction);
            print("<0");
        }
        else
        {
            
            if (direction == 0)
            {
                moveInput = new Vector2(Random.Range(1, 5), 0);
          
                //direction = 1;
            }
            else
            {
                moveInput = new Vector2(Random.Range(-5, -1), 0);
                
                //direction = 0;
            }

            duree = duree - Time.deltaTime;
            
        }
        //get all the input of the user
        //moveInput = new Vector2(Random.Range(1, 5), 0);
        
        
    }

    private void FixedUpdate()
    {
        //edit the velocity by use input and speed
        rb.velocity = moveInput * speed;

    }
}




    
