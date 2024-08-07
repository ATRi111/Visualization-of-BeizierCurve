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
        /// 顶点发生变化
        /// </summary>
        AfterDraggableVertexChange,
        /// <summary>
        /// 演示开始
        /// </summary>
        AfterLaunch,
        /// <summary>
        /// 演示停止
        /// </summary>
        AfterReset,
    }
}