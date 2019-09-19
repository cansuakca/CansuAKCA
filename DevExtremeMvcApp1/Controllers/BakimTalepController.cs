using DevExtremeMvcApp1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DevExtremeMvcApp1.Controllers
{

    public class BakimTalepController : Controller
    {
        private MainModel db = new MainModel();
        private readonly string BaglantiAdresi = "Server=CANSU;Database=DB;Integrated Security=SSPI;";

        // GET: BakimTalep
        public ActionResult Index()
        {
            return View(TempData["BakimTalep"]);
        }

        public Arac AracGetir(int id)
        {
            Arac arac = db.Arac.Find(id);
            return arac;
        }

        public UserAccount UserGetir(int id)
        {
            UserAccount userAccount = db.UserAccount.Find(id);
            return userAccount;
        }

        public ActionResult BakimTalepList()
        {
            List<BakimTalep> modellist = new List<BakimTalep>();

            string query = "SELECT * FROM BakimTalep";

            using (var conn = new SqlConnection(BaglantiAdresi))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                var aracc = AracGetir(rdr.GetInt32(rdr.GetOrdinal("AracID")));
                                var user = UserGetir(rdr.GetInt32(rdr.GetOrdinal("UserID")));
                                var m = new BakimTalep
                                {
                                    TalepDetay = rdr.GetString(rdr.GetOrdinal("TalepDetay")),
                                    TalepDurum = rdr.GetBoolean(rdr.GetOrdinal("TalepDurum")),
                                    TalepID = rdr.GetInt32(rdr.GetOrdinal("TalepID")),
                                    TalepTarihi = rdr.GetDateTime(rdr.GetOrdinal("TalepTarihi")),
                                    AracID = rdr.GetInt32(rdr.GetOrdinal("AracID")),
                                    UserID = rdr.GetInt32(rdr.GetOrdinal("UserID")),
                                    Arac = aracc,
                                    UserAccount = user
                                };
                                modellist.Add(m);
                            }
                        }
                    }
                }
            }
            return View(modellist);
        }
        [HttpPost]
        public ActionResult TalepDurumList(Boolean TalepDurum)
        {
            List<BakimTalep> modellist = new List<BakimTalep>();
            string query = "SELECT * FROM BakimTalep Where TalepDurum = @TalepDurum ";
            using (var conn = new SqlConnection(BaglantiAdresi))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TalepDurum", TalepDurum);
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                var aracc = AracGetir(rdr.GetInt32(rdr.GetOrdinal("AracID")));
                                var user = UserGetir(rdr.GetInt32(rdr.GetOrdinal("UserID")));
                                var m = new BakimTalep
                                {
                                    TalepDetay = rdr.GetString(rdr.GetOrdinal("TalepDetay")),
                                    TalepDurum = rdr.GetBoolean(rdr.GetOrdinal("TalepDurum")),
                                    TalepID = rdr.GetInt32(rdr.GetOrdinal("TalepID")),
                                    TalepTarihi = rdr.GetDateTime(rdr.GetOrdinal("TalepTarihi")),
                                    AracID = rdr.GetInt32(rdr.GetOrdinal("AracID")),
                                    UserID = rdr.GetInt32(rdr.GetOrdinal("UserID")),
                                    Arac = aracc,
                                    UserAccount = user
                                };
                                modellist.Add(m);
                            }
                        }
                    }
                }
            }
            return View(modellist);
        }


        [HttpPost]
        public ActionResult BakimTalepEkrani(Arac arac)
        {
            var bakimTalep = new BakimTalep() 
            {
                Arac = arac
            };
                            
            TempData["BakimTalep"] = bakimTalep;
            return RedirectToAction("Register");
        }

        [HttpPost]
        public ActionResult Onayla(BakimTalep BakimTalep)
        {
            var arac = (DevExtremeMvcApp1.Models.Arac)TempData["Arac"];
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = BaglantiAdresi
            };
            conn.Open();
            string insertQuery = "UPDATE BakimTalep SET TalepDurum = @true WHERE TalepID = @id; ";
            SqlCommand cmd = new SqlCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@id", BakimTalep.TalepID);
            cmd.Parameters.AddWithValue("@true", true);
            cmd.ExecuteNonQuery();
            Response.Write("Bakım Talep güncelleme başarılı!!!thank you");
            conn.Close();
            return RedirectToAction("BakimTalepList");
        }

        public ActionResult BakimTalep()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View(TempData["Arac"]);
        }

        [HttpPost]
        public ActionResult Register(BakimTalep bakimTalep)
        {
            var arac = (DevExtremeMvcApp1.Models.Arac)TempData["Arac"];
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = BaglantiAdresi
            };
            conn.Open();
            string insertQuery = "insert into BakimTalep(TalepTarihi, TalepDetay, TalepDurum, AracID, UserID)values (@talepTarihi,@talepDetay,@talepDurum,@aracID,@userID)";
            SqlCommand cmd = new SqlCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@aracID", arac.AracID);
            cmd.Parameters.AddWithValue("@userID", Session["UserID"]);
            cmd.Parameters.AddWithValue("@talepDurum", false);
            cmd.Parameters.AddWithValue("@talepTarihi", bakimTalep.TalepTarihi);
            cmd.Parameters.AddWithValue("@talepDetay", bakimTalep.TalepDetay);
            cmd.ExecuteNonQuery();
            Response.Write("Bakım Talebiniz Başarılı Bir Şekilde Kaydedildi!");
            conn.Close();
            return View();
        }

        public ActionResult Detay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BakimTalep bakimTalep = new BakimTalep();

            string query = "SELECT * FROM BakimTalep where BakimTalep.TalepID = @TalepId";

            using (var conn = new SqlConnection(BaglantiAdresi))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TalepId", id);
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                var aracc = AracGetir(rdr.GetInt32(rdr.GetOrdinal("AracID")));
                                var user = UserGetir(rdr.GetInt32(rdr.GetOrdinal("UserID")));
                                bakimTalep = new BakimTalep
                                {
                                    TalepDetay = rdr.GetString(rdr.GetOrdinal("TalepDetay")),
                                    TalepDurum = rdr.GetBoolean(rdr.GetOrdinal("TalepDurum")),
                                    TalepID = rdr.GetInt32(rdr.GetOrdinal("TalepID")),
                                    TalepTarihi = rdr.GetDateTime(rdr.GetOrdinal("TalepTarihi")),
                                    Arac = aracc,
                                    UserAccount = user
                                };
                            }
                        }
                    }
                }
            }

            if (bakimTalep == null)
            {
                return HttpNotFound();
            }
            return View(bakimTalep);
        }
    }
}