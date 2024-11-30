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