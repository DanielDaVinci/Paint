using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ColorView : MonoBehaviour, IPointerClickHandler
{
    public ColorViewPanel ColorPanel;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ColorPanel.PointColor = image.color;
        ColorPanel.gameObject.SetActive(false);
    }
}
