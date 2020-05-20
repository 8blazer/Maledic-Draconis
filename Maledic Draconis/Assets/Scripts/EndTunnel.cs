using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndTunnel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (LevelGen.enemyCount == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (transform.position.x == 0 || transform.position.y == 0)
        {
            if (LevelGen.goalY > LevelGen.permaStartY)
            {
                transform.position = new Vector3(LevelGen.goalX, LevelGen.goalY + 10, 0);
            }
            else
            {
                transform.position = new Vector3(LevelGen.goalX, LevelGen.goalY - 10, 0);
                gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0, .475f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LevelGen.open.Clear();
            LevelGen.squares.Clear();
            SceneManager.LoadScene("TopDown2");
        }
    }
}
