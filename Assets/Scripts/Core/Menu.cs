using System;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{ 
    public Image activeWeapon;
    public Button prevButton;

    void Start()
    {
       activeWeapon.sprite = Resources.Load<Sprite>("Image/" + Convert.ToString(PlayerInfo.Instance.ActiveWeapon())); 
    }

    public void onClick(Button button)
    {
        prevButton.GetComponent<Outline>().enabled = false;
        button.GetComponent<Outline>().enabled = true;
        prevButton = button;
        PlayerInfo.Instance.SetActiveWeapon(button.name);
        activeWeapon.sprite = Resources.Load<Sprite>("Image/" + Convert.ToString(PlayerInfo.Instance.ActiveWeapon()));
    }
}
