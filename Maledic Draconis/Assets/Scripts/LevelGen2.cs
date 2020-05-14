using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen2 : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (LevelGen.open.Contains(transform.position.x + " " + transform.position.y))
        {
            LevelGen.squares.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
