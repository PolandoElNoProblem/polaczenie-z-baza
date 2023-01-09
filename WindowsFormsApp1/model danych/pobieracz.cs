﻿using ListaUczestnikow.ModelDanych;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WinFormsApp1.ModelDanych
{
    public class Pobieracz
    {
        public List<Osoba> ListaOsob { get; set; }
        public Pobieracz()
        {
            ListaOsob = new List<Osoba> { };
        }
        public void PobierzDaneZBazy()
        {
            string polaczenie = @"Data Source= Uczestnicy.db";
            SqliteConnection connection = new SqliteConnection(polaczenie);
            connection.Open();
            var command=connection.CreateCommand();
            string sql = "select Id,Imie,Nazwisko,Data_Urodzewnia,Srednia_Ocen,Poziom_Angielski " + "from Osoba";
            
            command.CommandText = sql;
            var reader=command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("id"));
                string imie = reader.GetString(reader.GetOrdinal("Imie"));
                string nazwisko = reader.GetString(reader.GetOrdinal("Nazwisko"));
                DateTime dt_U = reader.GetDateTime(reader.GetOrdinal("Data_Urodzenia"));
                decimal sred = reader.GetDecimal(reader.GetOrdinal("Srednia_Ocen"));
                string poziom = reader.GetString(reader.GetOrdinal("Poziom_Angileski"));
                ListaOsob.Add(new Osoba(id, imie, nazwisko, dt_U, sred, poziom));

            }
            connection.Close();
            connection.Dispose();

        }
    }



}