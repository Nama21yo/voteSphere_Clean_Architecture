using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using voteSphere.Application.Commands.Command;
using voteSphere.Domain.UseCases;

namespace voteSphere.Application.Commands.CommandHandlers
{
    public class DeleteVoteGroupCommandHandler : IRequestHandler<DeleteVoteGroupCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteVoteGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteVoteGroupCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Retrieve vote group
                var voteGroup = await _unitOfWork.VoteGroups.GetByIdAsync(request.GroupId);
                if (voteGroup == null)
                {
                    return false; // Vote group not found
                }

                // Delete vote group
                _unitOfWork.VoteGroups.Delete(voteGroup);

                // Commit changes to database
                var result = await _unitOfWork.CompleteAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                // Log the exception (optional: you can replace this with a logging mechanism)
                Console.WriteLine($"Error deleting vote group: {ex.Message}");
                return false;
            }
        }
    }
}
