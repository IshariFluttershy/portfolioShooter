using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public BulletBehavior behavior;

    [SerializeField]
    int damages;

    


    public int Damages 
    {
        get { return damages; }
        private set { damages = value; }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        enemy Enemy = collision.gameObject.GetComponent<enemy>();
        player Player = collision.gameObject.GetComponent<player>();

        if (Enemy != null && tag == "player")
        {
            Destroy(gameObject);
        }
        else if (Player != null && tag == "enemy")
        {
            Destroy(gameObject);
        }
        else if (collision.tag == "DeathTrigger")
            Destroy(gameObject);
    }
}
