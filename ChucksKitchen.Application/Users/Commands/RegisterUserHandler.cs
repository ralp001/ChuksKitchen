using ChuksKitchen.Application.Common;
using ChuksKitchen.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ChuksKitchen.Application.Common.Interfaces;

namespace ChuksKitchen.Application.Users.Commands;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Result<Guid>>
{
    private readonly IApplicationDbContext _context;

    public RegisterUserHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        // 1. Edge Case: Check if user exists
        if (await _context.Users.AnyAsync(u => u.Email == request.Email, cancellationToken))
            return Result<Guid>.Failure("Email already registered.");

        // 2. Map to Anemic Domain Entity
        var user = new User
        {
            Id = Guid.NewGuid(),
            FullName = request.FullName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            ReferralCode = request.ReferralCode,
            IsVerified = false,
            OtpCode = "123456" // Simulated OTP for the deliverable
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(user.Id, "Registration successful. Please verify with OTP 123456.");
    }
}