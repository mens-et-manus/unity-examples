using UnityEngine;
using System.Collections;

public class Instantiate : MonoBehaviour {
    public Rigidbody2D prefab;
    public float rateHumanReadable;
    public float emmision_time;
    private float rate;

	// Use this for initialization
	void Start () {
        rate = 1 / rateHumanReadable;
        InvokeRepeating("instantiate", .5f, rate);
        StartCoroutine(runTimer());
    }

    // Update is called once per frame
    void Update () {
        //this bit is boring
    }

    IEnumerator runTimer()
    {
        yield return new WaitForSeconds(emmision_time);
        CancelInvoke("instantiate");
    }

    void instantiate()
    {
        Rigidbody2D instance = Instantiate(prefab);
        instance.position = new Vector2(0, 0);
    }
}
