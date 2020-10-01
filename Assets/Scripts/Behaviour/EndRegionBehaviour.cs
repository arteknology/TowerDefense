using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRegionBehaviour : MonoBehaviour
{
    private PlayerBehaviour _player;

    void Start()
    {
        _player = GameObject.FindObjectOfType<PlayerBehaviour>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        EnemyBehaviour enemy = col.gameObject.GetComponent<EnemyBehaviour>();
        if (enemy == null) return;

        _player.RemoveLife(enemy._value);
        GameObject.Destroy(col.gameObject);
    }
}
