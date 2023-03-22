using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] private float _bulletBaseSpeed = 5f;
    private Bullet bullet;
    [SerializeField] private Transform _shootPoint;

}
