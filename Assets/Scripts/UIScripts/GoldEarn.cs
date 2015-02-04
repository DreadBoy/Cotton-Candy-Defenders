using UnityEngine;
using System.Collections;

public class GoldEarn : MonoBehaviour
{

    bool instantiated = false;


    public GUISkin skin;
    private float opacity = 1f;
    Color guiColor;

    private Rect area = new Rect(500, 500, 80, 25);
    private Vector2 position = new Vector2(500, 500);
    private Vector2 goal = Vector2.zero;

    private Texture2D goldTexture = null;

    // Use this for initialization
    void Start()
    {
        goldTexture = Resources.Load<Texture2D>("GUI skin/gold");
    }

    public void Start(Vector3 pos)
    {
        position = Camera.main.WorldToScreenPoint(pos);
        position.y = Screen.height - position.y;
        position.y -= area.height * 1.5f;
        position.x -= area.width / 2;
        goal = position;
        goal.y -= 50;
        area.x = position.x;
        area.y = position.y;
        StartCoroutine("Move");
        instantiated = true;

    }

    void FixedUpdate()
    {
        area.x = position.x;
        area.y = position.y;
    }

    void OnGUI()
    {
        if (!instantiated)
            return;

        GUI.skin = skin;

        GUILayout.BeginArea(area);
        GUILayout.BeginHorizontal();

        guiColor = GUI.color;
        guiColor.a = opacity;
        GUI.color = guiColor;

        GUILayout.Label("+150", new GUIStyle(skin.label) { fixedHeight = 30, fontSize = 16 });
        GUILayout.Label(goldTexture, GUILayout.Height(30));

        GUILayout.EndHorizontal();
        GUILayout.EndArea();
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
            position = Vector2.Lerp(position, goal, timeSinceStarted / 4);
            opacity -= Time.deltaTime;

            // If the object has arrived, stop the coroutine
            if (position == goal)
            {
                GameObject.Destroy(gameObject);
                yield break;
            }

            // Otherwise, continue next frame
            yield return null;
        }
    }


}
