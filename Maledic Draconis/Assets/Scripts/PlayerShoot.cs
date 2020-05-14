using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject prefab;
    public float shootSpeed = 10.0f;
    public float bulletLifetime = 0.1f;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("swordDelay") == 0)
        {
            PlayerPrefs.SetInt("swordDelay", 3);
        }
        timer = PlayerPrefs.GetInt("swordDelay");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && timer > .5f)//PlayerPrefs.GetInt("swordDelay"))  <-- THIS INSTEAD OF .5f
        {
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector2 shootDirection = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            shootDirection.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * shootSpeed;
            Destroy(bullet, bulletLifetime);
            timer = 0;
        }
    }
}
