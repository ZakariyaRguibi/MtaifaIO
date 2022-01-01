using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float attackCooldown;
    private Animator anim;
    public int counter;
    private PlayerMovement playerMovement;

    private float cooldownTimer = Mathf.Infinity;
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(playerMovement.hitKey) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        counter++;
        anim.SetTrigger("attack");
        anim.SetBool("run", false);
        cooldownTimer = 0;
    }

}
