using System;
using CustomerSubscription.API.Application.Dtos;
using FluentValidation;

namespace CustomerSubscription.API.Application.Validators {
    public class NewSubscriptionValidator : AbstractValidator<NewSubscriptionDto> {

        public NewSubscriptionValidator() {
            RuleFor(x => x.CustomerId)
                .NotNull()
                .NotEqual(Guid.Empty);

            RuleFor(x => x.Amount)
                .NotEqual(default(double))
                .GreaterThan(100);

            RuleFor(x => x.CardSerialNumber)
                .NotEqual(default(long));
        }
    }
}