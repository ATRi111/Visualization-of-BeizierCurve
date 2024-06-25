namespace Services
{
    public enum EEvent
    {
        /// <summary>
        /// 加载场景前，参数：即将加载的场景号
        /// </summary>
        BeforeLoadScene,
        /// <summary>
        /// 加载场景后（至少一帧以后），参数：刚加载好的场景号
        /// </summary>
        AfterLoadScene,
        /// <summary>
        /// 显示或隐藏Area
        /// </summary>
        ShowArea,
        /// <summary>
        /// 刷新线段，参数:EdgeData
        /// </summary>
        AfterRefreshEdge,
        /// <summary>
        /// 使线段回到初始状态
        /// </summary>
        ResetEdge,
        /// <summary>
        /// 算法启动
        /// </summary>
        Launch,
        /// <summary>
        /// 算法前进一步
        /// </summary>
        MoveNext,
        /// <summary>
        /// 算法能否继续进行下一步
        /// </summary>
        HasNext,
    }
}