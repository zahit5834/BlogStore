using BlogStore.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x=>x.CategoryName)
                .NotEmpty().WithMessage("Kategori adı boş geçilemez.")
                .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır.")
                .MaximumLength(30).WithMessage("Kategori adı en fazla 30 karakter olmalıdır.");


        }
    }
}
