using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ShopUICurrentLevel : MonoBehaviour {

	
	void Awake() {
        GetComponent<Text>().text = PlayerProgress.level.ToString();
	}
}
