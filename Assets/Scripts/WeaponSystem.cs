using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WeaponSystem : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    public Image weaponIconUI;
    public Weapon[] weapons;
    public Weapon equippedWeapon;
    public Animator anim;
    public bool pistolMode;
    public bool mSGunMode;
    public bool rifMode;

    // Start is called before the first frame update
    void Start()
    {
        equippedWeapon = weapons[0];
        UpdateWeaponUI();
    }
    

    // Update is called once per frame
    void Update()
    {
        SwitchWeapons();
    }

    public void EquipGun(int gunToEquip)
    {
        equippedWeapon = weapons[gunToEquip - 1];
        UpdateWeaponUI();
    }

    public void SwitchWeapons()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipGun(1);
            anim.SetBool("RifMode", true);
            rifMode = true;
            anim.SetBool("PistolMode", false);
            pistolMode = false;
            anim.SetBool("MSGunMode", false);
            mSGunMode = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipGun(2);
            anim.SetBool("PistolMode", true);
            pistolMode = true;
            anim.SetBool("RifMode", false);
            rifMode = false;
            anim.SetBool("MSGunMode", false);
            mSGunMode = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipGun(3);
            anim.SetBool("MSGunMode", true);
            mSGunMode = true;
            anim.SetBool("PistolMode", false);
            pistolMode = false;
            anim.SetBool("RifMode", false);
            rifMode = false;
        }
    }

    public void UpdateWeaponUI()
    {
        ammoText.text = equippedWeapon.ammo.ToString();
        weaponIconUI.sprite = equippedWeapon.weaponIcon;
    }
}
