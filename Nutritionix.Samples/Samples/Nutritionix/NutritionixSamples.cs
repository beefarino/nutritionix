﻿using System;
using System.Linq;
using Nutritionix;

namespace Nutritionix.Samples
{
    public static class NutritionixSamples
    {
		// TODO: Update with your Nutritionix API ID and Key
        private const string myApiId = "api_id";
        private const string myApiKey = "api_key";

        public static void RunAll()
        {
            SearchItems();
			RetrieveItem();
            RetrieveBrand();
            RetrieveItemsByBrand();
        }

        public static void SearchItems()
        {
            var nutritionix = new NutritionixClient();
            nutritionix.Initialize(myApiId, myApiKey);

            var request = new NutritionixSearchRequest { Query = "pie" };
			Console.WriteLine("Searching Nutritionix for 'pie'...");
            NutritionixSearchResponse response = nutritionix.SearchItems(request);

			Console.WriteLine("Displaying results 1 - {0} of {1}", response.Results.Length, response.TotalResults);
            foreach(NutritionixSearchResult result in response.Results)
            {
                Console.WriteLine("* {0}", result.Item.Name);
            }

			Console.WriteLine();
        }

        public static void RetrieveItem()
        {
            var nutritionix = new NutritionixClient();
            nutritionix.Initialize(myApiId, myApiKey);

            Console.WriteLine("Retrieving 'Raspberry Pie' from Nutritionix...");
            NutritionixItem item = nutritionix.RetrieveItem("513fc995927da70408002d76");

            Console.WriteLine("Item Id: {0}", item.Id);
            Console.WriteLine("Item Name: {0}", item.Name);
            Console.WriteLine("Brand Name: {0}", item.BrandName);

            Console.WriteLine("Calories: {0}", item.NutritionFact_Calories);
            Console.WriteLine("Sugar: {0} g", item.NutritionFact_Sugar);

            Console.WriteLine();
        }

        public static void RetrieveBrand()
        {
            var nutritionix = new NutritionixClient();
            nutritionix.Initialize(myApiId, myApiKey);

            Console.WriteLine("Retrieving 'Taco Bell' from Nutritionix...");
            NutritionixBrand brand = nutritionix.RetrieveBrand("513fbc1283aa2dc80c000020");

            Console.WriteLine("Brand Id: {0}", brand.Id);
            Console.WriteLine("Brand Name: {0}", brand.Name);

            Console.WriteLine("Logo: {0}", brand.LogoUrl);
            Console.WriteLine("Website: {0}", brand.Website);

            Console.WriteLine();
        }

        public static void RetrieveItemsByBrand()
        {
            var nutritionix = new NutritionixClient();
            nutritionix.Initialize(myApiId, myApiKey);

            var request = new NutritionixSearchRequest { BrandId = "513fbc1283aa2dc80c000024" };
            Console.WriteLine("Searching Nutritionix for the Olive Garden brand...");
            NutritionixSearchResponse response = nutritionix.SearchItems(request);

            Console.WriteLine("Displaying results 1 - {0} of {1}", response.Results.Length, response.TotalResults);
            foreach (NutritionixSearchResult result in response.Results)
            {
                Console.WriteLine("* {0}", result.Item.Name);
            }

            Console.WriteLine();
        }
    }
}
