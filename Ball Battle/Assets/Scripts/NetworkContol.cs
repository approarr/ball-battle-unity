using UnityEngine.Networking;
using UnityStandardAssets.Vehicles.Ball;
using UnityEngine;

public class NetworkContol : NetworkBehaviour {

    [SerializeField] Behaviour[] ComponentsToDisable;
    [SerializeField] GameObject Camera;
    void Start()
    {
        if (!isLocalPlayer)
        {
            Camera.SetActive(false);
            for(int i = 0; i < ComponentsToDisable.Length; i++)
            {
                ComponentsToDisable[i].enabled=false;
            }
        }
    }

}
