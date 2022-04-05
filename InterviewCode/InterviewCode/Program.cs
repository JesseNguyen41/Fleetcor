using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCode
{
    class BinarySearchTree
    {
        //========================== FIRST PROMPT =================================
        public static int CharCount(string input, char target)
        {
            int count = 0;
            char[] inp = input.ToCharArray();
            for (int i = 0; i < inp.Length; i++)
            {
                if (inp[i] == target)
                    count++;
            }

            return count;
        }

        public static int StrCount(string input, string target)
        {
            int count = 0;
            string temp = "";
            char[] inp = input.ToCharArray();

            for (int i = 0; i < inp.Length; i++)
            {
                temp += inp[i];

                if (temp.Length > target.Length)
                {
                    temp = temp.Remove(0, 1);
                }

                if (temp == target)
                {
                    count++;
                    temp = "";
                }
            }

            return count;
        }
        //============================= SECOND PROMPT ==============================================
        class Node
        {
            public int value;
            public Node left, right;

            public Node(int element)
            {
                value = element;
                left = right = null;
            }
        }

        Node root;

        BinarySearchTree() { root = null; }

        void inorder() { inorderHelper(root); }

        void inorderHelper(Node root)
        {
            if (root != null)
            {
                inorderHelper(root.left);
                Console.WriteLine(root.value);
                inorderHelper(root.right);
            }
        }

        public bool Add(int value)
        {
            Node before = null, after = this.root;

            while (after != null)
            {
                before = after;
                if (value < after.value) //Is new node in left tree? 
                    after = after.left;
                else if (value > after.value) //Is new node in right tree?
                    after = after.right;
                else
                {
                    //Exist same value
                    return false;
                }
            }

            Node newNode = new Node(value);

            if (this.root == null)
                this.root = newNode;
            else
            {
                if (value < before.value)
                    before.left = newNode;
                else
                    before.right = newNode;
            }

            return true;
        }

        //========================================================================================
        public static void Main()
        {
            /*
            Some test cases

            string input = "";
            string input = "AaaAABBbbC";
            string input = "1@#45a!";
            string input = "\na";

            */
            string input = "abcdabaaa";
            char target = 'a';
            string secondTarget = "ab";

            int amt = input.Count(x => x == target);
            int result = StrCount(input, secondTarget);
            Console.WriteLine("Target string count: " + result);


            Console.WriteLine("BST traversal: ");

            BinarySearchTree bst = new BinarySearchTree();

            bst.Add(1);
            bst.Add(2);
            bst.Add(7);
            bst.Add(3);
            bst.Add(10);
            bst.Add(5);
            bst.Add(8);

            bst.inorder();

            Console.WriteLine("Enter a key to close");
            Console.ReadKey();
        }


    }

}
