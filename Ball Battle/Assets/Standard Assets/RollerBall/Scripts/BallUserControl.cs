using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

namespace UnityStandardAssets.Vehicles.Ball
{
    public class BallUserControl : MonoBehaviour
    {
        private Ball ball; // Reference to the ball controller.

        private Vector3 move;
        // the world-relative desired move direction, calculated from the camForward and user input.
        //[SerializeField] GameObject camera;
        Rigidbody rbody;
        [SerializeField] Vector3 Impulse;
        [SerializeField] Vector3 forceDir;


        [SerializeField] private Transform cam; // A reference to the main camera in the scenes transform
        [SerializeField] private Vector3 camForward; // The current forward direction of the camera
        private bool jump; // whether the jump button is currently pressed


        private void Awake()
        {
            // Set up the reference.
            ball = GetComponent<Ball>();
            rbody = GetComponent<Rigidbody>();

            // get the transform of the main camera
            if (Camera.main != null)
            {
                //cam = Camera.main.transform;
                //cam=
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Ball needs a Camera tagged \"MainCamera\", for camera-relative controls.");
                // we use world-relative controls in this case, which may not be what the user wants, but hey, we warned them!
            }
        }


        private void Update()
        {
            // Get the axis and jump input.

            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            jump = CrossPlatformInputManager.GetButton("Jump");

            // calculate move direction
            if (cam != null)
            {
                // calculate camera relative direction to move:
                camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
                move = (v*camForward + h*cam.right).normalized;
                //Debug.Log("Move");
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                move = (v*Vector3.forward + h*Vector3.right).normalized;
            }
        }

        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Player")
            {

                forceDir = col.transform.position - transform.position;
                Impulse = col.rigidbody.velocity - rbody.velocity;
                //move = (forceDir + Impulse).normalized;
                //Vector3 force = forceDir * Impulse;
                rbody.AddForce(forceDir * Impulse.magnitude);
                Debug.Log(Impulse.magnitude);
            }
        }


        private void FixedUpdate()
        {
            // Call the Move function of the ball controller
            ball.Move(move, jump);
            jump = false;
        }
    }
}
