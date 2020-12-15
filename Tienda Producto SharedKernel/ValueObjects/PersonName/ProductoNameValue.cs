
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tienda_Inventario_SharedKernel.Core;
using Tienda_Inventario_SharedKernel.ValueObjects.PersonName.Rule;

namespace Tienda_Inventario_SharedKernel.ValueObjects.PersonName
{
    public class ProductoNameValue : ValueObject, IComparable<ProductoNameValue>
    {
        public string Value { get; private set; }

        public ProductoNameValue(string value)
        {
            CheckRule(new NotNullRule<string>(value));
            CheckRule(new OnlyLettersRule(value));
            CheckRule(new NameLengtRule(value));

            Value = value;
        }


        #region Conversion

        public static implicit operator string(ProductoNameValue value) => value.Value;

        public static implicit operator ProductoNameValue(string value) => new ProductoNameValue(value);

        #endregion

        public int CompareTo([AllowNull] ProductoNameValue other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
