using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Equipo
   {
      private List<Jugador> jugadores;

      private string nombre;

      public Equipo (string nombre)
      {
         jugadores = new List<Jugador>();

         Nombre = nombre;
      }

      public string Nombre
      {
         get => nombre;
         set => nombre = (value.Length > 0 && value.Length <= 30) ? value : throw new ArgumentException(" el nombre no cumple con los requerimientos del campo");
      }

      public void ComprarJugador(Jugador jugador)
      {
         if (jugador == null)
            throw new ArgumentException(" el jugador no puede ser nulo.");
         if (jugadores.Contains(jugador))
            throw new ArgumentException($" el jugador {jugador.Nombre} ya esta en el equipo.");
         jugador.Equipo = this; // primero se asigna al externo
         jugadores.Add(jugador); // luego se agrega al interno
      }

      public List<Jugador> GetAllJugadores()
      {
         return jugadores;
      }

      public void VenderJugador(Jugador jugador, Equipo equipoDestino)
      {
         if (jugador == null)
            throw new ArgumentException(" el jugador no puede ser nulo.");
         if (!jugadores.Contains(jugador))
            throw new ArgumentException($" el jugador {jugador.Nombre} no esta en el equipo.");
         jugador.Equipo = equipoDestino;
         equipoDestino.ComprarJugador(jugador);
         jugadores.Remove(jugador);
      }

      public void LiberarJugador(Jugador jugador)
      {
         if (jugador == null)
            throw new ArgumentException(" el jugador no puede ser nulo.");
         if (!jugadores.Contains(jugador))
            throw new ArgumentException($" el jugador {jugador.Nombre} no esta en el equipo.");
         jugador.Equipo = null;
         jugadores.Remove(jugador);
      }

      public override string ToString()
      {
         return $"{Nombre}";
      }
   }
}
