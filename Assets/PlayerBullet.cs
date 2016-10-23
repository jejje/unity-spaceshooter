using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {


    float bulletExists;

	// Use this for initialization
	void Start () {
        bulletExists = Time.time + 1f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (bulletExists < Time.time)
        {
            DestroyObject(gameObject);
            
        }
	}
}
