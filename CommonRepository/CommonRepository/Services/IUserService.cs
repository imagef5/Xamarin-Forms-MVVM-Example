using System.Collections.Generic;
using System.Threading.Tasks;
using CommonRepository.Models;

namespace CommonRepository.Services
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
        Task<List<User>> GetUsersAsync();
    }
}
