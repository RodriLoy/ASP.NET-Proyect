using System;
using System.ComponentModel.DataAnnotations;

namespace Dotnet_ASP.NET.Models
{
    public abstract class ObjetoEscuelaBase
    {
        public string Id { get; set; }

        //VIRTUAL SIGNIFIFICA QUE PUEDE SER REESCRITO POR LAS CLASES HIJO
        public virtual string Nombre { get; set; }

        public ObjetoEscuelaBase()
        {
            Id = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Nombre},{Id}";
        }
    }
}