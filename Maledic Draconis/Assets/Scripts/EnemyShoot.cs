using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject prefab;
    public GameObject player;
    public float bulletSpeed = 10f;
    public float playerDistanceMin = 5;
    private float playerDistance = 0;
    public float bulletLifetime = 1.0f;
    public float shootDelay = 1.0f;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer = shootDelay;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 shootDirection = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        playerDistance = shootDirection.magnitude;
        timer += Time.deltaTime;
        if (timer > shootDelay && playerDistance < playerDistanceMin)
        {
            shootDirection.Normalize();
            Vector3 spawnPosition = transform.position;
            GameObject bullet = Instantiate(prefab, spawnPosition, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletSpeed;
            Destroy(bullet, bulletLifetime);
            timer = 0;
        }
    }
}