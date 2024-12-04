using MemberCalendars.Contracts;
using MemberCalendars.Dtos;
using MemberCalendars.Models;
using Microsoft.AspNetCore.Mvc;

namespace MemberCalendars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMember _memberRepository;

        public MemberController(IMember memberRepository)
        {
            _memberRepository = memberRepository;
        }

        /// <summary>
        /// 查詢所有會員資料
        /// </summary>
        /// <returns>所有會員的資料</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            var members = await _memberRepository.GetAllMembers();
            return Ok(new
            {
                Success = true,
                Message = "成功取得所有會員資料",
                Data = members
            });
        }

        /// <summary>
        /// 查詢指定 ID 的會員資料
        /// </summary>
        /// <param name="id">會員的唯一識別碼</param>
        /// <returns>指定會員的資料</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberById(Guid id)
        {
            var member = await _memberRepository.GetMemberById(id);
            if (member == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "找不到指定的會員資料"
                });
            }

            return Ok(new
            {
                Success = true,
                Message = "成功取得指定會員資料",
                Data = member
            });
        }

        /// <summary>
        /// 新增會員資料
        /// </summary>
        /// <param name="member">新增的會員資料</param>
        /// <returns>新增後的會員資料</returns>
        [HttpPost]
        public async Task<IActionResult> CreateMember(MemberForCreationDto member)
        {
            var createdMember = await _memberRepository.CreateMember(member);
            return CreatedAtAction(nameof(GetMemberById), new { id = createdMember }, new
            {
                Success = true,
                Message = "成功新增會員資料",
                Data = createdMember
            });
        }

        /// <summary>
        /// 更新指定 ID 的會員資料
        /// </summary>
        /// <param name="id">會員的唯一識別碼</param>
        /// <param name="member">更新的會員資料</param>
        /// <returns>更新結果</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(Guid id, MemberForUpdateDto member)
        {
            var existingMember = await _memberRepository.GetMemberById(id);
            if (existingMember == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "找不到指定的會員資料"
                });
            }

            await _memberRepository.UpdateMember(id, member);
            return Ok(new
            {
                Success = true,
                Message = "成功更新會員資料"
            });
        }

        /// <summary>
        /// 刪除指定 ID 的會員資料
        /// </summary>
        /// <param name="id">會員的唯一識別碼</param>
        /// <returns>刪除結果</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(Guid id)
        {
            var existingMember = await _memberRepository.GetMemberById(id);
            if (existingMember == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "找不到指定的會員資料"
                });
            }

            await _memberRepository.DeleteMember(id);
            return Ok(new
            {
                Success = true,
                Message = "成功刪除會員資料"
            });
        }
    }
}
