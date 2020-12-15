
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tienda_Inventario_SharedKernel.Core;
using Tienda_Inventario_SharedKernel.ValueObjects.PersonName.Rule;


namespace Tienda_Inventario_SharedKernel.ValueObjects.PersonName
{
    public class FacturaNameValue : ValueObject, IComparable<FacturaNameValue>
    {
        public string Value { get; private set; }

        public FacturaNameValue(string value)
        {
            CheckRule(new NotNullRule<string>(value));
            CheckRule(new OnlyLettersRule(value));
            CheckRule(new NameLengtRule(value));

            Value = value;
        }


        #region Conversion

        public static implicit operator string(FacturaNameValue value) => value.Value;

        public static implicit operator FacturaNameValue(string value) => new FacturaNameValue(value);

        #endregion

        public int CompareTo([AllowNull] FacturaNameValue other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
