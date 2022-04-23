using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    [SerializeField]
    protected float fireRate;
    protected float lastFiredBullet = 0.0f;

    [SerializeField]
    protected GameObject bulletPrefab;
    [SerializeField]
    public float speed;

    [SerializeField]
    protected AudioSource firingLaserAudio;


    // Start is called before the first frame update
    void Start()
    {
        if (tag == "player")
            lastFiredBullet = 5000.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Shoot(bool p_isPlayer)
    {
       // lastFiredBullet += Time.deltaTime;
       //
       // if (lastFiredBullet < (1.0f / fireRate) * 60.0f / 100.0f)
       //     return;
       //
       //
       // GameObject Bullet = Instantiate<GameObject>(bulletPrefab, transform.position, Quaternion.identity);
       //
       // if (p_isPlayer)
       // {
       //     Bullet.GetComponent<BulletBehavior>().direction = direction;
       //     Bullet.GetComponent<BulletBehavior>().speed = speed;
       //     Bullet.tag = "player";
       // }
       // else
       // {
       //     Bullet.GetComponent<BulletBehavior>().direction = direction;
       //     Bullet.GetComponent<BulletBehavior>().speed = speed;
       //     Bullet.tag = "enemy";
       // }
       //
       // lastFiredBullet = 0;
       // firingLaserAudio.Play();
    }
}
