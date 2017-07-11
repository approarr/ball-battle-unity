using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {

    public void LoadMulti()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadSingle()
    {
        SceneManager.LoadScene(1);
    }
}
