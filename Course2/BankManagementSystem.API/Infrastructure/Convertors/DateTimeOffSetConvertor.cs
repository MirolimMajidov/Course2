using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankManagementSystem.API.Infrastructure.Convertors;

public class DateTimeOffSetConvertor : ValueConverter<DateTimeOffset, DateTimeOffset>
{
    public DateTimeOffSetConvertor()
        : base(
            v => v.ToUniversalTime(),
            v => v.ToLocalTime())
    {
    }
}