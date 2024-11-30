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


public class ChunkManager 
{
    // 线程安全的区块管理
    private ConcurrentDictionary<Vector3Int, Block[,,]> loadedChunks = 
        new ConcurrentDictionary<Vector3Int, Block[,,]>();
    
    private WorldGenerator worldGenerator;
    private const int ChunkSize = 16;

    // 依赖注入世界生成设置
    public ChunkManager(WorldGenerationSettings settings)
    {
        worldGenerator = new WorldGenerator(settings);
    }

    public Block[,,] LoadChunk(Vector3Int chunkPosition)
    {
        return loadedChunks.GetOrAdd(chunkPosition, 
            pos => worldGenerator.GenerateChunk(pos, ChunkSize));
    }

    public Block GetBlockAtPosition(Vector3Int worldPosition)
    {
        Vector3Int chunkPosition = GetChunkPosition(worldPosition);
        
        if(loadedChunks.TryGetValue(chunkPosition, out Block[,,] chunk))
        {
            Vector3Int localPosition = worldPosition - chunkPosition;
            return chunk[localPosition.x, localPosition.y, localPosition.z];
        }

        return new Block(BlockType.Air, worldPosition);
    }

    // 添加区块卸载方法
    public void UnloadDistantChunks(Vector3Int playerPosition, int renderDistance)
    {
        var chunksToRemove = loadedChunks.Keys
            .Where(chunkPos => Vector3Int.Distance(chunkPos, playerPosition) > renderDistance)
            .ToList();

        foreach(var chunkPos in chunksToRemove)
        {
            loadedChunks.TryRemove(chunkPos, out _);
        }
    }

    private Vector3Int GetChunkPosition(Vector3Int worldPosition)
    {
        return new Vector3Int(
            Mathf.FloorToInt(worldPosition.x / (float)ChunkSize) * ChunkSize,
            Mathf.FloorToInt(worldPosition.y / (float)ChunkSize) * ChunkSize,
            Mathf.FloorToInt(worldPosition.z / (float)ChunkSize) * ChunkSize
        );
    }
}