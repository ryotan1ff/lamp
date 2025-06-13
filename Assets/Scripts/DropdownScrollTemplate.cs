using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Dropdownの子供にあるTemplateにアタッチ

public class DropdownScrollTemplate : MonoBehaviour
{
    private ScrollRect sr;

    public void Awake()
    {
        sr = this.gameObject.GetComponent<ScrollRect>();
    }
    // Start is called before the first frame update
    void Start()
    {
        var dropdown = GetComponentInParent<Dropdown>();
        if(dropdown!= null)
        {
            var viewport = this.transform.Find("Viewport").GetComponent<RectTransform>();
            var contentArea = this.transform.Find("Viewport/Content").GetComponent<RectTransform>();
            var contentItem = this.transform.Find("Viewport/Content/Item").GetComponent<RectTransform>();

            // Viewportに対するContentのスクロール位置を求める
            var areaHeight = contentArea.rect.height - viewport.rect.height;
            var cellHeight = contentItem.rect.height;
            var scrollRatio = (cellHeight * dropdown.value) / areaHeight;
            sr.verticalNormalizedPosition = 1.0f - Mathf.Clamp(scrollRatio, 0.0f, 1.0f);
        }
    }
}
