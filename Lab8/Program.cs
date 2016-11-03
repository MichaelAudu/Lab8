using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                bool continueOn = false;
                do
                {
                    Console.Clear();
                    int atBats;
                    bool isNum;
                    do
                    {
                        Console.WriteLine("Enter Number of Times at Bat");
                        isNum = validate(0, 60, Console.ReadLine(), out atBats);

                    } while (!isNum);

                    int[] aBs = new int[atBats];
                    int currentBat = 0;

                    do
                    {
                        int result;
                        Console.Write("Result for at Bat {0}:", currentBat + 1);
                        bool validEntry = validate(0, 4, Console.ReadLine(), out result);

                        if (validEntry)
                        {

                            aBs[currentBat] = result;
                            currentBat++;

                        }

                    } while (currentBat <= atBats - 1);

                    double battingPercentage, sluggingPercentage;
                    battingStatistics(aBs, out battingPercentage, out sluggingPercentage);
                    Console.WriteLine("Batting Percentage: {0}", battingPercentage.ToString("0.000"));
                    Console.WriteLine("Slugging Percentage: {0}", sluggingPercentage.ToString("0.000") + Environment.NewLine);
                    Console.WriteLine("Continue With Another Batter (Y/N?)");
                    string answer = Console.ReadLine().ToLower();
                    continueOn = answer == "y" ? true : false;
                } while (continueOn);
            }
            catch (System.OverflowException ex)
            {

                Console.WriteLine("Number is Out of Range");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        




        public static void battingStatistics(int[] aBs, out double battingPercentage, out double sluggingPercenatage)
        {
            int strikeOut =0;
            int totalBases = 0;

            foreach (int c in aBs)
            {
                if (c < 1)
                {
                    strikeOut += 1;
                    
                }
                totalBases += c;
            }

            battingPercentage = ((double)aBs.Length - (double)strikeOut )/ ((double)aBs.Length);
            sluggingPercenatage = (double)totalBases/ (double)aBs.Length;
        }




        public static bool validate(int min, int max, string input, out int number)
        {
            int comNumber;
            bool isInt = int.TryParse(input, out comNumber);

            if (!isInt)
            {
                number = -1;
                return false;
            }
            else
            {
                if (comNumber < min || comNumber > max)
                {
                    number = -1;
                    return false;
                }
                else
                {
                    number = comNumber;
                    return true;
                }
            }
        }
    }

    
  
}
