using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQtoSPARQLSpace;
using LINQtoSPARQLSpace.Tests;
using Newtonsoft.Json;
using Xunit;
using Xunit.Extensions;

namespace Custom_Test
{
    class Program
    {
        public void connectToDatabase()
        {
            //database conncetivity statements

        }

        public void testLINQtoSPARQL1(string data)
        {
            var query = TestDataProvider.GetQuerable<dynamic>(data);
            
        var list = query.Match(s: "?x", p: "foaf:name", o: "?campusName")
                .Match(s:"?x", p:"JEMEntityRelations:hasAddress" , o: "?address")
                .Match(s: "?address", p: "JEMEntityAttributes:CountryCode", o:"IN")
                .Select("?campusName ?address")
                .Limit(10)
                .Prefix("JEMEntityAttributes:", "https://www.JCIBuildingSchema.org/schema/JEMEntityAttributes#")
                .Prefix("JEMEntitySH:", "https://www.JCIBuildingSchema.org/schema/JEMEntitySH#")
                .Prefix("JEMEntityRelations:", "https://www.JCIBuildingSchema.org/schema/JEMEntityRelations#")
                .Prefix("foaf:", "http://xmlns.com/foaf/0.1/")
                .AsEnumerable()
                .ToList();

            var json = JsonConvert.SerializeObject(list);

            Console.WriteLine(json);
        }

        public void testLINQtoSPARQL2()
        {
            connectToDatabase();
        }
        static void Main(string[] args)
        {
            
            Program p = new Program();

            //Test LINQ against local ttl file as data storage
            //            p.testLINQtoSPARQL1("C:/Users/jjamads/Desktop/campus and address.ttl");

            //Test LINQ against graphDB Ontotext database as data storage
            //            p.testLINQtoSPARQL2();

            p.connectToDatabase();

            Console.WriteLine("Press any key to EXIT... ");
            Console.ReadKey();
        }

       
    }
}
