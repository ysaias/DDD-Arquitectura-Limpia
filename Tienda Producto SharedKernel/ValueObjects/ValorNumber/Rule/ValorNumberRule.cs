using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Tienda_Inventario_SharedKernel.Core;

namespace Tienda_Inventario_SharedKernel.ValueObjects.ValorNumber.Rule
{
    public class ValorNumberRule : IBusinessRule
    {
        private readonly string _value;

        public ValorNumberRule(string value)
        {
            _value = value;
        }

        public string Message => "El formato del número de pecio es incorrecto";

        public bool IsBroken()
        {
            return !Regex.IsMatch(_value, "^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$");
        }
    }
}
