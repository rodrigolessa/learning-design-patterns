# learning-design-patterns
A Practical guide

## Table of Content
 - Introdução
 - Design Patterns (Padrões GoF)
 * Padrões de criação
 * Padrões estruturais
 * Padrões comportamentais
 - App Project
 * Prerequisites
 * Creating App Project with Ionic CLI
 - Referências

## Introdução

O paradigma de programação orientada a objetos estabelece princípios fundamentais referentes à organização de um software. Princípios que podem diminuir consideravelmente o custo de desenvolver e principalmente de manter sistemas. A orientação a objetos é o modelo de programação mais utilizado na modelagem de sistemas corporativos.

Principais características de programação orientada a objetos:

* Modularidade
* Encapsulamento
* Polimorﬁsmo

Caso de uso: Como montar uma cidade com Design Patterns.

## Design Patterns (Padrões GoF)

Os 23 padrões do Gang of Four (GoF) são considerados os mais importantes e os pilares fundamentais para todos os outros padrões.

### Padrões de criação

Abstract Factory

Object pool

Builder

* Factory Method

Permite às classes delegar para subclasses decidirem o que vai ser instânciado.

História: 
Eu como construtor
Preciso criar muitas casas somente alterando características do terreno e altura.

```shel
public abstract class Casa {

	private int Tijolos;
	private int Cimento;

	public Casa (int tijolos, int cimento) {
		this.Tijolos = tijolos;
		this.Cimento = cimento;
  	}
}

public class PlantaDaCasa : Casa {

	public static int TijolosPorParade = 100;
	public static int PorçãoDeCimentoPorTijolo = 10;
}

public static class FábricaDeCasas {

	public static Construir(int altura, string tipoDeTerreno = "Plano") {

		var totalDetijolos = altura * PlantaDaCasa.TijolosPorParade;

		var totalDeCimento = totalDetijolos * PlantaDaCasa.PorçãoDeCimentoPorTijolo;

		var fundaçãoDeConcreto = 0;

		return new PlantaDaCasa(totalDetijolos, totalDeCimento);
	}
}

public void Main() {
	
	var umaCasaBaixaEmTerrenoPlano = FábricaDeCasas.Construir(2);
}
```

Prototype

Singleton

### Padrões estruturais

Private class data

Adapter

Bridge

Composite

Decorator

Façade (ou Facade)

Business Delegate

Flyweight

Proxy

### Padrões comportamentais

Chain of Responsibility

Command

Interpreter

Iterator

Mediator

Memento

Observer

State

Strategy

Template Method

Visitor

## App Project

### Prerequisites

 - Install Node.js (with npm package)
 - Install Ionic CLI
 - Install Visual Studio Code (a code editor)
 - Install Bitvise (SSH client)
 - Install Angular
 - Install TypeScript
 - Install Apache Cordova

### Creating App Project with Ionic CLI

## Referências

- Livro Design Patterns: Elements of Reusable Object-Oriented Software (editora Addison-Wesley, 1995) dos autores Erich Gamma, Richard Helm, Ralph Johnson e John Vlissides.