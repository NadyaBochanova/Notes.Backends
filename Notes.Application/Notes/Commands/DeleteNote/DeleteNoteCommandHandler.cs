using MediatR;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly INotesDbContext _dbContext;

        public DeleteNoteCommandHandler(INotesDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _dbContext.Notes.FindAsync(new[] { request.Id}, cancellationToken);

            if (note == null || note.UserId != request.UserId) 
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            _dbContext.Notes.Remove(note);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
