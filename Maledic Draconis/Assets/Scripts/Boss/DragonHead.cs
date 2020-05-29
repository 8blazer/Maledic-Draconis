using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DragonHead : MonoBehaviour
{
    public GameObject player;
    public GameObject saveManager;
    static public int health = 200;
    public ParticleSystem particleSystem;
    public GameObject bossWall;
    float timer;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health;
        transform.up = player.transform.position - transform.position;
        if (transform.eulerAngles.z < 120)
        {
            transform.eulerAngles = new Vector3(0, 0, 120);
        }
        else if (transform.eulerAngles.z > 240)
        {
            transform.eulerAngles = new Vector3(0, 0, 240);
        }
        if (bossWall.GetComponent<SpriteRenderer>().enabled)
        {
            timer += Time.deltaTime;
            if (timer > 7 && particleSystem.isPlaying == false)
            {
                particleSystem.Play();
            }
            else if (timer > 9)
            {
                particleSystem.Stop();
                timer = 0;
            }
        }
        if (health < 1)
        {
            SceneManager.LoadScene("Win");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (saveManager.GetComponent<SaveManager>().critChance > 99 || Random.Range(1, 101 - saveManager.GetComponent<SaveManager>().critChance) == 1)
            {
                DragonHead.health = DragonHead.health - (saveManager.GetComponent<SaveManager>().damage + saveManager.GetComponent<SaveManager>().critDamage);
            }
            else
            {
                DragonHead.health = DragonHead.health - saveManager.GetComponent<SaveManager>().damage - Random.Range(-1, 2);
            }
        }
    }
}
