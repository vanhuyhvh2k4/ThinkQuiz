﻿using ErrorOr;
using FluentValidation;
using MediatR;

namespace ThinkQuiz.Application.Common.Behaviors
{
	public class ValidationBehavior<TRequest, TResponse>
		where TRequest : IRequest<TRequest>
		where TResponse : IErrorOr
	{
		private readonly IValidator<TRequest>? _validator;

        public ValidationBehavior(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            // Before the handler
            if (_validator is null)
            {
                return await next();
            }
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            // After the handler
            if (validationResult.IsValid)
            {
                return await next();
            }

            var errors = validationResult.Errors
                .ConvertAll(validationFailure => Error.Validation(
                    validationFailure.PropertyName,
                    validationFailure.ErrorMessage));

            return (dynamic)errors;
        }
    }
}

