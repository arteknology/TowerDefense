using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehaviour : MonoBehaviour
{
    [SerializeField]
    private int enemy_count;

    [SerializeField]
    private float enemy_interval;

    [SerializeField]
    private EnemyBehaviour _enemy;

    [SerializeField]
    private DirectionEnum start_direction;

    private int current_count;
    private float current_interval;

    private void SpawnEnemy()
    {
        GameObject obj = GameObject.Instantiate(_enemy.gameObject);
        obj.transform.position = transform.position;
        obj.GetComponent<EnemyBehaviour>().ChangeDirection(start_direction);
    }

    private void Update()
    {
        if(current_count == enemy_count)
        {
            gameObject.SetActive(false);
        }

        current_interval += Time.deltaTime;

        if(current_interval >= enemy_interval)
        {
            SpawnEnemy();
            current_count++;
            current_interval = current_interval - enemy_interval;
        }
    }
}
