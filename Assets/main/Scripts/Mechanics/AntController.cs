using UnityEngine;

public class AntController : MonoBehaviour
{
    //values of speed choose in the software
    public float speed;
    public float speed2;
    [SerializeField] public Animator animator;

    //componante that manage physics
    private Rigidbody2D rb;

    //store the input's values
    private Vector2 moveInput;

    [SerializeField] private Transform enemy;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //get all the input of the user
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        //edit the velocity by use input and speed
        rb.velocity = moveInput * speed;
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
        
    }
}
