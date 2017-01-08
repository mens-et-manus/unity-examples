using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {
    public GameObject ObjectToFollow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    transform.position = ObjectToFollow.GetComponent<Transform>().position;
	}
}
