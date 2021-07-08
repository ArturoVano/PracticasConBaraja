using System;
using LibraryCards;


// Black jack: las cartas J, Q y K valen 10, las cartas númericas valen su valor, menos el A que vale 1

public class paractica4{

	public static void Main(string[] args){

		Deck baraja = new Deck();
		baraja.Shuffle();
		Card[] crupier = baraja.Draw(2);
		Card[] jugador = baraja.Draw(2);

		int pPuntos = 0;
		int cPuntos = 0;
		int cPPublico = 0;

		Console.WriteLine("\n### Bienvenido a Blackjack ###");
		bool game = true;
		
		
		string[] j1 = jugador[0].GetArrayAsciiCard();
		string[] j2 = jugador[1].GetArrayAsciiCard();
				
		Console.WriteLine("Cartas del crupier:\n{0}", crupier[0].GetAsciiCard());
		Console.WriteLine("┌───────────┐\n"
				  		 +"│ ######### │\n"
				  		 +"│ ######### │\n"
				  		 +"│ ######### │\n"
						 +"│ ######### │\n"
				 		 +"│ ######### │\n"
				 		 +"│ ######### │\n"
				 		 +"│ ######### │\n"
				 		 +"└───────────┘");

		Console.WriteLine("Tus cartas: ");
		for (int x = 0; x < 9; x++){
				
			Console.WriteLine(j1[x] + " " + j2[x]);
		}

		for (int i = 0; i < 2; i++){
				
				if (jugador[i].GetNum() > 9) //Si es un símbolo, vale 10
					pPuntos += 10;				
				else
					pPuntos += jugador[i].GetNum();

				if (crupier[i].GetNum() > 9){ //Si es un símbolo, vale 10
					cPuntos += 10;	
					cPPublico = 10;		
				}	
				else{
					cPPublico = crupier[i].GetNum();
					cPuntos += crupier[i].GetNum();
				}
			}
			
		while (game){					
			try{
				Console.WriteLine("Jugador: {0}, Crupier: {1}", pPuntos, cPPublico);
				Console.WriteLine("1. Plantarse / 2. Robar");
				int accion = int.Parse(Console.ReadLine());

				while ((accion == 1 || accion == 2) && game){			//Si se introduce cualquier otro número, se vuelve a intentar.

					if (accion == 1){

						string[] c1 = crupier[0].GetArrayAsciiCard();
						string[] c2 = crupier[1].GetArrayAsciiCard();
						Console.WriteLine("Desvela crupier:");
						for (int x = 0; x < 9; x++){        // Muestra las cartas del crupier expuestas.
					
							Console.WriteLine(c1[x] + " " + c2[x]);
						}
						Console.WriteLine("Crupier: {0}",cPuntos);
						while (cPuntos < 17){  				// Si el crupier tiene menos de 17, deberá pedir hasta alcanzalo.

							int i = crupier.Length;
							Array.Resize(ref crupier, crupier.Length + 1);
							crupier[i] = baraja.Draw();
							cPuntos += crupier[i].GetNum();
							
							Console.WriteLine("Carta robada del crupier:\n" + crupier[i].GetAsciiCard());						
							Console.WriteLine("Crupier: {0}",cPuntos);
						}
						if (cPuntos > 21){ 					// Si ha superado 21, ganará el jugador.
							Console.WriteLine("GANA EL JUGADOR!!!");
							game = false;
						}
						else if (cPuntos < pPuntos){ 		// Ninguno supera el 21, y el jugador se le acerca más.
							Console.WriteLine("GANA EL JUGADOR!");
							game = false;
						}
						else if (cPuntos > pPuntos){ 		// Ninguno supera el 21, y la banca se le acerca más.
							Console.WriteLine("GANA LA BANCA");
							game = false;
						}
						else if (cPuntos == pPuntos){
							Console.WriteLine("Empate");
							game = false;
						}

					}
					else if (accion == 2){

						Array.Resize(ref jugador, jugador.Length + 1);
						jugador[jugador.Length - 1] = baraja.Draw();
						pPuntos += jugador[jugador.Length-1].GetNum();
						
						Console.WriteLine("Carta robada del jugador:\n{0}", jugador[jugador.Length-1].GetAsciiCard());										
						Console.WriteLine("Jugador: {0}\n", pPuntos);
						
						if (pPuntos > 21){ // El jugador se ha pasado de 21

							Console.WriteLine("GANA LA BANCA");
							game = false;		
						}
						else{

							Console.WriteLine("1. Plantarse / 2. Robar");
							accion = int.Parse(Console.ReadLine());	
						}
							
					}
					else{
						Console.WriteLine("Valor no válido.");
					}
				}
			}
			catch(Exception ex){
				Console.WriteLine("Valor no válido " + ex.Message);
			}
		}	
	}	
}