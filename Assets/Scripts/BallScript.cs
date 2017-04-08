using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    [SerializeField]
    float forceValue = 4.5f;

    Rigidbody2D myBody;

	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody2D>();
        myBody.AddForce(new Vector2(forceValue * 50, 50));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
