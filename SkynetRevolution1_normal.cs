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
    struct Node{
        
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
        
       
    }
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int numberOfNodes = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
        int numberOfLinks = int.Parse(inputs[1]); // the number of links
        int numberOfExitGateways = int.Parse(inputs[2]); // the number of exit gateways
        
        List<Node> nodes = new List<Node>();
     
        
        for(int i =0; i < numberOfNodes; i++){
            nodes.Add(new Node(i));
            
        }
        for (int i = 0; i < numberOfLinks; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
            int N2 = int.Parse(inputs[1]);
            
            Console.Error.WriteLine("Node " + N1 + " links with " + N2);

            nodes[N1].AddNeighbour(N2);
            nodes[N2].AddNeighbour(N1);
        }
        
        for (int i = 0; i < numberOfExitGateways; i++)
        {
            int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            
            for(int j=0; j < nodes.Count; j++){
                
                  if(nodes[j].ID==EI){
                      nodes[j] =  new Node(EI, true);
                }
            }
            
        }
        

        // game loop
        while (true)
        {
            int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Skynet agent is positioned this turn
 
             //Check if the current skynet agent position links with a gateway node
             Node currentSkynetNode = new Node();
             List<int> skynetneighbourNodes = new List<int>();
             
             foreach(Node n in nodes){
                 if (n.ID==SI){
                     currentSkynetNode = n;
                     skynetneighbourNodes = currentSkynetNode.GetNeighbours();
                       
                 }
             }
    
           
            //Delete gateway node
            bool hasNeighbourgateway=false;
            
             foreach(int neighbourID in skynetneighbourNodes){ 
              
               foreach(Node n in nodes){
                 if (n.ID==neighbourID){
                 
                    if(n.isGateway){
                     hasNeighbourgateway = true;
                     Console.WriteLine(""+ currentSkynetNode.ID + " " + n.ID);
                    
                    }
                 }
                }
             }

           if(!hasNeighbourgateway){
               
              Console.WriteLine(""+ currentSkynetNode.ID + " " + currentSkynetNode.neighbours.FirstOrDefault());
             }
            
        }
    }
}