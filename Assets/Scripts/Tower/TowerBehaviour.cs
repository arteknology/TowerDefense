using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{

    public Collider2D NearestTarget => Physics2D.OverlapCircle(transform.position, _range);

    [SerializeField] private float _range;
    [SerializeField] private Transform _turret;
    [SerializeField] private float attack_speed;
    [SerializeField] private float ready_time;

    [SerializeField] private ProjectileBehaviour _projectile;
 
    private Collider2D _target;
    private float current_time;

    private const float turret_rotation_speed = 8f;

    private void Start()
    {
        current_time = 0f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, (_range-0.5f));
    }

    private void FollowTarget()
    {
        Vector3 vectorToTarget = _target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * turret_rotation_speed);
    }

    private bool IsInRange(Transform point)
    {
        float dist = Vector3.Distance(transform.position, point.position);
        bool isInRange = dist <= _range;
        Debug.Log("Distance : " + dist + " <= " + _range + " " + isInRange);
        return isInRange;
    }

    private void Fire()
    {
        current_time = current_time - attack_speed;

        ProjectileBehaviour bullet = GameObject.Instantiate(_projectile);
        bullet.transform.position = _turret.position;
        bullet.Init(_target.transform);

    }

    private void Update()
    {
        if (_target == null || !IsInRange(_target.transform))
        {
            _target = NearestTarget;
        }

        current_time += Time.deltaTime;

        if (_target != null)
        {
            FollowTarget();
            if (current_time >= attack_speed)
            {
                Fire();
            }
        }
        else if (current_time >= attack_speed)
        {
            current_time = attack_speed - ready_time;
        }
    }
}
