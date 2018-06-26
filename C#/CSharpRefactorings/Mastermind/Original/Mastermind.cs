using System;
using System.Linq;

namespace CSharpRefactorings.Mastermind.Original
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] g;
            char[] p = new[] {'A', 'A', 'A', 'A'};
            int i = 0;
            int j = 0;
            int x = 0;
            int c = 0;
            Random rand = new Random(DateTime.Now.Millisecond);
            if (args.Length > 0 && args[0] != null) p = args[0].ToCharArray();
            else goto randomize_password;
            guess: Console.Write("Take a guess: ");
            g = Console.ReadLine().ToArray();
            i = i + 1;
            if (g.Length != 4) goto wrong_size;
            if (g == p) goto success;
            x = 0;
            c = 0;
            check_loop:
            if (g[x] > 65 + 25) g[x] = (char) (g[x] - 32);
            if (g[x] == p[x]) Console.Write("+", c = c+1);
            else if (p.Contains(g[x])) Console.Write("-");
            x = x + 1;
            if (x < 4) goto check_loop;
            Console.WriteLine();
            if (c == 4) goto success;
            goto guess;
            success: Console.WriteLine("Congratulations you guessed the password in " + i + " tries.");
            goto end;
            wrong_size: Console.WriteLine("Password length is 4.");
            goto guess;
            randomize_password: j = 0;
            password_loop: p[j] = (char) (rand.Next(6) + 65);
            j = j + 1;
            if (j < 4) goto password_loop;
            goto guess;
            end: Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}
