namespace CW9Threading
{

    
    public class FindPiThread
    {
   
        //atrributes of the FindPiThread class
        private int DartsToThrow;
        private int DartsThatLanded;
        private Random random;

        //parameterized constructor that initalizies class attributes 
        public FindPiThread(int Darts2Throw)
        {
            this.DartsToThrow = Darts2Throw;
            this.DartsThatLanded = 0;
            this.random = new Random();
        }


        //accessor which returns private attribute 'DartsThatLanded' 
        public int NumDartsThatLanded()
        {
            return DartsThatLanded;
        }

        //this method throws the amount of Darts request by the user 
        public void ThrowDarts()
        {
            //this will loop the amount of Darts requested
            for (int i = 0; i < DartsToThrow; i++)
            {
                //coordX and coordY are randomly generated doubles from (0,1)
                double coordX = random.Next(0, 1);
                double coordY = random.Next(0, 1);

                //Checking if hypotenuse of coordX and coordY is less than or equal to 1
                if ((coordX * coordX) + (coordY * coordY) <= 1)
                {
                    //The dart has landed inside so we increment by 1
                    DartsThatLanded++;
                }
            }
        }


    }

   

    //The entry point of the program
    internal class Program
    {
        static void Main(string[] args)
        {

            //asking the user for amount of Darts
            Console.WriteLine("Hello, How many Darts would you like to throw?");
            //we are going to parse the input and convert it to an int
            int NumberOfDarts = int.Parse(Console.ReadLine());
            //this will be deleted, just for my testing purposes
            Console.WriteLine(NumberOfDarts);

            //asking the user for the amount of Threads
            Console.WriteLine("How many Threads would you like to run?");
            //we are going to parse the input and convert it to an int
            int NumberOfThreads = int.Parse(Console.ReadLine());
            //this will be deleted, just for my testing purposes
            Console.WriteLine(NumberOfThreads);

            //List syntax : List<type>[] nameOfList = new List<type>[capacity]
            List<Thread>[] threads = new List<Thread>[NumberOfThreads];
            List<FindPiThread>[] findPiThreads = new List<FindPiThread>[NumberOfThreads];


            //1st loop set up threads, 2nd main to wait for all threads to finish, 3rd collect results

       

        }
    }
}