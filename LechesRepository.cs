using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using ejemplo.Models;
using Microsoft.Data.Sqlite;

namespace ejemplo {


public class LechesRepository {

    public LechesRepository()
    {
        
    }
    private const string DBCON = @"Data Source=mydb.db;";
    public static void IniciarBD(){
        using (var connection = new SqliteConnection(DBCON))
//        ("" +    new SqliteConnectionStringBuilder()  {        DataSource = "data.db"  }))
        {
            connection.Open();
            connection.Execute(
                @"CREATE TABLE IF NOT EXISTS Leches (
                        Id INT PRIMARY KEY,
                        Nombre TEXT NULL,
                        Marca TEXT NULL,
                        Etapa INT NULL
                ) ;");
        }
    }

        internal List<Leche> LeerTodos()
        {
            using(var con = new SqliteConnection(DBCON)){

                return con.Query<Leche>("SELECT Id, Nombre, Marca, Etapa FROM Leches ").ToList();
            }
        }

        internal Leche LeerPorId(int id)
        {
            using(var con = new SqliteConnection(DBCON)){
                return con.Query<Leche>("SELECT Id, Nombre, Marca, Etapa FROM Leches WHERE Id = @Id "
                    , new { Id = id }).FirstOrDefault();
            }
        }

        internal void Crear(Leche model)
        {
            using(var con = new SqliteConnection(DBCON)){
                con.Execute("INSERT INTO Leches ( Nombre, Marca, Etapa) VALUES ( @Nombre, @Marca, @Etapa ) "
                    , model);
            }
        }

        internal void Actualizar(Leche model)
        {
             using(var con = new SqliteConnection(DBCON)){
                 con.Execute("UPDATE Leches SET  Nombre = @Nombre , Marca = @Marca, Etapa = @Etapa WHERE Id = @Id "
                    , model);
            }
        }

        internal void Borrar(int id)
        {
            using(var con = new SqliteConnection(DBCON)){
                con.Execute("DELETE FROM Leches WHERE Id = @Id "
                    , new { Id = id });
            }
        }
    }


}