using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TeamRepository.Interface;

namespace TeamRepository.MultipleQuery.Sql
{
    public class MultipleQueryRepositorySql : ITeamRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        public IList<Team> GetResultsList()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var grid = conn.QueryMultiple("pGetAll", commandType: CommandType.StoredProcedure);
                var teamList = grid.Read<Team>().ToList();
                var playerList = grid.Read<Player>().ToList();

                teamList = grid.MapChild(
                    teamList,
                    playerList,
                    team => team.TeamRef,
                    player => player.TeamRef,
                    (team, player) => { team.Players = player.ToList(); }
                    ).ToList();

                return teamList;
            }
        }
    }
}
