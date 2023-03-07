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
        public int GetNumDartsThatLanded()
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
            

            //asking the user for the amount of Threads
            Console.WriteLine("How many Threads would you like to run?");
            //we are going to parse the input and convert it to an int
            int NumberOfThreads = int.Parse(Console.ReadLine());
            

            //List syntax : List<type> nameOfList = new List<type>(capacity)
            List<Thread> threads = new List<Thread>(NumberOfThreads);
            List<FindPiThread> findPiThreads = new List<FindPiThread>(NumberOfThreads);



            //first loop
            for (int i = 0; i < NumberOfThreads; i++)
            {
                //creating FindPiThread object and passing in NumberOfDarts
                FindPiThread piThreads = new FindPiThread(NumberOfDarts);
                //adding our object into the list we created of FindPiThread
                findPiThreads.Add(piThreads);

                //creating a thread object and passing in Darts need to be thrown
                Thread thread = new Thread(piThreads.ThrowDarts);
                //adding our object into the list we created of Threads
                threads.Add(thread);

                //start the thread
                thread.Start();
                //tells main to sleep for 16 milliseconds
                Thread.Sleep(16);
            }

            // for every element in threads which is of type Thread
            foreach (Thread T in threads)
            {
                //we will perform .Join() on it
                T.Join();
            }

            //This will be the total amount of darts landed for each FindPiThread
            int totalLanded = 0;
            foreach (FindPiThread FPT in findPiThreads)
            {
                //when we perform the getNumDartsThatLanded(), it is added to totalLanded
                totalLanded += FPT.GetNumDartsThatLanded();
            }

            //evaluation of pi
            double valOfPi = (4 * (totalLanded) / NumberOfDarts);

            Console.WriteLine($"Value of pi: {valOfPi}");
            Console.ReadLine();
        }
    }
}