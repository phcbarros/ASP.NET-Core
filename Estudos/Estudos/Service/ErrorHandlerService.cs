using System;
using System.Collections.Generic;

namespace Estudos.Service
{
    public class ErrorHandlerService
    {
        public List<string> Errors { get; private set; }

        public ErrorHandlerService()
        {
            Errors = new List<String>();
        }

        public void Adicionar(string errorMessage)
        {
            Errors.Add(errorMessage);
        }

        public void Adicionar(IEnumerable<string> errorMessage)
        {
            Errors.AddRange(errorMessage);
        }
    }
}
