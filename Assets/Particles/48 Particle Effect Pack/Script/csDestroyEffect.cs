using UnityEngine;
using System.Collections;

public class csDestroyEffect : MonoBehaviour {

    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
    }
    void Update () {
        transform.Rotate(-180, 0, 0);
        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.C))
        {
            //Destroy(gameObject);
        }
    }
}
