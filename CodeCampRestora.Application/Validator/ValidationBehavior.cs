using FluentValidation;
using MediatR;

namespace CodeCampRestora.Application.Validator
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var validationResult = await Task.WhenAll(
                _validators.Select(validator => validator.ValidateAsync(request)));  

            var errors = validationResult
                .Where(validationResult => !validationResult.IsValid)             
                .SelectMany(validationResult => validationResult.Errors)
                .Select(validationFailure => new
                {
                    propertyName = validationFailure.PropertyName,
                    errorMessage = validationFailure.ErrorMessage
                })
                .ToList();

            if(errors.Any())
            {
                throw new ValidationException($"{errors[0].propertyName} has an error with message {errors[1].errorMessage}");
            }

            return await next();
        }
    }
}
