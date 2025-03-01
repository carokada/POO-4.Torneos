using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCs;

namespace DemoCs
{
   class Program
   {
      static void Main(string[] args)
      {
         string divisor = "----------------------------------------------------------";

         Console.WriteLine(" creando equipos...");
         Equipo equipo1 = new Equipo("boca");
         Equipo equipo2 = new Equipo("tigre");
         Equipo equipo3 = new Equipo("all boys");
         try
         {
            Equipo equipo4 = new Equipo("club atletico san lorenzo de almagro");
         }
         catch (Exception e)
         {
            Console.WriteLine(" !! error :" + e.Message);
         }
         Console.WriteLine("\n mostrando equipos cargados...");
         Console.WriteLine(equipo1);
         Console.WriteLine(equipo2);
         Console.WriteLine(equipo3);


         Console.WriteLine("\n" + divisor);
         Console.WriteLine(" creando jugadores...");
         Jugador jugador1 = new Jugador("martin gularte", new DateTime(2008, 10, 12), 15);
         Jugador jugador2 = new Jugador("fabricio gomez", new DateTime(2008, 5, 30), 16);
         Jugador jugador3 = new Jugador("alejandro prieto", new DateTime(2008, 7, 22), 17);
         try
         {
            Jugador jugador4 = new Jugador("Carmen Elizabeth Juanita Echo Sky Brava Cortez", new DateTime(2008, 10, 12), 18);
         }
         catch (Exception e)
         {
            Console.WriteLine(" !! error :" + e.Message);
         }
         try
         {
            Jugador jugador5 = new Jugador("juan salguero", new DateTime(2009, 4, 9), 19);
         }
         catch (Exception e)
         {
            Console.WriteLine(" !! error :" + e.Message);
         }
         try
         {
            Persona jugador5 = new Jugador("mario garcia", new DateTime(2006, 9, 15), 134);
         }
         catch (Exception e)
         {
            Console.WriteLine(" !! error :" + e.Message);
         }
         Console.WriteLine("\n mostrando jugadores cargados...");
         Console.WriteLine(jugador1);
         Console.WriteLine(jugador2);
         Console.WriteLine(jugador3);

         Console.WriteLine("\n" + divisor);
         Console.WriteLine(" creando arbitros...");
         Referee arbitro1 = new Referee("juan salguero", new DateTime(1998, 10, 12), true);
         Referee arbitro2 = new Referee("bernardo hidalgo", new DateTime(1999, 8, 31), false);
         Referee arbitro3 = new Referee("roberto bautista", new DateTime(2000, 11, 3), false);
         Console.WriteLine("\n mostrando arbitros cargados...");
         Console.WriteLine(arbitro1);
         Console.WriteLine(arbitro2);
         Console.WriteLine(arbitro3);

         Console.WriteLine("\n" + divisor);
         Console.WriteLine(" creando partidos...");
         Partido partido1 = new Partido(1, equipo1, equipo2, new DateTime(2025, 2, 15));
         Partido partido2 = new Partido(2, equipo2, equipo3, new DateTime(2025, 2, 16), 3, 1, arbitro2);
         Partido partido3 = new Partido(3, equipo3, equipo1, new DateTime(2025, 2, 17));
         Console.WriteLine("\n mostrando partidos cargados...");
         Console.WriteLine(partido1);
         Console.WriteLine(partido2);
         Console.WriteLine(partido3);
         Console.WriteLine("\n cargando goles...");
         partido1.NuevoGolVisitante(10);
         partido1.NuevoGolLocal(15);
         partido1.NuevoGolLocal(25);
         partido3.NuevoGolVisitante(35);
         partido3.NuevoGolVisitante(40);
         Console.WriteLine("\n marcando partido 1 como finalizado...");
         partido1.Finalizado();
         try
         {
            partido1.NuevoGolVisitante(35);
         }
         catch (Exception e)
         {
            Console.WriteLine(" !! error :" + e.Message);
         }
         Console.WriteLine("\n cargando arbitros...");
         try
         {
            partido2.SetArbitro(arbitro1);
         }
         catch (Exception e)
         {
            Console.WriteLine(" !! error :" + e.Message);
         }
         partido3.SetArbitro(arbitro1);
         Console.WriteLine("\n partidos:");
         Console.WriteLine(partido1 + $"\n\t arbitro: {partido1.Arbitro}");
         Console.WriteLine(partido2 + $"\n\t arbitro: {partido2.Arbitro}");
         Console.WriteLine(partido3 + $"\n\t arbitro: {partido3.Arbitro}");
         Console.WriteLine("\n goles:");
         VerGolesLocal(partido1);
         VerGolesVisitante(partido1);
         VerGolesLocal(partido3);
         VerGolesVisitante(partido3);

         Console.WriteLine(divisor);
         Console.WriteLine(" compra/venta de jugadores...");
         equipo1.ComprarJugador(jugador1);
         equipo1.ComprarJugador(jugador2);
         equipo1.ComprarJugador(jugador3);
         try
         {
            equipo1.ComprarJugador(jugador3);
         }
         catch (Exception e)
         {
            Console.WriteLine(" !! error :" + e.Message);
         }
         Console.WriteLine();
         Console.WriteLine(" jugadores comprados: ");
         VerJugadores(equipo1);
         Console.WriteLine(" realizando transacciones con jugadores...");
         equipo1.VenderJugador(jugador2, equipo3);
         equipo1.LiberarJugador(jugador3);
         VerJugadores(equipo1);
         VerJugadores(equipo2);
         VerJugadores(equipo3);

         // torneo ?? como o donde se prueba

         //Console.WriteLine("");
         //Console.WriteLine();
         Console.WriteLine(divisor);
         Console.WriteLine("\n presione una tecla para salir ");
         Console.ReadKey();
      }

      private static void VerGolesVisitante(Partido partido)
      {
         Console.WriteLine($" {partido}: goles visitante:");
         foreach (var gol in partido.GetAllGolesVisitante())
         {
            Console.WriteLine("\t - minuto " + gol);
         }
         Console.WriteLine();
      }

      private static void VerGolesLocal(Partido partido)
      {
         Console.WriteLine($" {partido}: goles local:");
         foreach (var gol in partido.GetAllGolesLocal())
         {
            Console.WriteLine("\t - minuto " + gol);
         }
         Console.WriteLine();
      }

      private static void VerJugadores(Equipo equipo)
      {
         Console.WriteLine($" jugadores en {equipo.Nombre}:");
         foreach (var jugador in equipo.GetAllJugadores())
         {
            Console.WriteLine("\t - " + jugador);
         }
         Console.WriteLine();
      }
   }
}
