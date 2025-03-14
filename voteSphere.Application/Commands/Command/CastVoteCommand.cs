
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MediatR;
using voteSphere.Domain.UseCases;

namespace voteSphere.Application.Commands.Command
{ 

    public class CastVoteCommand : IRequest<bool>
    {
       
        public int GroupId { get; set; }
        public string UserId { get; set; }

    }
}
