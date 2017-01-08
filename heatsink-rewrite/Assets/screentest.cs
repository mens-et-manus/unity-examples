using UnityEngine;
using System.Collections;

public class screentest : MonoBehaviour {
    public Transform target;
    public GameObject CameraToTrackFrom;
    Camera camera1;
    // Use this for initialization
    void Start () {
        camera1 = CameraToTrackFrom.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update () {
        Vector3 screenPos = camera1.WorldToScreenPoint(target.position);
        Debug.Log("target is " + screenPos.x + " pixels from the left");
    }
}
