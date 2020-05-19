using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using ejemplo.Models;
using Microsoft.Data.Sqlite;

namespace ejemplo {


public class ProductosRepository {

    public ProductosRepository()
    {
        
    }
    private const string DBCON = @"Data Source=mydb.db;";
    public static void IniciarBD(){
        using (var connection = new SqliteConnection(DBCON))
//        ("" +    new SqliteConnectionStringBuilder()  {        DataSource = "data.db"  }))
        {
            connection.Open();
            connection.Execute(
                @"CREATE TABLE IF NOT EXISTS Productos (
                        Id INT PRIMARY KEY,
                        Nombre TEXT NULL,
                        Linea TEXT NULL,
                        Precio DECIMAL NULL
                ) ;");
        }
    }

        internal List<Producto> LeerTodos()
        {
            using(var con = new SqliteConnection(DBCON)){

                return con.Query<Producto>("SELECT Id, Nombre, Linea, Precio FROM Productos ").ToList();
            }
        }

        internal Producto LeerPorId(int id)
        {
            using(var con = new SqliteConnection(DBCON)){
                return con.Query<Producto>("SELECT Id, Nombre, Linea, Precio FROM Productos WHERE Id = @Id "
                    , new { Id = id }).FirstOrDefault();
            }
        }

        internal void Crear(Producto model)
        {
            using(var con = new SqliteConnection(DBCON)){
                con.Execute("INSERT INTO Productos (Id, Nombre, Linea, Precio) VALUES (@Id, @Nombre, @Linea, @Precio ) "
                    , model);
            }
        }

        internal void Actualizar(Producto model)
        {
             using(var con = new SqliteConnection(DBCON)){
                 con.Execute("UPDATE Productos SET  Nombre = @Nombre , Linea = @Linea, Precio = @Precio WHERE Id = @Id "
                    , model);
            }
        }

        internal void Borrar(int id)
        {
            using(var con = new SqliteConnection(DBCON)){
                con.Execute("DELETE FROM Productos WHERE Id = @Id "
                    , new { Id = id });
            }
        }
    }


}