using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
	}
}
