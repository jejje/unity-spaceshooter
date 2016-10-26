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

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            DestroyObject(gameObject);
            //Debug.Log("I DESTROY DA PLAYA");
            GameManager gm = FindObjectOfType<GameManager>();
            //            gm.playerScore = gm.playerScore - 10;
          //  Debug.Log(gm.playerScore);
            gm.UpdateScore(-50);

        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            DestroyObject(gameObject);
            GameManager gm = FindObjectOfType<GameManager>();
            gm.playerScore = gm.playerScore - 10;
        }
    }
}
