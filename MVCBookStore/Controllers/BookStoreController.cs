﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBookStore.Models;
using PagedList;
using PagedList.Mvc;
namespace MVCBookStore.Controllers
{
    public class BookStoreController : Controller
    {

        dbQLBansachDataContext data = new dbQLBansachDataContext();
        private List<SACH>Laysachmoi(int count)
        {
            return data.SACHes.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }


        // GET: BookStore
        public ActionResult Index(int ? page)
        {
            int pagesize = 5;
            int pageNum = (page ?? 1);  
            var sachmoi = Laysachmoi(15);
            return View(sachmoi.ToPagedList(pageNum,pagesize));
        }

        public ActionResult Chude()
        {
            var chude = from cd in data.CHUDEs select cd;
            return PartialView(chude);
        }

        public ActionResult Nhaxuatban()
        {
            var nxb = from xb in data.NHAXUATBANs select xb;
            return PartialView(nxb);
        }
        public ActionResult SPTheochude(int id)
        {
            var sach = from s in data.SACHes where s.MaCD == id select s;
            return View(sach);
        }
        public ActionResult SPTheoNXB(int id)
        {
            var sach = from s in data.SACHes where s.MaNXB == id select s;
            return View(sach);
        }

        public ActionResult Details(int id)
        {
            var sach = from s in data.SACHes
                       where s.Masach == id
                       select s;
            return View(sach);
        }
    }
}