// See https://aka.ms/new-console-template for more information
using DotNet.Framework;
using DotNet.Framework.Templates;

Console.WriteLine("Hello, World!");

var mySolution = DotNetClient.New<Solution>("sample");

Console.WriteLine("Solution created!");
