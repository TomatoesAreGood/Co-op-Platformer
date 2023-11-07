using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntToText : MonoBehaviour
{
    private TextMeshProUGUI _textValue;

    private void Start()
    {
        _textValue = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText(int text)
    {
        _textValue.text = "" + text;
    }
}
