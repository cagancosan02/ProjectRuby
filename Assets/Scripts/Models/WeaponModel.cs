using UnityEngine;

[System.Serializable]
public class WeaponModel
{
    public GameObject Asset;
    public string Name;
    public string Description;
    public ushort Ammo;
    public float FireRate;
    public bool SingleShot;
}