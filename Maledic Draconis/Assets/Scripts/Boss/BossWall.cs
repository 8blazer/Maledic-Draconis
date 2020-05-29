using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossWall : MonoBehaviour
{
    public GameObject bossWall;
    public Image slider1;
    public Image slider2;
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
            slider1.GetComponent<Image>().enabled = true;
            slider2.GetComponent<Image>().enabled = true;
            Destroy(this);
        }
    }
}
