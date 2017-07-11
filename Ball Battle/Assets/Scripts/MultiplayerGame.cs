using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MultiplayerGame : NetworkBehaviour
{
    public GameObject[] animals;

    public int random;

    [SyncVar]
    public GameObject animals_fly;

    [SyncVar]
    public int Score;

    public void pickanimal(int index)
    {
        animals_fly = animals[index];
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            random = Random.Range(0, animals.Length);
            pickanimal(random);
            if (animals_fly.tag == "flies"&&!Input.GetMouseButton(0))
            {
                Score+=10;
            }
            else
            {
                if (Score >= 10)
                    Score -= 10;
            }
        }
    }
}
