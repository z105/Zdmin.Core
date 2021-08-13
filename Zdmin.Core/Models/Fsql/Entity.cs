using FreeSql.DataAnnotations;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Zdmin.Core.Models.Fsql
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class Entity<TKey>: EntityBase<TKey>
    {
        /// <summary>
        /// 创建者Id
        /// </summary>
        [Description("创建者Id")]
        [Column(Position = -7, CanUpdate = true)]
        public long? CreatedUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        [Column(Position = -5, CanUpdate = true, ServerTime = DateTimeKind.Local)]
        public DateTime? CreatedTime { get; set; }

        /// <summary>
        /// 修改者Id
        /// </summary>
        [Description("修改者Id")]
        [Column(Position = -4, CanInsert = true)]
        public long? ModifiedUserId { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Description("修改时间")]
        [Column(Position = -1, CanInsert = true, ServerTime = DateTimeKind.Local)]
        public DateTime? ModifiedTime { get; set; }

    }


}
