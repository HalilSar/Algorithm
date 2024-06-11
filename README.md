# Algorithm Implementations in C#

## Description 
This project provides implementations of various common algorithms in C#. Each algorithm includes basic operations and demonstrates usage with example code.

## Features 
- Sorting Algorithms 
  - Bubble Sort
  - Insertion Sort
  - Quick Sort
  - Merge Sort
- Searching Algorithms 
  - Linear Search
  - Binary Search
- Graph Algorithms 
  - Depth-First Search (DFS)
  - Breadth-First Search (BFS)
  - Dijkstra's Algorithm

## Installation (Kurulum)
1. Clone the repository:
   sh
   git clone https://github.com/HalilSar/Algorithm.git
   
2. Open the project in Visual Studio or your preferred C# IDE.

## Usage
### Sorting Algorithms 
```csharp
int[] array = { 5, 2, 9, 1, 5, 6 };
SortingAlgorithms.BubbleSort(array);
```

### Searching Algorithms 
```csharp
int[] array = { 1, 2, 3, 4, 5 };
int index = SearchingAlgorithms.BinarySearch(array, 3);
```

### Graph Algorithms 
```csharp
Graph graph = new Graph();
graph.AddEdge(0, 1);
graph.AddEdge(0, 2);
GraphAlgorithms.DepthFirstSearch(graph, 0);
```

## FAQ
  + *What algorithms are included?*
   - Sorting, searching, and graph algorithms are included.


---

This README provides a clear overview of the project, its features, and how to use the various algorithms implemented in C#.
