// Mohamed Nagy Mohamed - 225102507

using System;

namespace CselllTask1
{
    public class StudentList
    {
        public Student? First { get; private set; }
        public Student? Last { get; private set; }
        public int Count { get; private set; }

        public StudentList()
        {
            First = null;
            Last = null;
            Count = 0;
        }

        public void AddFront(int id)
        {
            Student newStudent = new Student(id);
            if (Count == 0)
            {
                First = newStudent;
                Last = newStudent;
            }
            else
            {
                newStudent.Next = First;
                First = newStudent;
            }
            Count++;
        }

        public void AddEnd(int id)
        {
            Student newStudent = new Student(id);
            if (Count == 0)
            {
                First = newStudent;
                Last = newStudent;
            }
            else
            {
                Last!.Next = newStudent;
                Last = newStudent;
            }
            Count++;
        }

        public bool Remove(int id)
        {
            if (Count == 0) return false;

            if (First!.Id == id)
            {
                First = First.Next;
                Count--;
                if (Count == 0) Last = null;
                return true;
            }

            Student current = First;
            while (current.Next != null)
            {
                if (current.Next.Id == id)
                {
                    if (current.Next == Last)
                    {
                        Last = current;
                    }
                    current.Next = current.Next.Next;
                    Count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Reverse()
        {
            if (Count <= 1) return;

            Student? prev = null;
            Student? current = First;
            Last = First;

            while (current != null)
            {
                Student? nextNode = current.Next;
                current.Next = prev;
                prev = current;
                current = nextNode;
            }
            First = prev;
        }

        public void Print()
        {
            Student? current = First;
            string result = "";
            while (current != null)
            {
                result += current.Id + (current.Next != null ? " " : "");
                current = current.Next;
            }
            Console.WriteLine(result);
        }
    }
}