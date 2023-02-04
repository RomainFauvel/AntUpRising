using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private RaycastHit2D hit;

    private Rigidbody2D rigidbody2d;
    private Vector2 moveInput;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        //Capter depuis combien de temps l'appuie sur le haut est activé

        //inverser le gravity scale
        if (Input.GetButtonDown("Jump")){
            GetComponent<Rigidbody2D>().gravityScale = -GetComponent<Rigidbody2D>().gravityScale;
        }

        // Get the position of your player
        Vector2 playerPosition = transform.position;

        // Get the direction of the raycast
        Vector2 rayDirection = Vector2.right;

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        moveInput = moveInput.normalized * moveSpeed;

        Debug.DrawRay(transform.position, -transform.up * 2, Color.red);
        rigidbody2d.velocity = moveInput;
    }
}
