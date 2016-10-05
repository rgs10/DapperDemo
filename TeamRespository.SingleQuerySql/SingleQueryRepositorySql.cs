using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TeamRepository.Interface;

namespace TeamRespository.SingleQuerySql
{
    public class SingleQueryRepositorySql : ITeamRepository
    {
        private readonly  string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        public IList<Team> GetResultsList()
        {
            const string sql = "select t.TeamRef as TeamRef, " +
                          "t.TeamName as TeamName, " +
                          "p.PlayerRef as Players_PlayerRef, " +
                          "p.TeamRef as Players_TeamRef, " +
                          "p.PlayerName as Players_PlayerName " +
                          "from Team t " +
                          "left join Player p on t.TeamRef = p.TeamRef";

            

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                {
                    dynamic test = conn.Query<dynamic>(sql);

                    Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Team), new List<string> { "TeamRef" });

                    var testTeam = (Slapper.AutoMapper.MapDynamic<Team>(test) as IEnumerable<Team>).ToList();

                    return testTeam;
                }
            }
        }
    }
}
