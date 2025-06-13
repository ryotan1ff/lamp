using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    public static GameObject oneself;
    public static GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        oneself = this.gameObject;
        prefab = (GameObject)Resources.Load("Prefabs/note");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void Send(string achiname)
    {
        GameObject note = Instantiate(prefab, oneself.transform);
        note.GetComponent<RectTransform>().position = oneself.transform.position + new Vector3(0, 600, 0);
        note.GetComponentsInChildren<Text>()[0].text = achiname.Substring(0, achiname.IndexOf("("));
        note.GetComponentsInChildren<Text>()[1].text = achiname.Substring(achiname.IndexOf("("));
    }
}
