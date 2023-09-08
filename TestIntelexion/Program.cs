// See https://aka.ms/new-console-template for more information

using System.Configuration;
using System.IO.Compression;
using TestIntelexion.Managers;

public class Program
{
    private static void Main(string[] args)
    {


        ProcessManager manager = new ProcessManager();
        manager.ProcessImages();
    }
}