using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;

    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (IsOffScreen())
        {
            Destroy(gameObject);
        }
    }

    bool IsOffScreen()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        return viewPos.x < -0.1f || viewPos.x > 1.1f;
    }
}
