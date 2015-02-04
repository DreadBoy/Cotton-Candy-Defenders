using UnityEngine;
using System.Collections;

public class TowerUpgradeDialog : MonoBehaviour
{

    GUISkin skin;
    private Rect windowRect = new Rect(0, 0, 50, 50);
    private bool opened;

    private Texture2D starIcon = null;
    private Texture2D demolishIcon = null;
    private Texture2D crossIcon = null;

    private TowerUpgrade caller;

    void Start()
    {

        starIcon = Resources.Load<Texture2D>("GUI skin/icon_star");
        demolishIcon = Resources.Load<Texture2D>("GUI skin/icon_demolish");
        crossIcon = Resources.Load<Texture2D>("GUI skin/icon_cross");

        skin = Resources.Load<GUISkin>("GUI skin/CCD");
    }

    void OnGUI()
    {
        if (!opened)
            return;
        if (starIcon == null || crossIcon == null)
            return;

        GUI.skin = skin;

        windowRect = GUILayout.Window(0, windowRect, upgradeTowerDialog, "");

    }


    private void upgradeTowerDialog(int windowID)
    {

        GUILayout.BeginHorizontal();
        if (!caller.MaxedOut())
            if (GUILayout.Button(starIcon, GUILayout.Width(50), GUILayout.Height(50)))
            {
                caller.Upgrade();
                this.Close();
            }
        if (GUILayout.Button(demolishIcon, GUILayout.Width(50), GUILayout.Height(50)))
        {
            caller.Demolish();
            this.Close();
        }
        if (GUILayout.Button(crossIcon, GUILayout.Width(50), GUILayout.Height(50)))
        {
            this.Close();
        }
        GUILayout.EndHorizontal();

    }

    public void Open()
    {
        windowRect.x = Input.mousePosition.x;
        windowRect.y = Screen.height - Input.mousePosition.y;
        windowRect.width = 50;
        windowRect.height = 50;
        opened = true;
    }

    public void Close()
    {
        opened = false;
    }

    public void Toggle()
    {
        if (opened)
            Close();
        else
            Open();
    }

    public TowerUpgradeDialog setCaller(TowerUpgrade call)
    {
        caller = call;
        return this;
    }
}
