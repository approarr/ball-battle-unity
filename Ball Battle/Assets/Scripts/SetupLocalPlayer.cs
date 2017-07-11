using UnityEngine.Networking;
using UnityEngine;


    public class SetupLocalPlayer : NetworkBehaviour
    {

        [SyncVar]
        public Color playerColor = Color.white;

        void Start()
        {
            Renderer rend = GetComponentInChildren<Renderer>();
            rend.material.color = playerColor;
            //transform.position = new Vector3(Random.Range(-20, 20), 1, (Random.Range(-20, 20)));
        }
        public virtual void OnStartClient(NetworkClient client)
        {
            GetComponentInChildren<Renderer>().material.color = playerColor;
        }
    }
