using UnityEngine;
using UnityEngine.Rendering;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject[] obstaclePrefabs;
    public float obstacleSpawnTime = 3f;

    private float timeAlive;
    private float timeUntilObstacleSpawn;
    public float obstacleSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        timeAlive = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        if (obstacleSpeed < 25)
        {
            obstacleSpeed *= difficultyInc();
        }

        if (obstacleSpeed > 10)
        {
            obstacleSpawnTime = 2f;
        }
        else if (obstacleSpeed > 17)
        {
            obstacleSpawnTime = 1f;
        }
        
        SpawnLoop();
    }

    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;

        if (timeUntilObstacleSpawn >= obstacleSpawnTime)
        {
            Spawn();
            timeUntilObstacleSpawn = 0f;
        }
    }

    private void Spawn()
    {
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.linearVelocity = Vector2.left * obstacleSpeed;
    }

    private float difficultyInc()
    {
        float difficultySpeed = .5f;
        while (difficultySpeed < .8f)
        {
            difficultySpeed = Mathf.Pow(timeAlive, .00003f);
        }

        return difficultySpeed;
    }

}
