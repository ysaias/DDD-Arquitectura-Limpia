using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tienda_Inventario_SharedKernel.Core;
using Tienda_Inventario_SharedKernel.ValueObjects.ValorNumber.Rule;

namespace Tienda_Inventario_SharedKernel.ValueObjects.ValorNumber


{
    public class PrecioNumberValue : ValueObject, IComparable<PrecioNumberValue>
    {
        public string Value { get; private set; }

        public PrecioNumberValue(string value)
        {
            CheckRule(new NotNullRule<string>(value));
            CheckRule(new ValorNumberRule(value));
            Value = value;
        }

        #region Conversion

        public static implicit operator string(PrecioNumberValue value) => value.Value;

        public static implicit operator PrecioNumberValue(string value) => new PrecioNumberValue(value);

        #endregion

        public int CompareTo([AllowNull] PrecioNumberValue other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
