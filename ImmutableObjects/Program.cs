using System;
using System.Collections.Generic;

namespace ImmutableObjects
{
    class Program
    {
        static bool IsHappyHour { get; set; }



        static MoneyAmount Reserve(MoneyAmount cost)
        {
            decimal factor = 1;
            if (IsHappyHour)
            {
                factor =  .5M;
            }
            Console.WriteLine("\n reserving the item costs {0}", cost);
            return cost.Scale(factor);
        }
        static void Buy(MoneyAmount wallet, MoneyAmount cost)
        {
            bool enoughMoney = wallet.Amount > cost.Amount;

            MoneyAmount finalCost = Reserve(cost);

            bool finalEnough = wallet.Amount > finalCost.Amount;

            if (enoughMoney && finalEnough)
                Console.WriteLine("you will pay {0} from your {1}",cost,wallet);
            else if(finalEnough)
                Console.WriteLine("this time, {0} will be enough to pay {1}", wallet,finalCost);
            else
                Console.WriteLine("you cannot pay {0} from your {1}", cost, wallet);



        }
        static void Main(string[] args)
        {
            Buy(new MoneyAmount (12,  "USD"),
                new MoneyAmount (10, "USD"));

            Buy(new MoneyAmount (7,  "USD"),
                new MoneyAmount (10,"USD"));

            IsHappyHour = true;
            Buy(new MoneyAmount (7, "USD" ),
                new MoneyAmount (10, "USD" ));

            //Equality check
            MoneyAmount x = new MoneyAmount(10, "USD");
            MoneyAmount Y = new MoneyAmount(10, "USD");

            if(x.Equals(Y))
                Console.WriteLine("X and Y are equal");


            //Hashcode override
            MoneyAmount a = new MoneyAmount(10, "USD");
            MoneyAmount b = new MoneyAmount(10, "USD");
            
            HashSet<MoneyAmount> sets = new HashSet<MoneyAmount>();

            sets.Add(a);
            if (sets.Contains(b))
                Console.WriteLine("already exist cannot be repeated");
            else
                sets.Add(b); // default Gethashcode impl returns value based on object reference

            Console.WriteLine("Hashset count {0}",sets.Count);



            //Custom Equality check
            MoneyAmount c = new MoneyAmount(10, "USD");
            MoneyAmount d = new MoneyAmount(10, "USD");

            if (c == d)
                Console.WriteLine("X and Y are equal");

            Console.ReadLine();

        }
    }


}
