using Project_Databas___Robin_R.Data;

namespace Project_Databas___Robin_R
    
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataAccess dataAccess = new DataAccess();

            dataAccess.Seed();
        }
    }
}