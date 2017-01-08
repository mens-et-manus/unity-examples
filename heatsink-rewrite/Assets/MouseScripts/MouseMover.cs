using UnityEngine;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

public class MouseMover : MonoBehaviour {
    public Transform ObjectToFollow;
    //public float MouseSensitivity;
    public GameObject CameraToTrackFrom;
    public bool TrackedObjectInCanvas = false;
    public int YCenter = -50;
    private int MouseX;
    private int MouseY;
    private Vector3 screenPos;
    Camera camera1;
	// Use this for initialization
	void Start () {
        camera1 = CameraToTrackFrom.GetComponent<Camera>();
        screenPos = new Vector3 (0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (TrackedObjectInCanvas)
        {
            screenPos = ObjectToFollow.position;
        }
        else {
            screenPos = camera1.WorldToScreenPoint(ObjectToFollow.position);
        }
        MouseX = (int)screenPos.x;
        MouseY = UnityEngine.Screen.height - (int)screenPos.y - YCenter;
        //Debug.Log(screenPos);
        System.Windows.Forms.Cursor.Position = new System.Drawing.Point(MouseX, MouseY);
        //UnityEngine.Screen.width;
    }
}
