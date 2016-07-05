using System;
using Xunit;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Digipolis.Common.Validation;

namespace Digipolis.Common.UnitTests.Validation
{
	public class DateTimeComparerDifferentTests
	{
		private class TestModel
		{
			[DateTimeCompare(nameof(End), ValueComparison.IsNotEqual)]
			public DateTime? Start { get; set; }
			public DateTime? End { get; set; }
		}

		[Fact]
		public void StartDateNotEqualsEndDateValid()
		{
			var testModel = new TestModel()
			{
				Start = new DateTime(2015, 9, 30),
				End = new DateTime(2015, 9, 30).AddDays(-1),
			};

			var context = new ValidationContext(testModel, null, null);
			var results = new List<ValidationResult>();
			var isModelStateValid = Validator.TryValidateObject(testModel, context, results, true);
			Assert.True(isModelStateValid);
		}

		[Fact]
		public void StartDateEqualsEndDateNotValid()
		{
			var testModel = new TestModel()
			{
				Start = new DateTime(2015, 9, 30).AddDays(1),
				End = new DateTime(2015, 9, 30).AddDays(1),
			};

			var context = new ValidationContext(testModel, null, null);
			var results = new List<ValidationResult>();
			var isModelStateValid = Validator.TryValidateObject(testModel, context, results, true);
			Assert.False(isModelStateValid);
		}

		[Fact]
		public void EndDateNullValid()
		{
			var testModel = new TestModel()
			{
				Start = new DateTime(2015, 9, 30)
			};

			var context = new ValidationContext(testModel, null, null);
			var results = new List<ValidationResult>();
			var isModelStateValid = Validator.TryValidateObject(testModel, context, results, true);
			Assert.True(isModelStateValid);
		}
	}
}