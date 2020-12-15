
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tienda_Inventario_SharedKernel.Core;
using Tienda_Inventario_SharedKernel.ValueObjects.PersonName.Rule;

namespace Tienda_Inventario_SharedKernel.ValueObjects.PersonName
{
    public class PersonNameClienteValue : ValueObject, IComparable<PersonNameClienteValue>
    {
        public string Value { get; private set; }

        public PersonNameClienteValue(string value)
        {
            CheckRule(new NotNullRule<string>(value));
            CheckRule(new OnlyLettersRule(value));
            CheckRule(new NameLengtRule(value));

            Value = value;
        }


        #region Conversion

        public static implicit operator string(PersonNameClienteValue value) => value.Value;

        public static implicit operator PersonNameClienteValue(string value) => new PersonNameClienteValue(value);

        #endregion

        public int CompareTo([AllowNull] PersonNameClienteValue other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
