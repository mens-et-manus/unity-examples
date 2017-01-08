using UnityEngine;
using System.Collections;

public class SpotBehavior : MonoBehaviour {

    public float DragMagnitude;
    public float MaxMagnitude;
    public float ZZero;
    public float blue;
    public float red;
    public float Sensitivity;
    private float Magnitude;
    private Rigidbody2D oneparticle;
    private Vector2 Velocity;
    private Vector2 UnitDirection;
    private float RawMagnitude;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        SpriteRenderer spot = GetComponent<SpriteRenderer>();
        /*
        if (Input.GetMouseButton(0))  //if left mouse button is held down
        {
            Magnitude = -1f * DragMagnitude;
            spot.color = new Color(0f, .2f, 1f, .2f);  //BLUE
            //Debug.Log("left click");
        }
        else if (Input.GetMouseButton(1))  //if right mouse button is held down
        {
            Magnitude = MaxMagnitude;
            spot.color = new Color(.8f, .1f, .1f, .3f);  //RED
            //Debug.Log("right click");
        }
        else
        {
            Magnitude = 0;
            spot.color = new Color(0f, 0f, 0f, .4f);
        }
        */
        RawMagnitude = transform.position.z - ZZero;
        Magnitude = RawMagnitude * Sensitivity;
        if (Magnitude > 0)
        {
            spot.color = new Color((Magnitude*red +.1f), .1f, .1f, .4f);
        }
        else if (Magnitude < 0)
        {
            spot.color = new Color(.1f, .1f, (Magnitude*blue*-1f + .1f), .4f);
        }
        //Debug.Log(transform.position.z);
        //Debug.Log(transform.position);
    }

    void OnTriggerStay2D(Collider2D particle)
    {
        //Debug.Log("Object in the trigger area");
            oneparticle = particle.gameObject.GetComponent<Rigidbody2D>();
            Velocity = oneparticle.velocity;
            UnitDirection = Velocity.normalized;
            oneparticle.AddForce(Magnitude * UnitDirection);
            //Debug.Log("adding force");
    }
}
