


using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Vector3 scale;
    private Animator anim;
    private bool grounded;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        if (horizontalInput > 0.01f)
        {
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        else if (horizontalInput < -0.01f)
        {
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            jump();
        }
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);

    }


    private void jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
