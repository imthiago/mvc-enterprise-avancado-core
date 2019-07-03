using System.Collections.Generic;
using DomainValidation.Interfaces.Validation;
using DomainValidation.Validation;

namespace EP.CursoMvc.Domain.Validations
{
    public abstract class Validator<TEntity> : IValidator<TEntity> where TEntity : class
    {
        private readonly Dictionary<string, IRule<TEntity>> _validations = new Dictionary<string, IRule<TEntity>>();

        public virtual ValidationResult Validate(TEntity entity)
        {
            var validationResult = new ValidationResult();
            foreach (var key in _validations.Keys)
            {
                var validation = _validations[key];
                if(!validation.Validate(entity))
                    validationResult.Add(new ValidationError(validation.ErrorMessage));
            }

            return validationResult;
        }

        protected virtual void Add(string name, IRule<TEntity> rule)
        {
            _validations.Add(name, rule);
        }

        protected virtual void Remove(string name)
        {
            _validations.Remove(name);
        }

        protected IRule<TEntity> GetRule(string name)
        {
            _validations.TryGetValue(name, out var rule);
            return rule;
        }
    }
}