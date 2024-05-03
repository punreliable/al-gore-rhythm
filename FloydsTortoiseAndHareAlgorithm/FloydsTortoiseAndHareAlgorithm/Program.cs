using System.Collections.Generic;

namespace FloydsTortoiseAndHare
{

    class TortoiseAndHare
    {
        
        public static bool FloydCycleDetection<T>(LinkedList<T> list)
        {
            
            if (list.Count <= 2)
            {
                
                return false;
                
            }

            LinkedListNode<T> tortoise = list.First.Next;
            LinkedListNode<T> hare = list.First.Next.Next;

            while ( tortoise != null && hare != null )
            {
        
                if ( tortoise == hare )
                {
                    
                    return true;
                    
                }

                if ( hare.Next != null )
                {
                    hare = hare.Next.Next;
                    
                }

                tortoise = tortoise.Next;

            }

            return false;

        }
        
    }

}