using HighSchool.Domain.Common;

namespace HighSchool.Domain.Entities;

public class User {
    public Guid Id { get; private set; }
    public string Username { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public string Role {get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public bool IsActive { get; private set; } = true;
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private User () {}

    private User (
        Guid id,
        string username,
        string passwordHash,
        string role,
        string email
    )
    {
        Id = id;
        Username = username;
        PasswordHash = passwordHash;
        Role = role;
        Email = email;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public static Result<User> Create(Guid id, string username, string passwordHash, string role, string email)
    {
        if(id == Guid.Empty) return new Error("User.EmptyId", "User Id cannot be empty.", ErrorType.Conflict);
        if(string.IsNullOrWhiteSpace(username)) return new Error("User.EmptyUsername", "Username cannot be empty.", ErrorType.Conflict);
        if(string.IsNullOrWhiteSpace(passwordHash)) return new Error("User.EmptyPasswordHash", "User password cannot be empty.", ErrorType.Conflict);
        if(string.IsNullOrWhiteSpace(role)) return new Error("User.EmptyRole", "User role cannot be empty.", ErrorType.Conflict);
        if(string.IsNullOrWhiteSpace(email)) return new Error("User.EmptyEmail", "User email cannot be empty.", ErrorType.Conflict);
        return new User(id, username, passwordHash, role, email);
    }

    public Result Update(
        string username,
        string role,
        string email
    )
    {
        if(string.IsNullOrWhiteSpace(username)) return new Error("User.EmptyUsername", "Username cannot be empty.", ErrorType.Conflict);
        if(string.IsNullOrWhiteSpace(role)) return new Error("User.EmptyRole", "User role cannot be empty.", ErrorType.Conflict);
        if(string.IsNullOrWhiteSpace(email)) return new Error("User.EmptyEmail", "User email cannot be empty.", ErrorType.Conflict);
        Username = username;
        Role = role;
        Email = email;
        UpdatedAt = DateTime.Now;
        return Result.Success();
    }

    public Result UpdatePassword(string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(passwordHash))
        {
            return new Error("User.EmptyPasswordHash", "Password hash cannot be empty.", ErrorType.Conflict);
        }
        PasswordHash = passwordHash;
        UpdatedAt = DateTime.Now;
        return Result.Success();
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }
}