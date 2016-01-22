using System.Collections.Generic;
using Microsoft.Owin;
using Newtonsoft.Json;
using OneMoreThing;

namespace Just.OneMoreThing.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var test = new Thing
            {
                Script = @"if(Body.RestaurantId == 1)
                                    {   
                                        Body.Test = false;                                 
                                        Body.NewField = true;
                                        Body.NewObject = {'field': true}   
                                    }
                                "
            };
            var testResponse = new TestObject();
            var testResultJson = test.Run(JsonConvert.SerializeObject(testResponse),
                new HeaderDictionary(new Dictionary<string, string[]>()));

            System.Console.WriteLine(testResultJson);
            System.Console.ReadLine();
        }
    }

    public class TestObject
    {
        public int RestaurantId = 1;
        public bool Test = true;
    }
}