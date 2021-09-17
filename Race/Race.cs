using System;

namespace Race
{
    class Race
    {
        // declaring const position
        const int RACE_END = 70; 

        // randomise
        static Random randomNumbers = new Random();

        // tortoise's position, hare's position and time-elapse
        static int tortoise, hare, timer; 
       

        //run the race
        static void Main(string[] args)
        {
            // initial position
            tortoise = 1;
            hare = 1;
            timer = 0;

            Console.WriteLine("ON YOUR MARK, GET SET");
            Console.WriteLine("BANG !!!!!");
            Console.WriteLine("AND THEY'RE OFF !!!!!");

            while (tortoise < RACE_END && hare < RACE_END)
            {
                ChangeHarePosition();
                ChangeTortoisePosition();
                PrintCurrentPositions();

                // slow down race
                for (int temp = 0; temp < 100000000; temp++) ;

                ++timer;
            }

            // tortoise beats hare or a tie
            if (tortoise >= hare)
            {
                Console.WriteLine("\nTORTOISE WINS!!! YAY!!!");
            }
            // hare beat tortoise
            else
            {
                Console.WriteLine("\nHare wins. Yuch!");
            }

            Console.WriteLine($"TIME ELAPSED = {timer} seconds");
        }

        // change tortoise's position
        public static void ChangeTortoisePosition()
        {
            // randomize move to choose
            int percent = randomNumbers.Next(1, 11);

            // determine moves by percent in range in Fig 8.33
            // fast plod
            if (percent >= 1 && percent <= 5)
            {
                tortoise += 3;
            }
            // slip
            else if (percent == 6 || percent == 7)
            {
                tortoise -= 6;
            }
            // slow plod
            else
            {
                ++tortoise;
            }

            // ensure tortoise doesn't slip beyond start position
            if (tortoise < 1)
            {
                tortoise = 1;
            }
            // ensure tortoise doesn't pass the finish
            else if (tortoise > RACE_END)
            {
                tortoise = RACE_END;
            }
        }

        // move hare's position
        public static void ChangeHarePosition()
        {
            // randomize move to choose
            int percent = randomNumbers.Next(1, 11);

            // determine moves by percent in range in Fig 8.33
            // big hop
            if (percent == 3 || percent == 4)
            {
                hare += 9;
            }
            // big slip
            else if (percent == 5)
            {
                hare -= 12;
            }
            // small hop
            else if (percent >= 6 && percent <= 8)
            {
                ++hare;
            }
            // small slip
            else if (percent > 8)
            {
                hare -= 2;
            }

            // ensure that hare doesn't slip beyond start position
            if (hare < 1)
            {
                hare = 1;
            }
            // ensure hare doesn't pass the finish
            else if (hare > RACE_END)
            {
                hare = RACE_END;
            }
        }

        // display positions of tortoise and hare
        public static void PrintCurrentPositions()
        {
            // goes through all 70 squares, printing H
            // if hare on position and T for tortoise
            for (int count = 1; count <= RACE_END; count++)
            {
                // tortoise and hare positions collide
                if (count == tortoise && count == hare)
                {
                    Console.Write("OUCH!!!");
                }
                else if (count == hare)
                {
                    Console.Write("H");
                }
                else if (count == tortoise)
                {
                    Console.Write("T");
                }
                else
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }

    }
    
}
