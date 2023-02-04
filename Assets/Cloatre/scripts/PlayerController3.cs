using UnityEngine;
using System;

public class PlayerController3 : MonoBehaviour
{
    public float moveSpeed = 5f;

    private float xScale;

    private RaycastHit2D hit;

    private Rigidbody2D rigidbody2d;
    private Vector2 moveInput;

    [SerializeField] public Animator animator;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        xScale = Math.Abs(transform.localScale.x);
    }

    private void Update(){
        //Capter depuis combien de temps l'appuie sur le haut est activé

        //inverser le gravity scale
        if (Input.GetButtonDown("Jump")){
            GetComponent<Rigidbody2D>().gravityScale = -GetComponent<Rigidbody2D>().gravityScale;
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        }

        // Get the position of your player
        Vector2 playerPosition = transform.position;

        // Get the direction of the raycast
        Vector2 rayDirection = Vector2.right;

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        moveInput = moveInput.normalized * moveSpeed;

        Debug.DrawRay(transform.position, -transform.up * 2, Color.red);
        rigidbody2d.velocity = moveInput;

        print(Input.GetAxisRaw("Horizontal"));

        if(Input.GetAxisRaw("Horizontal") == 1){
            transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
        }else if(Input.GetAxisRaw("Horizontal") == -1){
            transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
        }
    }

    private void FixedUpdate()
    {
        //edit the velocity by use input and speed
        float characterVelocity = Mathf.Abs(rigidbody2d.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
        
    }
}
