using System;
using System.Collections.Generic;
using System.Text;

namespace _020101125
{
    public class SINHVIEN
    {
        float  toan, van, anh;
        int sbd;
        
        public int SBD { get => sbd; }
        public float Toan { get => toan; }
        public float Van { get => van; }
        public float Anh { get => anh; }
        public float diemtong { get => toan + van + anh; }
        public SINHVIEN()
        {

        }
        public SINHVIEN(int Sbd,float dtoan,float dvan,float danh)
        {
            sbd = Sbd;
            toan = dtoan;
            van = dvan;
            anh = danh;
        }
        public static int sosanhtheoSBD(SINHVIEN a, SINHVIEN b) => (a.sbd - b.sbd);
        public static int sosanhtheoToan(SINHVIEN a, SINHVIEN b) => Convert.ToInt32(a.toan-b.toan);
        public static int sosanhtheoVan(SINHVIEN a, SINHVIEN b) => Convert.ToInt32(a.van - b.van);
        public static int sosanhtheoAnh(SINHVIEN a, SINHVIEN b) => Convert.ToInt32(a.anh - b.anh);
        public static int sosanhtheoTong(SINHVIEN a, SINHVIEN b) => Convert.ToInt32(a.diemtong - b.diemtong);
    }
}
