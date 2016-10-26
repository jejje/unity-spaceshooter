using UnityEngine;
using System.Collections;
using System;

public class PlayerInput : MonoBehaviour {

    GameManager gm;

    GameObject player;

    float speed = 50f;

    float timerShooting;

    private Vector2 touchOrigin = -Vector2.one; //Used to store location of screen touch origin for mobile controls.
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
	
    void FixedUpdate()
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


//#if UNITY_STANDALONE || UNITY_WEBPLAYER

        // The Input
        movementVector = new Vector3(h, v) * speed;

        // Previous Position before we move
        posPrevious = player.transform.position;




        movementVector = new Vector3(h, v) * speed;

        


        //Check if we are running on iOS, Android, Windows Phone 8 or Unity iPhone
#if UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE

        //Check if Input has registered more than zero touches
        if (Input.touchCount > 0)
        {
            //Store the first touch detected.
            Touch myTouch = Input.touches[0];

            //Check if the phase of that touch equals Began
            if (myTouch.phase == TouchPhase.Began)
            {
                //If so, set touchOrigin to the position of that touch
                touchOrigin = myTouch.position;
            }

            //If the touch phase is not Began, and instead is equal to Ended and the x of touchOrigin is greater or equal to zero:
            else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
            {
                //Set touchEnd to equal the position of this touch
                Vector2 touchEnd = myTouch.position;

                //Calculate the difference between the beginning and end of the touch on the x axis.
                float x = touchEnd.x - touchOrigin.x;

               // Debug.Log(x);

                //Calculate the difference between the beginning and end of the touch on the y axis.
                float y = touchEnd.y - touchOrigin.y;

                //Set touchOrigin.x to -1 so that our else if statement will evaluate false and not repeat immediately.
                touchOrigin.x = -1;

                float multiplier = 3f;

                //Check if the difference along the x axis is greater than the difference along the y axis.
                if (Mathf.Abs(x) > Mathf.Abs(y)) { 
                    //If x is greater than zero, set horizontal to 1, otherwise set it to -1
                    h = x > 0 ? 1 : -1;
                    h = h * multiplier;
                }
                else { 
                    //If y is greater than zero, set horizontal to 1, otherwise set it to -1
                    v = y > 0 ? 1 : -1;
                    v = v * multiplier;
                }





                //  h = h * 5f;
                // v = h * 5f;
                movementVector = new Vector3(x, y);

                // Move The Player
                player.transform.Translate(movementVector * Time.deltaTime);
            }

            
        }


#endif //End of mobile platform dependendent compilation section started above with #elif


        // Move The Player
       // player.transform.Translate(movementVector * Time.deltaTime);


        

        // Current Position after movement
        posCurrent = player.transform.position;
        // Calculate the velocity using Time
        velocity = ((posCurrent - posPrevious)) / Time.deltaTime;

        SmartphoneMovement();


        //Debug.Log(velocity);

        IntervalSpawning();
    }

    private void SmartphoneMovement()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log(gameObject.transform.name + " COLLIDED WITH " + coll.transform.tag);
    } 

    private void IntervalSpawning()
    {


        if (timerShooting < Time.time)
        { //This checks wether real time has caught up to the timer

            Vector2 pos = transform.position;
            pos = pos + new Vector2(0, 3f); 

            GameObject go = Instantiate(gm.prefabPlayerBullet, pos, Quaternion.identity) as GameObject;
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,
                150f));
            
            timerShooting = Time.time + .11f; //This sets the timer 3 seconds into the future
        }
    }


}
