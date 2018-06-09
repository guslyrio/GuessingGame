using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoplonGuessingGame
{
    public class Node
    {
        // Private member-variables
        private String question;
        private Node yes;
        private Node no;

        //constructors
        public Node() { }
        public Node(String question) : this(question, null, null) { }
        public Node(String question, Node yes, Node no)
        {
            this.question = question;
            this.yes = yes;
            this.no = no;
        }

        //methods
        public String GetQuestion()
        {
            return this.question;
        }

        public void SetQuestion(String question)
        {
            this.question = question;
        }

        public Node GetYesAnswer()
        {
            return this.yes;
        }

        public void SetYesAnswer(Node yes)
        {
            this.yes = yes;
        }

        public Node GetNoAnswer()
        {
            return this.no;
        }

        public void SetNoAnswer(Node no)
        {
            this.no = no;
        }

        public bool IsQuestion()
        {
            if (this.no == null && this.yes == null)
                return false;
            else
                return true;
        }

        public void Query()
        {
            if (this.IsQuestion())
            {
                //Console.WriteLine(this.message);
                //Console.Write("Enter 'y' for yes and 'n' for no: ");
                //char input = getYesOrNo(); //y or n
                bool input = true;
                if (input)
                    this.yes.Query();
                else
                    this.no.Query();
            }
            else
                this.OnQueryObject();
        }

        public void OnQueryObject()
        {
            //Console.WriteLine("Are you thinking of a(n) " + this.question + "?");
            //Console.Write("Enter 'y' for yes and 'n' for no: ");
            //char input = getYesOrNo(); //y or n
            bool input = true;
            if (input)
            {
                //Console.Write("The Computer Wins\n");
            }
            else
            {
                Console.Write("You win! What were you thinking of?");
                string userAnimal = Console.ReadLine();
                Console.Write("Please enter a question to distinguish a(n) "
                    + this.question + " from " + userAnimal + ": ");
                string userQuestion = Console.ReadLine();
                Console.Write("If you were thinking of a(n) " + userAnimal
                    + ", what would the answer to that question be?");
                input = true;//getYesOrNo(); //y or n

                this.UpdateTree(userAnimal, input);
            }
        }

        private void UpdateTree(String userQuestion, bool answer)
        {
            if (answer)
            {
                this.no = new Node(this.question);
                this.yes = new Node(userQuestion);
            }
            else
            {
                this.yes = new Node(this.question);
                this.no = new Node(userQuestion);
            }
            Console.Write("Thank you my knowledge has been increased");
            this.SetQuestion(userQuestion);
        }
    }
}
