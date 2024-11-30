public class GameConfigManager
{
    // 可序列化的游戏配置
    [Serializable]
    public class GameConfig
    {
        public int RenderDistance = 4;
        public bool EnableCheats = false;
        public float MasterVolume = 1.0f;
        public Difficulty GameDifficulty = Difficulty.Normal;
    }

    public enum Difficulty
    {
        Peaceful,
        Easy,
        Normal,
        Hard
    }

    private GameConfig _currentConfig;

    public void LoadConfig()
    {
        string configPath = Application.persistentDataPath + "/game_config.json";
        
        if (File.Exists(configPath))
        {
            string jsonContent = File.ReadAllText(configPath);
            _currentConfig = JsonUtility.FromJson<GameConfig>(jsonContent);
        }
        else
        {
            // 使用默认配置
            _currentConfig = new GameConfig();
        }
    }

    public void SaveConfig()
    {
        string configPath = Application.persistentDataPath + "/game_config.json";
        string jsonContent = JsonUtility.ToJson(_currentConfig);
        File.WriteAllText(configPath, jsonContent);
    }

    // 动态调整游戏参数
    public void AdjustDifficulty(Difficulty newDifficulty)
    {
        _currentConfig.GameDifficulty = newDifficulty;
        // 根据难度调整游戏机制
        ApplyDifficultySettings();
    }

    private void ApplyDifficultySettings()
    {
        switch (_currentConfig.GameDifficulty)
        {
            case Difficulty.Peaceful:
                // 禁用怪物生成
                // 增加生命恢复
                break;
            case Difficulty.Hard:
                // 增加怪物难度
                // 减少生命恢复
                break;
        }
    }
}