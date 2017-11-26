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
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int buildingWidth = int.Parse(inputs[0]); // width of the building.
        int buildingHeight = int.Parse(inputs[1]); // height of the building.
        int maxNumberOfJumps = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
        inputs = Console.ReadLine().Split(' ');
    
        int batmanStartPosX = int.Parse(inputs[0]);
        int batmanStartPosY = int.Parse(inputs[1]);

        
        Console.Error.WriteLine("Batman starting pos [x,y]=[" + batmanStartPosX +", "+batmanStartPosY + "]");
       int newBatmanPosX = batmanStartPosX;
       int newBatmanPosY = batmanStartPosY;
       
       int left = 0;
       int top = 0;
       int right = buildingWidth;
       int bottom = buildingHeight;
       
        // game loop
        while (true)
        {
            string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)
            
            Console.Error.WriteLine("Bomb direction: " + bombDir);
            

            if(bombDir.Contains('U')){
                 bottom = newBatmanPosY;
            }
            
            if(bombDir.Contains('D')){
                 top = newBatmanPosY;
            }
            
            if(bombDir.Contains('L')){
                right = newBatmanPosX;
            }
            if(bombDir.Contains('R')){
                left = newBatmanPosX;
            }
            
            newBatmanPosY = (top + bottom)/2;
            newBatmanPosX = (left + right)/2;
    
     
            Console.WriteLine(""+newBatmanPosX+ " " +newBatmanPosY);
        }
    }
    
}