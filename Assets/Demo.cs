using UnityEngine;
using System.Collections;

public class Demo : MonoBehaviour {

    CharacterController p;

	// Use this for initialization
	void Start () {
        p = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        p.Move(new Vector3(h * 2f, v, 0) * Time.deltaTime * 30f);

        transform.Rotate(new Vector3(v,h / 3, 0));
	}
}
