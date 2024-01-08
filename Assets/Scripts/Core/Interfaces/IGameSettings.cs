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
}