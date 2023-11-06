using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntToText : MonoBehaviour
{
    private TextMeshProUGUI textValue;

    private void Start()
    {
        textValue = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText(int text)
    {
        textValue.text = "" + text;
    }
}
