using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int numberOfOods = int.Parse(Console.ReadLine());
        int giftPrice = int.Parse(Console.ReadLine());
        
        int[] budgetArr = new int[numberOfOods];

        
        for (int i = 0; i < numberOfOods; i++)
        {
            int budget = int.Parse(Console.ReadLine());
            
            budgetArr[i] = budget;
  
        }

        if(budgetArr.Sum() < giftPrice){
            Console.WriteLine("IMPOSSIBLE");
            return;
        }
            
        Array.Sort(budgetArr);
        for(int i=0; i < numberOfOods; i++){
   
            int optimal = giftPrice / (numberOfOods - i);
            
            //Can the Ood pay the optimal share?
            if(budgetArr[i]<=optimal){
                giftPrice -= budgetArr[i];
                Console.WriteLine(budgetArr[i]);
                
            }else{
                giftPrice -= optimal;
                Console.WriteLine(optimal);
                
            }
            
        }

    }
}