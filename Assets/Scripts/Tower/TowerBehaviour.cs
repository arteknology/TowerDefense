using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{

    public Collider2D NearestTarget => Physics2D.OverlapCircle(transform.position, _range);

    [SerializeField] private float _range;
    [SerializeField] private Transform _turret;
 
    private Collider2D _target;
    private const float turret_rotation_speed = 8f;
    private void Start()
    {
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

    private void Update()
    {
        if (_target == null || !IsInRange(_target.transform))
        {
            _target = NearestTarget;
        }
        if (_target != null)
        {
            FollowTarget();
        }
    }
}
