using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Digipolis.Common.Validation;
using Xunit;

namespace Digipolis.Common.UnitTests.Validation
{
	public class DateTimeComparerSmallerThanTests
	{
		private class TestModel
		{
			[DateTimeCompare(nameof(End), ValueComparison.IsLessThan)]
			public DateTime? Start { get; set; }
			public DateTime? End { get; set; }
		}

		[Fact]
		public void StartDateAfterEndDateNotValid()
		{
			var testModel = new TestModel()
			{
				Start = new DateTime(2015, 9, 30),
				End = new DateTime(2015, 9, 30).AddDays(-1),
			};

			var context = new ValidationContext(testModel, null, null);
			var results = new List<ValidationResult>();
			var isModelStateValid = Validator.TryValidateObject(testModel, context, results, true);
			Assert.False(isModelStateValid);
		}

		[Fact]
		public void StartDateBeforeEndDateValid()
		{
			var testModel = new TestModel()
			{
				Start = new DateTime(2015, 9, 30),
				End = new DateTime(2015, 9, 30).AddDays(1),
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
				Start = new DateTime(2015, 9, 30),
				End = new DateTime(2015, 9, 30),
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