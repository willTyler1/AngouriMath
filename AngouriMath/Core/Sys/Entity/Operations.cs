
/* Copyright (c) 2019-2020 Angourisoft
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy,
 * modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software
 * is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
 * LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */



﻿using AngouriMath.Core.Sys.Items.Tensors;
using System.Linq;

namespace AngouriMath.Core
{
    public partial class Tensor : Entity
    {
        /// <summary>
        /// Compares two Tensors
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected override bool EqualsTo(Entity obj)
        {
            if (!(obj is Tensor t))
                return false;
            if (!TensorFunctional.SameShape(this, t))
                return false;
#pragma warning disable CS8604 // Possible null reference argument.
            return innerTensor == t.innerTensor;
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}

namespace AngouriMath
{
    public partial class FunctionEntity
    {
        protected override bool EqualsTo(Entity obj)
        {
            if (!(obj is FunctionEntity))
                return false;
            if (obj.Name != Name)
                return false;
            if (ChildrenCount != obj.ChildrenCount)
                return false;
            for (int i = 0; i < obj.ChildrenCount; i++)
            {
                if (GetChild(i) != obj.GetChild(i))
                    return false;
            }
            return true;
        }
    }

    public partial class OperatorEntity
    {
        protected override bool EqualsTo(Entity obj)
        {
            if (!(obj is OperatorEntity))
                return false;
            if (obj.Name != Name)
                return false;
            if (ChildrenCount != obj.ChildrenCount)
                return false;
            for (int i = 0; i < obj.ChildrenCount; i++)
            {
                if (!(GetChild(i) == obj.GetChild(i)))
                    return false;
            }
            return true;
        }
    }

    public partial class NumberEntity
    {
        protected override bool EqualsTo(Entity obj) => obj is NumberEntity n && Value == n.Value;
    }

    public partial class VariableEntity
    {
        protected override bool EqualsTo(Entity obj) => obj is VariableEntity && Name == obj.Name;
    }
}
