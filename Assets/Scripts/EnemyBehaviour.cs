using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private DirectionEnum _startDirection;
    [SerializeField]
    private float _speed;

    private Vector3 Direction;
    // Start is called before the first frame update
    void Start()
    {
        ChangeDirection(_startDirection);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Direction * _speed);
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
}
