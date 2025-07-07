using BlogStore.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.BusinessLayer.ValidationRules
{
    public class ArticleValidator:AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Makale başlığı boş geçilemez.")
                .MinimumLength(3).WithMessage("Makale başlığı en az 3 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Makale başlığı en fazla 100 karakter olmalıdır.");
        }
    }
}
