using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private Transform _target;
    private float _speed = 5f;
    private Vector3 dead_target;

    public void Init(Transform target)
    {
        this._target = target;
    }

    // Update is called once per frame
    void Update()
    {
        dead_target = _target.position;

        transform.position = transform.position + 
            ((_target == null ? dead_target : _target.position) - transform.position) * Time.deltaTime * _speed;
    }
}
