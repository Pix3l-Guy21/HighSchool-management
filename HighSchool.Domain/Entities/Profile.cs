using HighSchool.Domain.Common;
using HighSchool.Domain.Errors;

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
        if (id == Guid.Empty) return ProfileErrors.EmptyId;
        if (userId == Guid.Empty) return ProfileErrors.EmptyUserId;
        if (string.IsNullOrWhiteSpace(firstName)) return ProfileErrors.EmptyFirstName;
        if (string.IsNullOrWhiteSpace(lastName)) return ProfileErrors.EmptyLastName;
        if (string.IsNullOrWhiteSpace(phone)) return ProfileErrors.EmptyPhone;
        if (string.IsNullOrWhiteSpace(address)) return ProfileErrors.EmptyAddress;
        if (dateOfBirth == null) return ProfileErrors.EmptyDateOfBirth;
        return new Profile(id, userId, firstName, lastName, phone, address, dateOfBirth.Value);
    }

    public Result Update (Guid userId, string firstName, string lastName, string phone, string address, DateOnly? dateOfBirth)
    {
        if (userId == Guid.Empty) return ProfileErrors.EmptyUserId;
        if (string.IsNullOrWhiteSpace(firstName)) return ProfileErrors.EmptyFirstName;
        if (string.IsNullOrWhiteSpace(lastName)) return ProfileErrors.EmptyLastName;
        if (string.IsNullOrWhiteSpace(phone)) return ProfileErrors.EmptyPhone;
        if (string.IsNullOrWhiteSpace(address)) return ProfileErrors.EmptyAddress;
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Address = address;
        if (dateOfBirth != null) DateOfBirth = dateOfBirth.Value;
        return Result.Success();
    }
}