using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraEnable : NetworkBehaviour {

    public GameObject thisCamera;

    void Start () {
        thisCamera = this.gameObject;
        if (!isLocalPlayer)
        {
            thisCamera.SetActive(false);
        }		
	}
}
