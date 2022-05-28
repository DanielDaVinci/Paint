using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ColorPointView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Painter painter;
    [SerializeField] private ColorViewPanel colorPanel;

    private Image image;

    public Color PointColor
    {
        get { return image.color; }
        set 
        { 
            image.color = value;
            painter.PointColor = value;
        }
    }

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        colorPanel.gameObject.SetActive(!colorPanel.gameObject.activeSelf);
    }
    
}
