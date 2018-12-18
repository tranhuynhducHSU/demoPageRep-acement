using System;
using System.Collections.Generic;
using System.IO;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string dauRa="";
            string[] input=System.IO.File.ReadAllText("input.txt").Split(' ');
            if(input[0]=="0"){
                dauRa=Fifo.Handling();
            }
            if(input[0]=="1"){
                Input dulieu=new Input();
                dulieu=dulieu.getInput();
                Lru lRU = new Lru(dulieu.SoFrame, dulieu.DayThamChieu);
                dauRa=lRU.Process();
            }
            if(input[0]=="2"){
                
            }
            if(input[0]=="3"){
                dauRa=Optimal.Handling();
            }
            System.IO.File.WriteAllText("output.txt",dauRa);
            
            
        }

    }
}
