using FreeSql.DataAnnotations;
using System.ComponentModel;

namespace Zdmin.Core.Models.Fsql
{
    /// <summary>
    /// 软删除
    /// </summary>
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
