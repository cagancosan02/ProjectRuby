public interface IGameSettings
{
    /// <summary>
    /// Sets gravity of the game
    /// </summary>
    /// <param name="value">Gravity</param>
    void SetGravity(float value);

    /// <summary>
    /// Gets gravity of the game
    /// </summary>
    /// <returns>Gravity</returns>
    float GetGravity();


    /// <summary>
    /// Gets Player Data
    /// </summary>
    /// <returns>Player Data</returns>
    PlayerData GetPlayerData();


    /// <summary>
    /// Sets Players data
    /// </summary>
    /// <param name="data">Player Data</param>
    void SetPlayerData(PlayerData data);
}