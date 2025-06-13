using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    int timeCount = 0;
    RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = this.gameObject.GetComponent<RectTransform>();
        StartCoroutine("ControlNote");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ControlNote()
    {
        while (true)
        {
            //Debug.Log(timeCount);
            timeCount += 1;
            int width = Screen.width;
            float y;
            if (timeCount <= 3 * 60)
            {
                y = (600f - timeCount * 100f / 180f) * (width / 1920f);
                rect.position = this.gameObject.transform.parent.gameObject.transform.position
                    + new Vector3(0, y, 0);
            }
            else if (timeCount <= 6 * 60)
            {
                //do nothing
            }
            else if (timeCount <= 9 * 60)
            {
                y = (300f + timeCount * 100f / 180f) * (width / 1920f);
                rect.position = this.gameObject.transform.parent.gameObject.transform.position
                    + new Vector3(0, y, 0);
            }
            else if (timeCount > 10 * 60)
            {
                this.gameObject.SetActive(false);
                break;
            }
            yield return null;
        }

        //yield return null;
    }

}

