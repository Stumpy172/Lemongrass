﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MarketSimulation
{
	class Program
	{
		static void Main(string[] args)
		{


			
			Item.ItemCreation();
			StartMenu();
			ObjectCreation();
			/*
			 * Player p1 = new Player(1,"p1");
			p1.AddToInventory(Lemon, 1);
			p1.AddToInventory(Apple, 2);
			Listing playerBuyListing = p1.CreateListing(Apple, 2, Lemon, 2);
			Listing playerBuyListing2 = p1.CreateListing(Lemon, 5, Apple, 3);

			Market someTown = new Market("The Town of Some");
			someTown.AddListing(playerBuyListing);
			someTown.AddListing(playerBuyListing2);


			someTown.DisplayAllListings(someTown.marketListings);

			Console.WriteLine(" ");
			someTown.DisplayAllListings(someTown.SortBySellingItem(Lemon));
			Console.ReadLine();
			*/

		}
		public static void StartMenu()
		{

			Console.Clear();
			Console.WriteLine("\tLemon Trading Game");
			Console.WriteLine("1. Create Player");
			Console.WriteLine("2. Exit Game");
			string userInput = Console.ReadLine();
			switch (Int32.Parse(userInput))
			{
				case 1:
					int playerLoginIndex = Player.PlayerIndex(Player.CreatePlayer());
					MarketMenu(playerLoginIndex);
					break;
				case 2:
					Environment.Exit(1);
					break;
				default:
					StartMenu();
					break;
			}

		}
		public static void MarketMenu(int playerListIndex)
		{
			Console.Clear();

			Console.WriteLine("\t\tLemon Trading Game");
			Console.WriteLine("1. Add Items");
			Console.WriteLine("2. Make Trade Request");
			Console.WriteLine("3. Show all Trades");
			Console.WriteLine("4. Trade Filters");
			Console.WriteLine("5. Main Menu");
			Console.WriteLine("---------{0} Stats--------", Player.playerList[playerListIndex].PlayerName);
			Console.WriteLine("Inventory:");
			Player.playerList[playerListIndex].displayInventory();

			string userInput = Console.ReadLine();
			switch (Int32.Parse(userInput))
			{
				case 1:
					Player.playerList[playerListIndex].AddToInventory();
					MarketMenu(playerListIndex);
					break;
				case 2:
					
					break;
				default:
					StartMenu();
					break;
			}
		}

		public static void ObjectCreation()
		{
			
			Random rnd = new Random();
			Random rndFruitIndex = new Random();
			Market testTown = new Market("The Town of testing");
			Player Bob = new Player(0,"Bob");
			Player Jim = new Player(1, "Jim");
			Player Jones = new Player(2, "Jones");
			Player Gary = new Player(3, "Gary");
			Player.playerList.Add(Bob);
			Player.playerList.Add(Jim);
			Player.playerList.Add(Jones);
			Player.playerList.Add(Gary);
			Console.WriteLine(Player.playerList.Count);
			Console.WriteLine(Item.itemList.Count);
			Console.ReadLine();
			for (int i = 0; i < rnd.Next(10,100); i++)
			{
				Player.playerList[rnd.Next(0, Player.playerList.Count)].AddToInventory(Item.itemList[rndFruitIndex.Next(0,4)],rnd.Next(1,100));
				int playerIndex = rnd.Next(0, Player.playerList.Count);
				Listing newListing = Player.playerList[playerIndex].CreateListing(Item.itemList[rndFruitIndex.Next(0,4)], rnd.Next(1, 100), Item.itemList[rndFruitIndex.Next(0,4)], rnd.Next(1, 100), Player.playerList[playerIndex]);
				testTown.AddListing(newListing);

			}
			testTown.DisplayAllListings(testTown.marketListings);
			Console.ReadLine();
			testTown.DisplayAllListings(testTown.SortBySellingItem(Item.itemList[0]));
			Console.ReadLine();
		}

	}
}
