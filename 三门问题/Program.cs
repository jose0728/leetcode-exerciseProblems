using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 三门问题
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreeDoor threeDoor = new ThreeDoor();  //三门
            Player player = new Player();           //玩家
            Presenter presenter = new Presenter();  //主持人
            Scorer scorer = new Scorer();           //计分者
            Moder moder = new Moder();              //设置模式者

            moder.setMode();  //设置模式
            moder.showMode(); //显示模式

            //循环玩多次
            for (int i = 0; i < moder.playTotalCount; i++)
            {
                threeDoor.setPrize(); //设置门后奖品
                player.choiceDoor();  //玩家选择一个门
                                      //主持人打开一扇是山羊的门
                presenter.openFirstGoatPosition(threeDoor.threeDoor, player.firstChoicePosition);
                if (moder.mode.Equals("A"))
                    player.changeDoor(presenter.firstGoatPosition); //玩家换另外一扇门
                                                                    //计分
                scorer.score(threeDoor.threeDoor, player.lastChoicePosition);
            }

            scorer.statistics();  //统计获得汽车的概率
        }
    }

    //三门
    public class ThreeDoor
    {
        public string[] threeDoor = new String[3]; //三门

        //设置门后的奖品
        public void setPrize()
        {
            Random rd = new Random();
            int carPosition = (int)(int.Parse(rd.ToString()) * 100) % 3;

            threeDoor[0] = "Goat";
            threeDoor[1] = "Goat";
            threeDoor[2] = "Goat";
            threeDoor[carPosition] = "Car";
        }
    }

    //玩家
    public class Player
    {
        public int firstChoicePosition = 0;  //首次选择的门
        public int lastChoicePosition = 0;   //最终选择的门

        //选择一个门
        public void choiceDoor()
        {
            Random rd = new Random();
            firstChoicePosition = (int)(int.Parse(rd.ToString()) * 100) % 3; lastChoicePosition = firstChoicePosition;
        }

        //更换为另一个门
        public void changeDoor(int firstGoatPosition)
        {
            lastChoicePosition = 3 - firstChoicePosition - firstGoatPosition;
        }
    }

    //主持人
    public class Presenter
    {
        public int firstGoatPosition = 0;  //主持人打开的门

        //打开后面为山羊的门
        public void openFirstGoatPosition(String[] threeDoor, int playerFirstChoicePosition)
        {
            if (threeDoor[playerFirstChoicePosition].Equals("Car"))
            {
                do
                {
                    Random rd = new Random();
                    firstGoatPosition = (int)(int.Parse(rd.ToString()) * 100) % 3;
                } while (firstGoatPosition == playerFirstChoicePosition);
            }
            else
            {
                for (int i = 0; i < 3; i++)
                    if (!threeDoor[i].Equals("Car") && i != playerFirstChoicePosition)
                        firstGoatPosition = i;
            }
        }
    }

    //计分牌
    class Scorer
    {
        public int playCount = 0;        //玩的总次数
        public int choiceCarCount = 0;   //获得车的次数
        public int choiceGoatCount = 0;  //获得山羊的次数

        //计分
        public void score(String[] threeDoor, int playLastChoicePosition)
        {
            playCount++;
            if (threeDoor[playLastChoicePosition].Equals("Car"))
                choiceCarCount++;
            else
                choiceGoatCount++;
        }

        //计算获得车的概率
        public void statistics()
        {
            Console.WriteLine("Choice Goat Count: " + choiceGoatCount);
            Console.WriteLine("Choice Car  Count: " + choiceCarCount);
            Console.WriteLine("Choice Car  Rate : " + (float)choiceCarCount / playCount);
        }
    }

    //设置模式
    public class Moder
    {
        public string mode = "";       //模式，A：换门，B：不换门
        public int playTotalCount = 0; //玩的总次数

        //设置模式
        public void setMode()
        {
            //设置选门模式
            while (!mode.Equals("A") && !mode.Equals("B"))
            {
                Console.WriteLine("Plase input mode: A[Change]  B[Don't Change]");
                mode = Console.ReadLine();
                if (!mode.Equals("A") && !mode.Equals("B"))
                    Console.WriteLine("Input Error, Input again.");
            }

            //设置玩的总次数
            while (playTotalCount <= 0)
            {
                Console.WriteLine("Plase input play total count: ");
                try
                {
                    string scCnt = Console.ReadLine();
                    playTotalCount = int.Parse(scCnt);
                }
                catch (Exception e)
                {
                    playTotalCount = 0;
                }
                if (playTotalCount <= 0)
                    Console.WriteLine("Input Error, Input again.");
            }

            Console.WriteLine();
        }

        //显示设置的模式
        public void showMode()
        {
            if (mode.Equals("A"))
                Console.WriteLine("Mode: [Change]");
            else
                Console.WriteLine("Mode: [Don't Change]");

            Console.WriteLine("Play Total Count: " + playTotalCount);
            Console.WriteLine();
        }
    }
}
