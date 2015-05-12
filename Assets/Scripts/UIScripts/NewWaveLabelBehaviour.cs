using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class NewWaveLabelBehaviour : MonoBehaviour
{
    Text label;
    RectTransform rectTransform;
    void Awake()
    {
        label = GetComponent<Text>();
        rectTransform = GetComponent<RectTransform>();
    }

	/// <summary>
	/// Start animating the label
	/// </summary>
	public void Begin(Int32 wave){
		gameObject.SetActive(true);
		rectTransform.localPosition = Vector3.zero;
		rectTransform.localScale = Vector3.zero;

        label.text = "Wave " + wave;

		StartCoroutine("ScaleIn");
	}

    private IEnumerator ScaleIn()
    {
        float timeSinceStarted = 0f;
        while (true)
        {
            timeSinceStarted += Time.deltaTime;
            if (timeSinceStarted < 1.5f)
                rectTransform.localScale = new Vector3(timeSinceStarted, timeSinceStarted, timeSinceStarted);
            else if (timeSinceStarted < 2)
                rectTransform.localScale = new Vector3(3 - timeSinceStarted, 3 - timeSinceStarted, 3 - timeSinceStarted);
            else if (timeSinceStarted < 3)
                yield return null;
            else if (timeSinceStarted >= 3 && timeSinceStarted < 4)
            {
                rectTransform.localScale = new Vector3(1 - (timeSinceStarted - 3), 1 - (timeSinceStarted - 3), 1 - (timeSinceStarted - 3));
                rectTransform.localPosition = new Vector3(0, (timeSinceStarted - 3) * (Screen.height / 2), 0);
            }
			else if (timeSinceStarted >= 4){
				gameObject.SetActive(false);
                yield break;
			}


            // Otherwise, continue next frame
            yield return null;
        }
    }
}
