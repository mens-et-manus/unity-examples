using UnityEngine;
using System.Collections;

public class CursorTexture : MonoBehaviour {
    public Texture2D CursorImage;
    public Vector2 hotspot = Vector2.zero;
    public CursorMode mousemode = CursorMode.Auto;
	// Use this for initialization
	void Start () {
        //Cursor.SetCursor(CursorImage, hotspot, mousemode);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
