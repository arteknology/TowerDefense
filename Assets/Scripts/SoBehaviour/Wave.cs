using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Wave : ScriptableObject
{
    public Enemy _enemy;
    public EnemyBehaviour EnemyTemplate;
    public int EnemyCount;
    public float Interval;
}
