using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Don't let the machines win. You are humanity's last hope...
 **/
class Player
{

 
    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
        int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis

 
        char[,] charArray = new char[height, width];
        
    
        for (int i = 0; i < height; i++)
        {
            // width characters, each either 0 or .
            string line = Console.ReadLine();

             for(int j = 0; j < width; j++){

               //  charArray[i,j]=line[j];
                 if(line[j]=='0'){
                      charArray[i,j] = line[j];
                 }
                     
                }
              
        }
    
          for (int i = 0; i < height; i++){

            for(int j=0; j < width; j++){
                 string outputString = "";
                 string nodeString = "";
                 string rightNeighbourString = "-1 -1";
                 string bottomNeighbourString = "-1 -1";
                 
                if(j < width && i < height && charArray[i,j]=='0')
                {
                    nodeString = j + " " + i + " ";
                    
                    //Check the row until you find a 0
                    for(int k = j+1; k< width; k++){
                         if(charArray[i, k]=='0'){
                            int nextX = k;
                   
                            rightNeighbourString = nextX + " " + i;
                            break;
                         }
                    }
                    //Check the column until you find a 0
                   for(int k = i+1; k< height; k++){
                       if(charArray[k, j]=='0'){
                        int nextY = k;
                        bottomNeighbourString = j + " " + nextY;
                        break;
                       }
                   }
                    outputString = nodeString + " " + rightNeighbourString + " " + bottomNeighbourString; 
                    Console.WriteLine(outputString);
                }
                
            }
            
        }
 
    }
}