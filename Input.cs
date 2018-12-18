
using System;
using System.Collections.Generic;

class Input{
    private List<string> dayThamChieu;
    private int soFrame;
    private string type;

    public int SoFrame { get => soFrame; set => soFrame = value; }
    public List<string> DayThamChieu { get => dayThamChieu; set => dayThamChieu = value; }
    public string Type { get => type; set => type = value; }

    public Input(){
        DayThamChieu=new List<string>();
        soFrame=0;
        type="";
    }

    public Input getInput(){
        Input duLieu=new Input();
        try{
            string[] input=System.IO.File.ReadAllText("input.txt").Split(' ');
            
            duLieu.type=input[0];
            duLieu.soFrame=Int16.Parse(input[1]);
            string[] listRef= input[2].Split(',');
            
            duLieu.DayThamChieu.AddRange(listRef);
            
        }
        catch (Exception e){
            Console.WriteLine("Some thing war rwong!");
            Console.WriteLine(e.Message);
        }
        return duLieu;
    }
    
}