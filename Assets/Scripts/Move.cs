using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform target; // The target (capsule) that the zombie should move towards
    public float speed = 2f; // The movement speed of the zombie

    private Rigidbody zombieRigidbody;

    private void Start()
    {
        zombieRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (target != null)
        {
            // Calculate the direction from the zombie to the target
            Vector3 direction = (target.position - transform.position).normalized;

            // Move the zombie towards the target
            zombieRigidbody.velocity = direction * speed;

            // Rotate the zombie to look at the target
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        }
        
    }
}
