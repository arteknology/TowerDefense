using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Vector3 Direction;

    private float max_life;
    private float current_life;
    private float _speed;
    
    public int _gold;
    public int _value;

    private PlayerBehaviour _player;

    private void Start()
    {
        _player =GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
    }
    public void Init(Enemy enemy)
    {
        transform.localScale = new Vector3(enemy.Size, enemy.Size, 1f);

        SpriteRenderer _renderer = GetComponent<SpriteRenderer>();
        _renderer.sprite = enemy.Tsprite;
        _renderer.color = enemy.color;

        max_life = enemy.Life;
        current_life = max_life;
        _speed = enemy.MoveSpeed;
        _gold = enemy.Gold;
        _value = enemy.Value;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Direction * _speed * Time.deltaTime);
    }

    public void ChangeDirection(DirectionEnum dir)
    {
        switch (dir)
        {
            case DirectionEnum.UP:
                Direction = Vector3.up;
                break;
            case DirectionEnum.DOWN:
                Direction = Vector3.down;
                break;
            case DirectionEnum.LEFT:
                Direction = Vector3.left;
                break;
            case DirectionEnum.RIGHT:
                Direction = Vector3.right;
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Projectile")) return;

        ProjectileBehaviour projectile = col.GetComponent<ProjectileBehaviour>();
        current_life -= projectile.Damage;

        //TODO: animate enemy taken damage
        GameObject.Destroy(col.gameObject);

        if (current_life <= 0) {
            _player.AddGold(_value);
            GameObject.Destroy(this.gameObject);
        }
    }
}
