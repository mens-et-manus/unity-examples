using UnityEngine;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

public class ClickTimer : MonoBehaviour {

    public Transform LoadingBar;
    public GameObject FullTimerObject;
    float starttime;
    bool timerActive;
    Vector2 mousepos;

    //c# mouse stuff
    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
    private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    private const int MOUSEEVENTF_LEFTUP = 0x04;
    private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
    private const int MOUSEEVENTF_RIGHTUP = 0x10;


    // Use this for initialization
    void Start () {
        LoadingBar.GetComponent<UnityEngine.UI.Image>().fillAmount = 0;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (timerActive && starttime + 2f < Time.time)
        {
            //Debug.Log("MOUSECLICKED");
            timerActive = false;
            mousepos = Input.mousePosition;
            mousepos = new Vector2(mousepos.x, UnityEngine.Screen.height - mousepos.y);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)mousepos.x, (uint)mousepos.y, 0, 0);
        }
        if (timerActive) {
            LoadingBar.GetComponent<UnityEngine.UI.Image>().fillAmount = (Time.time - starttime) / 2f;
        }
    }

    public void HandEnter ()
    {
        FullTimerObject.SetActive(true);
        starttime = Time.time;
        timerActive = true;
        //Debug.Log("mouse entered");
    }
    public void HandExit ()
    {
        timerActive = false;
        FullTimerObject.SetActive(false);
    }
}
