using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class PlayerGoldUI : MonoBehaviour
{
    public Text guiText = null;
    public Text changeText = null;
    private RectTransform rectTransform = null;

    void Start()
    {
        UpdateText();
    }

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public PlayerGoldUI UpdateText()
    {
        if (guiText == null)
            return this;
        guiText.text = PlayerProgress.gold.gold.ToString();
        rectTransform.SetWidth(58 + guiText.text.Length * 22);
        return this;
    }
    public Boolean Earn(Int32 amount)
    {
        if (changeText == null)
            return false;
        changeText.text = "+ " + amount.ToString();
        Animator animator = changeText.GetComponent<Animator>();
        if(animator == null)
            return false;
        animator.SetTrigger("Earn");
        return true;
    }
    public Boolean Spend(Int32 amount)
    {
        if (changeText == null)
            return false;
        changeText.text = "- " + amount.ToString();
        Animator animator = changeText.GetComponent<Animator>();
        if(animator == null)
            return false;
        animator.SetTrigger("Spend");
        return true;
    }
}
