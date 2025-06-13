using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuggerAwaker : MonoBehaviour
{
    public GameObject[] debugger;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.H) &&
            Input.GetKey(KeyCode.D) &&
            Input.GetKey(KeyCode.O))
        {
            foreach(GameObject dbgr in debugger) dbgr.SetActive(true);
        }
        if (Input.GetKey(KeyCode.O) &&
            Input.GetKey(KeyCode.H) &&
            Input.GetKey(KeyCode.N) &&
            Input.GetKey(KeyCode.O))
        {
            foreach(GameObject dbgr in debugger) dbgr.SetActive(false);
        }

    }
}
