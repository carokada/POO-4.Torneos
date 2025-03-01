using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Partido
   {
      public byte Jornada { get; set; }
      public DateTime Fecha { get; set; }
      public byte GolesLocal { get; private set; }
      public byte GolesVisitante { get; private set; }
      private List<byte> minutosGolesLocal; // deberia ser readonly
      private List<byte> minutosGolesVisitante; // deberia ser readonly
      public bool FinPartido { get; set; }

      public Equipo EquipoLocal { get; set; } // asoc simple 1 partido 1 equipo local
      public Equipo EquipoVisitante { get; set; } // asoc simple 1 partido 1 equipo visitante
      public Referee Arbitro { get; set; } // asoc simple 1 partido 1 referee

      public Partido (byte jornada, Equipo equipoLocal, Equipo equipoVisitante, DateTime fecha)
      {
         minutosGolesLocal = new List<byte>();
         minutosGolesVisitante = new List<byte>();

         Jornada = jornada;
         EquipoLocal = equipoLocal;
         EquipoVisitante = equipoVisitante;
         Fecha = fecha;
         FinPartido = false;
      }

      public Partido (byte jornada, Equipo equipoLocal, Equipo equipoVisitante, DateTime fecha, byte golesLocal, byte golesVisitante, Referee arbitro) : this(jornada, equipoLocal, equipoVisitante, fecha)
      {
         GolesLocal = golesLocal;
         GolesVisitante = golesVisitante;
         Arbitro = arbitro;

         Finalizado();
      }

      public void NuevoGolLocal(ushort minutos)
      {
         if (FinPartido)
            throw new ArgumentException(" no se pueden agregar goles. el partido se marco como finalizado.");
         minutosGolesLocal.Add((byte)minutos);
         GolesLocal++;
      }

      public void NuevoGolVisitante(ushort minutos)
      {
         if (FinPartido)
            throw new ArgumentException(" no se pueden agregar goles. el partido se marco como finalizado.");
         minutosGolesVisitante.Add((byte)minutos);
         GolesVisitante++;
      }

      public List<byte> GetAllGolesLocal()
      {
         return minutosGolesLocal;
      }

      public List<byte> GetAllGolesVisitante()
      {
         return minutosGolesVisitante;
      }

      public void SetArbitro(Referee arbitro)
      {
         if (FinPartido)
            throw new ArgumentException(" no se puede asignar un arbitro. el partido se marco como finalizado.");
         Arbitro = arbitro;
      }

      public void Finalizado() // no permite mas modificaciones en el obj
      {
         FinPartido = true;
      }

      public override string ToString()
      {
         return $" jornada {Jornada}: {EquipoLocal} ({GolesLocal}) - {EquipoVisitante} ({GolesVisitante})";
      }
   }
}
