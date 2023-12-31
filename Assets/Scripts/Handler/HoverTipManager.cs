using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HoverTipManager : MonoBehaviour
{
    public TextMeshProUGUI tipText;
    public RectTransform tipWindow;
    public static Action<string, Vector2> OnMouseHover;
    public static Action OnMousLoseFocus;

    private void OnEnable() {
        OnMouseHover += ShowTip;
        OnMousLoseFocus += HideTip;
    }

    private void OnDisable() {
        OnMouseHover -= ShowTip;
        OnMousLoseFocus -= HideTip;
    }

    void Start()
    {
        HideTip();
    }

    private void ShowTip(string tip, Vector2 mousePos) {
        tipText.text = tip;
        //tipWindow.sizeDelta = new Vector2(tipText.preferredWidth > 200 ? 200 : tipText.preferredWidth, tipText.preferredHeight);

        tipWindow.gameObject.SetActive(true);
        tipWindow.transform.position = new Vector2(mousePos.x, mousePos.y+25);
    }

    private void HideTip() {
        tipText.text = default;
        tipWindow.gameObject.SetActive(false);
    }
}
