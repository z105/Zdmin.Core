using Zdmin.Core.Models.Fsql;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Zdmin.Core.Models.DB
{
    /// <summary>
    /// 用户
    /// </summary>
    [Table(Name = "base_user")]
    public class UserEntity : Entity<long>, ISoftDelete 
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Column(StringLength = 60)]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Column(StringLength = 60)]
        public string Password { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [Column(StringLength = 60)]
        public string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [Column(StringLength = 100)]
        public string Avatar { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column(StringLength = 500)]
        public string Remark { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [Description("")]
        [Column(Position = -8)]
        public bool IsDeleted { get; set; } = false;
       
    }
}
