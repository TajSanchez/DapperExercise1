using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using DapperDemoCSharpDemo;
using ZstdSharp.Unsafe;
using System.Diagnostics;
//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

#region Department Section
//var repo = new DepartmentRepo(conn);


//repo.InsertDepartment(Console.ReadLine());

//var departments = repo.GetAllDeparments();

//foreach (var department in departments)
//{
//    Console.WriteLine($"{department.DepartmentID} | {department.Name}");
//}
#endregion


var ProductRepository = new DapperProductRepository(conn);

var productToUpdate = ProductRepository.GetProduct(941);

var productRepostitory = new DapperProductRepository(conn);

productToUpdate.Name = "Updated!";
productToUpdate.Price = 1500;
productToUpdate.CategoryID = 1;
productToUpdate.OnSale = false;
productToUpdate.StockLevel = 705;




productRepostitory.UpdateProduct(productToUpdate);

var products = productRepostitory.GetAllProducts();
foreach (var product in products)
{
    Console.WriteLine(product.ProductID);
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Price);
    Console.WriteLine(product.CategoryID);
    Console.WriteLine(product.OnSale);
    Console.WriteLine(product.StockLevel);
    Console.WriteLine();
    Console.WriteLine();

}
    