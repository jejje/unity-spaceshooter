using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    Rigidbody2D rb;

    Vector2 start;
    Vector2 posEnemy;

    Vector2 posPlayer;
    Transform player;

    float distToGround;
    // Ground Layer
    int layerMaskGround = 1 << 9;

    public GameObject enemyBulletPrefab;

    float shootTimer;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();

        start = new Vector2(0, 20f);

        player = GameObject.FindGameObjectWithTag("Player").transform;

        distToGround = rb.GetComponent<Collider2D>().bounds.extents.y;

        shootTimer = Time.time;

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        rb = GetComponent<Rigidbody2D>();

        

        posEnemy = rb.position;
        posPlayer = GameObject.FindGameObjectWithTag("Player").transform.position;
        

        float a = 15f;
        float b = -0.5f;

        //Vector2 force = new Vector2(100f, -10f);



        /*
        if (posEnemy.x < posPlayer.x)
        {
            rb.AddForce(new Vector2(a, b));
        } else
        {
            rb.AddForce(new Vector2(-a, 0f));
        }
        */




        


        // rb.MovePosition(posPlayer * Time.deltaTime);
        



        ChasePlayer();
        ShootPlayer();
    }

    
    void ShootPlayer()
    {
        if (shootTimer < Time.time)
        { //This checks wether real time has caught up to the timer
            SpawnBullet();
            shootTimer = Time.time + 3f; //This sets the timer 3 seconds into the future
        }
    }

    void SpawnBullet()
    {
        Vector3 position = transform.position;
        position += new Vector3(0f, -3f);
        

        Instantiate(enemyBulletPrefab, position, Quaternion.identity);
    }

    void ChasePlayer()
    {
        float moveSpeed = 45f;

        posPlayer = new Vector2 (posPlayer.x + Random.Range(0f, 10f), posPlayer.y + -30f);


        


        Vector2 MovePos = new Vector2(
     transform.position.x + posPlayer.x * moveSpeed, //MoveTowards on 1 axis
     transform.position.y
 );
        transform.position = MovePos;


        if (transform.position.y < 20f)
        {
            // Move Towards Earth
            transform.position = Vector2.MoveTowards(posEnemy, new Vector2(0f, -100f), 3f * (3f * Time.deltaTime));

            //rb.AddForce(new Vector2(10f, 0f));

            
        } else
        {
            
            // Move Towards Player
            transform.position = Vector2.MoveTowards(posEnemy, posPlayer, 2f * (3f * Time.deltaTime));
        }

    }



    bool IsGrounded()
    {
        // RayCast
        Vector2 origin = transform.position;
        Vector2 addMe = new Vector2(0f, -10f);

        origin += addMe;

        Vector2 direction = new Vector2(0f, -10f);
        float distance = distToGround + 1f;
        // layermask
        float minDepth = -Mathf.Infinity;
        float maxDepth = Mathf.Infinity;


        bool iAmGrounded = Physics2D.Raycast(origin, direction, distance, layerMaskGround);
        Debug.DrawRay(origin, direction, new Color(1,0,0), distance); // RayCast Debug

        return iAmGrounded;

    }
}
