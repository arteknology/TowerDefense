using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRegionBehaviour : MonoBehaviour
{
    [SerializeField] private DirectionEnum target_direction;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        EnemyBehaviour enemy = col.gameObject.GetComponent<EnemyBehaviour>();

        if (enemy == null) return;

        enemy.ChangeDirection(target_direction);
    }
}
