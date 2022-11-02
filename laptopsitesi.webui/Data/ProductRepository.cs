using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using laptopsitesi.webui.Models;

namespace laptopsitesi.webui.Data
{
    public interface ILaptopDal
    {
        List<Laptop> GetAllLaptops();
        Laptop GetLaptopById(int id);
        void Create(Laptop lp);
        void Update(Product lp);
        int Delete(int laptopId);
    }
    public class MySqlLaptopDal : ILaptopDal
    {
        private MySqlConnection GetMySqlConnection()
        {
            string connectionString = @"server=localhost;port=3306;database=laptoplar;user=root;password=;";
            return new MySqlConnection(connectionString);
        }
        public void Create(Laptop lp)
        {

        }

        public int Delete(int laptopid)
        {

            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();
                    string sql = "delete  from site2 where id=@laptopid";

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.Add("@laptopid", MySqlDbType.Int32).Value = laptopid;

                    int result = command.ExecuteNonQuery();
                    return result;
                }
                catch (Exception)
                {

                }
                finally
                {
                    connection.Close();
                }

            }
            return 0;
        }

        public List<Laptop> GetAllLaptops()
        {
            List<Laptop> laptoplar = null;
            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();

                    string sql = "select * from n11clon,fullsite where fullsite.model=n11clon.model";

                    MySqlCommand command = new MySqlCommand(sql, connection);

                    MySqlDataReader reader = command.ExecuteReader();
                    laptoplar = new List<Laptop>();

                    while (reader.Read())
                    {
                        laptoplar.Add(new Laptop
                        {

                            Baslik = (reader[2].ToString()),
                            TrLink = (reader[18].ToString()),
                            TrFiyat = (reader[19].ToString()),
                            HLink = (reader[20].ToString()),
                            HFiyat = (reader[21].ToString()),
                            NLink = (reader[22].ToString()),
                            NFiyat = (reader[11].ToString()),
                            TeLink = (reader[24].ToString()),
                            TeFiyat = (reader[25].ToString()),
                            Model = (reader[9].ToString()),

                            Link = (reader[1].ToString()),

                            laptopid = int.Parse(reader["id"].ToString()),
                            Fiyat = (reader[11].ToString()),
                            EkranBoyutu = (reader[3].ToString()),
                            DiskKapasitesi = (reader[8].ToString()),
                            DiskTuru = (reader[4].ToString()),
                            IslemciModeli = (reader[7].ToString()),
                            IsletimSistemi = (reader[5].ToString()),
                            BellekKapasitesi = (reader[6].ToString()),
                            Marka = (reader[10].ToString()),

                            Puan = (reader[12].ToString()),
                            EkranKarti = (reader[13].ToString())

                        });


                    }

                    reader.Close();
                }
                catch (Exception)
                {

                }
                finally
                {
                    connection.Close();
                }
            }
            return laptoplar;
        }

        public Laptop GetLaptopById(int id)
        {
            Laptop laptop = null;
            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();

                    string sql = "select * from site1 where  id=@laptopid";

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.Add("@laptopid", MySqlDbType.Int32).Value = id;
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        laptop = new Laptop()
                        {


                        };


                    }

                    reader.Close();
                }
                catch (Exception)
                {

                }
                finally
                {
                    connection.Close();
                }
            }
            return laptop;
        }

        public void Update(Product item)
        {
            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();
                    string sql2 = "UPDATE site2 set Baslik=@item.Baslik,EkranBoyutu=@item.EkranBoyutu,DiskTuru=@item.DiskTuru,IsletimSistemi=@item.IsletimSistemi,BellekKapasitesi=@item.BellekKapasitesi,IslemciModeli=@item.IslemciModeli,DiskKapasitesi=@item.DiskKapasitesi,Model=@item.Model,Marka=@item.Marka,Fiyat=@item.Fiyat,Puan=@item.Puan,EkranKarti=@item.EkranKarti WHERE id=@item.laptopid";



                    MySqlCommand command2 = new MySqlCommand(sql2, connection);

                    command2.Parameters.AddWithValue("@item.Baslik", item.Baslik);
                    command2.Parameters.AddWithValue("@item.EkranBoyutu", item.EkranBoyutu);
                    command2.Parameters.AddWithValue("@item.DiskTuru", item.DiskTuru);
                    command2.Parameters.AddWithValue("@item.IsletimSistemi", item.IsletimSistemi);
                    command2.Parameters.AddWithValue("@item.BellekKapasitesi", item.BellekKapasitesi);
                    command2.Parameters.AddWithValue("@item.IslemciModeli", item.IslemciModeli);
                    command2.Parameters.AddWithValue("@item.DiskKapasitesi", item.DiskKapasitesi);
                    command2.Parameters.AddWithValue("@item.Model", item.Model);
                    command2.Parameters.AddWithValue("@item.Marka", item.Marka);
                    command2.Parameters.AddWithValue("@item.Fiyat", item.Fiyat);
                    command2.Parameters.AddWithValue("@item.Puan", item.Puan);
                    command2.Parameters.AddWithValue("@item.EkranKarti", item.EkranKarti);
                    command2.Parameters.AddWithValue("@item.laptopid", item.laptopid);
                    int result = command2.ExecuteNonQuery();


                }
                catch (Exception)
                {

                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public string Kontrol(Laptop item)
        {
            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();

                    string sql = "select model from site2 where model=" + "'" + item.Model + "'";


                    MySqlCommand command1 = new MySqlCommand(sql, connection);

                    MySqlDataReader reader2 = command1.ExecuteReader();
                    if (!(reader2.Read()))
                    {
                        using (var connection2 = GetMySqlConnection())
                        {
                            try
                            {
                                connection2.Open();

                                string sql2 = "INSERT INTO site2(Baslik,EkranBoyutu,DiskTuru,IsletimSistemi,BellekKapasitesi,IslemciModeli,DiskKapasitesi,Model,Marka,Fiyat,Puan,EkranKarti) VALUES (@item.Baslik,@item.EkranBoyutu,@item.DiskTuru,@item.IsletimSistemi,@item.BellekKapasitesi,@item.IslemciModeli,@item.DiskKapasitesi,@item.Model,@item.Marka,@item.Fiyat,@item.Puan,@item.EkranKarti)";



                                MySqlCommand command2 = new MySqlCommand(sql2, connection2);

                                command2.Parameters.AddWithValue("@item.Baslik", item.Baslik);
                                command2.Parameters.AddWithValue("@item.EkranBoyutu", item.EkranBoyutu);
                                command2.Parameters.AddWithValue("@item.DiskTuru", item.DiskTuru);
                                command2.Parameters.AddWithValue("@item.IsletimSistemi", item.IsletimSistemi);
                                command2.Parameters.AddWithValue("@item.BellekKapasitesi", item.BellekKapasitesi);
                                command2.Parameters.AddWithValue("@item.IslemciModeli", item.IslemciModeli);
                                command2.Parameters.AddWithValue("@item.DiskKapasitesi", item.DiskKapasitesi);
                                command2.Parameters.AddWithValue("@item.Model", item.Model);
                                command2.Parameters.AddWithValue("@item.Marka", item.Marka);
                                command2.Parameters.AddWithValue("@item.Fiyat", item.Fiyat);
                                command2.Parameters.AddWithValue("@item.Puan", item.Puan);
                                command2.Parameters.AddWithValue("@item.EkranKarti", item.EkranKarti);

                                int result = command2.ExecuteNonQuery();

                            }
                            catch (Exception)
                            {

                            }
                            finally
                            {
                                connection2.Close();
                            }

                            return item.Model;
                        }
                    }
                    else
                    {

                    }
                    reader2.Close();
                }
                catch (Exception)
                {

                }
                finally
                {
                    connection.Close();
                }
            }
            return null;
        }


    }
    public static class ProductRepository
    {
        private static List<Product> _products = null;

        static ProductRepository()
        {
            var laptopDal = new MySqlLaptopDal();
            var products = laptopDal.GetAllLaptops();

            _products = new List<Product> { };

            foreach (var item in products)
            {


                AddProduct(new Product { NFiyat = item.NFiyat, TrFiyat = item.TrFiyat, TeFiyat = item.TeFiyat, HFiyat = item.HFiyat, HLink = item.HLink, TeLink = item.TeLink, TrLink = item.TrLink, NLink = item.NLink, Model = item.Model, Baslik = item.Baslik, Marka = item.Marka, EkranBoyutu = item.EkranBoyutu, EkranKarti = item.EkranKarti, IslemciModeli = item.IslemciModeli, IsletimSistemi = item.IsletimSistemi, DiskKapasitesi = item.DiskKapasitesi, BellekKapasitesi = item.BellekKapasitesi, DiskTuru = item.DiskTuru, Puan = item.Puan, Fiyat = item.Fiyat });

            }
        }

        public static List<Product> Products
        {
            get
            {
                return _products;
            }
        }

        public static void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public static Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.laptopid == id);
        }
    }
}