using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {
    public string CircleScene;
    public string SquareScene;
    public string MolecularDynamics;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnCircleClick ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(CircleScene);
    }

    public void OnSquareClick ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SquareScene);
    }
    public void OnMDClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(MolecularDynamics);
    }
}
