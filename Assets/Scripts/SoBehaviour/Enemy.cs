using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Enemy : ScriptableObject
{
    public int Life;
    public Sprite Tsprite;
    public float Size;
    public Color color;
    public float MoveSpeed;
    public int Gold;
    public int Value;
}
