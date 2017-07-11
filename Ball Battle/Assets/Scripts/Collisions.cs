using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour {

    Rigidbody rbody;
    [SerializeField] Vector3 Impulse;
    [SerializeField] Vector3 forceDir;


    void Start () {
        rbody = GetComponent<Rigidbody>();
	}

    private void OnCollisionEnter(Collision col)
    {
        forceDir= col.transform.position - transform.position;
        Impulse = col.rigidbody.velocity - rbody.velocity;
        rbody.AddRelativeForce(forceDir+Impulse*Time.deltaTime);
    }
}
