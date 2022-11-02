using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace laptopsitesi.webui.Data
{
    public interface ICategoryDal
    {
        List<Category> GetAllCategories();

        void Create(Category ct);
        void Update(Category ct);
        void Delete(int CategoryId);
    }
    public class MySqlCategoryDal : ICategoryDal
    {
        private MySqlConnection GetMySqlConnection()
        {
            string connectionString = @"server=localhost;port=3306;database=laptoplar;user=root;password=;";
            return new MySqlConnection(connectionString);
        }
        public void Create(Category ct)
        {

        }

        public void Delete(int CategoryId)
        {

        }

        public List<Category> GetAllCategories()
        {

            List<Category> categories = null;
            using (var connection2 = GetMySqlConnection())
            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();
                    connection2.Open();

                    string sql = "show columns from n11clon";

                    MySqlCommand command = new MySqlCommand(sql, connection);

                    MySqlDataReader reader = command.ExecuteReader();

                    categories = new List<Category>();

                    while (reader.Read())
                    {

                        if (reader[0].ToString() == "id" || reader[0].ToString() == "Link" || reader[0].ToString() == "Baslik" || reader[0].ToString() == "Fiyat" || reader[0].ToString() == "Model" || reader[0].ToString() == "Puan")
                        {

                        }
                        else
                        {

                            string sql2 = "select DISTINCT " + reader[0].ToString() + " from n11clon";
                            MySqlCommand command2 = new MySqlCommand(sql2, connection2);

                            MySqlDataReader reader2 = command2.ExecuteReader();

                            while (reader2.Read())
                            {
                                categories.Add(new Category
                                {
                                    Name = (reader[0].ToString()),
                                    Features = (reader2[0].ToString())
                                });
                            }

                            reader2.Close();
                        }

                    }

                    reader.Close();


                }
                catch (Exception)
                {

                }
                finally
                {
                    connection.Close();
                    connection2.Close();

                }
            }



            return categories;
        }




        public void Update(Category ct)
        {
            throw new System.NotImplementedException();
        }

        public List<Category> GetAllFeatures(List<Category> categories)
        {
            List<Category> features = null;

            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();
                    for (int i = 0; i < categories.Count; i++)
                    {

                        string sql = "select DISTINCT " + categories[i].Name + " from site2";

                        MySqlCommand command = new MySqlCommand(sql, connection);

                        MySqlDataReader reader = command.ExecuteReader();


                        while (reader.Read())
                        {
                            features.Add(new Category
                            {
                                Name = categories[i].ToString(),
                                Features = (reader[0].ToString())
                            });
                            Console.WriteLine(reader[0]);
                        }
                        reader.Close();
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    connection.Close();
                }
            }
            return features;
        }
    }
    public class CategoryRepository
    {
        private static List<Category> _categories = null;

        static CategoryRepository()
        {
            var categoryDal = new MySqlCategoryDal();
            var categories = categoryDal.GetAllCategories();

            _categories = new List<Category> { };

            foreach (var item in categories)
            {

                AddCategory(new Category { Name = item.Name, Features = item.Features });

            }


        }

        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }

        public static void AddCategory(Category category)
        {
            _categories.Add(category);
        }
        public static void AddFeatures(Category category)
        {

        }
        public static Category GetCategorybyId(string name)
        {
            return _categories.FirstOrDefault(c => c.Name == name);
        }



    }
}