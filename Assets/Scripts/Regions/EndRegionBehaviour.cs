using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRegionBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyBehaviour>() == null) return;

        //TODO: Remove player Hp 
        GameObject.Destroy(collision.gameObject);
    }
}
