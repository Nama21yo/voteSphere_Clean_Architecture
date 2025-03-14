
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MediatR;
using voteSphere.Domain.UseCases;

namespace voteSphere.Application.Commands.Command
{ 

    public class UpdateVoteGroupCommand : IRequest<bool>
    {
       
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public string? GroupImageUrl { get; set; } // `?` makes the property nullable, meaning it can hold `null` values.

    }
}
