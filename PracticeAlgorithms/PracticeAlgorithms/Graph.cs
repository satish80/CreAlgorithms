using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithms
{
    public class Graph
    {
        public Dictionary<int, List<int>> AdjList;
        public int Vertex;
        public bool[] Visited;

        public Graph(int Vertex)
        {
            this.Vertex = Vertex;
            AdjList = new Dictionary<int, List<int>>(Vertex);
            Visited = new bool[Vertex];
        }

        public void AddEdge(int Vertex, int Weight)
        {
            if (AdjList.Count == 0 || !AdjList.ContainsKey(Vertex))
            {
                var list = new List<int>();
                list.Add(Weight);
                AdjList.Add(Vertex, list);
            }
            else if (AdjList.ContainsKey(Vertex))
            {
                AdjList[Vertex].Add(Weight);
            }

            //if (AdjList.Count == 0 || !AdjList.ContainsKey(Vertex))
            //{
            //    var list = new List<int>();
            //    list.Add(Weight);
            //    AdjList.Add(Vertex, list);
            //}
            //else if (AdjList.ContainsKey(Vertex))
            //{
            //    AdjList[Vertex].Add(Weight);
            //}

            //if (!AdjList.ContainsKey(Weight))
            //{
            //    var list = new List<int>();
            //    list.Add(Vertex);
            //    AdjList.Add(Weight, list);
            //}
            //else if (AdjList.ContainsKey(Weight))
            //{
            //    AdjList[Weight].Add(Vertex);
            //}
        }

        public void TraverseGraph(Graph graph)
        {
            for(int i=0; i < graph.AdjList.Count -1; i++)
            {
                if(!Visited[i])
                {
                    DFSGraphTraverse(graph, i);
                }
            }
        }

        private void DFSGraphTraverse(Graph graph, int Vertex)
        {
            Visited[Vertex] = true;

            List<int> adjList = graph.AdjList[Vertex];

            for(int i= 0; i < adjList.Count; i++)
            {
                if(! Visited[adjList[i]] && ! Visited[adjList[i]])
                {
                    DFSGraphTraverse(graph, adjList[i]);
                }
            }
        }

        public void TopologicalSort()
        {
            Stack<int> stack = new Stack<int>();

            for(int i= 0; i< Vertex; i++)
            {
                if(! Visited[i])
                {
                    TopologicalUtil(i, stack);
                }
            }

            while(stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }

        private void TopologicalUtil(int V, Stack<int> stack)
        {
            Visited[V] = true;

            if (AdjList.ContainsKey(V))
            {
                for (int vertex = 0; vertex < AdjList[V].Count; vertex++)
                {
                    if (!Visited[vertex])
                    {
                        TopologicalUtil(vertex, stack);
                    }
                }
            }

            stack.Push(V);
        }

        public void IsCyclic()
        {
            bool[] visited = new bool[Vertex];
            bool[] recStack = new bool[Vertex];

            Console.WriteLine(IsCyclicUtil(0, visited, ref recStack));
        }

        private bool IsCyclicUtil(int vertex, bool[] visited, ref bool[] recStack)
        {
            if(! visited[vertex])
            {
                visited[vertex] = true;
                recStack[vertex] = true;

                if (AdjList.ContainsKey(vertex))
                {
                    foreach (int idx in AdjList[vertex])
                    {
                        if (!visited[idx] && IsCyclicUtil(idx, visited, ref recStack))
                        {
                            return true;
                        }
                        else if (recStack[idx])
                        {
                            return true;
                        }
                    }
                }
            }

            recStack[vertex] = false;
            return false;
        }
        public void IsCyclicUndirected()
        {
            Graph g = new Graph(4);
            g.AddEdge(0, 1);
            g.AddEdge(1, 2);
            g.AddEdge(2, 3);

            IsCyclicUndirected(g);
        }

        public void IsCyclicUndirected(Graph g)
        {
            bool result = false;
            //bool[] Visited = new bool[g.Vertex];

            for (int idx = 0; idx < g.Vertex; idx++)
            {
                if (!g.Visited[idx])
                {
                    if (IsUndirectedCyclicUtil(g, idx, idx))
                    {
                        result = true;
                        break;
                    }
                }
            }
            Console.WriteLine(result);
        }
        
        private bool IsUndirectedCyclicUtil(Graph g, int Vertex, int Parent)
        {
            g.Visited[Vertex] = true;

            if (g.AdjList.ContainsKey(Vertex))
            {
                foreach (int idx in g.AdjList[Vertex])
                {
                    if (!g.Visited[idx])
                    {
                        if (IsUndirectedCyclicUtil(g, idx, Vertex))
                        {
                            return true;
                        }
                    }
                    else if (idx != Parent)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void FindMinTreeHeight()
        {
            Console.WriteLine("Min is {0}", MinTreeHeight(0));
        }

        private int MinTreeHeight(int V)
        {
            int count = 0;
            int min = 0;
            HashSet<int> dict = new HashSet<int>();
            for(int idx = 0; idx < this.Vertex; idx ++)
            {
                if(!this.Visited[idx])
                {
                    TreeHeightUtil(idx, ref min, idx, ref dict);
                    if(min == 0 || count < min)
                    {
                        min = count;
                    }
                }
            }
            return min;
        }

        private void TreeHeightUtil(int V, ref int min,  int parent, ref HashSet<int> dict)
        {
            if(AdjList[V].Count == 1 && AdjList[V][0] == parent && !dict.Contains(parent))
            {
                dict.Add(parent);
                Console.WriteLine("Min Tree: {0}", parent);
                
                return;
            }
            else
            {
                if(!Visited[V])
                {   
                    foreach (int idx in AdjList[V])
                    {
                        if(AdjList[V][AdjList[V].Count -1] == idx)
                        {
                            Visited[V] = true;
                        }

                        TreeHeightUtil(idx, ref min, V, ref dict);
                    }
                }
            }

            return;
        }

        public void SourceToDestMatrixBfs()
        {
            HashSet<Tuple<int, int>> map = new HashSet<Tuple<int, int>>();
            int[,] arr = new int[2, 2]
            {
                { 1, 2},
                {4, 5 }
            };

            Console.WriteLine(TraverseAdjNodesBfs(map, arr));
        }

        private int TraverseAdjNodesBfs(HashSet<Tuple<int, int>> map, int[,] arr)
        {
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(0, 0));
            bool reached = false;
            int count = 0;

            while(queue.Count > 0)
            {
                var item = queue.Dequeue();
                int row = item.Item1;
                int col = item.Item2;

                Tuple<int, int> right = null;
                Tuple<int, int> down = null;

                if (map.Contains(new Tuple<int, int>(row, col)) && reached)
                {
                     count++;
                }

                if (col < arr.GetUpperBound(1))
                {
                    if(map.Contains(new Tuple<int, int> (row, col +1)) )
                    {
                        if(reached)
                        {
                            count++;
                        }

                        continue;
                    }

                    right = new Tuple<int, int>(row, ++col);
                    map.Add(right);
                    queue.Enqueue(right);

                    if (row == arr.GetUpperBound(0) && col == arr.GetUpperBound(1))
                    {
                        reached = true;
                        count++;
                    }
                }

                if(row < arr.GetUpperBound(0))
                {
                    if (map.Contains(new Tuple<int, int>(row +1 , col)))
                    {
                        if (reached)
                        {
                            count++;
                        }

                        continue;
                    }
                    down = new Tuple<int, int>(++row, col);
                    map.Add(down);
                    queue.Enqueue(down);

                    if (row == arr.GetUpperBound(0) && col == arr.GetUpperBound(1))
                    {
                        reached = true;
                        count++;
                    }
                }
            }

            return count;
        }

        //public void BfsPathToNode()
        //{
        //    Graph g = new Graph(4);
        //    g.AddEdge(0, 1);
        //    g.AddEdge(0, 2);
        //    g.AddEdge(0, 3);
        //    g.AddEdge(1, 3);
        //    g.AddEdge(2, 0);
        //    g.AddEdge(2, 1);

        //    var result = BfsPathToNode(g, 2, 3);
        //    foreach(Stack<int> map in result)
        //    {

        //    }
        //}

        //private List<Stack<int>> BfsPathToNode(Graph g, int v, int end)
        //{
        //    var result = new List<Stack<int>>();
        //    Stack<Tuple<int, int>> map = new Stack<Tuple<int, int>>();
        //    Queue<Tuple<int, int>> paths = new Queue<Tuple<int, int>>();
        //    int level = 0;
        //    //paths.Enqueue(v);

        //    while(paths.Count > 0)
        //    {
        //        Tuple<int,int> vertex = paths.Dequeue();
        //        map.Push(new Tuple<int, int>(level, vertex.Item2));

        //        //g.Visited[vertex] = true;

        //        if(! g.AdjList.ContainsKey(vertex.Item2))
        //        {
        //            continue;
        //        }

        //        foreach(int adjVertex in g.AdjList[vertex.Item2])
        //        {
        //            if(adjVertex  == end)
        //            {
        //                result.Add(map);
        //                map.Pop();
        //            }

        //            if (! g.Visited[adjVertex])
        //            {
        //                paths.Enqueue(adjVertex);
        //            }
        //        }
        //    }

        //return result;
        //}

        public void CheckPathExistence()
        {
            DirectedGraph g = new DirectedGraph(6);
            g.AddEdge(0, 1);
            g.AddEdge(1, 2);
            g.AddEdge(2, 3);
            g.AddEdge(4, 5);

            Console.WriteLine(DoesPathExist(g, 4, 5));
        }

        private bool DoesPathExist(DirectedGraph g, int source, int target)
        {
            if(g == null || g.AdjList.Count == 0)
            {
                return false;
            }

            if (!g.AdjList.ContainsKey(source))
            {
                return false;
            }

            bool result = false;
            
            foreach(int vertex in g.AdjList[source])
            {
                if(! g.Visited[vertex])
                {
                    result = DoesPathExistUtil(g, vertex, target);
                    if(result)
                    {
                        return result;
                    }
                }
            }

            return result;
        }

        private bool DoesPathExistUtil(DirectedGraph g, int source, int target)
        {
            bool result = false;

            if(source == target)
            {
                return true;
            }

            if(! g.AdjList.ContainsKey(source))
            {
                return false;
            }

            if( g.AdjList[source].Contains(target))
            {
                return true;
            }

            foreach(int vertex in g.AdjList[source])
            {
                if(!g.Visited[vertex] && !result)
                {
                    result = DoesPathExistUtil(g, vertex, target);
                    g.Visited[vertex] = true;
                }
            }

            return false;
        }

        public void FindSameContacts()
        {
            contact c1 = new contact()
            {
                field1 = "Gaurav",
                field2 = "gaurav@gmail.com",
                field3 = "gaurav@gfgQA.com"
            };

            contact c2 = new contact()
            {
                field1 = "Lucky",
                field2 = "lucky@gmail.com",
                field3 = "+1234567"
            };

            contact c3 = new contact()
            {
                field1 = "gaurav123",
                field2 = "+5412312",
                field3 = "gaurav123@skype.com"
            };

            contact c4 = new contact()
            {
                field1 = "gaurav1993",
                field2 = "+5412312",
                field3 = "gaurav@gfgQA.com"
            };

            contact c5 = new contact()
            {
                field1 = "raja",
                field2 = "+2231210",
                field3 = "raja@gfg.com" 
            };

            contact c6 = new contact()
            {
                field1 = "bahubali",
                field2 = "+878312",
                field3 = "raja"
            };


            contact[] contacts = new contact[]
            {
               c1, c2, c3, c4, c5, c6
             };

            FindSameContactsUtil(contacts);
        }

        private void FindSameContactsUtil(contact[] contacts)
        {
            List<int> sol = new List<int>();
            int[,] mat = new int[contacts.Length, contacts.Length];

            for(int row = 0; row < contacts.Length; row ++)
            {
                for(int col = row +1; col < contacts.Length; col ++)
                {
                    if(contacts[row].field1 == contacts[col].field1 ||
                       contacts[row].field1 == contacts[col].field2 ||
                       contacts[row].field1 == contacts[col].field3 ||
                       contacts[row].field2 == contacts[col].field1 ||
                       contacts[row].field2 == contacts[col].field2 ||
                       contacts[row].field2 == contacts[col].field3 ||
                       contacts[row].field3 == contacts[col].field1 ||
                       contacts[row].field3 == contacts[col].field2 ||
                       contacts[row].field3 == contacts[col].field3)
                    {
                        mat[row, col] = 1;
                        mat[col, row] = 1;
                        break;
                    }
                }
            }

            for(int idx = 0; idx < contacts.Length; idx ++)
            {
                if(!Visited[idx])
                {
                    DFS_Visit(idx, mat, sol, contacts.Length);
                    sol.Add(-1);
                }
            }

            for (int i = 0; i < sol.Count; i++)
            {
                if (sol[i] == -1)
                {
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.WriteLine(sol[i]);
                }
            }
        }

        private void DFS_Visit(int idx, int[,] mat, List<int> sol, int n)
        {
            Visited[idx] = true;

            sol.Add(idx);

            for (int j = 0; j < n; j++)
            {
                if (mat[idx, j] == 1 && !Visited[j])
                {
                    DFS_Visit(j, mat, sol, n);
                }
            }
        }

        struct contact
        {
            public string field1, field2, field3;
        };
    }
}

public class DirectedGraph
{
    public Dictionary<int, List<int>> AdjList;
    public int Vertex;
    public bool[] Visited;

    public DirectedGraph(int Vertex)
    {
        this.Vertex = Vertex;
        AdjList = new Dictionary<int, List<int>>(Vertex);
        Visited = new bool[Vertex];
    }

    public void AddEdge(int Vertex, int Weight)
    {
        if (AdjList.Count == 0 || !AdjList.ContainsKey(Vertex))
        {
            var list = new List<int>();
            list.Add(Weight);
            AdjList.Add(Vertex, list);
        }
        else if (AdjList.ContainsKey(Vertex))
        {
            AdjList[Vertex].Add(Weight);
        }
    }
}