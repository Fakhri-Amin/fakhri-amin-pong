using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public static PowerUpSpawner Instance;
    public int currentInstanceAmount;

    [SerializeField] private GameObject[] powerUps;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    [SerializeField] private float spawnAreaX;
    [SerializeField] private float spawnAreaY;
    [SerializeField] int maxPowerUpInstanceAmount;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(SpawnPowerUp());
    }

    private void Update()
    {
        if (!GameManager.Instance.isGameEnd) return;

        var instances = FindObjectsOfType<PowerUp>();
        foreach (PowerUp powerUp in instances)
        {
            Destroy(powerUp.gameObject);
        }
    }

    IEnumerator SpawnPowerUp()
    {
        while (!GameManager.Instance.isGameEnd)
        {
            float randomSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(randomSpawnTime);

            if (currentInstanceAmount < maxPowerUpInstanceAmount) Spawn();
        }
    }

    private void Spawn()
    {
        currentInstanceAmount++;
        GameObject randomPowerup = powerUps[Random.Range(0, powerUps.Length)];

        float randomX = Random.Range(-spawnAreaX, spawnAreaX);
        float randomY = Random.Range(-spawnAreaY, spawnAreaY);
        Vector2 spawnArea = new Vector2(randomX, randomY);

        Instantiate(randomPowerup, spawnArea, Quaternion.identity);
    }
}
