using System;

namespace LibraryCards
{

	public class Card
	{
		enum ESuits
		{
			Diamonds,
			Hearts,
			Spades,
			Clubs
		}

		enum ENums
		{
			A = 1,
			Two,
			Three,
			Four,
			Five,
			Six,
			Seven,
			Eight,
			Nine,
			Ten,
			J,
			Q,
			K,
		}

		private ESuits suit;
		private ENums num;

		// Constructor por defecto
		public Card()
		{
			suit = (ESuits) 0;
			num = (ENums) 1;
		}
		// Constructor definido
		public Card(int suit, int num)
		{
			this.suit = (ESuits) suit;
			this.num = (ENums) num;
		}

		// GETTERS
		public int GetSuit()
		{
			return (int)suit;
		}

		public int GetNum()
		{
			return (int) num;
		}

		// Métodos
		private string GetSymbol()
		{
			string symbol = "";

			switch (suit)
			{
				case ESuits.Diamonds:
					symbol = "♦";
					break;

				case ESuits.Hearts:
					symbol = "♥";
					break;

				case ESuits.Spades:
					symbol = "♠";
					break;

				case ESuits.Clubs:
					symbol = "♣";
					break;
			}

			return symbol;
		}

		// Formatea el caracter del ENums
		private string GetCharacter()
		{
			int number = (int) num;
			string character = "";


			// Si el número es >=2 y <=10, lo muestra como número.
			if (number >= 2 && number <= 10)
			{
				character = number.ToString();
			}
			// De lo contrario lo muestra como está en el enum.
			else
			{
				character = num.ToString();
			}

			return character;
		}

		// Devuelve la carta "Ascii".
		public string GetAsciiCard()
		{
			string symbol = GetSymbol();
			string charac = GetCharacter();

			return String.Format ("┌───────────┐\n"
				  				 +"│{0,2}         │\n"
				  				 +"│           │\n"
				  				 +"│           │\n"
							     +"│    {1,2}     │\n"
				 				 +"│           │\n"
				 				 +"│           │\n"
				 				 +"│         {2,-2}│\n"
				 				 +"└───────────┘", charac, symbol, charac);
		}

		// Devuelve un array de strings para poder dibujar cartas en horizontal usado adecuadamente.
        public string[] GetArrayAsciiCard()
		{
			string symbol = GetSymbol();
			string charac = GetCharacter();
			string[] lineasCarta = new string[9];

			lineasCarta[0] = "┌───────────┐";
			lineasCarta[1] = String.Format("│{0,2}         │", charac);
			lineasCarta[2] = "│           │";
			lineasCarta[3] = "│           │";
			lineasCarta[4] = String.Format("│    {0,2}     │",symbol);
			lineasCarta[5] = "│           │";
			lineasCarta[6] = "│           │";
			lineasCarta[7] = String.Format("│         {0,-2}│", charac);
			lineasCarta[8] = "└───────────┘";

			return lineasCarta;
		}
	}
}
