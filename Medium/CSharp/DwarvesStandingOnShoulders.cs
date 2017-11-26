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
        int numberOfNodes = int.Parse(Console.ReadLine()); // the number of relationships of influence
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

       
        for (int i = 0; i < numberOfNodes; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int x = int.Parse(inputs[0]); // a relationship of influence between two people (x influences y)
            int y = int.Parse(inputs[1]);
            Console.Error.WriteLine("x: " + x +  " influences y: " + y); 
             
             //Does x exist in the dictionary?
             if(!graph.ContainsKey(x)){
                   graph.Add(x, new List<int>(){y});
             }
             else{
                  graph[x].Add(y);
             }
        }

        int maxCount = 0;
    
        foreach(KeyValuePair<int, List<int>> kv in graph)
        {
            int temp = countRelationships(kv.Key, graph);
            if (temp > maxCount)
                maxCount = temp;
        }

        Console.WriteLine(maxCount);
    }
    
   
    public static int countRelationships(int node, Dictionary<int, List<int>> _graph)
    {
        if (_graph.ContainsKey(node))
        {
            int maxCount = 0; 
            
            foreach (int influenced in _graph[node])
            {
                int temp = countRelationships(influenced, _graph); //Recursive to find all the influenced nodes
             
                if (temp > maxCount)
                    maxCount = temp;
            }
            return maxCount + 1;
        }
        else
            return 1;
    }
    
}