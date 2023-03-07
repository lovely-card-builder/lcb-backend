using MediatR;
using Microsoft.EntityFrameworkCore;
using Template.DAL.Models;
using Template.Infrastructure;

namespace Lcb.BLL.MediatR.SetPostcard;

public class SetUserPostcardRequestHandler : IRequestHandler<SetUserPostcardRequest>
{
    private readonly IRepository<Postcard> _repository;

    public SetUserPostcardRequestHandler(IRepository<Postcard> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(SetUserPostcardRequest request, CancellationToken cancellationToken)
    {
        var postcard = await _repository.GetAll().FirstAsync(p => p.Id == request.PostcardId, cancellationToken: cancellationToken);

        if (request.FileName != null)
        {
            postcard.FileName = request.FileName;
        } 
        
        if (request.WishFrom != null)
        {
            postcard.WishFrom = request.WishFrom;
        }
        
        if (request.WishTo != null)
        {
            postcard.WishTo = request.WishTo;
        }
        
        if (request.WishText != null)
        {
            postcard.WishText = request.WishText;
        }
        
        return Unit.Value;
    }
}