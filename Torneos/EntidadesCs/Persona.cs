using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public abstract class Persona
   {
      public ushort Edad { get => CalcularEdad(); }
      private DateTime fechaNacimiento;
      private string nombre;

      public Persona()
      {
         Nombre = " ";
         FechaNacimiento = DateTime.MinValue;
      }

      public Persona(string nombre, DateTime fechaNacimiento)
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
         set
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
