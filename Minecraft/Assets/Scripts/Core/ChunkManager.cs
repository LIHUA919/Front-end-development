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



public class ChunkManager 
{
    private Dictionary<Vector3, Block[,,]> loadedChunks = new Dictionary<Vector3, Block[,,]>();
    private WorldGenerator worldGenerator = new WorldGenerator();
    private const int ChunkSize = 16;

    public void LoadChunk(Vector3 chunkPosition)
    {
        if(!loadedChunks.ContainsKey(chunkPosition))
        {
            Block[,,] chunk = worldGenerator.GenerateChunk(chunkPosition, ChunkSize);
            loadedChunks[chunkPosition] = chunk;
        }
    }

    public Block GetBlockAtPosition(Vector3 worldPosition)
    {
        Vector3 chunkPosition = GetChunkPosition(worldPosition);
        
        if(loadedChunks.TryGetValue(chunkPosition, out Block[,,] chunk))
        {
            Vector3 localPosition = worldPosition - chunkPosition;
            return chunk[(int)localPosition.x, (int)localPosition.y, (int)localPosition.z];
        }

        return null;
    }

    private Vector3 GetChunkPosition(Vector3 worldPosition)
    {
        return new Vector3(
            Mathf.Floor(worldPosition.x / ChunkSize) * ChunkSize,
            Mathf.Floor(worldPosition.y / ChunkSize) * ChunkSize,
            Mathf.Floor(worldPosition.z / ChunkSize) * ChunkSize
        );
    }
}