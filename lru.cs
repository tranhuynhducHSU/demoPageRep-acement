using System;
using System.Collections.Generic;

class Lru
{
    private int nFrame = 0; // So luong frame
    private List<string> frames; //Day cac frame hien tai
    private List<string> refs; //Day tham chieu
    private int vt = 0; //Vi tri con tro hien tai

    public Lru(int nFrame, List<string> refs)//truyen vao De bai
    {
        this.nFrame = nFrame;
        this.refs = refs;
        this.frames = new List<string>(); // Khoi tao day frame
        for (int i = 0; i < nFrame; i++)
        {
            this.frames.Add(""); //Quy dinh chuoi rong "" la frame rong
        }
        this.vt = 0; //Dat vi tri con tro bang 0

    }

    public Lru()
    {
        nFrame = 0;
        refs = new List<string>();
        frames = new List<string>();
    }

    public string Process()
    {
        string dauRa = "";
        int a = 1;

        for (int i = 0; i < refs.Count; i++)
        {
            string hienTai = refs[i];
            if (!frames.Contains(hienTai))
            {
                if (frames[vt] == "") //Frame chua co du lieu
                {
                    frames[vt] = hienTai;
                    vt = (vt + 1) % nFrame;
                }
                else //Frame da co du lieu
                {
                    //Muc tieu: Tim cho thay the trang
                    int dem = 0;
                    List<string> temp = new List<string>(); // Luu cac ref da duoc dem roi
                    for (int j = i - 1; j > -1; j--)//j >= 0 ton them 1 phep tinh
                    {
                        if (dem < nFrame)
                        {
                            if (!temp.Contains(refs[j]))
                            {
                                dem++;
                                temp.Add(refs[j]); // Ghi nho ref nay da duoc dem
                            }

                        }
                        if (dem == nFrame)//else thi no se bo qua roi lai lap for dan den sai ket qua(logic bug)
                        {
                            //Thay the o day
                            // Tim frame can thay the
                            for (int k = 0; k < frames.Count; k++)
                            {
                                if (frames[k] == refs[j])
                                {
                                    vt = k;
                                    break;
                                }
                            }

                            //thay the
                            frames[vt] = hienTai;

                            vt = (vt + 1) % nFrame;

                            break;
                        }
                    }
                }
            }
            string str = "";
            for (int j = 0; j < frames.Count; j++)
            {
                str += frames[j] + ",";
            }
            str = str.Substring(0, str.Length - 1);

            if (i == 0)
            {
                dauRa = i + 1 + " " + vt + " " + str;
            }
            if (i != 0)
            {
                a = a + 1;
                dauRa = dauRa + System.Environment.NewLine + a + " " + vt + " " + str;
            }
        }
        return dauRa;
    }



}