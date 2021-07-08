using System;
using LibraryCards;

/*
	Aplicación de cliente que haga uso del módulo de librería que baraje la carta 
	y vaya sacando una a una las cartas mostrando qué carta se ha sacado (una cadena en modo 
	texto que lo indique)
*/

public class practica1{

	public static void Main(string[] args){

		Deck baraja1 = new Deck();
		
		baraja1.Shuffle(); //Baraja las cartas

		Card[] houseOfCards = baraja1.Draw(52);
		int vistaCarta;
		int suite;

		for (int i = 0; i < houseOfCards.Length; i++){

			vistaCarta = houseOfCards[i].GetNum();
			suite = houseOfCards[i].GetSuit();
			Console.WriteLine(vistaCarta + ", " +suite);
		}		
		
		
	}
}