using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWall : MonoBehaviour
{
    public GameObject bossWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 20)
        {
            bossWall.GetComponent<BoxCollider2D>().enabled = true;
            bossWall.GetComponent<SpriteRenderer>().enabled = true;
            Destroy(this);
        }
    }
}
