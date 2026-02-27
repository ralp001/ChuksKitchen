using MediatR;
using ChuksKitchen.Application.Common;

namespace ChuksKitchen.Application.Users.Commands;

public record RegisterUserCommand(
    string FullName,
    string Email,
    string PhoneNumber,
    string? ReferralCode) : IRequest<Result<Guid>>;