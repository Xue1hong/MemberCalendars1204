using Dapper;
using MemberCalendars.Contracts;
using MemberCalendars.Dtos;
using MemberCalendars.Models;
using MemberCalendars.Utilities;
using System.Data;

namespace MemberCalendars.Repositories
{
    public class MemberRepository : IMember
    {
        private readonly DbContext _dbContext;

        public MemberRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Member>> GetAllMembers()
        {
            const string query = "SELECT * FROM Member";
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QueryAsync<Member>(query);
            }
        }

        public async Task<Member> GetMemberById(Guid id)
        {
            const string query = "SELECT * FROM Member WHERE Mid = @Id";
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Member>(query, new { Id = id });
            }
        }

        public async Task<MemberForCreationDto> CreateMember(MemberForCreationDto member)
        {
            const string query = "INSERT INTO Member (Mname, Mage) OUTPUT INSERTED.* VALUES (@Mname, @Mage)";
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QuerySingleAsync<MemberForCreationDto>(query, member);
            }
        }

        public async Task UpdateMember(Guid id, MemberForUpdateDto member)
        {
            const string query = "UPDATE Member SET Mname = @Mname, Mage = @Mage, Maddress = @Maddress, Mphone = @Mphone WHERE Mid = @Id";
            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { member.Mname, member.Mage, member.Maddress, member.Mphone, Id = id });
            }
        }

        public async Task DeleteMember(Guid id)
        {
            const string query = "DELETE FROM Member WHERE Mid = @Id";
            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
