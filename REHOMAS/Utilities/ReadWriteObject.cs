using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ConsoleApplication
{
    public class ReadWriteObject
    {
        
        public static void writeObjectsToFile<T>(Collection<T> objects)        
        {
            Collection<string> lines = new Collection<string>();
            foreach (var VARIABLE in objects)
            {
                lines.Add(Serialize(VARIABLE));                
            }
            writeToFile(lines);
        }
        
        public static Collection<T> readObjectsFromFile<T>(String roomNo)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Jethro\Documents\REHOMAS\REHOMAS\REHOMAS\RoomData.txt");
            Collection<T> spans = new Collection<T>();
            foreach (var VARIABLE in lines)
            {
                T obj = Deserialize<T>(VARIABLE);
                if (obj.ToString() == roomNo)
                {
                    spans.Add(obj);
                    
                }
            }
            return spans;
        }
        
        
        
        
        public static void writeToFile(Collection<string> lines)
        {
            System.IO.File.WriteAllLines(@"C:\Users\Jethro\Documents\REHOMAS\REHOMAS\REHOMAS\RoomData.txt", lines);
            
        }

        
        
        public static T Deserialize<T>(string json)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(ms);
            } 
        }
        
        public static string Serialize<T>(T obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                return Encoding.Default.GetString(ms.ToArray());
            }
        }
    }
}