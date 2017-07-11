using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    public int moveSpeed;
    public int JumpPower;
    private Rigidbody rbody;
    public GameObject cam;
	
	void Start () {
        rbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 pushDir = transform.position-cam.transform.position;

        float moveX = xInput * moveSpeed * Time.deltaTime;
        float moveZ = zInput * moveSpeed * Time.deltaTime;

        rbody.AddRelativeForce(-moveX, 0f, -moveZ);

        //rbody.AddForce(moveX,0,moveZ);
        if (Input.GetButtonDown("Jump"))
        {
            rbody.AddForce(0, JumpPower, 0);
        }
        
	}
}
