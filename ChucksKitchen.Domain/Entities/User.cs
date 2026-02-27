namespace ChuksKitchen.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? ReferralCode { get; set; }
    public bool IsVerified { get; set; }
    public string OtpCode { get; set; } = string.Empty; // For simulation
}