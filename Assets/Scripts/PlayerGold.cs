using UnityEngine;
using System.Collections;
using System;

public class PlayerGold : MonoBehaviour {

    private PlayerGoldUI goldUI = null;

    void Awake()
    {
        goldUI = (PlayerGoldUI)FindObjectOfType(typeof(PlayerGoldUI));
    }
    public Boolean Earn(Int32 amount)
    {
        if (goldUI == null)
            return false;
        Boolean result = PlayerProgress.gold.Earn(amount);
        if(result)
            return goldUI.UpdateText().Earn(amount);
        return false;
    }
    public Boolean Spend(Int32 amount)
    {
        if (goldUI == null)
            return false;
        Boolean result = PlayerProgress.gold.Spend(amount);
        if (result)
            return goldUI.UpdateText().Spend(amount);
        return false;
    } 
}
