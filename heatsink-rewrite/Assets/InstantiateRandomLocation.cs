using UnityEngine;
using System.Collections;

public class InstantiateRandomLocation : MonoBehaviour
{
    public Rigidbody2D prefab;
    public float rateHumanReadable;
    public float emmision_time;
    public float X_Max;
    //public float X_Min;
    public float Y_Max;
    //public float Y_Min;
    
    private float rate;

    // Use this for initialization
    void Start()
    {
        rate = 1 / rateHumanReadable;
        InvokeRepeating("instantiate", .5f, rate);
        StartCoroutine(runTimer());
    }

    // Update is called once per frame
    void Update()
    {
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
        instance.position = new Vector2((Random.value*2 - 1f)*X_Max, (Random.value * 2 - 1f) * Y_Max);
    }
}
