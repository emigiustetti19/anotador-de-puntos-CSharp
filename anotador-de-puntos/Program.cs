using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Marcador
{
    Dictionary<string, int> players = new Dictionary<string, int>();
    void Menu()
    {
        string opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("=============================\n" +
                              "|    ANOTADOR DE PUNTOS     |\n" +
                              "=============================\n" +
                              "| 1. Añadir Jugadores       |\n" +
                              "| 2. Eliminar jugadores     |\n" +
                              "| 3. Modificar puntos       |\n" +
                              "| 4. Salir                  |\n" +
                              "=============================\n");
            Console.Write("Seleccione una opción: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AddPlayers();
                    break;
                case "2":
                    if (players.Count == 0)
                    {
                        Console.WriteLine("No hay jugadores para eliminar. Presione Enter para continuar...");
                        Console.ReadLine();
                    }
                    else
                        RemovePlayers();
                    break;
                case "3":
                    if (players.Count == 0)
                    {
                        Console.WriteLine("No hay jugadores para modificar. Presione Enter para continuar...");
                        Console.ReadLine();
                    }
                    else
                        ModifyPoints();
                    break;
                case "4": //Salir();
                    break;
                default:
                    Console.WriteLine("Opción no válida. Presione Enter para continuar...");
                    Console.ReadLine();
                    break;
            }

        } while (opcion != "4");
    }

    void AddPlayers()
    {
        string? nombre;

        do
        {
            Console.Clear();
            Console.WriteLine("Añadir jugadores (\"Enter\" nuevamente para salir)");
            foreach (var players in players)
            {
                Console.WriteLine($"- {players.Key}");
            }
            nombre = Console.ReadLine();
            if (!string.IsNullOrEmpty(nombre))
            {
                while (players.ContainsKey(nombre))
                {
                    Console.WriteLine("El jugador ya existe.");
                    nombre = Console.ReadLine();
                }
                if (!string.IsNullOrEmpty(nombre))
                {
                    players.Add(nombre, 0);
                }
            }

        } while (!string.IsNullOrEmpty(nombre));
    }

    void RemovePlayers()
    {
        string? nombre;

        do
        {
            Console.Clear();
            Console.WriteLine("Eliminar jugadores (\"Enter\" nuevamente para salir)");
            foreach (var players in players)
            {
                Console.WriteLine($"- {players.Key}");
            }
            nombre = Console.ReadLine();
            if (!string.IsNullOrEmpty(nombre))
            {
                if (players.ContainsKey(nombre))
                {
                    players.Remove(nombre);
                }
                else
                {
                    while (!players.ContainsKey(nombre) && !string.IsNullOrEmpty(nombre))
                    {
                        Console.WriteLine("El jugador no existe. Presione Enter para continuar");
                        nombre = Console.ReadLine();
                    }
                    if (players.ContainsKey(nombre))
                    {
                        players.Remove(nombre);
                    }
                }
            }

        } while (!string.IsNullOrEmpty(nombre));
    }

    void ModifyPoints()
    {
        string? entrada;
        int numero;
        int modificacion;

        List<string> playerNames = new List<string>(players.Keys);

        do
        {
            Console.Clear();
            Console.WriteLine("PUNTAJE DE LOS JUGADORES");

            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {playerNames[i]}: {players[playerNames[i]]} puntos");
            }

            Console.Write("Seleccionar numero de jugador (Enter vacío para salir): ");
            entrada = Console.ReadLine();
            while (int.TryParse(entrada, out numero))
            {
                if (numero > 0 && numero <= players.Count)
                    break;
                else if (numero <= 0 || numero > players.Count)
                    Console.WriteLine("Número no válido.");
                entrada = Console.ReadLine();
            }
            if (entrada == "")
                break;
            else
            {
                Console.Clear();
                Console.WriteLine($"Sumar o restar puntos de {playerNames[numero - 1]}: )");
                modificacion = Convert.ToInt32(Console.ReadLine());
                players[playerNames[numero - 1]] += modificacion;
            }
        } while (!string.IsNullOrEmpty(entrada));
    }

    static void Main(string[] args)
    {
        Marcador marcador = new Marcador();
        marcador.Menu();
    }
}