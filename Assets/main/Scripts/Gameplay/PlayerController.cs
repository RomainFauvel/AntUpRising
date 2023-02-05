using UnityEngine;
using System;

public class PlayerController : MonoBehaviour{

    public float moveSpeed = 5f;

    private float xScale;

    private Rigidbody2D rigidbody2d;
    private Vector2 moveInput;

    [SerializeField] public Animator animator;

    public bool isFreeze;

    private bool isTouchingAbove;

    [SerializeField] float maxRoofDistance = 8f;

    public bool isRetourned = false;

    private RaycastHit2D hitRoof;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        xScale = Math.Abs(transform.localScale.x);
    }

    private void Update(){
        Vector2 raycastStart = transform.position;
        Vector2 raycastDirection = Vector2.up;

        if(!isRetourned){
            Debug.DrawLine(raycastStart, raycastStart + raycastDirection * maxRoofDistance, Color.red);
            hitRoof = Physics2D.Raycast(raycastStart, raycastDirection, maxRoofDistance);
        }else{
            Debug.DrawLine(raycastStart, raycastStart - raycastDirection * maxRoofDistance, Color.red);
            hitRoof = Physics2D.Raycast(raycastStart, - raycastDirection, maxRoofDistance);
        }

        // Get the position of your player
        Vector2 playerPosition = transform.position;

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        moveInput = moveInput.normalized * moveSpeed;

        if(!isFreeze){
            rigidbody2d.velocity = moveInput;

            if(Input.GetAxisRaw("Horizontal") == 1){
                transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
            }else if(Input.GetAxisRaw("Horizontal") == -1){
                transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
            }

            if (hitRoof.collider != null && Input.GetButtonDown("Jump")){
                isRetourned = !isRetourned;
                GetComponent<Rigidbody2D>().gravityScale = -GetComponent<Rigidbody2D>().gravityScale;
                transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
            }
        }
    }

    private void FixedUpdate()
    {
        //edit the velocity by use input and speed
        float characterVelocity = Mathf.Abs(rigidbody2d.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
        
    }
}
