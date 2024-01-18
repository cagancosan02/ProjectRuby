using UnityEngine;

public class GameSettings : IGameSettings
{
    private static GameSettings _instance;

    private PlayerData _playerData;
    private GameSettings()
    {
        _playerData = new();
    }
    public static GameSettings Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new();
            }
            return _instance;
        }
    }

    public void SetGravity(float value)
    {
        _playerData.Gravity = value;
    }

    public float GetGravity()
    {
        return _playerData.Gravity;
    }

    public PlayerData GetPlayerData()
    {
        return _playerData;
    }

    public void SetPlayerData(PlayerData data)
    {
        _playerData = data;
    }
}