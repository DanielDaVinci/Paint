using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorViewPanel : MonoBehaviour
{
    [SerializeField] private ColorPointView colorView;
    [SerializeField] private GameObject     content;
    [SerializeField] private GameObject     colorViewPrefab;
    [Space(10)]
    [SerializeField] private List<Color>    colors;

    public Color PointColor
    {
        get { return colorView.PointColor; }
        set { colorView.PointColor = value; }
    }

    private void Start()
    {
        CreateColorViews();
    }

    private void CreateColorViews()
    {
        for (int i = 0; i < colors.Count; i++)
        {
            GameObject color = Instantiate(colorViewPrefab, content.transform);
            Image colorViewImage = color.GetComponent<Image>() ?? color.AddComponent<Image>();
            colorViewImage.color = colors[i];

            ColorView colorView = color.GetComponent<ColorView>() ?? color.AddComponent<ColorView>();
            colorView.ColorPanel = this;
        }

    }
}