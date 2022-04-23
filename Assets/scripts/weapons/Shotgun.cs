using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : WeaponBehavior
{
    [SerializeField]
    List<Vector3> bulletsStartPosition;
    [SerializeField]
    List<Vector3> bulletsDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lastFiredBullet += Time.deltaTime;
    }


    public override void Shoot(bool p_isPlayer)
    {

        if (lastFiredBullet < (1.0f / (fireRate)) * 60.0f / 100.0f)
            return;

        for (int i = 0; i < bulletsStartPosition.Count; i++) 
        {
            GameObject Bullet = Instantiate<GameObject>(bulletPrefab, transform.position + bulletsStartPosition[i], Quaternion.identity);
            Bullet.GetComponent<BulletBehavior>().direction = bulletsDirection[i];
            Bullet.GetComponent<BulletBehavior>().speed = speed;

            if (p_isPlayer)
            {
                Bullet.tag = "player";
            }
            else
            {
                Bullet.tag = "enemy";
            }
        }

        lastFiredBullet = 0;

        if (firingLaserAudio != null)
            firingLaserAudio.Play();
    }
}
