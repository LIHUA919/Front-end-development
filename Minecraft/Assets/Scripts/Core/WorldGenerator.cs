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