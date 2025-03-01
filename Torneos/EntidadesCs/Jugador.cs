using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Jugador :  Persona
   {
      private ushort numero;
      public Equipo Equipo { get; set; } // asoc equipo (1 jugador 1 equipo)

      public Jugador (string nombre, DateTime fechaNacimiento, ushort numero) : base(nombre, fechaNacimiento)
      {
         Numero = numero;
      }

      public ushort Numero
      {
         get => numero;
         set => numero = (value > 0 && value <= 99) ? value : throw new ArgumentException(" el numero debe ser un valor entre 1 y 99");
      }

      public override string ToString()
      {
         return $"{Nombre} (#{Numero})";
      }
   }
}
