public class GameLogger
{
    private static GameLogger _instance;
    public static GameLogger Instance 
    {
        get 
        {
            if (_instance == null)
                _instance = new GameLogger();
            return _instance;
        }
    }

    private string logFilePath;

    private GameLogger()
    {
        logFilePath = Application.persistentDataPath + "/game_log.txt";
    }

    public void LogInfo(string message)
    {
        WriteLog($"[INFO] {message}");
    }

    public void LogError(string message)
    {
        WriteLog($"[ERROR] {message}");
        // 可以同时触发错误报告机制
    }

    private void WriteLog(string logMessage)
    {
        try 
        {
            File.AppendAllText(logFilePath, 
                $"{DateTime.Now}: {logMessage}\n");
        }
        catch (Exception ex)
        {
            Debug.LogError($"日志写入失败: {ex.Message}");
        }
    }
}




public void LogPlayerInteraction(InteractionEvent interaction)
{
    string logMessage = $"交互类型: {interaction.Type}, " +
                        $"位置: {interaction.Position}, " +
                        $"方块类型: {interaction.BlockType}, " +
                        $"时间: {interaction.Timestamp}";
    
    GameLogger.Instance.LogInfo(logMessage);
}