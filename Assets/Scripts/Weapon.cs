using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Bullet bullet;
    public Transform[] firePoints;
    public float damage;
    public float shotsPerSeconds;
    private float nextShotTime;
    public int ammo;
    public Sprite weaponIcon;
    public Animator fireAnim;

    private void Start()
    {
        fireAnim = GetComponentInChildren<Animator>();
    }

    public void Shoot()
    {
        if (nextShotTime <= Time.time && ammo >0)
        {
            fireAnim.SetTrigger("Fire");
            foreach(Transform firePoint in firePoints)
            {
                Bullet _bullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                _bullet.damage = damage;
            }
            nextShotTime = Time.time + (1 / shotsPerSeconds);
            ammo--;
        }
    }
}
