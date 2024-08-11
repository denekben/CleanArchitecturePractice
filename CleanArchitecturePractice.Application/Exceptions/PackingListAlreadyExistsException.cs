using CleanArchitecturePractice.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecturePractice.Application.Exceptions
{
    public class PackingListAlreadyExistsException : PackItException
    {
        public string Name { get; }
        public PackingListAlreadyExistsException(string name) : base($"Packing list '{name}' already exists.")
        {
            Name = name;
        }
    }
}
