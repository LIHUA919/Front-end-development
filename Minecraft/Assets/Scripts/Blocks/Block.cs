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