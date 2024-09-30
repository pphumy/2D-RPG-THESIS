using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Range,
    Melee
}

[CreateAssetMenu(fileName = "Weapon")]
public class Weapon : ScriptableObject
{
    [Header("Config")]
    public Sprite Icon;
    public WeaponType WeaponType;
    public float damage;

    [Header("Projectile")]
    public Projectile ProjectilePrefab;
    public float RequiredMana;
}
