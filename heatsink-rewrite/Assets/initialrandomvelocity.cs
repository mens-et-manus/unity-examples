using UnityEngine;
using System.Collections;

public class initialrandomvelocity : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 ((Random.value - .5f)*speed, (Random.value - .5f)*speed);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
