using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

	public void LoadLevel(string sceneName){
		Application.LoadLevel (sceneName);
	}
}
