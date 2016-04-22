using System;
using System.Threading;

namespace CSharpRefactorings.TicTacToe.Original
{
    class Program
    {
        private char winChar;

        public char winPerson
        {
            get { return winChar; }
            set { winChar = value; }
        }

        private bool hasWon;

        public bool isWin
        {
            get { return hasWon; }
            set { hasWon = value; }
        }

        private bool isX;

        public bool isY
        {
            get { return isX; }
            set { isX = value; }
        }

        private char boxone, boxtwo, boxthree, boxfour, boxfive, boxsix, boxseven, boxeight, boxnine;

        public char box1
        {
            get { return boxone; }
            set { boxone = value; }
        }

        public char box2
        {
            get { return boxtwo; }
            set { boxtwo = value; }
        }

        public char box3
        {
            get { return boxthree; }
            set { boxthree = value; }
        }

        public char box4
        {
            get { return boxfour; }
            set { boxfour = value; }
        }

        public char box5
        {
            get { return boxfive; }
            set { boxfive = value; }
        }

        public char box6
        {
            get { return boxsix; }
            set { boxsix = value; }
        }

        public char box7
        {
            get { return boxseven; }
            set { boxseven = value; }
        }

        public char box8
        {
            get { return boxeight; }
            set { boxeight = value; }
        }

        public char box9
        {
            get { return boxnine; }
            set { boxnine = value; }
        }

        public void WriteBoard()
        {
            Console.WriteLine(" {0} | {1} | {2} ", boxone, boxtwo, boxthree);
            Console.WriteLine(" --------- ");
            Console.WriteLine(" {0} | {1} | {2} ", boxfour, boxfive, boxsix);
            Console.WriteLine(" --------- ");
            Console.WriteLine(" {0} | {1} | {2} ", boxseven, boxeight, boxnine);
        }

        public void CheckWin()
        {
            // 123, 456, 789, 147, 258, 369, 159, 357
            if ((box1 == 'X') && (box2 == 'X') && (box3 == 'X'))
            {
                isWin = true;
                winPerson = 'X';
                return;
            }
            if ((box4 == 'X') && (box5 == 'X') && (box6 == 'X'))
            {
                isWin = true;
                winPerson = 'X';
                return;
            }
            if ((box7 == 'X') && (box8 == 'X') && (box9 == 'X'))
            {
                isWin = true;
                winPerson = 'X';
                return;
            }
            if ((box1 == 'X') && (box4 == 'X') && (box7 == 'X'))
            {
                isWin = true;
                winPerson = 'X';
                return;
            }
            if ((box2 == 'X') && (box5 == 'X') && (box8 == 'X'))
            {
                isWin = true;
                winPerson = 'X';
                return;
            }
            if ((box3 == 'X') && (box6 == 'X') && (box9 == 'X'))
            {
                isWin = true;
                winPerson = 'X';
                return;
            } // 159, 357
            if ((box1 == 'X') && (box5 == 'X') && (box9 == 'X'))
            {
                isWin = true;
                winPerson = 'X';
                return;
            }
            if ((box3 == 'X') && (box5 == 'X') && (box7 == 'X'))
            {
                isWin = true;
                winPerson = 'X';
                return;
            }
            if ((box1 == 'Y') && (box2 == 'Y') && (box3 == 'Y'))
            {
                isWin = true;
                winPerson = 'Y';
                return;
            }
            if ((box4 == 'Y') && (box5 == 'Y') && (box6 == 'Y'))
            {
                isWin = true;
                winPerson = 'Y';
                return;
            }
            if ((box7 == 'Y') && (box8 == 'Y') && (box9 == 'Y'))
            {
                isWin = true;
                winPerson = 'Y';
                return;
            }
            if ((box1 == 'Y') && (box4 == 'Y') && (box7 == 'Y'))
            {
                isWin = true;
                winPerson = 'Y';
                return;
            }
            if ((box2 == 'Y') && (box5 == 'Y') && (box8 == 'Y'))
            {
                isWin = true;
                winPerson = 'Y';
                return;
            }
            if ((box3 == 'Y') && (box6 == 'Y') && (box9 == 'Y'))
            {
                isWin = true;
                winPerson = 'Y';
                return;
            } // 159, 357
            if ((box1 == 'Y') && (box5 == 'Y') && (box9 == 'Y'))
            {
                isWin = true;
                winPerson = 'Y';
                return;
            }
            if ((box3 == 'Y') && (box5 == 'Y') && (box7 == 'Y'))
            {
                isWin = true;
                winPerson = 'Y';
                return;
            }
        }

        public void NotVacantError()
        {
            _error = true;
            Console.WriteLine();
            Console.WriteLine("Error: box not vacant!");
            Console.WriteLine("Press any key to try again..");
            Console.ReadKey();
            return;
        }

        public void DisplayLoss()
        {
            Console.WriteLine();
            Console.WriteLine("No one won.");
            Console.ReadKey();
            Environment.Exit(1);
        }

        private bool hasError;

        public bool _error
        {
            get { return hasError; }
            set { hasError = value; }
        }

        static void Main()
        {
            int moveCount = 0; // check loss
            char askMove; // display X or Y in question
            int selTemp;
            Program prog = new Program();
            prog._error = false;
            prog.box1 = ' ';
            prog.box2 = ' ';
            prog.box3 = ' ';
            prog.box4 = ' ';
            prog.box5 = ' ';
            prog.box6 = ' ';
            prog.box7 = ' ';
            prog.box8 = ' ';
            prog.box9 = ' ';
            prog.isY = true;
            Console.WriteLine(" -- Tic Tac Toe -- ");
            Thread.Sleep(1200);
            Console.Clear();
            while (!prog.isWin)
            {
                if (moveCount == 9)
                {
                    prog.DisplayLoss();
                }
                if ((prog.isY) == true) // if is X
                {
                    askMove = 'X';
                }
                else
                {
                    askMove = 'Y';
                }
                Console.Clear();
                prog.WriteBoard();
                Console.WriteLine();
                Console.WriteLine("What box do you want to place {0} in? (1-9)", askMove);
                Console.Write("> ");
                selTemp = int.Parse(Console.ReadLine());
                switch (selTemp)
                {
                    case 1:
                        if (prog.box1 == ' ')
                        {
                            prog.box1 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }
                        break;
                    case 2:
                        if (prog.box2 == ' ')
                        {
                            prog.box2 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }
                        break;
                    case 3:
                        if (prog.box3 == ' ')
                        {
                            prog.box3 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }
                        break;
                    case 4:
                        if (prog.box4 == ' ')
                        {
                            prog.box4 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }
                        break;
                    case 5:
                        if (prog.box5 == ' ')
                        {
                            prog.box5 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }
                        break;
                    case 6:
                        if (prog.box6 == ' ')
                        {
                            prog.box6 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }
                        break;
                    case 7:
                        if (prog.box7 == ' ')
                        {
                            prog.box7 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }
                        break;
                    case 8:
                        if (prog.box8 == ' ')
                        {
                            prog.box8 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }
                        break;
                    case 9:
                        if (prog.box9 == ' ')
                        {
                            prog.box9 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }
                        break;
                    default:
                        Console.WriteLine("Wrong selection entered!");
                        Console.WriteLine("Press any key to try again..");
                        Console.ReadKey();
                        prog._error = true;
                        break;
                }
                if (prog._error)
                {
                    prog.CheckWin(); // if error, just check win
                    prog._error = !prog._error;
                }
                else
                {
                    prog.isY = !prog.isY; // flip boolean
                    prog.CheckWin();
                }
            }
            Console.Clear();
            prog.WriteBoard();
            Console.WriteLine();
            Console.WriteLine("The winner is {0}!", prog.winPerson);
            Console.ReadKey();
        }
    }
}
