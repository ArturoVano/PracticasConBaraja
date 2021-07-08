# PracticasConBaraja

módulo de librería en C# que contiene dos clases:		

→ Card (carta) : Representa un juego de cartas estándar. Con 4 palos : Picas, Corazones, Tréboles y Diamantes y un valor desde el as hasta el rey.
					
→ Deck (baraja) : Representa una baraja de x cartas pudiendo acceder al siguiente elemento de la baraja y la posibilidad de barajar.

Esta librería es usada por los los demás programas que realizan cuatro juegos distintos de cartas, explicados en forma de comentarios en los mismos.

## Compilación

Para compilar basta con los comandos:

mcs -target:library -out:LibraryCards.dll Card.cs Deck.cs
mcs -r:LibraryCards main.cs
