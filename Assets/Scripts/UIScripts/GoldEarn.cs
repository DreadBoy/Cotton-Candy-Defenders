using UnityEngine;
using System.Collections;

public class GoldEarn : MonoBehaviour {

    public GUISkin skin;

    private bool showing = false;
    private Vector2 position = Vector2.zero;
    private Vector2 goal = Vector2.zero;

    private Texture2D goldTexture = null;

	// Use this for initialization
	void Start () {
        goldTexture = Resources.Load<Texture2D>("GUI skin/gold");
        //StartCoroutine("DelayDestroy");
        StartCoroutine("Move");
        position = transform.position;
        goal = position + (Vector2)(Vector3.down * 50);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.skin = skin;

        GUILayout.BeginArea()

        GUILayout.BeginHorizontal();


        GUILayout.Label("+150", new GUIStyle(skin.label) { fixedHeight = 30, fontSize = 16 });

        GUILayout.Label(goldTexture, GUILayout.Height(30));

        GUILayout.EndHorizontal();
    }

    private IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(2);
        GameObject.Destroy(gameObject);
    }

    private IEnumerator Move()
    {
        float timeSinceStarted = 0f;
        while (true)
        {
            timeSinceStarted += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, goal, timeSinceStarted / 2);

            // If the object has arrived, stop the coroutine
            if (transform.position == goal)
            {
                GameObject.Destroy(gameObject);
                yield break;
            }

            // Otherwise, continue next frame
            yield return null;
        }
    }


}
