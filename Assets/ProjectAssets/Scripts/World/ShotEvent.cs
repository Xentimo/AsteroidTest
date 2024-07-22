using System;
using System.Collections;
using System.Collections.Generic;
using Game.World;
using Unity.VisualScripting;
using UnityEngine;

public enum WeaponType
{
    Bullet = 0, Lazer = 1
}
public class ShotEvent 
{
    public Vector3 startPoint;
    public double startTime;
    public Vector3 direction;
    public Vector3 endPoint;
    public WeaponType weaponType;
    public float speed;
    public double maxDistance;
    public float health;
    public bool isEnemy;
    public float damage;
}
