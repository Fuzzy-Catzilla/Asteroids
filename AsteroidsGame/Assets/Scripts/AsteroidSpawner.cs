using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private Vector2 spawnSize = new();
    [SerializeField] private Vector2 pointSize = new();


    private void Awake()
    {
        SpawnAsteroid();
    }

    public void SpawnAsteroid()
    {
        Vector2 spawnPos = new();
        int dir = Random.Range(0, 3);
        switch(dir)
        {
            case 0:
                spawnPos = new(spawnSize.x, Random.Range(-spawnSize.y, spawnSize.y));
                break;
            case 1:
                spawnPos = new(-spawnSize.x, Random.Range(-spawnSize.y, spawnSize.y));
                break;
            case 2:
                spawnPos = new(Random.Range(-spawnSize.x, spawnSize.x), spawnSize.y);
                break;
             case 3:
                spawnPos = new(Random.Range(-spawnSize.x, spawnSize.x), -spawnPos.y);
                break;
            default:
                Debug.Log("Something's wrong I can feel it.");
                break;
        }

        Vector2 pointAt = new(Random.Range(-pointSize.x, pointSize.x), Random.Range(-pointSize.y, pointSize.y));
        //Sets the direction the asteroid will go.
        Vector3 diff = pointAt - spawnPos;
        diff.Normalize();
        float zRot = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPos, Quaternion.Euler(0f, 0f, zRot - 90));


    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector3.zero, spawnSize * 2);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero, pointSize * 2);
    }
}
