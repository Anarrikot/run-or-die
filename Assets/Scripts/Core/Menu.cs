using System;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{ 
    public Image activeWeapon;

    void Start()
    {
       activeWeapon.sprite = Resources.Load<Sprite>("Image/" + Convert.ToString(PlayerInfo.Instance.ActiveWeapon())); 
    }


}
