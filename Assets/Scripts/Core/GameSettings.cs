public class GameSettings : IGameSettings
{
    private static GameSettings _instance;

    private GameSettingsModel _gameSettings;
    private GameSettings()
    {
        _gameSettings = new();
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
        _gameSettings.Gravity = value;
    }

    public float GetGravity()
    {
        return _gameSettings.Gravity;
    }
}