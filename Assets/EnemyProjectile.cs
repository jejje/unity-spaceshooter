using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

    float bulletExists;

    // Use this for initialization
    void Start () {
        bulletExists = Time.time + 6f;
    }
	
	// Update is called once per frame
	void Update () {


        if (transform.position.y < -50f)
        {
            // Stop stuff
        } else
        {
            Vector2 end = new Vector2(transform.position.x, transform.position.y - 100);
            transform.position = Vector2.MoveTowards(transform.position, end, 10f * (3f * Time.deltaTime));
            
           // GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -20f));
        }
    }

    void FixedUpdate()
    {
        if (bulletExists < Time.time)
        {
            DestroyObject(gameObject);

        }
    }
}
