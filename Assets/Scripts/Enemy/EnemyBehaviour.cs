using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Vector3 Direction;
    // Start is called before the first frame update
    void Start()
    {

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

        GameObject.Destroy(col.gameObject);
    }
}
