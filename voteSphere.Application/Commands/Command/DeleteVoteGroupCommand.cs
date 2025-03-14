
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MediatR;
using voteSphere.Domain.UseCases;

namespace voteSphere.Application.Commands.Command
{ 

    public class DeleteVoteGroupCommand : IRequest<bool>
    {
       
        public int GroupId { get; set; }
       
    }
}
