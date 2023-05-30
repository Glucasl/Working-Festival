using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Librerías que necesitamos
using System.Data;
using System.IO;
using Mono.Data.Sqlite;

public class DataBaseController : MonoBehaviour
{
    /*
    //Variable para controlar la ruta de la base de datos, constructor de la ruta, y el nombre de la base de datos
    static string rutaDB;
    static string strConexion;
    static string DBFileName = "MoneyRanking.db";

    //Variable para trabajar con las conexiones
    static IDbConnection dbConnection;
    //Para poder ejecutar comandos
    static IDbCommand dbCommand;
    //Variable para leer
    static IDataReader reader;

    static void OpenDB(string DatabaseName)
    {

#if UNITY_EDITOR
        var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
            // check if file exists in Application.persistentDataPath
            var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);
       
            if (!File.Exists(filepath))
            {
                Debug.Log("Database not in Persistent path");
                // if it doesn't ->
                // open StreamingAssets directory and load the db ->
           
#if UNITY_ANDROID
                var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
                while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
                // then save to Application.persistentDataPath
                File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
           
#elif UNITY_WINRT
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#endif
           
                Debug.Log("Database written");
            }
       
            var dbPath = filepath;
#endif
        //_connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Final PATH: " + dbPath);

        //open db connection
        strConexion = "URI=file:" + dbPath;
        Debug.Log("Stablishing connection to: " + strConexion);
        dbConnection = new SqliteConnection(strConexion);
        dbConnection.Open();
    }

    //Método para obtener el Ranking de la DB
    void ObtenerRanking()
    {
        //Primero dejamos la lista de Rankings limpia
        rankings.Clear();
        //Abrimos la DB
        AbrirDB();
        // Crear la consulta
        dbCommand = dbConnection.CreateCommand();
        string sqlQuery = "SELECT * FROM ranking";
        dbCommand.CommandText = sqlQuery;

        // Leer la base de datos
        reader = dbCommand.ExecuteReader();
        while (reader.Read())
        {
            rankings.Add(new Ranking(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetDateTime(3)));
        }
        reader.Close();
        reader = null;
        //Cerramos la DB
        CerrarDB();
        //Ordenamos la lista
        rankings.Sort();
    }

    //Método para insertar puntos en la DB
    public static void InsertarPuntos( int money)
    {
        //Abrimos la DB
        OpenDB(DBFileName);
        // Crear la consulta
        dbCommand = dbConnection.CreateCommand();
        string sqlQuery = String.Format("INSERT INTO ranking(money) values(\"{0}\")",money);
        dbCommand.CommandText = sqlQuery;
        dbCommand.ExecuteScalar();
        //Cerramos la DB
        CerrarDB();
    }

    //Método para cerrar la DB
    static void CerrarDB()
    {
        // Cerrar las conexiones
        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;
    }
    */

}
