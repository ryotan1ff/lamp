using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class LightController : MonoBehaviour
{
    public int id_x, id_y;
    public bool isOn = true;
    public GameController GC;
    public GameObject[] neighbors = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        GC = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnLightClick(bool click)
    {
        if (click)
        {
            int clickcount = PlayerPrefs.GetInt("CLICKCOUNT", 0);
            clickcount += 1;
            PlayerPrefs.SetInt("CLICKCOUNT", clickcount);
            //‚à‚µŽÀÑ‰ðœ‚É‚È‚Á‚½‚ç
            int index = Array.BinarySearch(Achievement.achiNumber, clickcount);
            if (index >= 0)
            {
                GC.SetAchi();
                Notification.Send(Achievement.achiName[index + (GameController.levelMaxLimit - GameController.levelMinLimit + 1)]);
            }
        }

        this.isOn = !this.isOn;
        if (this.isOn)
        {
            this.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
        }
        else
        {
            this.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
        }
        foreach (GameObject neighbor in neighbors)
        {
            if (neighbor == null) continue;
            bool neighborIsOn = neighbor.GetComponent<LightController>().isOn;
            neighbor.GetComponent<LightController>().isOn = !neighborIsOn;
            neighborIsOn = !neighborIsOn;
            if (neighborIsOn)
            {
                neighbor.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
            }
            else
            {
                neighbor.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
            }
        }
    }
}
