namespace HugoButa.DataStructure.LinkedList
{
    public interface ILinkedList<T>
    {
        // Empty linked list
        void Clear();
        
        // Return the size of linked list
        int Size();
        
        // Check if the list is empty
        bool IsEmpty();
        
        // Add element to the tail of the linked list, O(1)
        void Add(T element);
        
        // Add element to the beginning of the linked list, O(1)
        void AddFirst(T element);
        
        // Add a note to the tail of the linked list
        void AddLast(T element);
        
        // Check the value of the first node, if it exists, O(1)
        T PeekFirst();
        
        // Check the value of the last node, if it exists, O(1)
        T PeekLast();
        
        // Remove the first value of the list, O(1)
        T RemoveFirst();
        
        // Remove the last value of the list, O(1)
        T RemoveLast();
        
        // Remove a node at a particular index, O(n)
        T RemoveAt(int index);
        
        // Remove a particular value in the linked list, O(n)
        bool Remove(T element);
        
        // Find the index of a particular value in the linked list, O(n)
        int IndexOf(T element);
        
        // Check is a value is contained within the linked list
        bool Contains(T element);
    }
}
