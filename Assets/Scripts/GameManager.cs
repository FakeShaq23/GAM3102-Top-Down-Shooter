using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject shopMenu;
    public int money;
    public TextMeshProUGUI moneyText;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        money = SaveManager.instance.activeSave.currentMoney;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            Shop();
        }

        UpdateMoneyText();
    }

    public void Shop()
    {
        Time.timeScale = 0;
        shopMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        shopMenu.SetActive(false);
    }

    public void UpdateMoneyText()
    {
        moneyText.text = money.ToString();
    }
}
