using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeSql;
using Zdmin.Core.Models.DB;

namespace Zdmin.Core.Controllers.Kernel
{
    /// <summary>
    /// 用户管理
    /// </summary>
    [Route("api/kernel/[controller]/[action]")]
    public class UserController : BaseController
    {
        IBaseRepository<UserEntity> _userRepos;
        public UserController(IBaseRepository<UserEntity> userRepos)
        {
            _userRepos = userRepos;
        }

        [HttpGet]
        public async Task<IActionResult> GetGrid(int page, int limit)
        {
            var data = await _userRepos.Select.Count(out var total).Page(page, limit).ToListAsync();
            var gridData = new
            {
                code = 0,
                msg = "",
                count = total,
                data = data
            };
            return Ok(gridData);
        }

        [HttpPost]
        public IActionResult Add(UserEntity user)
        {
            _userRepos.Insert(user);
            return Ok("1");
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserEntity user)
        {
            await _userRepos.UpdateAsync(user);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Get(int id)
        {
            //await _userRepos.Select.
            return Ok();
        }

    }
}
