using System.Collections.Generic;
using TeamRepository.Interface;

namespace DapperDemo
{
    public class ResultsModel
    {
        public IList<Team>[] GetResults()
        {
            var respositoryFactory = new RepositoryFactory();
            var singleQueryRepo = respositoryFactory.GetRepository("SingleQuery");
            var singleQueryRepoResults = singleQueryRepo.GetResultsList();

            var multipleQueryRepo = respositoryFactory.GetRepository("MultipleQuery");
            var multipleQueryRepoResults = multipleQueryRepo.GetResultsList();

            IList<Team>[] results = new IList<Team>[2];
            results[0] =  singleQueryRepoResults;
            results[1] = multipleQueryRepoResults;
            return results;
        }
    }
}
