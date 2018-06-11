using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Microsoft.VisualBasic;

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
                MessageBoxResult result = System.Windows.MessageBox.Show("Does the animal that you tought about " + this.GetQuestion() + "?", "Guessing Game", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                    this.yes.Query();
                else
                    this.no.Query();
            }
            else
                this.OnQueryObject();
        }

        public void OnQueryObject()
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Are you thinking about a " + this.GetQuestion() + "?", "Guessing Game", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                System.Windows.MessageBox.Show("I won.\n", "Guessing Game");                
            }
            else
            {
                this.UpdateTree();                
            }
        }

        private void UpdateTree()
        {
            string animal ="";
            DialogResult userAnimalResult = InputDialog.Show("What was the animal that you tought about?", "Guessing Game", ref animal);

            string question = "";
            DialogResult userQuestionResult = InputDialog.Show("A " + animal + "______ but a " + this.GetQuestion() + " does not (Fill it with an animal trait, like lives in water", "Guessing Game", ref question);
            this.no = new Node(this.question);
            this.yes = new Node(animal);
            //}
            //else
            //{
            //    this.yes = new Node(this.question);
            //    this.no = new Node(userQuestion);
            //}
            System.Windows.MessageBox.Show("Thank you I am getting smarter!", "Guessing Game");
            this.SetQuestion(question);            
        }
    }
}
