using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo 
{

    public static Weapon bow = new() {name = "bow", damage = 1, attack_speed = 2, damage_area = 0 };
    public static Weapon crossbow = new() {name = "crossbow", damage = 2, attack_speed = 1, damage_area = 0 };
    public static Weapon pistol = new() {name = "pistol", damage = 5, attack_speed = 0.75f, damage_area = 0 };
    public static Weapon machine_gun = new() {name = "machine_gun", damage = 10, attack_speed = 0.3f, damage_area = 0 };
    public static Weapon rocket_launcher = new() {name = "rocket_launcher", damage = 20, attack_speed = 0.75f, damage_area = 5 };

    public static Weapon activeWeapon = bow;

    private static PlayerInfo _instance;
    public static PlayerInfo Instance
        => _instance ??= new PlayerInfo();

    public PlayerInfo()
    {
        _instance = this;
    }

    public void SetActiveWeapon(string name)
    {
        foreach (Weapon weapon in new Weapon[] { bow, crossbow, pistol, machine_gun, rocket_launcher })
        {
            if (weapon.name == name)
            {
                // Присваиваем переменной activeWeapon найденный объект
                activeWeapon = weapon;
                break;
            }
        }
    }

    public string ActiveWeapon()
    {
        return activeWeapon.name;       
    }
}
