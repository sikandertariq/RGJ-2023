//using UnityEngine;

//public class ZombieSpawnManager : MonoBehaviour
//{
//    public GameObject zombiePrefab;
//    public Transform target; // The capsule's Transform (player character).

//    public float spawnRate = 3f; // Adjust this to control how often zombies spawn.
//    public int maxZombies = 5; // Adjust this to limit the maximum number of zombies in the scene.

//    private void Start()
//    {
//        // Call the SpawnZombie function repeatedly with the defined spawnRate.
//        InvokeRepeating("SpawnZombie", 0f, spawnRate);
//    }

//    private void SpawnZombie()
//    {
//        // Check if the maximum number of zombies is reached.
//        if (GameObject.FindGameObjectsWithTag("Tiny").Length >= maxZombies)
//            return;

//        // Generate a random position on the plane to spawn the zombie.
//        float offsetX = Random.Range(-15f, 15f); // Adjust the values based on the desired range.
//        float offsetZ = Random.Range(-15f, 15f);

//        Vector3 spawnPosition = target.position + new Vector3(offsetX, 0f, offsetZ);


//        // Instantiate the zombie prefab at the generated position.
//        GameObject newZombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
//        newZombie.GetComponent<Move>().target = target; // Set the target for the zombie's movement script.
//    }
//}

//using UnityEngine;

//public class ZombieSpawnManager : MonoBehaviour
//{
//    public GameObject zombiePrefab;
//    public Transform target; // The capsule's Transform (player character).

//    public float spawnRate = 3f; // Adjust this to control how often zombies spawn.
//    public int maxZombies = 5; // Adjust this to limit the maximum number of zombies in the scene.
//    public float minSpawnDistance = 4f; // Minimum distance to spawn around the tower.
//    private int totalZombiesSpawned = 0; // Counter for total zombies spawned.

//    private void Start()
//    {
//        // Call the SpawnZombie function repeatedly with the defined spawnRate.
//        InvokeRepeating("SpawnZombie", 0f, spawnRate);
//    }

//    private void SpawnZombie()
//    {
//        // Check if the maximum number of zombies is reached.
//        if (GameObject.FindGameObjectsWithTag("Tiny").Length >= maxZombies)
//            return;

//        Vector3 spawnPosition = GenerateValidSpawnPosition();

//        // Instantiate the zombie prefab at the generated position.
//        GameObject newZombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
//        newZombie.GetComponent<Move>().target = target; // Set the target for the zombie's movement script.
//    }

//    private Vector3 GenerateValidSpawnPosition()
//    {
//        Vector3 randomOffset = new Vector3(
//            Random.Range(-15f, 15f),
//            0f,
//            Random.Range(-15f, 15f)
//        );

//        Vector3 spawnPosition = target.position + randomOffset;

//        // Calculate the distance between the spawn position and the tower.
//        float distanceToTower = Vector3.Distance(spawnPosition, transform.position);

//        // If the distance is less than the minimum spawn distance, adjust the spawn position.
//        if (distanceToTower < minSpawnDistance)
//        {
//            Vector3 directionToTower = (spawnPosition - transform.position).normalized;
//            spawnPosition = transform.position + directionToTower * minSpawnDistance;
//        }

//        return spawnPosition;
//    }
//}

using UnityEngine;

public class ZombieSpawnManager : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform target; // The capsule's Transform (player character).

    public float spawnRate = 3f; // Adjust this to control how often zombies spawn.
    public int maxZombies = 5; // Adjust this to limit the maximum number of zombies in the scene.
    public float minSpawnDistance = 4f; // Minimum distance to spawn around the tower.

    private int totalZombiesSpawned = 0; // Counter for total zombies spawned.

    private void Start()
    {
        // Call the SpawnZombie function repeatedly with the defined spawnRate.
        InvokeRepeating("SpawnZombie", 0f, spawnRate);
    }

    private void SpawnZombie()
    {
        // Check if the maximum number of zombies is reached or the total count is 20.
        if (totalZombiesSpawned >= 12 || GameObject.FindGameObjectsWithTag("Tiny").Length >= maxZombies)
            return;

        Vector3 spawnPosition = GenerateValidSpawnPosition();

        // Instantiate the zombie prefab at the generated position.
        GameObject newZombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
        newZombie.GetComponent<Move>().target = target; // Set the target for the zombie's movement script.

        totalZombiesSpawned++; // Increment the total zombies spawned count.
    }

    private Vector3 GenerateValidSpawnPosition()
    {
        Vector3 randomOffset = new Vector3(
            Random.Range(-15f, 15f),
            0f,
            Random.Range(-15f, 15f)
        );

        Vector3 spawnPosition = target.position + randomOffset;

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
}



