using System;
using System.Data;
using DuckDB.NET.Data;

class Program
{
    static void Main(string[] args)
    {
    
        using var conn = new DuckDBConnection("DataSource=:memory:");
        conn.Open();
        Console.WriteLine("DuckDB connected successfully");
      
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = "INSTALL json; LOAD json;";
            cmd.ExecuteNonQuery();
        }
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = @"SELECT * FROM read_json_auto('DBData/data.json')";
            PrintResults(cmd.ExecuteReader(), "Simple JSON");
        }

        
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = @"SELECT * FROM read_csv_auto('DBData/data.csv', HEADER=TRUE)";
            PrintResults(cmd.ExecuteReader(), "CSV File");
        }

  
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = @"
                SELECT 
                    e.value->>'id'   AS emp_id,
                    e.value->>'name' AS emp_name,
                    e.value->>'role' AS skill
                FROM read_json_auto('DBData/complex.json') t,
                     json_each(t.employees) e;
            ";
            PrintResults(cmd.ExecuteReader(), "Employees with Skills");
        }

        
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = @"
                SELECT 
                    d.value->>'deptId'   AS dept_id,
                    d.value->>'deptName' AS dept_name
                FROM read_json_auto('DBData/complex.json') t,
                     json_each(t.departments) d;
            ";
            PrintResults(cmd.ExecuteReader(), "Departments");
        }

        conn.Close();
    }

  //print data function 
    static void PrintResults(IDataReader reader, string title)
    {
        Console.WriteLine($"\n=== {title} ===");

       
        for (int i = 0; i < reader.FieldCount; i++)
            Console.Write($"{reader.GetName(i),-12}");
        Console.WriteLine();

       
        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
                Console.Write($"{reader[i],-12}");
            Console.WriteLine();
        }
    }
}
