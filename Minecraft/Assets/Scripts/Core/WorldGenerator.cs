// Assets/Scripts/Core/WorldGenerator.cs
public class WorldGenerator 
{
    public Block[,,] GenerateChunk(Vector3 chunkPosition, int chunkSize = 16)
    {
        Block[,,] chunk = new Block[chunkSize, chunkSize, chunkSize];
        
        // 使用Perlin噪声生成地形
        for(int x = 0; x < chunkSize; x++)
        {
            for(int z = 0; z < chunkSize; z++)
            {
                // 根据噪声计算高度
                int height = CalculateHeight(x, z);
                
                for(int y = 0; y < height; y++)
                {
                    chunk[x,y,z] = CreateBlockByHeight(y);
                }
            }
        }

        return chunk;
    }

    private int CalculateHeight(int x, int z)
    {
        // 使用Perlin噪声计算地形高度
        return 0; // 占位
    }

    private Block CreateBlockByHeight(int height)
    {
        // 根据高度返回不同方块类型
        return new Block(BlockType.Dirt, Vector3.zero);
    }
}



public class WorldGenerator 
{
    private System.Random random = new System.Random();

    public Block[,,] GenerateChunk(Vector3 chunkPosition, int chunkSize = 16)
    {
        Block[,,] chunk = new Block[chunkSize, chunkSize, chunkSize];
        
        for(int x = 0; x < chunkSize; x++)
        {
            for(int z = 0; z < chunkSize; z++)
            {
                int height = CalculateHeight(x, z);
                
                for(int y = 0; y < height; y++)
                {
                    chunk[x,y,z] = GenerateBlockByHeight(y, height);
                }
            }
        }

        return chunk;
    }

    private int CalculateHeight(int x, int z)
    {
        // 使用Perlin噪声生成高度
        float seed = 0.1f;
        float noise = Mathf.PerlinNoise(x * seed, z * seed);
        return Mathf.FloorToInt(noise * 64);
    }

    private Block GenerateBlockByHeight(int currentHeight, int maxHeight)
    {
        BlockType type;

        if(currentHeight == 0) 
            type = BlockType.Stone;
        else if(currentHeight < maxHeight - 3) 
            type = BlockType.Dirt;
        else if(currentHeight < maxHeight - 1) 
            type = BlockType.Grass;
        else 
            type = BlockType.Air;

        return new Block(type, new Vector3(currentHeight, 0, 0));
    }
}