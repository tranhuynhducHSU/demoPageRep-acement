using System;
using System.Collections.Generic;
class Fifo
{
    static public string Handling(){
        Input dulieu = new Input();
        dulieu= dulieu.getInput();
        string dauRa="";
        int time=0;
        int poin=0;
        string tam="";
        string[] statusTam=new string[dulieu.SoFrame];
        for(int i=0;i<dulieu.DayThamChieu.Count;i++){
            time=i+1;
            tam=dulieu.DayThamChieu[i];
            if(notIn(tam,statusTam)==true){
                statusTam[poin]=dulieu.DayThamChieu[i];
                poin++;
                if(poin>dulieu.SoFrame-1){
                    poin=0;
                }
            }
            string strStatusTam="";
            strStatusTam=Optimal.arrToString(statusTam);
            if(dauRa==""){
                int a=i+1;
                dauRa=a+" "+poin+" "+strStatusTam+" ";
            }
            else{
                int a=i+1;
                dauRa =dauRa+System.Environment.NewLine+a+" "+poin+" "+strStatusTam+" ";
            }
        }
        return dauRa;
    }
    static public bool notIn(string str,string[] arrStr){
        for(int i=0;i<arrStr.Length;i++){
            if(str==arrStr[i]){
                return false;
            }
        }
        return true;
    }
    static public string createArrStr(string[] arrStr){
        string str="";
        for(int i=0;i<arrStr.Length;i++){
            if(str==""){
                str=arrStr[i];
            }
            else{
                if(arrStr[i]==""){
                    str=str+",";
                }
                else{
                    str=str+","+arrStr[i];
                }
            }
        }
        return str;
    }
    static public void arrToList(string[] arr,List<string> list){
        for(int i=0;i<arr.Length;i++){
            list.Add(arr[i]);
        }
        
    }
    static public void listToArr(string[] arr,List<string> list){
        for(int i=0;i<list.Count;i++){
            arr[i]=list[i];
        }
        
    }

}
