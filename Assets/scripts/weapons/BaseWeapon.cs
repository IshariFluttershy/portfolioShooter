using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : WeaponBehavior
{
    [SerializeField]
    Vector3 bulletsStartPosition;
    [SerializeField]
    Vector3 bulletsDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Shoot(bool p_isPlayer)
    {
        lastFiredBullet += Time.deltaTime;

        if (lastFiredBullet < (1.0f / (fireRate)) * 60.0f / 100.0f)
            return;

            GameObject Bullet = Instantiate<GameObject>(bulletPrefab, transform.position + bulletsStartPosition, Quaternion.identity);
            Bullet.GetComponent<BulletBehavior>().direction = bulletsDirection;
            Bullet.GetComponent<BulletBehavior>().speed = speed;

            if (p_isPlayer)
            {
                Bullet.tag = "player";
            }
            else
            {
                Bullet.tag = "enemy";
            }
        

        lastFiredBullet = 0;
        firingLaserAudio.Play();
    }
}
