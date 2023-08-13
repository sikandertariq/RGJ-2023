using UnityEngine;

public class sampleMove : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to control the speed of movement

    private Vector3 randomDirection;

    private void Start()
    {
        // Generate a random direction when the object starts
        GenerateRandomDirection();
    }

    private void Update()
    {
        // Move the object in the random direction
        Vector3 movement = randomDirection * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void GenerateRandomDirection()
    {
        // Generate a random direction in 3D space
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        randomDirection = new Vector3(randomX, 0f, randomZ).normalized;
    }
}
