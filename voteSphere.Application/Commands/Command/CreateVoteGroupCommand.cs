
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MediatR;

namespace voteSphere.Application.Commands.Command
{
    public class CreateVoteGroupCommand : IRequest<bool>
    {
       
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public string GroupImageUrl { get; set; } 
    }
}
