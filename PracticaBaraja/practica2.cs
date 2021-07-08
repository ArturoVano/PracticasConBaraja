using System;
using LibraryCards;

/*
	II) Aplicación de cliente que obtiene cinco cartas de una baraja previamente barajada. 
	Si tres cartas son del mismo palo debe indicarlo en pantalla. Si no son del mismo palo, 
	mostrar un mensaje indicando que vuelvo a intentarlo hasta que lo consiga.
*/

public class practica2{

	public static void Main(string[] args){

		Deck baraja1 = new Deck();
		bool triple = false;

		baraja1.Shuffle(); //Baraja las cartas
		Card[] houseOfCards = baraja1.Draw(5);// Coge 5 cartas de arriba.
		int[] suits = null;

		while (!triple && houseOfCards[0] != null) {
					
			suits = new int[houseOfCards.Length];
			int suit = 0;
			string suitStr = null;

			for(int i = 0; i < houseOfCards.Length; i++){ // Llena un array solo con los palos de las cartas.

				suits[i] = houseOfCards[i].GetSuit();
				}

				foreach (int symbol in suits) {
					int count = 0;
					foreach (int sweep in suits) {// Compara cada símbolo con cada símbolo, el mismo inclusive.

						if (symbol == sweep) 
							count++; // Siempre sumara mínimo una vez.
					}

					if (count >= 3) { // Si tres cartas son del mismo palo.
						triple = true;
						suit = symbol;
						suitStr = GetSymbol(suit);

					}												
				}

			if (!triple) 
				Console.WriteLine("No hay tres carcas con el mismo palo, se volverá a intentar");
			else
				Console.WriteLine("El palo '{0}' se ha repetido tres veces", suitStr);
			
			for (int i = 0; i < 5; i++){
				houseOfCards[i]  = baraja1.Draw();
			}		
		}
		
	}

	private static string GetSymbol(int suit) {

		string symbol = "";

		switch (suit) {

			case 0:
				symbol = "♦";
				break;

			case 1:
				symbol = "♥";
				break;

			case 2:
				symbol = "♠";
				break;

			case 3:
				symbol = "♣";
				break;
		}

		return symbol;
	}
}