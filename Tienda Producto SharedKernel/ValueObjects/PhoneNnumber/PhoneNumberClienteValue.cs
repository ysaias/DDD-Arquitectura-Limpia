using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tienda_Inventario_SharedKernel.Core;
using Tienda_Inventario_SharedKernel.ValueObjects.PhoneNumber.Rule;

namespace Tienda_Inventario_SharedKernel.ValueObjects.PhoneNumber
{
    public class PhoneNumberClienteValue : ValueObject, IComparable<PhoneNumberClienteValue>
    {
        public string Value { get; private set; }

        public PhoneNumberClienteValue(string value)
        {
            CheckRule(new NotNullRule<string>(value));
            CheckRule(new PhoneNumberRule(value));
            Value = value;
        }

        #region Conversion

        public static implicit operator string(PhoneNumberClienteValue value) => value.Value;

        public static implicit operator PhoneNumberClienteValue(string value) => new PhoneNumberClienteValue(value);

        #endregion

        public int CompareTo([AllowNull] PhoneNumberClienteValue other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
