using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UjalaCityNews1.Models;

namespace UjalaCityNews1.DAL
{
    public class CommonDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        public void AddContact(ContactUs contact)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Proc_AddContactUs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", contact.Name);
                cmd.Parameters.AddWithValue("@Email", contact.Email);
                cmd.Parameters.AddWithValue("@Subject", contact.Subject);
                cmd.Parameters.AddWithValue("@Message", contact.Message);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public List<ContactUs> GetContactList()
        {
            List<ContactUs> list = new List<ContactUs>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from ContactUs", con); // Assume you have a stored procedure for this
                cmd.CommandType = CommandType.Text;// Handle null values

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ContactUs item = new ContactUs
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? null : reader.GetString(reader.GetOrdinal("Name")),
                            Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                            Subject = reader.IsDBNull(reader.GetOrdinal("Subject")) ? null : reader.GetString(reader.GetOrdinal("Subject")),
                            Message = reader.IsDBNull(reader.GetOrdinal("Message")) ? null : reader.GetString(reader.GetOrdinal("Message")),
                        };

                        list.Add(item);
                    }
                }
            }

            return list;
        }
        #region News Post
        public void SaveOrUpdateNewsPost(NewsPosts newsPost)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Proc_SaveOrUpdateNewsPost", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", newsPost.Id);
                cmd.Parameters.AddWithValue("@EnglishTitle", newsPost.EnglishTitle ?? string.Empty);
                cmd.Parameters.AddWithValue("@HindiTitle", newsPost.HindiTitle ?? string.Empty);
                cmd.Parameters.AddWithValue("@Category", newsPost.Category ?? string.Empty);
                cmd.Parameters.AddWithValue("@Name", newsPost.Name ?? string.Empty);
                cmd.Parameters.AddWithValue("@Date", newsPost.Date == null ? (object)newsPost.Date : (object)newsPost.Date);
                cmd.Parameters.AddWithValue("@ImagePath", newsPost.ImagePath ?? string.Empty);
                cmd.Parameters.AddWithValue("@Description", newsPost.Description ?? string.Empty);
                cmd.Parameters.AddWithValue("@Tag", newsPost.Tag ?? string.Empty);
                cmd.Parameters.AddWithValue("@Slug", newsPost.Slug ?? string.Empty);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public NewsPosts GetNewsPostById(int id)
        {
            NewsPosts newsPost = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Proc_GetNewsPostById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        newsPost = new NewsPosts
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            EnglishTitle = reader.IsDBNull(reader.GetOrdinal("EnglishTitle")) ? null : reader.GetString(reader.GetOrdinal("EnglishTitle")),
                            HindiTitle = reader.IsDBNull(reader.GetOrdinal("HindiTitle")) ? null : reader.GetString(reader.GetOrdinal("HindiTitle")),
                            Category = reader.IsDBNull(reader.GetOrdinal("Category")) ? null : reader.GetString(reader.GetOrdinal("Category")),
                            Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? null : reader.GetString(reader.GetOrdinal("Name")),
                            Date = reader.IsDBNull(reader.GetOrdinal("Date")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Date")),
                            CreatedDate = reader.IsDBNull(reader.GetOrdinal("CreatedDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                            ImagePath = reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? null : reader.GetString(reader.GetOrdinal("ImagePath")),
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                            Tag = reader.IsDBNull(reader.GetOrdinal("Tag")) ? null : reader.GetString(reader.GetOrdinal("Tag")),
                            Slug = reader.IsDBNull(reader.GetOrdinal("Slug")) ? null : reader.GetString(reader.GetOrdinal("Slug"))
                        };

                    }
                }
            }

            return newsPost;
        }
        public NewsPosts GetNewsPostByTitle(string keyword)
        {
            NewsPosts newsPost = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Proc_GetNewsPostByTitle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@keyword", keyword);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        newsPost = new NewsPosts
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            EnglishTitle = reader.IsDBNull(reader.GetOrdinal("EnglishTitle")) ? null : reader.GetString(reader.GetOrdinal("EnglishTitle")),
                            HindiTitle = reader.IsDBNull(reader.GetOrdinal("HindiTitle")) ? null : reader.GetString(reader.GetOrdinal("HindiTitle")),
                            Category = reader.IsDBNull(reader.GetOrdinal("Category")) ? null : reader.GetString(reader.GetOrdinal("Category")),
                            Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? null : reader.GetString(reader.GetOrdinal("Name")),
                            Date = reader.IsDBNull(reader.GetOrdinal("Date")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Date")),
                            CreatedDate = reader.IsDBNull(reader.GetOrdinal("CreatedDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                            ImagePath = reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? null : reader.GetString(reader.GetOrdinal("ImagePath")),
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                            Tag = reader.IsDBNull(reader.GetOrdinal("Tag")) ? null : reader.GetString(reader.GetOrdinal("Tag")),
                            Slug = reader.IsDBNull(reader.GetOrdinal("Slug")) ? null : reader.GetString(reader.GetOrdinal("Slug"))
                        };

                    }
                }
            }

            return newsPost;
        }
        public NewsPosts GetNewsPostByCategory(string category)
        {
            NewsPosts newsPost = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Proc_GetNewsPostByTitle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@keyword", category);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        newsPost = new NewsPosts
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            EnglishTitle = reader.IsDBNull(reader.GetOrdinal("EnglishTitle")) ? null : reader.GetString(reader.GetOrdinal("EnglishTitle")),
                            HindiTitle = reader.IsDBNull(reader.GetOrdinal("HindiTitle")) ? null : reader.GetString(reader.GetOrdinal("HindiTitle")),
                            Category = reader.IsDBNull(reader.GetOrdinal("Category")) ? null : reader.GetString(reader.GetOrdinal("Category")),
                            Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? null : reader.GetString(reader.GetOrdinal("Name")),
                            Date = reader.IsDBNull(reader.GetOrdinal("Date")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Date")),
                            CreatedDate = reader.IsDBNull(reader.GetOrdinal("CreatedDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                            ImagePath = reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? null : reader.GetString(reader.GetOrdinal("ImagePath")),
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                            Tag = reader.IsDBNull(reader.GetOrdinal("Tag")) ? null : reader.GetString(reader.GetOrdinal("Tag")),
                            Slug = reader.IsDBNull(reader.GetOrdinal("Slug")) ? null : reader.GetString(reader.GetOrdinal("Slug"))
                        };

                    }
                }
            }

            return newsPost;
        }
        public List<NewsPosts> GetNewsPostsByName(string name = "")
        {
            List<NewsPosts> newsPostsList = new List<NewsPosts>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Proc_GetNewsPostsByName", con); // Assume you have a stored procedure for this
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name ?? (object)DBNull.Value); // Handle null values

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        NewsPosts newsPost = new NewsPosts
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            EnglishTitle = reader.IsDBNull(reader.GetOrdinal("EnglishTitle")) ? null : reader.GetString(reader.GetOrdinal("EnglishTitle")),
                            HindiTitle = reader.IsDBNull(reader.GetOrdinal("HindiTitle")) ? null : reader.GetString(reader.GetOrdinal("HindiTitle")),
                            Category = reader.IsDBNull(reader.GetOrdinal("Category")) ? null : reader.GetString(reader.GetOrdinal("Category")),
                            Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? null : reader.GetString(reader.GetOrdinal("Name")),
                            Date = reader.IsDBNull(reader.GetOrdinal("Date")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Date")),
                            DateString = reader.IsDBNull(reader.GetOrdinal("Date")) ? (string)null : reader.GetDateTime(reader.GetOrdinal("Date")).ToString("dd-MM-yyyy"),
                            CreatedDate = reader.IsDBNull(reader.GetOrdinal("CreatedDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                            ImagePath = reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? null : reader.GetString(reader.GetOrdinal("ImagePath")),
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                            Tag = reader.IsDBNull(reader.GetOrdinal("Tag")) ? null : reader.GetString(reader.GetOrdinal("Tag")),
                            Slug = reader.IsDBNull(reader.GetOrdinal("Slug")) ? null : reader.GetString(reader.GetOrdinal("Slug"))
                        };

                        newsPostsList.Add(newsPost);
                    }
                }
            }

            return newsPostsList;
        }
        public int DeletePostById(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Delete NewsPosts where id = @id", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            return 1;
        }
        #endregion


        #region Categories
        public List<NewsPosts> Proc_GetNewsByCategory(string name = "")
        {
            List<NewsPosts> newsPostsList = new List<NewsPosts>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Proc_GetNewsByCategory", con); // Assume you have a stored procedure for this
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Categories", name ?? (object)DBNull.Value); // Handle null values

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        NewsPosts newsPost = new NewsPosts
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            EnglishTitle = reader.IsDBNull(reader.GetOrdinal("EnglishTitle")) ? null : reader.GetString(reader.GetOrdinal("EnglishTitle")),
                            HindiTitle = reader.IsDBNull(reader.GetOrdinal("HindiTitle")) ? null : reader.GetString(reader.GetOrdinal("HindiTitle")),
                            Category = reader.IsDBNull(reader.GetOrdinal("Category")) ? null : reader.GetString(reader.GetOrdinal("Category")),
                            Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? null : reader.GetString(reader.GetOrdinal("Name")),
                            Date = reader.IsDBNull(reader.GetOrdinal("Date")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Date")),
                            CreatedDate = reader.IsDBNull(reader.GetOrdinal("CreatedDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                            ImagePath = reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? null : reader.GetString(reader.GetOrdinal("ImagePath")),
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                            Tag = reader.IsDBNull(reader.GetOrdinal("Tag")) ? null : reader.GetString(reader.GetOrdinal("Tag")),
                            Slug = reader.IsDBNull(reader.GetOrdinal("Slug")) ? null : reader.GetString(reader.GetOrdinal("Slug"))
                        };

                        newsPostsList.Add(newsPost);
                    }
                }
            }

            return newsPostsList;
        }
        public Categories GetCategoriesById(int id)
        {
            Categories categories = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Proc_GetCategoriesById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        categories = new Categories
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? null : reader.GetString(reader.GetOrdinal("Name")),
                            IsActive = reader.IsDBNull(reader.GetOrdinal("IsActive")) ? false : reader.GetBoolean(reader.GetOrdinal("IsActive")),
                            IsActiveForHome = reader.IsDBNull(reader.GetOrdinal("IsActiveForHome")) ? false : reader.GetBoolean(reader.GetOrdinal("IsActiveForHome"))
                        };

                    }
                }
            }

            return categories;
        }
        public List<Categories> GetCategoriesList()
        {
            List<Categories> list = new List<Categories>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from Categories", con); // Assume you have a stored procedure for this
                cmd.CommandType = CommandType.Text;// Handle null values

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Categories item = new Categories
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? null : reader.GetString(reader.GetOrdinal("Name")),
                            IsActive = reader.IsDBNull(reader.GetOrdinal("IsActive")) ? false : reader.GetBoolean(reader.GetOrdinal("IsActive")),
                            IsActiveForHome = reader.IsDBNull(reader.GetOrdinal("IsActiveForHome")) ? false : reader.GetBoolean(reader.GetOrdinal("IsActiveForHome"))
                        };

                        list.Add(item);
                    }
                }
            }

            return list;
        }
        public List<Categories> GetActiveCategoriesDDL()
        {
            List<Categories> list = new List<Categories>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from Categories where IsActive = 1", con); // Assume you have a stored procedure for this
                cmd.CommandType = CommandType.Text;// Handle null values

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Categories item = new Categories
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? null : reader.GetString(reader.GetOrdinal("Name")),
                            IsActive = reader.IsDBNull(reader.GetOrdinal("IsActive")) ? false : reader.GetBoolean(reader.GetOrdinal("IsActive")),
                            IsActiveForHome = reader.IsDBNull(reader.GetOrdinal("IsActiveForHome")) ? false : reader.GetBoolean(reader.GetOrdinal("IsActiveForHome"))
                        };

                        list.Add(item);
                    }
                }
            }

            return list;
        }
        public void SaveOrUpdateCategories(Categories model)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Proc_SaveOrUpdateCategories", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.Parameters.AddWithValue("@Name", model.Name ?? string.Empty);
                cmd.Parameters.AddWithValue("@IsActive", model.IsActive);
                cmd.Parameters.AddWithValue("@IsActiveForHome", model.IsActiveForHome);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateIsActiveCategories(int id, string type = "isactive")
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = type == "isactive"
                    ? @"UPDATE Categories SET IsActive = IsActive ^ 1 WHERE id = @Id"
                    : @"UPDATE Categories SET IsActiveForHome = IsActiveForHome ^ 1 WHERE id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion


        #region Account Controller
        public int InsertUser(AddUser user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("Proc_AddUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Adding parameters
                    command.Parameters.AddWithValue("@Username", user.username);
                    command.Parameters.AddWithValue("@Email", user.email);
                    command.Parameters.AddWithValue("@Password", user.password);

                    //// Output parameter to capture the new user's ID
                    //SqlParameter userIdParam = new SqlParameter
                    //{
                    //    ParameterName = "@UserId",
                    //    SqlDbType = SqlDbType.Int,
                    //    Direction = ParameterDirection.Output
                    //};
                    //command.Parameters.Add(userIdParam);

                    // Open the connection
                    connection.Open();

                    // Execute the command
                    command.ExecuteNonQuery();

                    // Retrieve the newly created UserId
                    //int newUserId = (int)userIdParam.Value;

                    return 1;
                }
            }
        }
        public int? VerifyUserLogin(Login login)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("Proc_VerifyUserLogin", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Adding parameters
                    command.Parameters.AddWithValue("@UsernameOrEmail", login.username);
                    command.Parameters.AddWithValue("@Password", login.password);

                    // Output parameter to capture the user ID if login is successful
                    SqlParameter userIdParam = new SqlParameter
                    {
                        ParameterName = "@UserId",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(userIdParam);

                    // Open the connection
                    connection.Open();

                    // Execute the command
                    command.ExecuteNonQuery();

                    // Retrieve the UserId if login is successful
                    if (userIdParam.Value != DBNull.Value)
                    {
                        return (int)userIdParam.Value;
                    }
                    else
                    {
                        return null; // Login failed
                    }
                }
            }
        }
        #endregion


        #region Slider
        public void SaveOrUpdateHomeSlider(HomeSlider homeSlider)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Proc_AddOrUpdateHomeSlider", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", homeSlider.Id);
                cmd.Parameters.AddWithValue("@Title", homeSlider.Title ?? string.Empty);
                cmd.Parameters.AddWithValue("@TitleSlug", homeSlider.TitleSlug ?? string.Empty);
                cmd.Parameters.AddWithValue("@Date", homeSlider.Date ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DateString", homeSlider.DateString ?? string.Empty);
                cmd.Parameters.AddWithValue("@CreatedDate", homeSlider.CreatedDate ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ImagePath", homeSlider.ImagePath ?? string.Empty);
                cmd.Parameters.AddWithValue("@isShowOnHome", homeSlider.isShowOnHome);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public HomeSlider GetHomeSliderById(int id)
        {
            HomeSlider homeSlider = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from HomeSlider where id = @Id", con); // Assuming the SP is named "GetHomeSliderById"
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        homeSlider = new HomeSlider
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.IsDBNull(reader.GetOrdinal("Title")) ? null : reader.GetString(reader.GetOrdinal("Title")),
                            TitleSlug = reader.IsDBNull(reader.GetOrdinal("TitleSlug")) ? null : reader.GetString(reader.GetOrdinal("TitleSlug")),
                            Date = reader.IsDBNull(reader.GetOrdinal("Date")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Date")),
                            DateString = reader.IsDBNull(reader.GetOrdinal("Date")) ? null : reader.GetOrdinal("Date").ToString("MMM dd, yyyy"),
                            CreatedDate = reader.IsDBNull(reader.GetOrdinal("CreatedDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                            ImagePath = reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? null : reader.GetString(reader.GetOrdinal("ImagePath")),
                            isShowOnHome = reader.IsDBNull(reader.GetOrdinal("isShowOnHome")) ? false : reader.GetBoolean(reader.GetOrdinal("isShowOnHome"))
                        };
                    }
                }
            }

            return homeSlider;
        }

        public List<HomeSlider> GetSliderList()
        {
            List<HomeSlider> list = new List<HomeSlider>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from HomeSlider", con); // Assume you have a stored procedure for this
                cmd.CommandType = CommandType.Text;// Handle null values

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HomeSlider item = new HomeSlider
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.IsDBNull(reader.GetOrdinal("Title")) ? null : reader.GetString(reader.GetOrdinal("Title")),
                            TitleSlug = reader.IsDBNull(reader.GetOrdinal("TitleSlug")) ? null : reader.GetString(reader.GetOrdinal("TitleSlug")),
                            Date = reader.IsDBNull(reader.GetOrdinal("Date")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Date")),
                            DateString = reader.IsDBNull(reader.GetOrdinal("Date")) ? null : reader.GetDateTime(reader.GetOrdinal("Date")).ToString("MMM dd, yyyy"),
                            CreatedDate = reader.IsDBNull(reader.GetOrdinal("CreatedDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                            ImagePath = reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? null : reader.GetString(reader.GetOrdinal("ImagePath")),
                            isShowOnHome = reader.IsDBNull(reader.GetOrdinal("isShowOnHome")) ? false : reader.GetBoolean(reader.GetOrdinal("isShowOnHome"))
                        };

                        list.Add(item);
                    }
                }
            }

            return list;
        }
        public List<HomeSlider> GetSliderListForHome()
        {
            List<HomeSlider> list = new List<HomeSlider>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from HomeSlider where isShowOnHome = 1", con); // Assume you have a stored procedure for this
                cmd.CommandType = CommandType.Text;// Handle null values

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HomeSlider item = new HomeSlider
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.IsDBNull(reader.GetOrdinal("Title")) ? null : reader.GetString(reader.GetOrdinal("Title")),
                            TitleSlug = reader.IsDBNull(reader.GetOrdinal("TitleSlug")) ? null : reader.GetString(reader.GetOrdinal("TitleSlug")),
                            Date = reader.IsDBNull(reader.GetOrdinal("Date")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Date")),
                            DateString = reader.IsDBNull(reader.GetOrdinal("Date")) ? null : reader.GetDateTime(reader.GetOrdinal("Date")).ToString("MMM dd, yyyy"),
                            CreatedDate = reader.IsDBNull(reader.GetOrdinal("CreatedDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                            ImagePath = reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? null : reader.GetString(reader.GetOrdinal("ImagePath")),
                            isShowOnHome = reader.IsDBNull(reader.GetOrdinal("isShowOnHome")) ? false : reader.GetBoolean(reader.GetOrdinal("isShowOnHome"))
                        };

                        list.Add(item);
                    }
                }
            }

            return list;
        }
        public int DeleteSliderById(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Delete HomeSlider where id = @id", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            return 1;
        }
        public void UpdateIsShowOnHome(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE HomeSlider SET isShowOnHome = isShowOnHome ^ 1 WHERE id = @Id", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
    }
}