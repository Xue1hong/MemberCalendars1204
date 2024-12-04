using MemberCalendars.Dtos;
using MemberCalendars.Models;

namespace MemberCalendars.Contracts
{
    public interface IMember
    {
        /// <summary>
        /// 查詢所有 Member 資料
        /// </summary>
        /// <returns>所有會員的資料集合</returns>
        Task<IEnumerable<Member>> GetAllMembers();

        /// <summary>
        /// 查詢單一 Member 資料（依指定 id）
        /// </summary>
        /// <param name="id">會員的唯一識別碼</param>
        /// <returns>指定會員的資料</returns>
        Task<Member> GetMemberById(Guid id);

        /// <summary>
        /// 新增 Member 資料
        /// </summary>
        /// <param name="member">新增的會員資料</param>
        /// <returns>新增會員的資料</returns>
        Task<MemberForCreationDto> CreateMember(MemberForCreationDto member);

        /// <summary>
        /// 更新 Member 資料（依指定 id）
        /// </summary>
        /// <param name="id">會員的唯一識別碼</param>
        /// <param name="member">更新的會員資料</param>
        /// <returns>Task</returns>
        Task UpdateMember(Guid id, MemberForUpdateDto member);

        /// <summary>
        /// 刪除 Member 資料（依指定 id）
        /// </summary>
        /// <param name="id">會員的唯一識別碼</param>
        /// <returns>Task</returns>
        Task DeleteMember(Guid id);
    }
}
