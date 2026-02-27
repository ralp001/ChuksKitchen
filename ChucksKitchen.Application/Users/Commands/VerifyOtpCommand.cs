using MediatR;
using ChuksKitchen.Application.Common;

namespace ChuksKitchen.Application.Users.Commands;

public record VerifyOtpCommand(Guid UserId, string OtpCode) : IRequest<Result<bool>>;