using FluentValidation;
using Traversal.CoreLayer.Utilities;
using Traversal.Entity.Concrete;

namespace Traversal.BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        private readonly ValidatorMessages _validatorMessages;

        public AboutValidator(ValidatorMessages validatorMessages)
        {
            _validatorMessages = validatorMessages;
        }

        public AboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithName("Başlık").WithMessage("{PropertyName}" + _validatorMessages.NotEmpty).MinimumLength(5).WithMessage("{PropertyName}" + _validatorMessages.NotSmaller).MaximumLength(50).WithMessage("{PropertyName}" + _validatorMessages.NotBigger);

            RuleFor(x => x.Description).NotEmpty().WithName("Açıklama").WithMessage("{PropertyName}" + _validatorMessages.NotEmpty).MinimumLength(50).WithMessage("{PropertyName}" + _validatorMessages.NotSmaller).MaximumLength(1500).WithMessage("{PropertyName}" + _validatorMessages.NotBigger);

            RuleFor(x => x.Image1).NotEmpty().WithName("Resim").WithMessage("{PropertyName}" + _validatorMessages.LoadImage);

        }
    }
}
