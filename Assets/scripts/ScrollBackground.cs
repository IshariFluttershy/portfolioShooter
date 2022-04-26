using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField]
    Transform bg1;
    [SerializeField]
    Transform bg2;

    [SerializeField]
    float yLimit;
    [SerializeField]
    float offset;
    [SerializeField]
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bg1.position += Vector3.down * speed * Time.deltaTime;
        bg2.position += Vector3.down * speed * Time.deltaTime;


        if (bg1.position.y <= yLimit)
        {
            bg1.position += Vector3.up * offset;
        }
        if (bg2.position.y <= yLimit)
        {
            bg2.position += Vector3.up * offset;
        }
    }
}
