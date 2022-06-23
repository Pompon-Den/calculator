using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCalculator
{
   public class Pro1
    {
        public double Answer { get; private set; }
        public string Work_String, History = "";
        public double Operand;
        public enum State { FirstOp, SecondOp };
        public State state = State.FirstOp;
        public bool Correct_Enter = true; 
        public bool Ban_Button = false;
        private double memory = 0;
        private bool Memory_Clear = true;
        public enum Action {  pusto, plus, minus, multiply, divide };
        public Action action = Action.pusto;

        public void MPlus() //кнопка М+
        {
            if (Memory_Clear == false)
            {
                memory += double.Parse(Work_String);
            }
        }
       
        public void MMinus() //кнопка М-
        {
            if (Memory_Clear == false)
            {
                memory -= double.Parse(Work_String);
            }
        }

        public void MSave_Number() //кнопка МS сохранить
        {
            memory = double.Parse(Work_String);
            Memory_Clear = false;
        }
   
        public void MC() //кнопка МC/ удалить
        {
            memory = 0;
            Memory_Clear = true;
        }
        public void MR() //кнопка МR/ показать
        {
            if (Memory_Clear == false)
            {
                Work_String = memory.ToString();
            }
        }
        public void Plus()
        {
            if (Ban_Button == false)
            {
                History += " + ";
                Correct_Enter = false;

                if (state == State.FirstOp)
                {
                    Answer = double.Parse(Work_String);
                    state = State.SecondOp;
                    
                }
                else
                {
                    Operand = double.Parse(Work_String);
                    HelpProcess();
                    
                  
                }
                action = Action.plus;
            }
        }

        public void HelpProcess()
        {
            if (action == Action.plus)
            {
                Answer += Operand;
                Work_String = Answer.ToString();
            }
            if (action == Action.minus)
            {
                Answer -= Operand;
                Work_String = Answer.ToString();
            }
            if (action == Action.multiply)
            {
                Answer *= Operand;
                Work_String = Answer.ToString();
            }
            if (action == Action.divide)
            {
                if (Operand != 0)
                {
                    Answer /= Operand;
                    Work_String = Answer.ToString();
                }
                else
                {
                    Work_String = "Деление на 0 невозможно";
                    Ban_Button = true;
                }
            }
        }
        public void Minus()
        {
            if (Ban_Button == false)
            {
                History += " - ";
                Correct_Enter = false;

                if (state == State.FirstOp)
                {
                    Answer = double.Parse(Work_String);
                    state = State.SecondOp;
                    
                }
                else
                {
                    Operand = double.Parse(Work_String);
                    HelpProcess();
                    Work_String = Answer.ToString();
                    
                }
                action = Action.minus;
            }
        }

        public void Multiply()
        {
            if (Ban_Button == false)
            {
                History += " * ";
                Correct_Enter = false;

                if (state == State.FirstOp)
                {
                    Answer = double.Parse(Work_String);
                    state = State.SecondOp;
                    
                }
                else
                {
                    Operand = double.Parse(Work_String);
                    HelpProcess();
                    Work_String = Answer.ToString();
                }
                action = Action.multiply;
            }
        }

        public void Divide()
        {
            if (Ban_Button == false)
            {
                History += " / ";
                Correct_Enter = false;

                if (state == State.FirstOp)
                {
                    Answer = double.Parse(Work_String);
                    state = State.SecondOp;
                    
                }
                else
                {
                    Operand = double.Parse(Work_String);
                    HelpProcess();
                    Work_String = Answer.ToString();
                }
                action = Action.divide;
            }
        }
    
        public void Revers()
        {
            if (Ban_Button == false)
            {
                Answer = double.Parse(Work_String);
                if ( Answer != 0)
                {
                    Answer = 1 / Answer;
                    Work_String = Answer.ToString();
                }
                else
                {
                    Work_String = "Деление на 0 невозможно";
                    Ban_Button = true;
                }
            }
        }

        public void ChangeSign()
        {
            if (Ban_Button == false)
            {
                if (double.Parse(Work_String) != 0)
                {
                    Work_String = Work_String[0] == '-' ? Work_String.Remove(0, 1) : "-" + Work_String;
                }
            }
        }

       
        public void Sqrt_Two()
        {
            if (Ban_Button == false)
            {
                Answer = double.Parse(Work_String);
                History = " sqrt(" + Work_String + ")";
                if (Answer >= 0)
                {
                    Answer = Math.Sqrt(Answer);
                    Work_String = Answer.ToString();
                }
                else
                {
                    Work_String = "Недопустимый ввод";
                    Ban_Button = true;

                }
            }
        }

        public void DeleteLastChar()
        {
            if (Work_String.Length > 1 && Work_String.Contains("E")  == false )
            {
                Work_String = Work_String.Remove(Work_String.Length - 1);
                History = Work_String;
            }
            else
            {
                Work_String = "0";
                History = "";
            }
        }
        public void C()
        {
            Ban_Button = false;
            Work_String = "0";
            History = "";
        }

        public void CE()
        {
            Ban_Button = false;
            Work_String = "0";
        }

        public void Point()
        {
            if (Ban_Button == false)
            {
                if ((Work_String.IndexOf(",") == -1) && (Work_String.IndexOf("∞") == -1))
                {
                    Work_String += ",";
                }
            }
        }
        public void Ravno()
        {
            if (Ban_Button == false)
            {
                
               Operand = double.Parse(Work_String);
                Correct_Enter = false;

                if (action == Action.pusto) { }
                if (action == Action.plus)
                {
                    Answer += Operand;
                    Work_String = Answer.ToString();
                    state = State.FirstOp;
                }
                if (action == Action.minus)
                {
                    Answer -= Operand;
                    Work_String = Answer.ToString();
                    state = State.FirstOp;
                }
                if (action == Action.multiply)
                {
                    Answer *= Operand;
                    Work_String = Answer.ToString();
                    state = State.FirstOp;
                }
                if (action == Action.divide)
                {
                    if (Operand != 0)
                    {
                        Answer /= Operand;
                        Work_String = Answer.ToString();
                    }
                    else
                    {
                        Work_String = "Деление на 0 невозможно";
                        Ban_Button = true;
                    }
                    state = State.FirstOp;
                }

                History = "";
            }
        }



    }
}
