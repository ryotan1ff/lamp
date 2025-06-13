using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Debugger : MonoBehaviour
{
    //InputField inputField;
    public string purpose;
    public Text inputText;
    public Text outputText;
    public GameObject GC;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(purpose == "maxlevel")
        {
            outputText.text = PlayerPrefs.GetInt("MAXLEVEL", -1).ToString();
        }
        if(purpose == "clickcount")
        {
            outputText.text = PlayerPrefs.GetInt("CLICKCOUNT", 0).ToString();
        }
    }

    public void OnEndEdit()
    {
        //GC.GetComponent<GameController>().level = int.Parse(text.text);
        if (purpose == "maxlevel")
        {
            int setLevel = 0;//int.Parse(text.text);
            int.TryParse(inputText.text, out setLevel);
            PlayerPrefs.SetInt("LEVEL", setLevel);
            PlayerPrefs.SetInt("MAXLEVEL", setLevel);
            GC.GetComponent<GameController>().ResetScene();
        }
        if(purpose == "clickcount")
        {
            int setcount = 0;
            int.TryParse(inputText.text, out setcount);
            PlayerPrefs.SetInt("CLICKCOUNT", setcount);
            GC.GetComponent<GameController>().SetAchi();
        }

    }
}
