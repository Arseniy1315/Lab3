using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public enum Score_Type
        {
            Текущий, Сберегательный
        }

        public class BankAccount
        {
            private int  Account_Number;
            private double Balance;
            private Score_Type type;
            private static int AccountID=1;

            public BankAccount()
            {
                Account_Number = AccountID;
                NumberAccount();
            }
            public int GetNumber()
            {
                return Account_Number;
            }


            public double GetBalance()
            {
                return Balance;
            }
            public Score_Type Gettype()
            {
                return type;
            }

            public void Type(Score_Type type2)
            {
                type = type2;
            }

            public void Total_Balance(int money)
            {
                Balance = money;
            }


            public static void NumberAccount()
            {
                AccountID++;
            }
            public void WithdrawMoney(int num, int take)
            {
                

                if (BankAccount.AccountID == num)
                {
                    if ( Balance >= take)
                    {
                        Balance = Balance - take;
                        MessageBox.Show($"Со счета была снята сумма {Balance}");
                    }
                    else
                    {
                        MessageBox.Show("На счету не достаточно средств");
                    }

                }



                //if (BankAccount.AccountID == BankAccount.AccountID )
                //{
            //    if (Balance >= take)
            //    {
            //        Balance = Balance - take;
            //        MessageBox.Show($"Со счета была снята сумма {Balance}");
            //    }
            //    else
            //    {
            //        MessageBox.Show("На счету не достаточно средств");
            //    }
            //}


        }
        public void Deposit_Money()
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            BankAccount bankAccount = new BankAccount();
            bankAccount.Total_Balance(rnd.Next(10000, 1000000));
            Score_Type type = bankAccount.Gettype();
            richTextBox1.Text = $"Аккаунт {bankAccount.GetNumber()} счет {type}  баланс {bankAccount.GetBalance()}  \n";
            BankAccount bank = new BankAccount();
            bank.Total_Balance(rnd.Next(12002, 213213));
            bank.Type(Score_Type.Сберегательный);
            Score_Type type1 = bank.Gettype();
            richTextBox1.Text += $"Аккаунт {bank.GetNumber()} cчет {type1} баланс {bank.GetBalance()} \n";

            

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
