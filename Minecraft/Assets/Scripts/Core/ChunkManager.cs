// Assets/Scripts/Core/ChunkManager.cs
public class ChunkManager 
{
    private Dictionary<Vector3, Block[,,]> loadedChunks = new Dictionary<Vector3, Block[,,]>();
    private WorldGenerator worldGenerator = new WorldGenerator();

    public void LoadChunk(Vector3 chunkPosition)
    {
        if(!loadedChunks.ContainsKey(chunkPosition))
        {
            Block[,,] chunk = worldGenerator.GenerateChunk(chunkPosition);
            loadedChunks[chunkPosition] = chunk;
        }
    }

    public void UnloadDistantChunks(Vector3 playerPosition)
    {
        // 卸载远离玩家的区块
    }
}