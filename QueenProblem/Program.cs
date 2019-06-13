using System;

namespace QueenProblem
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			Console.WriteLine("I'm working...");
			//var queenProblemSolver = new QueenProblemSolver(new RandomProvider(), new DoubleProvider()); // Finished with 30 queen in 400-30000 ms
            //var queenProblemSolver = new QueenProblemSolver(new RandomProvider(), new RandomProvider()); // Finished with 30 queen in 30000 ms
            var queenProblemSolver = new QueenProblemSolver(new SequentialProvider(), new DoubleProvider()); // Finished with 12 queen in 40000 ms
            //var queenProblemSolver = new QueenProblemSolver(new SequentialProvider(), new SequentialProvider()); // Finished with 12 queen in 80000 ms

            var start = Environment.TickCount;
            var firstSolution = queenProblemSolver.GetSolution(12);
            var end = Environment.TickCount;

            var delta = end - start;
            Console.WriteLine($"Time taken: {delta}");
            Console.WriteLine(firstSolution);
            Console.ReadLine();
        }
    }
}
