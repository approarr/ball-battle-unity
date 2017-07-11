using UnityEngine.Networking;
using UnityEngine;
using UnityStandardAssets.Vehicles.Ball;

public class CameraSetting : NetworkBehaviour {

    [SerializeField]
    GameObject Camera;
    [SerializeField]
    Behaviour BallControl;

    private void Awake()
    {
        BallControl = GetComponentInChildren<BallUserControl>();
    }

    void Start () {
        if (!isLocalPlayer)
        {
            Camera.SetActive(false);
            BallControl.enabled = false;
        }
	}	
}
