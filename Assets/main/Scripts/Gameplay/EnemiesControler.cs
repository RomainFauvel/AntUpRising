using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesControler : MonoBehaviour
{
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

    //[SerializeField] public Animator animator;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        xScale = Mathf.Abs(transform.localScale.x);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {


        //Capter depuis combien de temps l'appuie sur le haut est activé

        //inverser le gravity scale
        /*
        if (Input.GetButtonDown("Jump")){
            GetComponent<Rigidbody2D>().gravityScale = -GetComponent<Rigidbody2D>().gravityScale;
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        }*/

        // Get the position of your player
        Vector2 playerPosition = transform.position;

        // Get the direction of the raycast
        Vector2 rayDirection = Vector2.right;

        /*moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        moveInput = moveInput.normalized * moveSpeed;

        Debug.DrawRay(transform.position, -transform.up * 2, Color.red);
        rigidbody2d.velocity = moveInput;

        print(Input.GetAxisRaw("Horizontal"));*/

        if (isTrigger == false)
        {
            print(duree);
            if (duree < 0)
            {
                duree = UnityEngine.Random.Range(1, 3);
                direction = UnityEngine.Random.Range(0, 2);
                print(direction);
                print(duree);
                GetComponent<Rigidbody2D>().gravityScale = -GetComponent<Rigidbody2D>().gravityScale;
                transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);

            }
            else
            {


                if (direction == 0)
                {
                    transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
                    moveInput = new Vector2(1, 0);
                    moveInput = moveInput * moveSpeed;

                    //direction = 1;
                    print("0");
                }
                else
                {
                    transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
                    moveInput = new Vector2(-1, 0);
                    moveInput = moveInput.normalized * moveSpeed;

                    //direction = 0;

                    print("1");
                }

                duree = duree - Time.deltaTime;

            }

            Debug.DrawRay(transform.position, -transform.up * 2, Color.red);


            print(Input.GetAxisRaw("Horizontal"));


        }
        else
        {
            moveInput = (player.transform.position - gameObject.transform.position).normalized * aggroSpeed;
            print("Triggered");
        }
        /*if (Input.GetAxisRaw("Horizontal") == 1){
            transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
        }else if(Input.GetAxisRaw("Horizontal") == -1){
            transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
        }*/
    }

    private void FixedUpdate()
    {
        //edit the velocity by use input and speed
        // float characterVelocity = Mathf.Abs(rigidbody2d.velocity.x);
        //animator.SetFloat("Speed", characterVelocity);

        // transform.localScale = moveInput ;
        rigidbody2d.velocity = moveInput;

    }

    public void getTrigger()
    {
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


