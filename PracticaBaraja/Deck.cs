using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryCards
{
	public class Deck
	{
		List<Card> cards;

		public Deck()
		{
			// Crear lista de cartas de 52 posiciones
			cards = new List<Card>(52);

			for (int suit = 0; suit < 4; suit++)
			{
				for (int num = 1; num <= 13; num++)
				{
					cards.Add (new Card(suit, num));
				}
			}
		}

		// Métodos
		// Devuleve un número aleatorio entre 'min' y 'max - 1'.
		private int Rand(int min, int max)
		{
			Random random = new Random();
			return random.Next(min, max);
		}

		// Devuelve el array pasado por pará metro sin los valores NULL.
		// Se redimensiona para ello.
		private Card[] RemoveNull(Card[] cardSet)
		{
			bool continuar=true;
			for(int i = 0; i < cardSet.Length && continuar; i++)
			{
				if (cardSet[i] == null)
				{
					continuar=false;
					Array.Resize (ref cardSet, i);
				}
			}

			return cardSet;
		}

		// Roba la carta de abajo (la elimina del Deck)
		public Card DrawBottom()
		{
			// La carta de abajo se encuentra en la última posición
			int pos = cards.Count - 1;
			Card c;

			// Si la baraja se termina, devolverá NULL
			try
			{
				c = cards[pos];
				cards.RemoveAt(pos);
			}
			catch(ArgumentOutOfRangeException aoore)
			{
				c = null;
			}

			return c;
		}

		// Devuelve un número especificado de cartas de abajo hacia arriba.
		public Card[] DrawBottom(int num)
		{
			bool nil = false;
			Card[] cardSet = new Card[num];

			for (int c = 0; c < num; c++)
			{
				cardSet[c] = DrawBottom();
				if (cardSet[c] == null)
				{
					nil = true;
				}
			}

			if (nil)
				cardSet = RemoveNull(cardSet);

			return cardSet;
		}

		// Roba una carta aleatoria (la elimina del Deck)
		public Card DrawRandom()
		{
			// Número aleatorio entre 'arg1' y 'arg2 - 1'
			int pos = Rand(0, cards.Count);
			Card c;

			// Si la baraja se termina, devolverá NULL
			try
			{
				c = cards[pos];
				cards.RemoveAt(pos);
			}
			catch(ArgumentOutOfRangeException aoore)
			{
				c = null;
			}

			return c;
		}

		// Devuelve un número de cartas especificado de forma aleatoria.
		public Card[] DrawRandom(int num)
		{
			bool nil = false;
			Card[] cardSet = new Card[num];

			for (int c = 0; c < num; c++)
			{
				cardSet[c] = DrawRandom();
				if (cardSet[c] == null)
				{
					nil = true;
				}
			}

			if (nil)
				cardSet = RemoveNull(cardSet);

			return cardSet;
		}

		// Devuelve la carta de arriba (la elimina del Deck)
		public Card Draw()
		{
            Card c;

			// Si la baraja se termina, devolverá NULL
            try
            {
				// La carta de arriba se encuentra en la primera posición.
				c = cards[0];
				cards.RemoveAt(0);
            }
            catch(ArgumentOutOfRangeException aoore)
            {
                c = null;
            }

			return c;
		}

		// Devuelve un número de cartas especificado de arriba a bajo.
		public Card[] Draw(int num)
		{
			bool nil = false;
			Card[] cardSet = new Card[num];

			for (int c = 0; c < num; c++)
			{
				cardSet[c] = Draw();
				if (cardSet[c] == null)
				{
					nil = true;
				}
			}

			if (nil)
				cardSet = RemoveNull(cardSet);

			return cardSet;
		}

		//Fisher-Yates shuffle:Desordena la baraja sin repetir números.
		/* 1.i recorrera de 52 a 0 (n a 0)
			2.genera un número aleatorio entre 0 y el valor tomado por i (inclusive)
			3.mueve a[rand] al final de la lista, intercambiándolo con el último número sin "tachar" a[i])*/
		public void Shuffle()
		{
			Random random = new Random();
			int randNum = 0;
			Card aux;
			for(int i = cards.Count - 1; i > 0; i--)
			{
				randNum = random.Next(0, i);
				aux = cards[randNum];
				cards[randNum] = cards[i];
				cards[i] = aux;
			}
		}
		

		// Muestra tantas cartas como posiciones tenga 'cartas' en horizontal.
		public void PrintCards(Card[] cardSet)
		{
			int rows = cardSet.Length;
			int cols = 9;
			// Array de arrays de string de 'row' filas.
			string[][] array = new string[rows][];

			// Rellenar 'array' con cada elemento de 'cardSet' en forma de 'string[]'.
			for (int row = 0; row < rows; row++)
			{
				array[row] = cardSet[row].GetArrayAsciiCard();
			}

			// Muestra todas las filas de la columna 0, luego la 1, 2, 3...
			for (int col = 0; col < cols; col++)
			{
				for (int row = 0; row < rows; row++)
				{
					Console.Write(array[row][col]);
				}
				Console.WriteLine();
			}
		}
	}
}
