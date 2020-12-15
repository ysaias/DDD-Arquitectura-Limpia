using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Tienda_Inventario_SharedKernel.Core;

namespace Tienda_Inventario_SharedKernel.ValueObjects.PersonName.Rule
{
    public class OnlyLettersRule : IBusinessRule
    {
        private readonly string _value;

        public OnlyLettersRule(string value)
        {
            _value = value;
        }

        public string Message => "El nombre no puede contener puede contener números";

        public bool IsBroken()
        {
            return Regex.IsMatch(_value, "\\d");
        }
    }
}