using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRegionBehaviour : MonoBehaviour
{
    [SerializeField]
    private DirectionEnum _targetDirection;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBehaviour Enemy = collision.gameObject.GetComponent<EnemyBehaviour>();

        if (Enemy == null) return;

        Enemy.ChangeDirection(_targetDirection);
    }
}
