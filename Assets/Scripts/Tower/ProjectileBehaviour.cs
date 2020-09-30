using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private Transform _target;
    private float _speed;
    private Vector3 dead_target;

    public int Damage;

    public void Init(Projectiles projectile, Transform target, int Damage)
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = projectile.color;
        transform.localScale = new Vector3(projectile.Size, projectile.Size, 1f);

        _speed = projectile.Speed;

        this.Damage = Damage;
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
