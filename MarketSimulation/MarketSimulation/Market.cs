﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSimulation
{
	class Market
	/*
	 * Markets are a list of items that are for sale. The market will detail
	 * which items are for sale and their price.
	 *	
	 * Variables:
	 * - marketListings: A list of all market buy and sell orders (listings).
	 */
	{
		public List<Listing> marketListings = new List<Listing>();
		public string Name { get; set; }

		public Market(string name)
		{
			Name = name;
		}

		public void AddListing(Listing listing)
		{
			marketListings.Add(listing);
		}


		public List<Listing> SortBySellingItem(Item item)
		// Returns all listings that are selling the specified item.
		{
			List<Listing> itemList = new List<Listing>();

			foreach (Listing listing in marketListings)
			{
				if (listing.ItemToSell == item)
				{
					itemList.Add(listing);
				}
			}
			return itemList;
		}


		public List<Listing> SortByBuyingItem(Item item)
		// Returns all listings that are buying the specified item.
		{
			List<Listing> itemList = new List<Listing>();

			foreach (Listing listing in marketListings)
			{
				if (listing.ItemToBuy == item)
				{
					itemList.Add(listing);
				}
			}
			return itemList;
		}

		public void DisplayAllListings(List<Listing> list)
		// Prints all listings from a list of 'Listing' objects
		// Remove params, instead refer to marketListings
		{

			foreach (Listing Object in list)
			{
				Console.WriteLine(Object.ItemToSell.name + " " + Object.NumberToSell + " " + Object.ItemToBuy.name + " " + Object.NumberToBuy + " " + Object.Player.PlayerName);
			}
		}
	}
}
