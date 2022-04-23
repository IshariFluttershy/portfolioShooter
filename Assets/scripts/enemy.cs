using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField]
    int life = 10;

    public bool Alive { get { return life > 0; } }

    GameManager manager;

    WeaponBehavior weapon;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        weapon = GetComponent<WeaponBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            gameObject.SetActive(false);
            manager.EnemyDestroyed();
        }

            weapon.Shoot(false);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bullet Bullet = collision.gameObject.GetComponent<bullet>();
        if (Bullet != null && Bullet.tag == "player")
        {
            GetHit(Bullet.Damages);
        }
        else if (collision.tag == "DeathTrigger")
            life = 0;
    }

    private void GetHit(int damages)
    {
        life -= damages;
        Debug.Log("Life == " + life);
    }
}
