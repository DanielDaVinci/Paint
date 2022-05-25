using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeFieldController : MonoBehaviour
{
    [SerializeField] private Painter painter;
    [SerializeField] private InputField InputField;

    public void ValueChanged()
    {
        if (InputField.text == "")
            return;

        if (!char.IsDigit(InputField.text[InputField.text.Length - 1]) || InputField.text.Length > 2)
            InputField.text = InputField.text.Remove(InputField.text.Length - 1);

        uint result;
        if (uint.TryParse(InputField.text, out result))
            painter.PointSize = result;
        else
            painter.PointSize = 0;

        InputField.text = painter.PointSize.ToString();
    }
}
