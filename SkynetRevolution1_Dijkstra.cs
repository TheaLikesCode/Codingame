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
    public class Node{
        
        public Node(int ID=-1, bool isGateway = false){
            this.ID = ID;
            neighbours = new List<int>();
            this.isGateway = isGateway;
        }
        
        public int ID;
        public List<int> neighbours;
        public bool isGateway;
        
        public List<int> GetNeighbours(){
            return neighbours;
        }
      
        public void AddNeighbour(int n){
         neighbours.Add(n);   
        }
        public void SetGateway(bool flag){
            this.isGateway = flag;
        }
    }
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int numberOfNodes = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
        int numberOfLinks = int.Parse(inputs[1]); // the number of links
        int numberOfExitGateways = int.Parse(inputs[2]); // the number of exit gateways
        
        List<Node> nodes = new List<Node>();
        List<Node> exits = new List<Node>();
        
        for(int i =0; i < numberOfNodes; i++){
            nodes.Add(new Node(i));           
        }

        for (int i = 0; i < numberOfLinks; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
            int N2 = int.Parse(inputs[1]);
            
            nodes[N1].AddNeighbour(N2);
            nodes[N2].AddNeighbour(N1);
        }
        
        for (int i = 0; i < numberOfExitGateways; i++)
        {
            int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            
            var gateways = nodes.Where(n=> n.ID==EI);
          
            foreach(var n in gateways){
              n.SetGateway(true);
              exits.Add(n);
          }
          
        }

        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        foreach(Node n in nodes){
            graph[n.ID] = n.GetNeighbours();
        }       

        // game loop
        while (true)
        {
            int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Skynet agent is positioned this turn          
           
            int shortestDist = int.MaxValue;
            List<int> shortestPath = null;
            
            for(int i = 0; i < numberOfExitGateways; i++)
            {
              List<int> path = FindShortestPath(graph, SI, exits[i].ID);
              
                if(path != null && path.Count > 0)
                {
                    if(path.Count < shortestDist)
                    {
                        shortestDist = path.Count;
                        shortestPath = path;
                    }
                }
            }

                int start = SI, end = shortestPath.FirstOrDefault();
                Console.WriteLine(start + " " + end);
        }
    }
    
    public static List<int> FindShortestPath(Dictionary<int, List<int>> graph , int start, int finish)
    {
        List<int> nodes = new List<int>();
        Dictionary<int, int> distances = new Dictionary<int,int>();
        Dictionary<int, int> previous = new Dictionary<int, int>();
        
        
        for(int i = 0; i < graph.Count; i++)
        {
            nodes.Add(i);
            distances[i] = int.MaxValue; //set to infinity
        }
         
        distances[start] = 0; //Starting node has a distance of 0
        
        List<int> path = new List<int>();
        
        while(nodes.Count != 0)
        { 
           nodes.Sort((a, b) => distances[a] - distances[b] );

            int closest = nodes[0];
            nodes.RemoveAt(0);
            
            if(closest == finish)
            {
                 // Found the shortest path
                while(previous.ContainsKey(closest))
                {
                    path.Add(closest);
                    closest = previous[closest];
                }
                break;
            }
            
            if(distances[closest] == int.MaxValue)
            {
                return null;
            }
            
             // Calculate distances
            foreach(int neighbor in graph[closest])
            {
                if(distances[closest] + 1 < distances[neighbor])
                {
                    distances[neighbor] = distances[closest] + 1;
                    previous[neighbor] = closest;
                }
            }
        }
        path.Reverse();
        return path;
   
    }
}