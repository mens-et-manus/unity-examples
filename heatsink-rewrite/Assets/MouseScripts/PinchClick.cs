using UnityEngine;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

public class PinchClick : MonoBehaviour {

    public GameObject ObjectWithDetectJoints;
    string HandState;
    Vector2 mousepos;
    bool mousedown = false;
    bool kinectReady = false;
    float[] InputStates = new float[7];
    string InputState;
    float total;

    //c# mouse stuff
    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
    private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    private const int MOUSEEVENTF_LEFTUP = 0x04;
    private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
    private const int MOUSEEVENTF_RIGHTUP = 0x10;

    // Use this for initialization
    void Start () {
        StartCoroutine(runTimer());
    }
	
	// Update is called once per frame
	void Update () {
        if (kinectReady)
        {
            InputState = ObjectWithDetectJoints.GetComponent<DetectJoints>().Hand1State();
            for (int i = 1; i <= (7 - 1); i++)  //shift data up the array
            {
                total = InputStates[i - 1] + total;
                InputStates[i - 1] = InputStates[i];
            }
            
            if (InputState == "Closed") {
                InputStates[7 - 1] = 0;  //input new data at end            
            } else if (InputState == "Unknown") {
                InputStates[7 - 1] = 1;  //input new data at end
            } else if (InputState == "Open") {
                InputStates[7 - 1] = 2;  //input new data at end
            }
            
            if (total/7f < 1.5f)
            {
                HandState = "Closed";
            } else
            {
                HandState = "Open";
            }
            total = 0;

        }
        if (HandState == "Closed" && mousedown == false) {
            mousepos = Input.mousePosition;
            mousepos = new Vector2(mousepos.x, UnityEngine.Screen.height - mousepos.y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)mousepos.x, (uint)mousepos.y, 0, 0);
            mousedown = true;
        }
        else if (mousedown == true && HandState != "Closed") {
            mousepos = Input.mousePosition;
            mousepos = new Vector2(mousepos.x, UnityEngine.Screen.height - mousepos.y);
            mouse_event(MOUSEEVENTF_LEFTUP, (uint)mousepos.x, (uint)mousepos.y, 0, 0);
            mousedown = false;
        }
        Debug.Log(total);
        Debug.Log(InputState);
        Debug.Log(HandState);
	}

    IEnumerator runTimer()
    {
        yield return new WaitForSeconds(6);
        kinectReady = true;
    }
}
