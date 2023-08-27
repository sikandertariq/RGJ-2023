using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform target; // The target (capsule) that the zombie should move towards
    public float speed = 2f; // The movement speed of the zombie
    private Animator animator;
    private bool isAttacking = false;
    public float attackRange = 1.5f; // Adjust this to set the range at which the zombie starts attacking.
    private Rigidbody zombieRigidbody;
    public GameObject Blood;
    public int attackDamage = 10; // Set the damage zombies deal to the tower.

    //public AudioSource audioSource;
    private void Start()
    {
        zombieRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        //audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //if (distanceToTarget <= attackRange)
        //{
        //    // Within attack range, stop moving and transition to attack animation.
        //    isAttacking = true;
        //    animator.SetBool("IsAttacking", true);
        //}
        if (target != null)
        {
            if (!isAttacking)
            {
                // Calculate the direction from the zombie to the target
                Vector3 direction = (target.position - transform.position).normalized;

                Vector3 movementOffset = direction * speed * Time.deltaTime;
                transform.position += movementOffset;

                // Rotate the zombie to look at the target
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);

                // Move the zombie towards the target
                //zombieRigidbody.velocity = direction * speed;

                //Vector3 movement = direction * speed * Time.deltaTime;
                //transform.Translate(movement);
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Instantiate(Blood, transform.position, Quaternion.identity);
        AudioManager.instance.PlayDeathSound();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            Debug.Log("works");
            isAttacking = true;
            animator.SetBool("isAttacking", true);
            AudioManager.instance.PlayAttackSound();
            TowerHealth towerHealth = collision.gameObject.GetComponent<TowerHealth>();
            if (towerHealth != null)
            {
                towerHealth.TakeDamage(attackDamage);
            }
        }

        if (collision.gameObject.CompareTag("Guard"))
        {
            Die();
        }
    }
}
