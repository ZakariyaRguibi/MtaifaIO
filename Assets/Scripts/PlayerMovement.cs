using UnityEngine;

public abstract class PlayerMovement : MonoBehaviour
{

    protected KeyCode leftkey;
    protected KeyCode rightKey;
    protected KeyCode jumpKey;

    public KeyCode hitKey;

    [SerializeField] protected float speed;
    [SerializeField] protected float jumpPower;

    [SerializeField] protected LayerMask groundLayer;
    protected Rigidbody2D body;
    protected Vector3 scale;
    protected Animator anim;
    protected BoxCollider2D boxCollider;
    protected float horizontalInput;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected void Update()
    {
        //get current scale 
        scale = transform.localScale;
        //get input axis (1 if rightclick, -1 if left click)
        horizontalInput = getHorizontalInput();
        if (isClickingRightKey())
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        else if (isClickingLeftKey())
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        if (Input.GetKey(jumpKey) && IsGrounded())
        {
            jump();
        }
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", IsGrounded());

        if (Input.GetKey(hitKey) && IsGrounded())
        {
            anim.SetTrigger("hit");

        }
    }


    private void jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        anim.SetTrigger("jump");

    }


    private void hit()
    {
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);

        return raycastHit.collider != null;
    }
    public bool canAttack()
    {
        return horizontalInput == 0 && IsGrounded();
    }
    private float getHorizontalInput()
    {
        if (isClickingLeftKey()) return -0.5f;
        else if (isClickingRightKey()) return 0.5f;
        else return 0f;
    }
    protected bool isClickingLeftKey()
    {
        return Input.GetKey(leftkey);
    }
    protected bool isClickingRightKey()
    {
        return Input.GetKey(rightKey);
    }
}

