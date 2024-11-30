// Assets/Scripts/Blocks/Block.cs
public enum BlockType 
{
    Air,
    Grass,
    Dirt,
    Stone,
    Wood,
    Leaves
}

public class Block 
{
    public BlockType Type { get; private set; }
    public Vector3 Position { get; private set; }
    public bool IsBreakable { get; private set; }

    public Block(BlockType type, Vector3 position)
    {
        Type = type;
        Position = position;
        IsBreakable = type != BlockType.Air;
    }
}



// Block.cs
public enum BlockType 
{
    Air,
    Grass,
    Dirt,
    Stone,
    Wood,
    Leaves,
    Sand,
    Water
}

public class Block 
{
    public BlockType Type { get; private set; }
    public Vector3 Position { get; private set; }
    public bool IsTransparent { get; private set; }
    public float Hardness { get; private set; }

    public Block(BlockType type, Vector3 position)
    {
        Type = type;
        Position = position;
        InitBlockProperties(type);
    }

    private void InitBlockProperties(BlockType type)
    {
        switch(type)
        {
            case BlockType.Grass:
                IsTransparent = false;
                Hardness = 0.6f;
                break;
            case BlockType.Wood:
                IsTransparent = false;
                Hardness = 2.0f;
                break;
            // 其他方块类型
        }
    }
}


public enum BlockType 
{
    Air = 0,
    Grass = 1,
    Dirt = 2,
    Stone = 3,
    Wood = 4,
    Leaves = 5,
    Sand = 6,
    Water = 7
}

public class Block 
{
    // 添加更多属性提高扩展性
    public BlockType Type { get; private set; }
    public Vector3Int Position { get; private set; }
    public bool IsTransparent { get; private set; }
    public float Hardness { get; private set; }
    public bool CanBeDestroyed { get; private set; }

    // 构造函数增加更多参数
    public Block(BlockType type, Vector3Int position)
    {
        Type = type;
        Position = position;
        InitBlockProperties(type);
    }

    // 增加错误处理和详细的属性初始化
    private void InitBlockProperties(BlockType type)
    {
        try 
        {
            switch(type)
            {
                case BlockType.Grass:
                    IsTransparent = false;
                    Hardness = 0.6f;
                    CanBeDestroyed = true;
                    break;
                case BlockType.Wood:
                    IsTransparent = false;
                    Hardness = 2.0f;
                    CanBeDestroyed = true;
                    break;
                case BlockType.Air:
                    IsTransparent = true;
                    Hardness = 0f;
                    CanBeDestroyed = false;
                    break;
                default:
                    throw new ArgumentException($"未定义的方块类型: {type}");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"初始化方块属性时发生错误: {ex.Message}");
        }
    }

    // 添加方法增加交互性
    public bool TryDestroy(float toolStrength)
    {
        if (!CanBeDestroyed) return false;
        return toolStrength >= Hardness;
    }
}


// BlockTest.cs
[TestClass]
public class BlockTest 
{
    [TestMethod]
    public void TestBlockCreation()
    {
        // 测试方块创建
        Block grassBlock = new Block(BlockType.Grass, Vector3Int.zero);
        
        Assert.AreEqual(BlockType.Grass, grassBlock.Type);
        Assert.IsFalse(grassBlock.IsTransparent);
        Assert.IsTrue(grassBlock.CanBeDestroyed);
    }

    [TestMethod]
    public void TestBlockDestroy()
    {
        Block stoneBlock = new Block(BlockType.Stone, Vector3Int.zero);
        
        // 测试方块是否可被破坏
        Assert.IsTrue(stoneBlock.TryDestroy(2.5f));
        Assert.IsFalse(stoneBlock.TryDestroy(0.5f));
    }
}


[TestClass]
public class PlayerInteractionSystemTest
{
    private PlayerInteractionSystem _interactionSystem;
    private ChunkManager _chunkManager;

    [TestInitialize]
    public void Setup()
    {
        var settings = new WorldGenerationSettings();
        _chunkManager = new ChunkManager(settings);
        _interactionSystem = new PlayerInteractionSystem(_chunkManager);
    }

    [TestMethod]
    public void TestBreakBlock_ValidBlock()
    {
        Vector3Int blockPos = new Vector3Int(0, 0, 0);
        bool result = _interactionSystem.TryBreakBlock(blockPos);
        
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestPlaceBlock_InvalidPosition()
    {
        Vector3Int blockPos = new Vector3Int(0, 0, 0);
        bool result = _interactionSystem.TryPlaceBlock(blockPos, BlockType.Dirt);
        
        Assert.IsFalse(result);
    }
}