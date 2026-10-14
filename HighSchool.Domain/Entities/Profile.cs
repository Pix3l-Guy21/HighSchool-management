using HighSchool.Domain.Common;

namespace HighSchool.Domain.Entities;

public class Profile
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public string Address { get; private set; } = string.Empty;
    public DateOnly DateOfBirth { get; private set; }

    private Profile () {}

    private Profile (Guid id, Guid userId, string firstName, string lastName, string phone, string address, DateOnly dateOfBirth)
    {
        Id = id;
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Address = address;
        DateOfBirth = dateOfBirth;
    }

    public static Result<Profile> Create(Guid id, Guid userId, string firstName, string lastName, string phone, string address, DateOnly? dateOfBirth)
    {
        if (id == Guid.Empty) return new Error("Profile.EmptyId", "Profile Id cannot be empty.", ErrorType.Conflict);
        if (userId == Guid.Empty) return new Error("Profile.EmptyUserId", "Profile user Id cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(firstName)) return new Error("Profile.EmptyFirstName", "Profile first name cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(lastName)) return new Error("Profile.EmptyLastName", "Profile last name cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(phone)) return new Error("Profile.EmptyPhone", "Profile phone number cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(address)) return new Error("Profile.EmptyAddress", "Profile address cannot be empty.", ErrorType.Conflict);
        if (dateOfBirth == null) return new Error("Profile.EmptyDateOfBirth", "Date of birth cannot be empty.", ErrorType.Conflict);
        return new Profile(id, userId, firstName, lastName, phone, address, dateOfBirth.Value);
    }

    public Result Update (Guid userId, string firstName, string lastName, string phone, string address, DateOnly? dateOfBirth)
    {
        if (userId == Guid.Empty) return new Error("Profile.EmptyUserId", "Profile user Id cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(firstName)) return new Error("Profile.EmptyFirstName", "Profile first name cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(lastName)) return new Error("Profile.EmptyLastName", "Profile last name cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(phone)) return new Error("Profile.EmptyPhone", "Profile phone number cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(address)) return new Error("Profile.EmptyAddress", "Profile address cannot be empty.", ErrorType.Conflict);
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Address = address;
        if (dateOfBirth != null) DateOfBirth = dateOfBirth.Value;
        return Result.Success();
    }
}