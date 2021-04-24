using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitFights
{
    class Program
    {
        static private Random randItem = new();
        /*
        static private Unit @mage = new Mage();
        static private Unit @archer = new Archer();
        static private Unit @swordsman = new SwordsMan();
        */
        static void Main(string[] args)
        {
            List<Unit> TeamRed = new();
            List<Unit> TeamBlue = new();
            int Winner = 0;//1 - win red, 2 - win blue, 3 - tie
            int RoundCounter = 0;

            GenerateTeamRed(TeamRed);
            GenerateTeamBlue(TeamBlue);

            ConsoleKeyInfo pressedButton;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\t\tPress space to start!");
            Console.ResetColor();
            pressedButton = Console.ReadKey();
            Console.Clear();

            while (pressedButton.Key != ConsoleKey.Escape && pressedButton.Key == ConsoleKey.Spacebar && !ChooseWinner(TeamRed, TeamBlue, out Winner))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Team red:");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\tTeam blue:");
                Console.ResetColor();

                for (int i = 0; i < 3; i++)
                {
                    if(i < TeamRed.Count)
                    {
                        Console.Write($"{TeamRed[i].GetType().Name} Hp:{TeamRed[i].HealthPoints} Damage:{TeamRed[i].DamagePoints}\t\t");
                    }
                    else
                    {
                        Console.Write("\t\t\t\t");
                    }
                    if (i < TeamBlue.Count)
                    {
                        Console.WriteLine($"{TeamBlue[i].GetType().Name} Hp:{TeamBlue[i].HealthPoints} Damage:{TeamBlue[i].DamagePoints}");
                    }
                    else
                    {
                        Console.Write("\t\t\t");
                    }
                }
                Console.WriteLine();

                OneRound(TeamRed, TeamBlue, ref RoundCounter);
                CheckDeadHeroes(TeamRed, TeamBlue);
                pressedButton = Console.ReadKey();
            }

            switch(Winner)
            {
                case 1:
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\tTeam red won!");
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n\tTeam blue won!");
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\tIt's time for tie!");
                        break;
                    }
            }
        }

        static void OneRound(List<Unit> TeamRed, List<Unit> TeamBlue, ref int RoundCounter)
        {
            Random random = new();
            int UnitChoice, TeamRedId, TeamBlueId, DefenderId;
            Unit Attacker, Defender;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Round: {RoundCounter + 1}");
            Console.ResetColor();

            if (RoundCounter % 2 == 0)   //TeamRed step
            {
                UnitChoice = random.Next(TeamRed.Count);
                Attacker = TeamRed[UnitChoice];
                Defender = ChooseDefender(Attacker, TeamBlue);

                DefenderId = TeamBlue.IndexOf(Defender);
                TeamRedId = 1;
                TeamBlueId = 2;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nTeam red");
            }
            else   //TeamBlue step
            {
                UnitChoice = random.Next(TeamBlue.Count);
                Attacker = TeamBlue[UnitChoice];
                Defender = ChooseDefender(Attacker, TeamRed);

                DefenderId = TeamRed.IndexOf(Defender);
                TeamRedId = 2;
                TeamBlueId = 1;

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\nTeam blue");
            }

            Console.Write($" {Attacker.GetType().Name}{TeamRedId}{UnitChoice + 1} attacked {Defender.GetType().Name}{TeamBlueId}{DefenderId + 1} ");
            if(HitDefender(Attacker,Defender))
            {
                Console.WriteLine("succesfully!");
            }
            else
            {
                Console.WriteLine("unsuccesfully!");
            }

            Console.WriteLine($"{Attacker.GetType().Name}{TeamRedId}{UnitChoice + 1} Health:{Attacker.HealthPoints}\t{Defender.GetType().Name}{TeamBlueId}{DefenderId + 1} Health:{Defender.HealthPoints}");

            Console.ResetColor();
            Console.WriteLine("\t\tPress space for next step!");
            RoundCounter++;
        }

        static bool HitDefender(Unit Attacker, Unit Defender)
        {
            Random random = new();
            int HitChance = random.Next(100);

            if(HitChance > Attacker.MissChance)
            {
                Defender.HealthPoints -= Attacker.DamagePoints;
                return true;
            }

            return false;
        }
        static Unit ChooseDefender(Unit Attacker, List<Unit> Defenders)
        {
            foreach(var defender in Defenders)
            {
                if(defender.GetType().Equals(Attacker.GetType()))
                {
                    return defender;
                }
            }

            Random random = new();
            int ChDefender = random.Next(Defenders.Count);
            return Defenders[ChDefender];
        }
        static void CheckDeadHeroes(List<Unit> TeamRed, List<Unit> TeamBlue)
        {
            for(int i = 0; i < TeamRed.Count; i++)
            {
                if(!TeamRed[i].IsAlive)
                {
                    TeamRed.RemoveAt(i);
                }
            }
            for (int i = 0; i < TeamBlue.Count; i++)
            {
                if (!TeamBlue[i].IsAlive)
                {
                    TeamBlue.RemoveAt(i);
                }
            }
        }
        static bool ChooseWinner(List<Unit> TeamRed, List<Unit> TeamBlue, out int Winner)//1 - win red, 2 - win blue, 0 - tie
        {
            if (TeamRed.Count == 0)
            {
                Winner = 2;
                return true;
            }
            else if (TeamBlue.Count == 0)
            {
                Winner = 1;
                return true;
            }
            else if (TeamBlue.Count == 0 && TeamRed.Count == 0)
            {
                Winner = 3;
                return true;
            }
            Winner = 0;
            return false;
        }
        static void GenerateTeamRed(List<Unit> TeamRed)
        {
            for (int i = 0; i < 3; i++)
            {
                switch (randItem.Next(0, 3))
                {
                    case 0:
                        {
                            TeamRed.Add(new Mage());
                            break;
                        }
                    case 1:
                        {
                            TeamRed.Add(new Archer());
                            break;
                        }
                    case 2:
                        {
                            TeamRed.Add(new SwordsMan());
                            break;
                        }
                }
            }
        }
        static void GenerateTeamBlue(List<Unit> TeamBlue)
        {
            for (int i = 0; i < 3; i++)
            {
                switch (randItem.Next(0, 3))
                {
                    case 0:
                        {
                            TeamBlue.Add(new Mage());
                            break;
                        }
                    case 1:
                        {
                            TeamBlue.Add(new Archer());
                            break;
                        }
                    case 2:
                        {
                            TeamBlue.Add(new SwordsMan());
                            break;
                        }
                }
            }
        }
    }
}
