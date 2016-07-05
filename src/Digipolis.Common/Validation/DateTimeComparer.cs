using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Digipolis.Common.Validation
{

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class DateTimeCompareAttribute : PropertyValidationAttribute
    {
        private readonly ValueComparison comparison;
        private readonly ValidationResult failure;
        private readonly ValidationResult success;

        public DateTimeCompareAttribute(string otherProperty, ValueComparison comparison) : base(otherProperty)
        {
            if (!Enum.IsDefined(typeof(ValueComparison), comparison)) throw new ArgumentException("Undefined value.", "comparison");

            this.comparison = comparison;
            this.success = ValidationResult.Success;
            this.failure = new ValidationResult(String.Empty);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime? date = GetDate(value);
                if (date.HasValue) return IsValid(date.Value, validationContext);
            }

            return success;
        }

        private DateTime? GetDate(object value)
        {
            DateTime? date = null;

            if (value is DateTime)
            {
                date = (DateTime)value;
            }
            else if (value is DateTime?)
            {
                date = (DateTime?)value;
            }

            return date;
        }

        private ValidationResult IsValid(DateTime value, ValidationContext validationContext)
        {
            object otherValue = GetValue(validationContext);

            if (otherValue != null)
            {
                DateTime? otherDate = GetDate(otherValue);
                if (otherDate.HasValue) return IsValid(value, otherDate.Value);
            }

            return success;
        }

        private ValidationResult IsValid(DateTime value, DateTime otherValue)
        {
            switch (comparison)
            {
                case ValueComparison.IsEqual:
                    if (value != otherValue) return failure;
                    break;
                case ValueComparison.IsNotEqual:
                    if (value == otherValue) return failure;
                    break;
                case ValueComparison.IsGreaterThan:
                    if (value <= otherValue) return failure;
                    break;
                case ValueComparison.IsGreaterThanOrEqual:
                    if (value < otherValue) return failure;
                    break;
                case ValueComparison.IsLessThan:
                    if (value >= otherValue) return failure;
                    break;
                case ValueComparison.IsLessThanOrEqual:
                    if (value > otherValue) return failure;
                    break;
            }

            return success;
        }
    }

    public enum ValueComparison : int
    {
        IsEqual = 0,
        IsNotEqual = 1,
        IsGreaterThan = 2,
        IsGreaterThanOrEqual = 3,
        IsLessThan = 4,
        IsLessThanOrEqual = 5
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public abstract class PropertyValidationAttribute : ValidationAttribute
    {
        private readonly string propertyName;
        private object value;

        protected PropertyValidationAttribute(string propertyName) : base()
        {
            if (String.IsNullOrWhiteSpace(propertyName)) throw new ArgumentNullException("propertyName");
            this.propertyName = propertyName;
        }

        public override bool RequiresValidationContext => true;
        protected string PropertyName => this.propertyName;

        protected object GetValue(ValidationContext validationContext)
        {
            Type type = validationContext.ObjectType;
            PropertyInfo property = type.GetProperty(PropertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty);

            if (property == null)
                throw new InvalidOperationException($"Type {type.FullName} does not contains public instance property {PropertyName}.");

            value = property.GetValue(validationContext.ObjectInstance);

            return value;
        }
    }
}