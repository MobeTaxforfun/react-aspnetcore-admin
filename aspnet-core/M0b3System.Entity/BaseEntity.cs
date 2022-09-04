using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M0b3System.Entity
{
    public abstract class BaseEntity<T> : IAudit
    {
        [Key]
        [Column("Id")]
        public T Id { get; set; }

        /// <summary>
        /// 創建者
        /// </summary>
        [Description("創建者")]
        [Column("CreatedUser")]
        public long CreatedUser { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        [Description("建立時間")]
        [Column("CreatedTime")]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 最後更新者
        /// </summary>
        [Description("最後更新者")]
        [Column("UpdatedUser")]
        public long UpdatedUser { get; set; }

        /// <summary>
        /// 更新時間
        /// </summary>
        [Description("更新時間")]
        [Column("UpdatedTime")]
        public DateTime UpdatedTime { get; set; }
    }
}