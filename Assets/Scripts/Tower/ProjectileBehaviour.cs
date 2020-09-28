using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private Transform _target;
    private float _speed = 5f;


    public void Init(Transform target)
    {
        this._target = target;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (_target.position - transform.position) * Time.deltaTime * _speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Enemy")) return;
    }
    

}
