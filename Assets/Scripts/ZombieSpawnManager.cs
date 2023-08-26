using UnityEngine;

public class ZombieSpawnManager : MonoBehaviour
{
    public GameObject zombiePrefab;
    [SerializeField] private GameObject levelManager;

    public Transform target; // The capsule's Transform (player character).

    public int maxZombies = 5; // Adjust this to limit the maximum number of zombies in the scene.
    private int totalZombiesSpawned = 0; // Counter for total zombies spawned.

    public float spawnRate = 3f; // Adjust this to control how often zombies spawn.
    public float minSpawnDistance = 4f; // Minimum distance to spawn around the tower.

    private void Start()
    {
        // Call the SpawnZombie function repeatedly with the defined spawnRate.
        InvokeRepeating("SpawnZombie", 0f, spawnRate);
        levelManager.SetActive(true);
    }
    private void SpawnZombie()
    {
        // Check if the maximum number of zombies is reached or the total count is 20.
        if (totalZombiesSpawned >= 12 || GameObject.FindGameObjectsWithTag("Tiny").Length >= maxZombies)
            return;
        Vector3 spawnPosition = GenerateValidSpawnPosition();
        if (spawnPosition != Vector3.zero)
        {
            // Instantiate the zombie prefab at the generated position.
            GameObject newZombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
            newZombie.GetComponent<Move>().target = target; // Set the target for the zombie's movement script.

            totalZombiesSpawned++; // Increment the total zombies spawned count.
        }
    }

    private Vector3 GenerateValidSpawnPosition()
    {
        Vector3 randomOffset = new Vector3(
            Random.Range(-15f, 15f),
            0f,
            Random.Range(-15f, 15f)
        );
        Vector3 spawnPosition;
        if (target.position != null)
        {
            spawnPosition = target.position + randomOffset;

            // Calculate the distance between the spawn position and the tower.
            float distanceToTower = Vector3.Distance(spawnPosition, transform.position);

            // If the distance is less than the minimum spawn distance, adjust the spawn position.
            if (distanceToTower < minSpawnDistance)
            {
                Vector3 directionToTower = (spawnPosition - transform.position).normalized;
                spawnPosition = transform.position + directionToTower * minSpawnDistance;
            }
            return spawnPosition;
        }
        return Vector3.zero;
    }
}
