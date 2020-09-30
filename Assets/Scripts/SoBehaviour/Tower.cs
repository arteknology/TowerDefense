using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Tower : ScriptableObject
{
    public int Damage;
    public float AttackSpeed;
    public float ReadyTime;
    public float Range;
    public int Cost;

    public Sprite BaseSprite;
    public Color BaseColor;

    public bool FreezeRotation = false;
    public Sprite Turret;
    public Color TurretColor;

    public Projectiles projectile;
    public ProjectileBehaviour projectile_template;
}
