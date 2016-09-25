using System.Collections.Generic;

namespace TeamRepository.Interface
{
    public interface ITeamRepository
    {
        IList<Team> GetResultsList();
    }
}
