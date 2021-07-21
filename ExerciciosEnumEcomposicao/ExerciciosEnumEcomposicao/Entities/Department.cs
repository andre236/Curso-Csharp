using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciciosEnumEcomposicao.Entities
{
    class Department
    {
        public string Name { get; private set; }

        public Department()
        {
        }
        public Department(string name)
        {
            Name = name;
        }
    }
}
