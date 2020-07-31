using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float shotSpeed;
    public static float StaticShotSpeed { get; private set; }

    public GameObject bulletPrefab;
    public static GameObject StaticBulletPrefab { get; private set; }

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        StaticBulletPrefab = bulletPrefab;
        StaticShotSpeed = shotSpeed;

        InputManager.Fire += Fire;
    }
    
    private void Fire()
    {
        _animator.SetBool("Firing", true);
    }
}
