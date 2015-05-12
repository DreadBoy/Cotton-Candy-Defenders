using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class UIDialog : MonoBehaviour {

    public Button closeButton = null;

	void Start () {
        if (closeButton == null)
            throw new System.NullReferenceException("Close button can't be null");

        closeButton.onClick.AddListener(() => Close());
	}

    public void Open(Vector3 mousePosition)
    {

        var rectTransform = GetComponent<RectTransform>();
        Boolean flipHorizontal = false,
            flipVertical = false;

        flipVertical = mousePosition.y - rectTransform.rect.height < 0;
        flipHorizontal = mousePosition.x + rectTransform.rect.width > Screen.width;

        Vector2 position = Vector2.zero;
        position.x = flipHorizontal ? mousePosition.x - rectTransform.rect.width : mousePosition.x;
        position.y = flipVertical ? mousePosition.y - Screen.height + rectTransform.rect.height : mousePosition.y - Screen.height;

        rectTransform.anchoredPosition = position;
        gameObject.GetComponent<CanvasGroup>().alpha = 1;
        gameObject.SetActive(true);
    }

    public void Open()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 1;
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 0;
        gameObject.SetActive(false);
    }
}
