using MediatR;
using ChuksKitchen.Application.Common;
using Microsoft.EntityFrameworkCore;
using ChuksKitchen.Application.Common.Interfaces;

namespace ChuksKitchen.Application.Users.Commands;

public class VerifyOtpHandler : IRequestHandler<VerifyOtpCommand, Result<bool>>
{
    private readonly IApplicationDbContext _context;

    public VerifyOtpHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<bool>> Handle(VerifyOtpCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null)
            return Result<bool>.Failure("User not found.");

        // Edge Case: Validate OTP
        if (user.OtpCode != request.OtpCode)
            return Result<bool>.Failure("Invalid OTP code.");

        // Update Anemic Model state
        user.IsVerified = true;

        await _context.SaveChangesAsync(cancellationToken);

        return Result<bool>.Success(true, "Account verified successfully.");
    }
}