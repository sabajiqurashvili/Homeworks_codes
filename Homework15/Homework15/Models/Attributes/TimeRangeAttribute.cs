using System.ComponentModel.DataAnnotations;

namespace Homework15.Models.Attributes;

public class TimeRangeAttribute : ValidationAttribute
{
    private readonly TimeSpan start;
    private readonly TimeSpan end;

    public TimeRangeAttribute(string start, string end)
    {
        this.start = TimeSpan.Parse(start);
        this.end = TimeSpan.Parse(end);
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }

        DateTime datetime;
        if (value is DateTime)
        {
            datetime = (DateTime)value;
        }

        else
        {
            return new ValidationResult("wrong time format");
        }

        var time = datetime.TimeOfDay;
        if (time >= start && time <= end)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage);
    }
}