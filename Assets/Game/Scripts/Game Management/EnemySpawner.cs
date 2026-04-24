using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 5f;

    public float spawnYMin = -3f;
    public float spawnYMax = 3f;

    public void Start()
    {
        StartCoroutine(spawnRoutine());
    }

    IEnumerator spawnRoutine()
    {
        while (true)
        {
            spawnEnemy();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void spawnEnemy()
    {
        float y = Random.Range(spawnYMin, spawnYMax);

        bool spawnLeft = Random.value > 0.5f;

        float x = spawnLeft ? GetLeftEdge() : GetRightEdge();
        Vector2 spawnPos = new Vector2(x, y);

        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        EnemyMover mover = enemy.GetComponent<EnemyMover>();

        Vector2 direction = spawnLeft ? Vector2.right : Vector2.left;
        mover.SetDirection(direction);

    }

    float GetLeftEdge()
    {
        return Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - 1f;
    }

    float GetRightEdge()
    {
        return Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + 1f;
    }
}


