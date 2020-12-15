using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tienda_Inventario_SharedKernel.Core;
using Tienda_Inventario_SharedKernel.ValueObjects.ValorNumber.Rule;

namespace Tienda_Inventario_SharedKernel.ValueObjects.ValorNumber
{
    public class CantidadNumberValue : ValueObject, IComparable<CantidadNumberValue>
    {
        public string Value { get; private set; }

        public CantidadNumberValue(string value)
        {
            CheckRule(new NotNullRule<string>(value));
            CheckRule(new ValorNumberRule(value));
            Value = value;
        }

        #region Conversion

        public static implicit operator string(CantidadNumberValue value) => value.Value;

        public static implicit operator CantidadNumberValue(string value) => new CantidadNumberValue(value);

        #endregion

        public int CompareTo([AllowNull] CantidadNumberValue other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
