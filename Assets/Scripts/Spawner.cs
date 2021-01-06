using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePatterns;
    float timeBetweenSpawn;
    [SerializeField] float startTimeBetweenSpawn;
    [SerializeField] float decreaseTime;
    [SerializeField] float minTime = 0.65f;

    void Update()
    {
        if (timeBetweenSpawn <= 0)
        {
            int rand = Random.Range(0, obstaclePatterns.Length);
            Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
            timeBetweenSpawn = startTimeBetweenSpawn;
            if (startTimeBetweenSpawn > minTime)
                startTimeBetweenSpawn -= decreaseTime;
        }
        else
            timeBetweenSpawn -= Time.deltaTime;
    }
}
