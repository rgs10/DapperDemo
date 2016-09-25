using System;
using TeamRepository.Interface;
using TeamRepository.MultipleQuery.Sql;
using TeamRespository.SingleQuerySql;

namespace DapperDemo
{
    public class RepositoryFactory
    {
        public ITeamRepository GetRepository(string repositoryType)
        {
            ITeamRepository repo;

            switch (repositoryType)
            {
                case "SingleQuery":
                    repo = new SingleQueryRepositorySql();
                    break;
                case "MultipleQuery":
                    repo = new MultipleQueryRepositorySql();
                    break;
                default:
                    throw new ArgumentException("Invalid Repository Type");
            }
            return repo;
        }
    }
}
