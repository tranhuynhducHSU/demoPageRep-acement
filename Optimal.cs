using System.Collections.Generic;

class Optimal{
    static public string Handling(){
        Input dulieu = new Input();
        dulieu= dulieu.getInput();
        string dauRa="";
        int time=0;
        int poin=0;
        string tam="";
        string[] dayThamChieu=new string[dulieu.DayThamChieu.Count];
        Fifo.listToArr(dayThamChieu,dulieu.DayThamChieu);
        string[] statusTam=new string[dulieu.SoFrame];
        string[] future=new string[dulieu.SoFrame];

        for(int i=0;i<dulieu.DayThamChieu.Count;i++){
            time++;
            tam=dulieu.DayThamChieu[i];
            if(Fifo.notIn(tam,statusTam)==true){
                if(isFull(statusTam)==false){
                    statusTam[poin]=tam;
                    int VT=returnVTri(tam,dayThamChieu,i+1);
                    future[poin]=VT.ToString();
                    poin++;
                }
                else{
                    poin=getVtriMax(future);
                    statusTam[poin]=tam;
                    int VT=returnVTri(tam,dayThamChieu,i+1);
                    future[poin]=VT.ToString();
                }
            }
            else{
                int VT=0;
                for(int j=0;j<statusTam.Length;j++){
                    if(tam==statusTam[j]){
                        VT=j;
                    }
                }
                future[VT]=returnVTri(tam,dayThamChieu,i+1).ToString();
                poin=getVtriMax(future);
            }
            
            string strStatusTam="";
            string strFuture="";
            strStatusTam=arrToString(statusTam);
            strFuture=arrToString(future);
            if(dauRa==""){
                int a=i+1;
                dauRa=a+" "+poin+" "+strStatusTam+" "+strFuture;
            }
            else{
                int a=i+1;
                dauRa =dauRa+System.Environment.NewLine+a+" "+poin+" "+strStatusTam+" "+strFuture;
            }
        }

        return dauRa;
    }

    static public bool isFull(string[] arrStr){
        for(int i=0;i<arrStr.Length;i++){
            if(arrStr[i]==null)
            return false;
        }
        return true;
    }
    static public int getVtriMax(string[] arrStr){
        int VTMax=0;
        int max=0;
        int[] status = arrStringToInt(arrStr);
        for(int i=0;i<status.Length;i++){
            if(max<status[i]){
                max=status[i];
                VTMax=i;
            }
        }
        return VTMax;
    }
    static public int returnVTri(string str,string[] arrStr,int VT){
        for(int i=VT;i<arrStr.Length;i++){
            if(str==arrStr[i]){
                return i;
            }
        }
        return arrStr.Length;
    }
    
    static int[] arrStringToInt(string[] arrStr){
        int[] arrInt=new int[arrStr.Length];
        for(int i=0;i<arrStr.Length;i++){
            arrInt[i]=int.Parse(arrStr[i]);
        }
        return arrInt;
    }

    static public string arrToString(string[] arrStr){
        string str="";
        for(int i=0;i<arrStr.Length;i++){
            if(str==""){
                str=arrStr[i];
            }
            else{
                str=str+","+arrStr[i];
            }
        }
        return str;
    }
}