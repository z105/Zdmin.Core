using FreeSql.DataAnnotations;
using System.ComponentModel;

namespace Zdmin.Core.Models.Fsql
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class EntityBase<TKey>
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Description("主键Id")]
        [Column(Position = 1, IsIdentity = true, IsPrimary = true)]
        public virtual TKey Id { get; set; }
    }
}
