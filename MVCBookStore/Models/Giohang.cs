using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBookStore.Models
{
    public class Giohang
    {
        dbQLBansachDataContext data = new dbQLBansachDataContext();
        public int iMasach { set; get; }
        public string sTensach { set; get; }
        public string  sHinhminhhoa { set; get; }
        public double dDongia { set; get; }
        public int iSoluong { set; get; }

        public double iThanhtien {
            get { return iSoluong * dDongia; }
        }

        public Giohang(int Masach)
        {
            iMasach = Masach;
            SACH sach = data.SACHes.Single(n => n.Masach == iMasach);
            sTensach = sach.Tensach;
            sHinhminhhoa = sach.Hinhminhhoa;
            dDongia = double.Parse(sach.Dongia.ToString());
            iSoluong = 1;
        }
    }
}