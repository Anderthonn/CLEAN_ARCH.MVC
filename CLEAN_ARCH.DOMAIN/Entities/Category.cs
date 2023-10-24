using CLEAN_ARCH.DOMAIN.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLEAN_ARCH.DOMAIN.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        public ICollection<Product> Products { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value!");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name, name is required!");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimun 3 charecters!");

            Name = name;
        }
    }
}