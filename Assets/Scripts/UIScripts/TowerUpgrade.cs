using UnityEngine;
using System.Collections;


[RequireComponent(typeof(TowerStats))]
[RequireComponent(typeof(TowerUpgradeDialog))]
public class TowerUpgrade : MonoBehaviour
{

    TowerStats towerStats = null;

    Rect area;
    GUISkin skin;
    Texture2D starTexture = null;

    TowerUpgradeDialog upgradeTowerDialog = null;

    void Start()
    {
        towerStats = GetComponent<TowerStats>();
        upgradeTowerDialog = GetComponent<TowerUpgradeDialog>();

        Vector3 position = Camera.main.WorldToScreenPoint(towerStats.transform.position + towerStats.shotPosition);
        position.y = Screen.height - position.y;

        area = new Rect(position.x, position.y, towerStats.level * 20, 20);
        area.y -= area.height;
        area.x -= area.width / 2;

        starTexture = Resources.Load<Texture2D>("GUI skin/star_gold");

        skin = Resources.Load<GUISkin>("GUI skin/CCD");
    }

    void OnGUI()
    {
        GUI.skin = skin;
        var noMargin = new GUIStyle(skin.label) { margin = new RectOffset(0, 0, 0, 0) };

        GUILayout.BeginArea(area);
        GUILayout.BeginHorizontal();

        for (int i = 0; i < towerStats.level; i++)
        {
            GUILayout.Label(starTexture, noMargin, GUILayout.Height(20), GUILayout.Width(20));
        }


        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }


    void OnMouseDown()
    {
        if (upgradeTowerDialog != null)
            upgradeTowerDialog.setCaller(this).Toggle();
    }

    public void Upgrade()
    {
        if (towerStats.level < 3)
        {
            towerStats.level++;
            area.width = towerStats.level * 20;
            area.x -= 10;
        }
    }

    public void Demolish()
    {
        Destroy(gameObject);
        towerStats.spot.SetActive(true);
    }

    public bool MaxedOut()
    {
        return towerStats.level >= 3;
    }
}
