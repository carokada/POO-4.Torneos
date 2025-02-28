using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Referee : Persona
   {
      public bool Internacional { get; set; } = false; // ok ??

      // new() ?? que lleva el constructor
      //public Referee ()
      //{

      //}

      public Referee (string nombre, DateTime fechaNacimiento, bool internacional) : base(nombre, fechaNacimiento)
      {
         Internacional = internacional;
      }

      public override string ToString()
      {
         if (Internacional)
            return $" {Nombre} (I)";
         else
            return $" {Nombre}";
      }
   }
}
