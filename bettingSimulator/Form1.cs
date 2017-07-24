using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bettingSimulator
{
    public partial class bettingSimulator : Form
    {
        public bettingSimulator()
        {
            InitializeComponent();
            pbTotal.Text = "0.00";
            totalBox.Text = "0.00";
            horseTotal.Text = "0.00";
            pokerTotal.Text = "0.00";
        }

        public class powerBall : IComparable<powerBall>
        {
            private int[] numbers = new int[7];
            //Got Guid.NewGuid().GetHashCode() from Stack Overflow
            Random random = new Random(Guid.NewGuid().GetHashCode());

            public int getNumber(int number)
            {
                return numbers[number];
            }

            public int CompareTo(powerBall other)
            {
                for (int index = 0; index < 7; index++)
                {
                    int number = this.numbers[index].CompareTo(other.numbers[index]);

                    if (number != 0)
                    {
                        return 1;
                    }
                }
                return 0;
            }

            public powerBall(int one = 0, int two = 0, int three = 0, int four = 0, int five = 0, int six = 0, int seven = 0)
            {
                if (one == 0 && two == 0 && three == 0 && four == 0 && five == 0 && six == 0 && seven == 0)
                {
                    numbers[0] = random.Next(1, 70);
                    numbers[1] = random.Next(1, 70);
                    numbers[2] = random.Next(1, 70);
                    numbers[3] = random.Next(1, 70);
                    numbers[4] = random.Next(1, 70);
                    numbers[5] = random.Next(1, 70);
                    numbers[6] = random.Next(1, 27);
                }
                else
                {
                    numbers[0] = one;
                    numbers[1] = two;
                    numbers[2] = three;
                    numbers[3] = four;
                    numbers[4] = five;
                    numbers[5] = six;
                    numbers[6] = seven;
                }
            }
        }

        public class horseRace : IComparable<horseRace>
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());

            public int Horse { get; set; }

            public horseRace(int num = 0)
            {
                if (num == 0)
                {
                    Horse = random.Next(1, 6);
                }
                else Horse = num;
            }

            public int CompareTo(horseRace other)
            {
                int number = this.Horse.CompareTo(other.Horse);

                if (number == 0)
                {
                    return 0;
                }
                else return 1;
            }
        }

        public class poker : IComparable<poker>
        {
            private int[] cards = new int[5];
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int total = 0;

            public poker(int one = 0, int two = 0, int three = 0, int four = 0, int five = 0)
            {
                if (one == 0 && two == 0 && three == 0 && four == 0 && five == 0)
                {
                    cards[0] = random.Next(1, 13);
                    cards[1] = random.Next(1, 13);
                    cards[2] = random.Next(1, 13);
                    cards[3] = random.Next(1, 13);
                    cards[4] = random.Next(1, 13);
                }
                else
                {
                    cards[0] = one;
                    cards[1] = two;
                    cards[2] = three;
                    cards[3] = four;
                    cards[4] = five;
                }
                total = cards[0] + cards[1] + cards[2] + cards[3] + cards[4];
            }

            public int getCardNumber(int number)
            {
                return cards[number];
            }

            public int CompareTo(poker other)
            {
                return this.total.CompareTo(other.total);
            }
        }

        private void powerBallButton_Click(object sender, EventArgs e)
        {
            powerBall myResults = new powerBall();
            powerBall winningResults = new powerBall();

            pb1.Text = $"{myResults.getNumber(0)},{myResults.getNumber(1)},{myResults.getNumber(2)},{myResults.getNumber(3)},{myResults.getNumber(4)},{myResults.getNumber(5)},{myResults.getNumber(6)}";
            pb2.Text = $"{winningResults.getNumber(0)},{winningResults.getNumber(1)},{winningResults.getNumber(2)},{winningResults.getNumber(3)},{winningResults.getNumber(4)},{winningResults.getNumber(5)},{winningResults.getNumber(6)}";

            if (myResults.CompareTo(winningResults) == 0)
            {
                MessageBox.Show("You won the jackpot!!!!");
                pbTotal.Text = "348999998.00";
            }
            else pbTotal.Text = "-2.00";

            powerBallButton.Visible = false;
            totals();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            double total = 0;
            horsesBox.ReadOnly = true;

            if (!double.TryParse(horsesBox.Text, out total))
            {
                total = 0;
            }
            horseTotal.Text = Convert.ToString($"{Math.Round((total * -1), 2)}");
            submit.Visible = false;
            h1.Visible = true;
            h2.Visible = true;
            h3.Visible = true;
            h4.Visible = true;
            h5.Visible = true;
            totals();
        }

        private void h5_Click(object sender, EventArgs e)
        {
            horseRace myPick = new horseRace(5);
            horseRace winnerPick = new horseRace();
            horseFunctions(myPick, winnerPick);
        }

        private void h4_Click(object sender, EventArgs e)
        {
            horseRace myPick = new horseRace(4);
            horseRace winnerPick = new horseRace();
            horseFunctions(myPick, winnerPick);
        }

        private void h3_Click(object sender, EventArgs e)
        {
            horseRace myPick = new horseRace(3);
            horseRace winnerPick = new horseRace();
            horseFunctions(myPick, winnerPick);
        }

        private void h2_Click(object sender, EventArgs e)
        {
            horseRace myPick = new horseRace(2);
            horseRace winnerPick = new horseRace();
            horseFunctions(myPick, winnerPick);
        }

        private void h1_Click(object sender, EventArgs e)
        {
            horseRace myPick = new horseRace(1);
            horseRace winnerPick = new horseRace();
            horseFunctions(myPick, winnerPick);
        }

        private void invisibleButton()
        {
            h1.Visible = false;
            h2.Visible = false;
            h3.Visible = false;
            h4.Visible = false;
            h5.Visible = false;
        }

        private void horseFunctions(horseRace myPick, horseRace winnerPick)
        {
            if (myPick.CompareTo(winnerPick) == 0)
            {
                MessageBox.Show("Your horse won!!!!");
                horseTotal.Text = Convert.ToString($"{Convert.ToDouble(horseTotal.Text) * -1}");
            }
            fastestBox.Text = Convert.ToString($"Horse # {winnerPick.Horse}");
            invisibleButton();
            totals();
        }

        private void endGame_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Game over. You owe/earned: {totalBox.Text}");
            this.Close();
        }

        private void genButton_Click(object sender, EventArgs e)
        {
            poker myCards = new poker();
            poker theirCards = new poker();
            string[] myCardString = returnStringArray(myCards);
            string[] theirCardString = returnStringArray(theirCards);
            genButton.Visible = false;
            myCard.Text = $"{ myCardString[0]} {myCardString[1]} {myCardString[2]} {myCardString[3]} {myCardString[4]}";
            theirCard.Text = $"{ theirCardString[0]} {theirCardString[1]} {theirCardString[2]} {theirCardString[3]} {theirCardString[4]}";
            //if (myCards.CompareTo(theirCards) == 1)
            {
                MessageBox.Show("You have the higher total. You win!!!");

                double total = 0;

                if (!double.TryParse(pokerBet.Text, out total))
                {
                    total = 0;
                }
                pokerTotal.Text = Convert.ToString($"{(total * 1.2) - total}");
                totals();
            }
        }

        private string[] returnStringArray(poker myCards)
        {
            string[] cardString = new string[5];

            for (int index = 0; index < 5; index++)
            {
                if (myCards.getCardNumber(index) == 0)
                {
                    cardString[index] = "2";
                }
                else if (myCards.getCardNumber(index) == 1)
                {
                    cardString[index] = "3";
                }
                else if (myCards.getCardNumber(index) == 2)
                {
                    cardString[index] = "4";
                }
                else if (myCards.getCardNumber(index) == 3)
                {
                    cardString[index] = "5";
                }
                else if (myCards.getCardNumber(index) == 4)
                {
                    cardString[index] = "6";
                }
                else if (myCards.getCardNumber(index) == 5)
                {
                    cardString[index] = "7";
                }
                else if (myCards.getCardNumber(index) == 6)
                {
                    cardString[index] = "8";
                }
                else if (myCards.getCardNumber(index) == 7)
                {
                    cardString[index] = "9";
                }
                else if (myCards.getCardNumber(index) == 8)
                {
                    cardString[index] = "10";
                }
                else if (myCards.getCardNumber(index) == 9)
                {
                    cardString[index] = "J";
                }
                else if (myCards.getCardNumber(index) == 10)
                {
                    cardString[index] = "Q";
                }
                else if (myCards.getCardNumber(index) == 11)
                {
                    cardString[index] = "K";
                }
                else if (myCards.getCardNumber(index) == 12)
                {
                    cardString[index] = "A";
                }
            }

            return cardString;
        }

        private void pokerSubmit_Click(object sender, EventArgs e)
        {
            pokerBet.ReadOnly = true;
            pokerSubmit.Visible = false;
            genButton.Visible = true;
            double total = 0;

            if (!double.TryParse(pokerBet.Text, out total))
            {
                total = 0;
            }
            pokerTotal.Text = Convert.ToString($"{total * -1}");
            totals();
        }

        private void totals()
        {
            double pb = 0, horse = 0, poker = 0;

            if (!double.TryParse(pbTotal.Text, out pb))
            {
                pb = 0;
            }
            if (!double.TryParse(pokerTotal.Text, out horse))
            {
                horse = 0;
            }
            if (!double.TryParse(horseTotal.Text, out poker))
            {
                poker = 0;
            }
            totalBox.Text = Convert.ToString($"{Math.Round((pb + horse + poker), 2)}");

        }
    }
}
