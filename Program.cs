using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _endproject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //_endproject code

            string[] questions = new string[4];

            questions[0] = "A while loop can be used when you want to run a block of code at least once, even when\n" +
                "the condition to exit the loop is true? [5] \nTrue or False?";
            questions[1] = "Which Key word cannot be used when creating a Switch statement. [2] \nA.Break        B.Default    C.GoTo";
            questions[2] = "Which one of the following is not a primitive data type. [3] \n A.Char      B.Bool      C.ENum      D.Int";
            questions[3] = "What is the result of the following code? [10] \n string str = \"Hello, World!\"; \n Console.WriteLine(SubString(7,5));";

            string[] answers = new string[4] { "False", "C", "C", "World" };
            int[] questionScore = new int[4] { 5, 2, 3, 10 };
            string optionInput;
            int score = 0;
            bool start = false, restartQuiz = false;
            string userAnswer;


            Console.WriteLine("Hello");

            while (!start)
            {
                WelcomePage();

                optionInput = Console.ReadLine();

                switch (optionInput)
                {
                    case "1":
                        {
                            Console.WriteLine("Starting Quizz");

                            start = true;
                        }
                        break;

                    case "2":
                        Exit();
                        break;

                    default:
                        {
                            Console.WriteLine("Invalid Input please try Again!!");
                            Console.ReadLine();

                            Console.Clear();
                        }
                        break;
                }

                Console.WriteLine("=====================================================================");

            }

            while (!restartQuiz)
            {
                Console.WriteLine("================================================================================================================================================================");
                Console.WriteLine("Instructions \n For questions that have multiple choice answers just input the LETTER of the correct answer");
                Console.WriteLine("e.g if you think the answer is A , input A as your answer!!!\n");

                Console.WriteLine("For the true or false question ,input the word true if you think the statement is true or \ninput false if the statement is false \n");
                Console.WriteLine("For the questions that ask for the result of code, input the result that would be \ndisplayed on the console when the code is run");
                Console.WriteLine("e.g if you think the code will display a 5 input 5 as your answer if the code results in \"Hello world\" \nbeing displayed input \"hello world\" as your answer.\n");

                Console.WriteLine("================================================================================================================================================================");

                Console.ReadLine();
                Console.Clear();

                for (int i = 0; i < questions.Length; i++)
                {
                    AskQuestions(questions, i);

                    Console.WriteLine();
                    Console.Write("Answer: ");

                    userAnswer = CheckAnswer(Console.ReadLine(),i);

                    score = CheckAnswer(answers, questionScore, userAnswer, score, i);

                    Console.WriteLine();

                }

                DisplayScore(score);

                Console.WriteLine("Would you like you restart the quizz?");
                Console.WriteLine("1.Yes         2.No");
                Console.Write("Input Operation:  [ ] \b\b\b");

                optionInput = Console.ReadLine();

                bool exitLoop = false;

                while (!exitLoop)
                {

                    switch (optionInput)
                    {
                        case "1":
                            restartQuiz = false;
                            exitLoop = true;

                            Console.WriteLine();
                            Console.Clear();

                            score = 0;
                            break;

                        case "2":

                            Console.WriteLine();

                            Console.Clear();
                            Exit();
                            break;

                        default:
                            {
                                Console.WriteLine("Invalid input please input \"1\" or \"2\"");

                                Console.WriteLine("Would you like you restart the quizz?");
                                Console.WriteLine("1.Yes         2.No");
                                Console.Write("Input Operation:  [ ] \b\b\b");

                                optionInput = Console.ReadLine();
                            }
                            break;
                    }

                }

               

             
                

            }

            Exit();

        }

        static void WelcomePage()
        {

            Console.WriteLine("===========================Quiz Application=======================");
            Console.WriteLine("Welcome to Sean Mashava's Quizz Application!!\n");
            Console.WriteLine("1. Start                             2. Exit \n");

            Console.WriteLine("Please input an operation");
            Console.WriteLine("Input 1 to start the quiz or input 2 to exit the program");
            Console.Write("Operation: [ ] \b\b\b");

        }

        static void Exit()
        {
            //This is used whenever the user chooses to exit the program

            Console.WriteLine("Thank you for using My Quiz App... \nHope you enjoy the rest of your day \n");
            Console.WriteLine("==================================================================");
            Console.ReadLine();

            Environment.Exit(0);

        }

        static byte InputValidation(string userInput)
        {

            //to make sure the user inputs a number
            
            bool isNumber = byte.TryParse(userInput, out byte num);

            while (isNumber != true)
            {

                Console.WriteLine();
                Console.WriteLine("Invalid input!!!");
                Console.WriteLine("Please input either \"1\" or \"2\"!!!");
                Console.Write("Input Operation:  [ ] \b\b\b");
                userInput = Console.ReadLine();

                isNumber = byte.TryParse(userInput, out num);

            }

            return num;

        }

        static void AskQuestions(string[] questionList, int i)
        {
            Console.WriteLine((i + 1) + ". " + questionList[i]);
        }

        static int CheckAnswer(string[] answerList, int[] questionScore, string userAnswer, int currentScore, int i)
        {
            int mark, score = currentScore;

            int qScore = questionScore[i];
            string ans = answerList[i];

            //mark is set to three in order to make sure that the score is not increased 

            mark = 3;

            switch (i)
            {
                case 0:
                    mark = ans.CompareTo(userAnswer);
                    break;
                case 1:
                    {
                        if (userAnswer == "c" || userAnswer == "C")
                        {
                            mark = ans.CompareTo(userAnswer);
                        }
                    }

                    break;
                case 2:

                    {
                        if (userAnswer == "c" || userAnswer == "C")
                        {
                            mark = ans.CompareTo(userAnswer);
                        }
                    }
                    break;

                case 3:
                    {
                        if (userAnswer.Length == ans.Length)
                        {
                            mark = ans.CompareTo(userAnswer);
                        }
                    };
                    break;

            }

            if (mark == 0 || mark == 1)
            {
                score += qScore;
            }

            return score;
        }

        static void DisplayScore(double scoreTotal)
        {

            double percentage;

            percentage = (scoreTotal / 20) * 100;

            if (percentage > 80)
            {

                Console.WriteLine("Your score is " + scoreTotal);
                Console.WriteLine("Feedback: Excellent");

            } else if (percentage > 60)
            {

                Console.WriteLine("Your score is " + scoreTotal);
                Console.WriteLine("Feedback: Good");
            }
            else if (percentage > 40)
            {

                Console.WriteLine("Your score is " + scoreTotal);
                Console.WriteLine("Feedback: Satisfactory");

            }
            else if (percentage > 20)
            {

                Console.WriteLine("Your score is " + scoreTotal);
                Console.WriteLine("Feedback: Poor");

            }
            else
            {

                Console.WriteLine("Your score is " + scoreTotal);
                Console.WriteLine("Feedback: Failed");

            }

            Console.WriteLine();

        }

        static string CheckAnswer(string userAnswer, int currentQuestion)
        {

            //a function to check if the answer is in the correct form
            //e.g the answer should onnly be trtue or false if its a true/false question
            
            bool correctFormat = false;

            while (correctFormat == false)
            {
                switch (currentQuestion)
                {
                    case 0:
                        {

                            if (userAnswer == "True" || userAnswer == "true")
                            { correctFormat = true;
                                break;
                            }
                            else if (userAnswer == "False" || userAnswer == "false")
                            { correctFormat = true;
                                break;
                            }


                            Console.WriteLine("Your answer is not in the correct format");
                            Console.Write("Please input \"True\" or \"False\": ");

                            userAnswer = Console.ReadLine();


                        }
                        break;

                    case 1:
                        {


                            if (userAnswer == "A" || userAnswer == "a")
                            { correctFormat = true; 
                                break ;
                            }
                            else if (userAnswer == "B" || userAnswer == "b")
                            {
                                correctFormat = true;
                                break;
                            }
                            else if (userAnswer == "C" || userAnswer == "c")
                            {
                                correctFormat = true;
                                break;
                            }
                            else if (userAnswer == "D" || userAnswer == "d")
                            {
                                correctFormat = true;
                                break;
                            }


                            Console.WriteLine("Your answer is not in the correct format");
                            Console.Write("Please input \"A\" or \"B\" or \"C\" or \"D\": ");

                            userAnswer = Console.ReadLine();
                        }
                        break;

                    case 2:
                        {


                            if (userAnswer == "A" || userAnswer == "a")
                            {
                                correctFormat = true;
                                break;
                            }
                            else if (userAnswer == "B" || userAnswer == "b")
                            {
                                correctFormat = true;
                                break;
                            }
                            else if (userAnswer == "C" || userAnswer == "c")
                            {
                                correctFormat = true;
                                break;
                            }
                            else if (userAnswer == "D" || userAnswer == "d")
                            {
                                correctFormat = true;
                                break;
                            }


                            Console.WriteLine("Your answer is not in the correct format");
                            Console.Write("Please input \"A\" or \"B\" or \"C\" or \"D\": ");

                            userAnswer = Console.ReadLine();
                        }
                        break;

                    default:
                        correctFormat = true;
                        break;

                }
            }

            return userAnswer;
        }

    }

    

}
