using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    public GameObject infoPanel;
    public Text infoButtonText;
    [SerializeField] string buttonName;

    // Start is called before the first frame update
    void Start()
    {
        infoPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInfoButtonClick()
    {
        if (infoPanel.activeSelf == true)
        {
            infoPanel.SetActive(false);
            infoButtonText.text = buttonName;
        }
        else
        {
            infoPanel.SetActive(true);
            infoButtonText.text = "close";
        }

    }
}
