using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDS.RDF.Query;

namespace Connect_Database_via_DotNetRDF
{
    class Program
    {

        public void connectBlazegraph()
        {
            string query = "SELECT * WHERE {?s ?p ?o} LIMIT 50";
            var endpoint = new VDS.RDF.Query.SparqlRemoteEndpoint(new Uri("http://10.109.219.5:9999/blazegraph/sparql"));
            SparqlResultSet results = endpoint.QueryWithResultSet(query);
        }

        public void connectMarkLogic()
        {
            string query = "SELECT * WHERE {?s ?p ?o} LIMIT 50";
            var endpoint = new VDS.RDF.Query.SparqlRemoteEndpoint(new Uri("http://localhost:8000/v1/graphs/sparql?database=NewMirvacDB"));
            endpoint.SetCredentials("samir","SSSjjj@123");
            SparqlResultSet results = endpoint.QueryWithResultSet(query);
        }

        public void connectOntotext()
        {
            string query = "SELECT * WHERE {?s ?p ?o} LIMIT 50";
            var endpoint = new VDS.RDF.Query.SparqlRemoteEndpoint(new Uri("http://localhost:7200/repositories/786"));
            VDS.RDF.Options.ForceHttpBasicAuth = true;
            endpoint.SetCredentials("admin","admin");
            SparqlResultSet results = endpoint.QueryWithResultSet(query);
        }

        static void Main(string[] args)
        {
            Program p = new Program();

            p.connectBlazegraph();
            p.connectMarkLogic();
            p.connectOntotext();

        }
    }
}
