using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {


    //
    public int health;

    GameManager gm;
    // Movement
    public float MoveSpeed = 10.0f;

    public float frequency = 20.0f;  // Speed of sine movement
    public float magnitude = 5f;   // Size of sine movement
    private Vector3 axis;
    private Vector3 pos;

    void Awake()
    {
        health = 100;
    }

    void Start()
    {
        //InitSine();
        gm = FindObjectOfType<GameManager>();

    }

    private void InitSine()
    {
        pos = transform.position;
        //DestroyObject(gameObject, 20.0f);
        axis = transform.right;  // May or may not be the axis you want
    }

    void Update()
    {

        // transform.Translate()

        if(health > 0)
        {
            transform.Translate(new Vector3(0, -5f, 0f) * Time.deltaTime);
        } else
        {
            DestroyObject(gameObject);            
            gm.UpdateScore(25);
        }

        if (transform.position.y < -30f)
        {
            DestroyObject(gameObject);
        }
        
        
        //SineMovement();
    }

    private void SineMovement()
    {
        if (health > 0)
        {
            // Movement
            pos += -transform.up * Time.deltaTime * MoveSpeed;
            transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        //Debug.Log("Collided");
        if(coll.transform.tag == "PlayerBullet")
        {
            DestroyObject(coll.gameObject);
            health = health - 1;
        } 
    }

}
