using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVVMBasic.Models;

namespace MVVMBasic.Services
{
    /// <summary>
    /// UserService Interfce
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 사용자 리스트 가져오기(페이지 단위)
        /// </summary>
        /// <returns>사용자 리스트 </returns>
        Task<IList<User>> GetUsersAsync();
    }
}
