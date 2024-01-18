using System;

[Serializable]
public class PlayerData
{
    #region AMMO
    public ushort Pistol { get; set; } = 60;
    public ushort Rifle { get; set; } = 0;
    public ushort Shotgun { get; set; } = 0;
    public ushort RPG { get; set; } = 0;
    #endregion

    #region PLAYER
    public float Health { get; set; } = 100f;
    public ushort SelectedWeapon { get; set; } = 9;
    #endregion

    #region SETTINGS
    public float Gravity { get; set; } = -0f;
    #endregion
}