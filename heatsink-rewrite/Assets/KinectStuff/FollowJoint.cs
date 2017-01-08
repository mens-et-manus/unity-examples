using UnityEngine;
using System.Collections;

public class FollowJoint : MonoBehaviour {
    public GameObject TrackedObject;
    public float sensitivity =20;
    public Vector3 ObjectCenter;  //desired center of object
    public int SmoothingInteger = 15;
    public bool ConvertWorldspaceToCanvas = false;
    public bool ShowCursor = true;
    private Vector3 ReadPosition;
    private Vector3[] vectors;
    private Vector3 sum;
    private Vector3 average;


    // Use this for initialization
    void Start () {
        Cursor.visible = ShowCursor;
        vectors = new Vector3[SmoothingInteger];
        for (int i = 0; i <= (SmoothingInteger - 1); i++)
        {
            vectors[i] = new Vector3(0, 0, 0);
            //Debug.Log(i);
        }
        //Debug.Log(vectors);
    }
	
	// Update is called once per frame
	void Update () {
        ReadPosition = ((TrackedObject.transform.position * sensitivity) - ObjectCenter);
        //Debug.Log(transform.position);
        
        if (ConvertWorldspaceToCanvas)
        {
            transform.position = Camera.main.WorldToScreenPoint(AverageVectors(ReadPosition));
        }
        else {
            transform.position = AverageVectors(ReadPosition);
        }
	}

    Vector3 AverageVectors (Vector3 inputdata)  //input new vector into array, shift older entries down, and return average
    {
        for (int i = 1; i <= (SmoothingInteger - 1); i++)  //shift data up the array
        {
            vectors[i-1] = vectors[i];
        }
        vectors[SmoothingInteger - 1] = inputdata;  //input new data at end

        sum = new Vector3(0, 0, 0);
        for (int i = 0; i <= (SmoothingInteger - 1); i++)  //average the whole thing
        {
            sum = sum + vectors[i];
        }
        average = sum / SmoothingInteger;

        return average;
    }
}
