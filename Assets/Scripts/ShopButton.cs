using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopButton : MonoBehaviour
{
    public WeaponSystem weaponSystem;

    public int CostOfItem;
    public int amountToAdd;
    public int weaponPosInWS;
    public TextMeshProUGUI ItemPriceText;

    private void Update()
    {
        ItemPriceText.text = CostOfItem.ToString();
    }

    public void Buy()
    {
        if(GameManager.instance.money >= CostOfItem)
        {
            GameManager.instance.money -= CostOfItem;
            SaveManager.instance.activeSave.currentMoney = GameManager.instance.money;
            weaponSystem.weapons[weaponPosInWS].ammo += amountToAdd;
            GameManager.instance.UpdateMoneyText();
        }
    }
}
