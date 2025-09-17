
Random RNG = new Random(); // Genera un número entre 1 y 14, siendo 1 una A, y las démas cartas números, excepto las figuras que son 11,12 y 13
bool opcionSalir = false, apostar = false;
int opcion = 0;
int carta; 
int puntosJugador = 0, puntosDealer = 0;
int fichasCasino = 100, apuesta = 0; // Se empieza con unas 100 fichas por defecto
string CartasMano = "";


Console.WriteLine("////////////////////////////");
Console.WriteLine("////                    ////");
Console.WriteLine("////   BIENVENIDO A UN  ////");
Console.WriteLine("//// JUEGO DE BLACKJACK ////");
Console.WriteLine("////                    ////");
Console.WriteLine("////////////////////////////");
Console.WriteLine("-Para empezar presiona un botón-");
Console.ReadKey();

do
{
    do // Primer bucle para preguntar cuantas fichas se desea apostar
    {
        Console.WriteLine($"Tienes un total de {fichasCasino} fichas");
        Console.WriteLine("¿Cuántas fichas deseas apostar?");
        apuesta = int.Parse(Console.ReadLine());
        if (apuesta > fichasCasino)
        {
            Console.WriteLine("No tienes fichas suficientes, intentalo de nuevo."); apostar = false;
        }
        else if (apuesta <= 0)
        {
            Console.WriteLine("Debes apostar una cantidad positiva"); apostar = false;
        }
        else apostar = true;
    } while (!apostar);

            do // Segundo bucle para el juego de Blackjack
            {
                try
                {
                    Console.WriteLine("Ahora estás en contra el dealer, que quieres hacer?");
                    Console.WriteLine("1.Robar\n2.Plantarse");
                    opcion = int.Parse(Console.ReadLine());

                    if (opcion == 1) // Opción para robar una carta
                    {
                        string cartaRobada = "";
                        carta = RNG.Next(1, 14); // Saca una carta random de la pila
                        puntosDealer += carta;   // Suma los puntos al dealer
                        carta = RNG.Next(1, 14); // Saca una carta random de la pila

                        // Dependiendo del tipo de carta se añade a la cadena de la mano
                        if (carta == 1) // Carta A
                        {
                            cartaRobada = "A";
                            if (puntosJugador <= 10) puntosJugador += 11; else puntosJugador += 1;  // Suma los puntos al jugador
                        }
                        else if (carta > 10 && carta < 14) // Cartas figuras
                        {
                            switch (carta)
                            {
                                case 11: cartaRobada = "J"; break;

                                case 12: cartaRobada = "Q"; break;

                                case 13: cartaRobada = "K"; break;
                            }
                            puntosJugador += 10;  // Suma los puntos al jugador
                        }
                        else
                        {
                            puntosJugador += carta;         // Suma los puntos al jugador
                            cartaRobada = carta.ToString(); // Transforma la carta a string
                        }
                        CartasMano += cartaRobada + " ";

                        Console.WriteLine($"\nHas robado un {cartaRobada}\n");
                        Console.WriteLine("//////////////");
                        Console.WriteLine($"Mano actual:{CartasMano}");
                        Console.WriteLine("//////////////");
                    }
                    else if (opcion == 2) // El jugador se planta, se calculan los puntos del dealer y del jugador
                    {
                        Console.WriteLine($"Puntos del jugador: {puntosJugador}.");
                        Console.WriteLine($"Puntos del dealer:  {puntosDealer}.");
                        if (puntosJugador > 21)
                        {
                            Console.WriteLine("Perdiste. Te pasaste de 21 puntos.");
                            fichasCasino -= apuesta;
                        }
                        else if (puntosJugador > puntosDealer)
                        {
                            Console.WriteLine("¡Felicitaciones! Ganaste.\n");
                            fichasCasino += apuesta * 2;
                        }
                        else if (puntosDealer > puntosJugador)
                        {
                            if (puntosDealer > 21)
                            {
                                Console.WriteLine("¡Felicitaciones! Ganaste, el dealer se paso de 21.\n"); fichasCasino += apuesta * 2;
                            }
                            else
                            {
                                Console.WriteLine("Perdiste. El dealer ganó.\n"); fichasCasino -= apuesta;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Empate. La casa gana!\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opción inválida, intentelo de nuevo");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error en el sistema:" + e.Message);
                    Console.WriteLine("Volviendo con el dealer...");
                }

            } while (opcion != 2);  

    Console.WriteLine("Se acabo el juego.");
    Console.WriteLine($"Tienes un total de {fichasCasino} fichas");
    Console.WriteLine("¿Quieres intentarlo de nuevo?.");
    Console.WriteLine("1.Si 2.No");
    opcionSalir = int.Parse(Console.ReadLine()) == 1 ? false : true;
    if (!opcionSalir) // Reinicia en caso de querer intentarlo de nuevo
    {
        puntosJugador = 0; 
        puntosDealer = 0;
        apuesta = 0;
        CartasMano = "";
    }
} while (!opcionSalir);

Console.WriteLine("GRACIAS POR JUGAR");