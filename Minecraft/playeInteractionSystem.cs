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



public class PlayerInteractionSystem
{
    // 玩家状态
    public class PlayerState
    {
        public Vector3 Position { get; set; }
        public float Health { get; set; }
        public Inventory Inventory { get; set; }
        public float ReachDistance { get; set; } = 5f;
    }

    // 交互类型
    public enum InteractionType
    {
        BreakBlock,
        PlaceBlock,
        PickUpItem
    }

    // 交互事件
    public class InteractionEvent
    {
        public InteractionType Type { get; set; }
        public Vector3 Position { get; set; }
        public BlockType BlockType { get; set; }
        public DateTime Timestamp { get; set; }
    }

    private PlayerState _playerState;
    private ChunkManager _chunkManager;
    private GameLogger _logger;

    public PlayerInteractionSystem(ChunkManager chunkManager)
    {
        _chunkManager = chunkManager;
        _logger = GameLogger.Instance;
        _playerState = new PlayerState();
    }

    // 破坏方块
    public bool TryBreakBlock(Vector3Int position)
    {
        // 检查距离
        if (Vector3.Distance(_playerState.Position, position) > _playerState.ReachDistance)
        {
            _logger.LogInfo($"超出破坏距离: {position}");
            return false;
        }

        Block targetBlock = _chunkManager.GetBlockAtPosition(position);
        
        if (targetBlock == null || !targetBlock.CanBeDestroyed)
        {
            _logger.LogInfo($"无法破坏方块: {position}");
            return false;
        }

        // 记录交互事件
        RecordInteraction(new InteractionEvent 
        { 
            Type = InteractionType.BreakBlock, 
            Position = position,
            BlockType = targetBlock.Type
        });

        // 掉落物品逻辑
        DropBlockItem(targetBlock);

        return true;
    }

    // 放置方块
    public bool TryPlaceBlock(Vector3Int position, BlockType blockType)
    {
        // 检查周围是否有方块
        if (!HasAdjacentBlock(position))
        {
            _logger.LogInfo($"无法放置方块: {position}");
            return false;
        }

        // 放置方块逻辑
        Block newBlock = new Block(blockType, position);
        
        RecordInteraction(new InteractionEvent 
        { 
            Type = InteractionType.PlaceBlock, 
            Position = position,
            BlockType = blockType
        });

        return true;
    }

    // 记录交互事件
    private void RecordInteraction(InteractionEvent interaction)
    {
        // 可以存储到数据库或日志
        _logger.LogInfo($"玩家交互: {interaction.Type} 位置: {interaction.Position}");
    }

    // 掉落物品
    private void DropBlockItem(Block block)
    {
        // 根据方块类型生成物品
        Item droppedItem = ItemFactory.CreateItem(block.Type);
        _playerState.Inventory.AddItem(droppedItem);
    }
}