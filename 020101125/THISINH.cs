using System;
using System.Collections.Generic;
using System.Text;

namespace _020101125
{
    public class THISINH
    {
        float toan, van, anh;
        int sbd;

        public int SBD { get => sbd; }
        public float Toan { get => toan; }
        public float Van { get => van; }
        public float Anh { get => anh; }
        public float diemtong { get => toan + van + anh; }
        public THISINH()
        {

        }
        public THISINH(int Sbd, float dtoan, float dvan, float danh)
        {
            sbd = Sbd;
            toan = dtoan;
            van = dvan;
            anh = danh;
        }
        public static int sosanhtheoSBD(THISINH a, THISINH b) => (a.sbd - b.sbd);
        public static int sosanhtheoToan(THISINH a, THISINH b) => Convert.ToInt32(a.toan - b.toan);
        public static int sosanhtheoVan(THISINH a, THISINH b) => Convert.ToInt32(a.van - b.van);
        public static int sosanhtheoAnh(THISINH a, THISINH b) => Convert.ToInt32(a.anh - b.anh);
        public static int sosanhtheoTong(THISINH a, THISINH b) => Convert.ToInt32(a.diemtong - b.diemtong);
        public static THISINH ScanfromString(string s)
        {
            string[] infos = new string[4];
            int sbd;
            float toan, van, anh;
            infos = s.Split(',', StringSplitOptions.RemoveEmptyEntries);
            if (infos.Length > 0)
            {
                sbd = Convert.ToInt32(infos[0]);
                toan = float.Parse(infos[1]);
                van = float.Parse(infos[2]);
                anh = float.Parse(infos[3]);

                THISINH sv = new THISINH(sbd, toan, van, anh);
                return sv;
            }else
            return null;
        }
    }
}
