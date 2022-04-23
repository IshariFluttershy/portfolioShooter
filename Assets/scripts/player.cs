using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float speed;

    [SerializeField]
    int lives;



    Vector3 velocity = Vector3.zero;

    GameManager manager;
    SpriteRenderer renderer;
    Collider2D collider;
    WeaponBehavior weapon;



    [SerializeField]
    float maxInvincibilityTime;
    bool invincible = false;



    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        renderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        weapon = GetComponent<WeaponBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = Vector3.zero;

         if (Input.GetKey(KeyCode.RightArrow))
         {
             velocity += Vector3.right;
         }
         if (Input.GetKey(KeyCode.LeftArrow))
         {
             velocity += Vector3.left;
         }
         if (Input.GetKey(KeyCode.UpArrow))
         {
             velocity += Vector3.up;
         }
         if (Input.GetKey(KeyCode.DownArrow))
         {
             velocity += Vector3.down;
         }

        if (Input.GetKey(KeyCode.Space))
        {
            weapon.Shoot(true);
        }

        transform.position += velocity * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        enemy Enemy = collision.gameObject.GetComponent<enemy>();
        bullet Bullet = collision.gameObject.GetComponent<bullet>();

        if (invincible)
            return;

        if (Enemy != null || (Bullet != null && Bullet.tag == "enemy"))
        {
            lives -= 1;

            if (lives <= 0)
            {
                manager.PlayerDestroyed();
            }
            else
            {
                StartCoroutine(SetInvincible());
            }
        }
    }

    private IEnumerator SetInvincible()
    {
        collider.enabled = false;
        invincible = true;

        StartCoroutine(MaterialFlash());

        yield return new WaitForSeconds(maxInvincibilityTime);

        renderer.material.color = new Color(1, 1, 1, 1);
        invincible = false;
        collider.enabled = true;
    }

    private IEnumerator MaterialFlash()
    {
        for (float  i = 0; i < maxInvincibilityTime; i += Time.deltaTime)
        {
            float alpha = Mathf.PingPong(i, 0.5f);
            renderer.material.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
    }   
}
