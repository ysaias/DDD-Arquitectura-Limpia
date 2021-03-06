﻿using System;
using System.Collections.Generic;
using System.Text;
using Tienda_Inventario_SharedKernel.Core;

namespace Tienda_Inventario_SharedKernel.ValueObjects.PersonName.Rule
{
    public class NameLengtRule : IBusinessRule
    {
        private readonly string _value;

        public NameLengtRule(string value)
        {
            _value = value;
        }

        public string Message => "El nombre no puede contener mas de 200 caracteres";

        public bool IsBroken() => _value.Length > 200;
    }
}
