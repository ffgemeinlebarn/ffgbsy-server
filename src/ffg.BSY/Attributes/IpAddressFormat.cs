using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ffg.BSY.Attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class IpAddressFormat : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
            return new ValidationResult("Die IP-Adresse darf nicht null sein!");

        if (Regex.IsMatch((string)value, "^((25[0-5]|(2[0-4]|1\\d|[1-9]|)\\d)(\\.(?!$)|$)){4}$"))
            return ValidationResult.Success;

        return new ValidationResult("Die IP-Adresse besitzt ein ungültiges Format!");
    }
}
