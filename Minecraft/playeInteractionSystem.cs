public class PlayerInteraction 
{
    private ChunkManager chunkManager;

    public void DestroyBlock(Vector3 position)
    {
        Block targetBlock = chunkManager.GetBlockAtPosition(position);
        if(targetBlock != null && targetBlock.Type != BlockType.Air)
        {
            // 销毁方块逻辑
            // 可能生成物品掉落
        }
    }

    public void PlaceBlock(Vector3 position, BlockType blockType)
    {
        // 检查是否可以放置方块
        // 创建新的方块
    }
}
