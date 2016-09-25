using System;
using System.Collections.Generic;

namespace TeamRepository.Interface
{
    public class Team
    {
        //[Slapper.AutoMapper.Id]
        public Guid TeamRef { get; set; }
        public string TeamName { get; set; }

        public IList<Player> Players { get; set; }
    }
}
