using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   // es clase static de utilidad ?
   public static class Torneo
   {
      private static List<Persona> personas = new List<Persona>(); // asoc multiple 1 torneo muchas personas

      // persona se agrega con la creacion de persona ?? 
      public static void AddPersona(Persona persona)
      {
         if (persona == null)
            throw new ArgumentException(" la persona no puede ser nula.");
         if (personas.Contains(persona))
            throw new ArgumentException($" la persona {persona.Nombre} ya esta incluida en el torneo.");
         personas.Add(persona);
      }
   }
}
