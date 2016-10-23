using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    GameManager gm;

    GameObject player;

    float speed = 50f;

    float timerShooting;
    

    void Awake()
    {
        gm = FindObjectOfType<GameManager>();

        timerShooting = Time.time;
        
    }

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	
    void Update()
    {
        // Axis Input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        
        // The amount we move
        Vector3 movementVector;

        // The Current Position
        Vector3 posCurrent;
        // Previous position
        Vector3 posPrevious;
        // Velocity Vector calculated from positions
        Vector3 velocity;


        // The Input
        movementVector = new Vector3(h, v) * speed;

        // Previous Position before we move
        posPrevious = player.transform.position;        

        // Move The Player
        player.transform.Translate(movementVector * Time.deltaTime);

        // Current Position after movement
        posCurrent = player.transform.position;
        // Calculate the velocity using Time
        velocity = ((posCurrent - posPrevious)) / Time.deltaTime;



        //Debug.Log(velocity);

        IntervalSpawning();
    }



    private void IntervalSpawning()
    {


        if (timerShooting < Time.time)
        { //This checks wether real time has caught up to the timer

            Vector2 pos = transform.position;
            pos = pos + new Vector2(0, 5f); 

            GameObject go = Instantiate(gm.prefabPlayerBullet, pos, Quaternion.identity) as GameObject;
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,
                1350f));
            
            timerShooting = Time.time + .11f; //This sets the timer 3 seconds into the future
        }
    }

}
