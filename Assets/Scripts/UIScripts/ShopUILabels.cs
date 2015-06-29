using UnityEngine;
using System.Collections;
using Action = ShopUIButtons.Action;

[RequireComponent(typeof(CanvasGroup))]
public class ShopUILabels : MonoBehaviour
{
    CanvasGroup group;

    public TowerType tower;
    public Action action;

    void Awake()
    {
        group = GetComponent<CanvasGroup>();
    }
    void Start()
    {
        checkVisibility();

    }
    void Update()
    {
        checkVisibility();
    }

    void enable()
    {
        group.alpha = 1;
        group.interactable = true;
    }
    void disable()
    {
        group.alpha = 0;
        group.interactable = false;
    }

    void checkVisibility()
    {
        foreach (var progress in PlayerProgress.towerProgress.progress.Keys)
        {
            if (tower == progress) // in corrrect tab
            {
                if (action == Action.upgrade)
                {
                    if (!PlayerProgress.towerProgress.progress[progress].unlocked)
                        disable();
                    else
                        enable();
                }
                if (action == Action.left)
                {
                    if (!PlayerProgress.towerProgress.progress[progress].upgraded)
                        disable();
                    else
                        enable();
                }
                if (action == Action.right)
                {
                    if (!PlayerProgress.towerProgress.progress[progress].upgraded)
                        disable();
                    else
                        enable();
                }
            }
        }

    }

}
