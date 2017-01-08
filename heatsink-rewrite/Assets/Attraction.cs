using UnityEngine;
using System.Collections;

public class Attraction : MonoBehaviour {
    public GameObject[] MoleculeList;
    Vector3 forceToAdd;
    Vector3 distanceFromObject;
    float distanceMagnitude;
    Vector3 forceDirection;
    float forceMagnitude;
    public float forceScalar;
    public float latticeDistance;
    Rigidbody2D ThisMolecule;
    Vector3 ZeroVector;
	// Use this for initialization
	void Start () {
        ThisMolecule = gameObject.GetComponent<Rigidbody2D>();
        ZeroVector = new Vector3(0, 0, 0);
        StartCoroutine(runTimer());
    }
	
	// Update is called once per frame
	void Update () {
        //MoleculeList = GameObject.FindGameObjectsWithTag("Molecule");
	    foreach (GameObject molecule in MoleculeList)
        {
            distanceFromObject = molecule.transform.position - transform.position;
            if (distanceFromObject.sqrMagnitude < (16))  //16 before trying optimization
            {
                forceDirection = distanceFromObject.normalized;
                distanceMagnitude = distanceFromObject.magnitude;
                //forceDirection = distanceFromObject / distanceMagnitude;
                if (distanceMagnitude < latticeDistance)
                {
                    forceMagnitude = (distanceMagnitude - latticeDistance) * (distanceMagnitude - 2f); // (1-x)^2 for x < 1
                    forceToAdd = forceToAdd + forceMagnitude * -forceDirection * 20f;
                }
                if (distanceMagnitude > latticeDistance)
                {
                    forceMagnitude = (distanceMagnitude - latticeDistance) * (distanceMagnitude - 2f); // -(1-x)^2 for x > 1
                    forceToAdd = forceToAdd + forceMagnitude * forceDirection * .01f;
                }
            }
        }
        ThisMolecule.AddForce(forceToAdd*forceScalar);
        forceToAdd = ZeroVector;
	}

    IEnumerator runTimer()
    {
        yield return new WaitForSeconds(6);
        MoleculeList = GameObject.FindGameObjectsWithTag("Molecule");
    }
}
