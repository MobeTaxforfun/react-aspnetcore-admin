namespace M0b3System.Entity
{
    public interface IAudit
    {
        /// <summary>
        /// 創建者
        /// </summary>
        long? CreatedUser { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        DateTime? CreatedTime { get; set; }

        /// <summary>
        /// 最後更新者
        /// </summary>
        long? UpdatedUser { get; set; }

        /// <summary>
        /// 更新時間
        /// </summary>
        DateTime? UpdatedTime { get; set; }
        
    }
}