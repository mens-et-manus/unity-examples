using UnityEngine;
using System.Collections;

public class GoTo_Menu : MonoBehaviour {
    public string MenuScene;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(MenuScene);
        }
	}
}
