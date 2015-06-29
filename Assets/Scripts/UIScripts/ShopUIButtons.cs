using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(CanvasGroup))]
public class ShopUIButtons : MonoBehaviour
{

    public enum Action
    {
        unlock,
        upgrade,
        left,
        right
    }
    public TowerType tower;
    public Action action;
    public Int32 cost;
    public Button alternateState;

    private Text gold = null;
    private CanvasGroup group;

    void Awake()
    {
        group = GetComponent<CanvasGroup>();
    }
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => doAction());
        var g = GameObject.Find("Gold");
        if (g != null)
        {
            gold = g.GetComponent<Text>();
            gold.text = PlayerProgress.gold.gold.ToString();
        }
        applyProgress();
        checkVisibility();
    }

    void Update()
    {
        checkVisibility();
    }

    void swapState(Button org, Button alt)
    {
        Button inst = Instantiate<Button>(alternateState);
        inst.GetComponent<RectTransform>().SetParent(GetComponent<RectTransform>().parent, false);
        inst.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
        inst.gameObject.SetActive(true);
        org.gameObject.SetActive(false);
    }

    void applyProgress()
    {
        foreach (var progress in PlayerProgress.towerProgress.progress.Keys)
        {
            if(tower == progress) // in corrrect tab
            {
                if (action == Action.unlock)
                {
                    if (PlayerProgress.towerProgress.progress[progress].unlocked)
                        swapState(this.GetComponent<Button>(), alternateState);
                }
                if (action == Action.upgrade)
                {
                    if (PlayerProgress.towerProgress.progress[progress].upgraded)
                        swapState(this.GetComponent<Button>(), alternateState);
                }
                if (action == Action.left)
                {
                    if (PlayerProgress.towerProgress.progress[progress].left)
                        swapState(this.GetComponent<Button>(), alternateState);
                }
                if (action == Action.right)
                {
                    if (PlayerProgress.towerProgress.progress[progress].right)
                        swapState(this.GetComponent<Button>(), alternateState);
                }
            }
        }

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

    public void doAction()
    {
        if (gold == null)
            return;
        switch (action)
        {
            case Action.unlock:
                if ((int)tower >= PlayerProgress.level || cost > PlayerProgress.gold.gold || alternateState == null)
                    break;
                PlayerProgress.towerProgress.progress[tower].unlocked = true;
                PlayerProgress.gold.Spend(cost);
                gold.text = PlayerProgress.gold.gold.ToString();
                swapState(this.GetComponent<Button>(), alternateState);
                break;
            case Action.upgrade:
                if (!PlayerProgress.towerProgress.progress[tower].unlocked || cost > PlayerProgress.gold.gold || alternateState == null)
                    break;
                PlayerProgress.towerProgress.progress[tower].upgraded = true;
                PlayerProgress.gold.Spend(cost);
                gold.text = PlayerProgress.gold.gold.ToString();
                swapState(this.GetComponent<Button>(), alternateState);
                break;
            case Action.left:
                if (!PlayerProgress.towerProgress.progress[tower].upgraded || cost > PlayerProgress.gold.gold || alternateState == null)
                    break;
                PlayerProgress.towerProgress.progress[tower].left = true;
                PlayerProgress.gold.Spend(cost);
                gold.text = PlayerProgress.gold.gold.ToString();
                swapState(this.GetComponent<Button>(), alternateState);
                break;
            case Action.right:
                if (!PlayerProgress.towerProgress.progress[tower].upgraded || cost > PlayerProgress.gold.gold || alternateState == null)
                    break;
                PlayerProgress.towerProgress.progress[tower].right = true;
                PlayerProgress.gold.Spend(cost);
                gold.text = PlayerProgress.gold.gold.ToString();
                swapState(this.GetComponent<Button>(), alternateState);
                break;
        }
    }
}
