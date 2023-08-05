using UnityEngine;

public class ZombieSpawnManager : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform target; // The capsule's Transform (player character).

    public float spawnRate = 3f; // Adjust this to control how often zombies spawn.
    public int maxZombies = 10; // Adjust this to limit the maximum number of zombies in the scene.

    private void Start()
    {
        // Call the SpawnZombie function repeatedly with the defined spawnRate.
        InvokeRepeating("SpawnZombie", 0f, spawnRate);
    }

    private void SpawnZombie()
    {
        // Check if the maximum number of zombies is reached.
        if (GameObject.FindGameObjectsWithTag("Tiny").Length >= maxZombies)
            return;

        // Generate a random position on the plane to spawn the zombie.
        float offsetX = Random.Range(-10f, 10f); // Adjust the values based on the desired range.
        float offsetZ = Random.Range(-10f, 10f);

        Vector3 spawnPosition = target.position + new Vector3(offsetX, 0f, offsetZ);


        // Instantiate the zombie prefab at the generated position.
        GameObject newZombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
        newZombie.GetComponent<Move>().target = target; // Set the target for the zombie's movement script.
    }
}
