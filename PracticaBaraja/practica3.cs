using System;
using LibraryCards;

/*
	III) Aplicación de cliente que simula un pequeño juego entre dos jugadores. 
	Cada jugador sacará diez cartas de la baraja y se irán comparando de una en una en turno rotatorio. 
	Si son del mismo palo se comparan las cartas y se lleva un punto el que tenga la carta más alta 
	(y el primero pasa a ser el otro). Si son de distinto palo gana el punto quien sacó la primera carta 
	El turno se lo queda siempre el que pierde
*/

public class practica3{

	public static void Main(string[] args){

		Deck baraja = new Deck();
		baraja.Shuffle();
		Card[] playerOne = baraja.Draw(10);
		Card[] playerTwo = baraja.Draw(10);

		bool turno = true; // true para playerOne, false para playerTwo
		int poPoints = 0;
		int ptPoints = 0;

		for (int i = 0; i < 10; i++){ // Bucle de la partida

			if (turno){ // Turno de playerOne

				if (playerOne[i].GetSuit() == playerTwo[i].GetSuit()){ // Si son del mismo palo
					Console.WriteLine("Mismo palo. suit one: {0}, suit two: {1}", playerOne[i].GetSuit(), playerTwo[i].GetSuit());

					if (playerOne[i].GetNum() > playerTwo[i].GetNum()){

						poPoints++;
						turno = false;
						Console.WriteLine("P1 tiene la carta más alta.");
					}
					else{

						ptPoints++;
						turno = true;
						Console.WriteLine("P2 tiene la carta más alta.");
					}
				}
				else{ // Si son de distinto palo punto para quien sacó la primera carta
					Console.WriteLine("Distinto palo, punto para P1. suit one: {0}, suit two: {1}", playerOne[i].GetSuit(), playerTwo[i].GetSuit());
					poPoints++;
					turno = false;
				}
			}
			else{ // Turno de playerTwo

				if (playerTwo[i].GetSuit() == playerOne[i].GetSuit()){
					Console.WriteLine("Mismo palo. suit one: {0}, suit two: {1}", playerOne[i].GetSuit(), playerTwo[i].GetSuit());

					if (playerTwo[i].GetNum() > playerOne[i].GetNum()){

						ptPoints++;
						turno = true;
						Console.WriteLine("P2 tiene la carta más alta.");
					}
					else{ 

						poPoints++;
						turno = false;
						Console.WriteLine("P1 tiene la carta más alta.");
					}
				}
				else{ // Si son de distinto palo punto para quien sacó la primera carta
					Console.WriteLine("Distinto palo, punto para P2. suit one: {0}, suit two: {1}", playerOne[i].GetSuit(), playerTwo[i].GetSuit());
					ptPoints++;
					turno = true;
				}
			}
		}

		Console.WriteLine("Puntos de Player One: {0}, puntos de Player Two: {1}",poPoints, ptPoints);	
	}
}