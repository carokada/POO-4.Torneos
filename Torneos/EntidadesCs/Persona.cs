using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public abstract class Persona
   {
      public ushort Edad { get => CalcularEdad(); } // private set ??
      private DateTime fechaNacimiento;
      private string nombre;

      // metodos simil constructor ?? uno vacio y otro con parametros
      protected Persona()
      {
         Nombre = " ";
         FechaNacimiento = DateTime.MinValue;
      }

      protected Persona(string nombre, DateTime fechaNacimiento)
      {
         Nombre = nombre;
         FechaNacimiento = fechaNacimiento;
      }

      public string Nombre
      {
         get => nombre;
         set => nombre = (value.Length > 0 && value.Length <= 30) ? value : throw new ArgumentException(" el nombre no cumple con los requerimientos del campo.");
      }

      public DateTime FechaNacimiento
      {
         get => fechaNacimiento;
         set // se puede usar calcular edad para validar aca ?
         {
            if (DateTime.Today.AddYears(-16) < value)
               throw new ArgumentException(" la persona debe tener por lo menos 16 anios.");
            fechaNacimiento = value;
         }
      }

      public ushort CalcularEdad()
      {
         int age = DateTime.Now.Year - FechaNacimiento.Year;

         if (FechaNacimiento.Date > DateTime.Today.AddYears(-age))
            age--;

         return (ushort)age;
      }

      public override string ToString()
      {
         return $" {Nombre} ({Edad})";
      }
   }
}
