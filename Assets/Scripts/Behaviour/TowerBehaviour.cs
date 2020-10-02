using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public Collider2D NearestTarget => Physics2D.OverlapCircle(transform.position, _range);

    private int _damage;
    private float _range;
    private float attack_speed;
    private float ready_time;
    [NonSerialized]public int Cost;

    private Projectiles _projectile;
    private ProjectileBehaviour projectile_template;


    [SerializeField] private GameObject tower_base;
    [SerializeField] private GameObject tower_turret;
    [SerializeField] private GameObject tower_range;
 
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

    public void Init(Tower tower)
    {
        SpriteRenderer base_renderer = tower_base.GetComponent<SpriteRenderer>();
        base_renderer.sprite = tower.BaseSprite;
        base_renderer.color = tower.BaseColor;

        SpriteRenderer turret_renderer = tower_turret.GetComponent<SpriteRenderer>();
        turret_renderer.sprite = tower.Turret;
        turret_renderer.color = tower.TurretColor;

        _damage = tower.Damage;
        attack_speed = tower.AttackSpeed;
        ready_time = tower.ReadyTime;
        _range = tower.Range;
        Cost = tower.Cost;

        _projectile = tower.projectile;
        projectile_template = tower.projectile_template;        

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
        //Debug.Log("Distance : " + dist + " <= " + _range + " " + isInRange);
        return isInRange;
    }

    private void Fire()
    {
        current_time = current_time - attack_speed;

        ProjectileBehaviour bullet = GameObject.Instantiate(projectile_template);
        bullet.transform.position = tower_turret.transform.position;
        bullet.Init(_projectile, _target.transform, _damage);

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
