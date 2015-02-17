using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CanvasGroup))]
public class WaitThenDisable : MonoBehaviour {

	void Start()
	{
		StartCoroutine(DelayDisable());
	}
	IEnumerator DelayDisable()
	{
		
		//returning 0 will make it wait 1 frame
		yield return 0;

		gameObject.SetActive(false);
		var canvasGroup = GetComponent<CanvasGroup>();
		if(canvasGroup != null)
			canvasGroup.alpha = 1;
		
		
	}
}
