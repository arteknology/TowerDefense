using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehaviour : MonoBehaviour
{
    [SerializeField] private Wave[] waves;
    [SerializeField] private DirectionEnum start_direction;

    private int current_wave;
    private int current_count;
    private float current_interval;
    private bool _active;

    private void Start()
    {
        current_wave = 0;
        current_count = 0;
        current_interval = 0f;
        _active = true;
    }

    private void SpawnEnemy()
    {
        GameObject obj = GameObject.Instantiate(waves[current_wave].EnemyTemplate.gameObject);
        obj.transform.position = transform.position;
        EnemyBehaviour behaviour = obj.GetComponent<EnemyBehaviour>();
        behaviour.Init(waves[current_wave]._enemy);
        behaviour.ChangeDirection(start_direction);
    }

    private void Update()
    {
        if (_active)
        {
            if (current_count == waves[current_wave].EnemyCount)
            {
                _active = false;
            }

            current_interval += Time.deltaTime;

            if (current_interval >= waves[current_wave].Interval)
            {
                SpawnEnemy();
                current_count++;
                current_interval = current_interval - waves[current_wave].Interval;
            }
        }

        else
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Targetable");
            if(enemies.Length == 0)
            {
                _active = true;
                current_wave += 1;
            }
        }
    }
}
