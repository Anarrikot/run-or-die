using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo 
{

    public static Weapon bow = new Weapon() {name = "bow", damage = 1, attack_speed = 2, damage_area = 0 };
    public static Weapon crossbow = new Weapon() {name = "crossbow", damage = 2, attack_speed = 1, damage_area = 0 };
    public static Weapon pistol = new Weapon() {name = "pistol", damage = 5, attack_speed = 0.75f, damage_area = 0 };
    public static Weapon machine_gun = new Weapon() {name = "machine_gun", damage = 10, attack_speed = 0.3f, damage_area = 0 };
    public static Weapon rocket_launcher = new Weapon() {name = "rocket_launcher", damage = 20, attack_speed = 0.75f, damage_area = 5 };

    public static Weapon activeWeapon = bow;

    private static PlayerInfo _instance;
    public static PlayerInfo Instance
        => _instance ??= new PlayerInfo();

    public PlayerInfo()
    {
        _instance = this;
    }

    public string ActiveWeapon()
    {
        return activeWeapon.name;       
    }
}
