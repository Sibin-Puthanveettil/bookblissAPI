using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SKbooks.Data;
using SKbooks.Models;
using SKbooksAPI.Models;
using SKbooksAPI.Models.Request;
using SKbooksAPI.Models.Response;
using System.Collections.Generic;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SKbooks.Sanath.BLL
{
    public class Customerbll
    {
            
        public BaseReponse addCustomer(RegisterReqest cust)
        {
            BaseReponse response = new BaseReponse();
            DataSet ds = new DataSet();
            DBhelper helper = new DBhelper();
            try
            {
                string sql = "select * from Customers where mobile=" + cust.mobile;
                ds = helper.ExecuteDataSet(sql);
                int CountCust = Convert.ToInt32(ds.Tables[0].Rows.Count);
                if (CountCust == 0)
                {
                    sql = "insert into Customers(Name,mobile,Password,Createddate)values('" + cust.Name + "'," + cust.mobile + ",'" + cust.Password + "','" + cust.Createddate + "')";
                    helper.Exexecutenonquery(sql);

                    sql = "select max(id) from Customers";
                    ds = helper.ExecuteDataSet(sql);
                    int id = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                    sql = "update Customers set [ProfilePic] = @ph  where id= " + id + "";
                    UpdateBlob(cust.ProfilePic, sql);

                    response.status = 1;
                    response.message = "success";
                }
                else
                {
                    response.status = 0;
                    response.message = "Customers with Same mobile number already Existed !!!!, Please Login";
                }

               
            }
            catch (Exception ex)
            {
                response.status = 0;
                response.message = "failed";
            }
            return response;

        }

        public CustomerResponse custlogin(LoginReqToken login)
        {
            DBhelper helper = new DBhelper();
            DataTable dt = new DataTable(); string ImageDataURI2 = "";
            CustomerResponse reponse = new CustomerResponse();
            string sql = "select * from Customers where mobile=" + login.mobile + " and Password='" + login.Password + "'";
            dt = helper.ExecuteDataSet(sql).Tables[0];
            int cnt = Convert.ToInt32(dt.Rows.Count);
            if (cnt > 0)
            {

                if (dt.Rows[0][5] != DBNull.Value)
                {
                    byte[] data2 = (byte[])dt.Rows[0][5];
                    ImageDataURI2 = Convert.ToBase64String(data2);
                }

                reponse.id = dt.Rows[0][0].ToString();
                reponse.CustomerName = dt.Rows[0][1].ToString();
                reponse.MobileNumber = dt.Rows[0][2].ToString();
                reponse.ProfilePic = "data:image/jpeg;base64," + ImageDataURI2;
                reponse.status = 1;
                reponse.message = "success";
            }
            else
            {
                reponse.status = 0;
                reponse.message = "Customer Not Available, Please Register";
            }
            return reponse;
        }

        public BaseReponse addcategory(category category)
        {

            BaseReponse reponse = new BaseReponse();
            try
            {
                DBhelper helper = new DBhelper();
                string sql = "insert into Categories(categoryname)values('" + category.categoryname + "')";
                helper.Exexecutenonquery(sql);
                reponse.status = 1;
                reponse.message = "success";

            }
            catch (Exception ex)
            {
                reponse.status = 0;
                reponse.message = ex.Message;
            }
            return reponse;
        }


        public BaseReponse AddLanguage(Language langu)
        {

            BaseReponse reponse = new BaseReponse();
            try
            {
                DBhelper helper = new DBhelper();
                string sql = "insert into languages(languageName)values('" + langu.languageName + "')";
                helper.Exexecutenonquery(sql);
                reponse.status = 1;
                reponse.message = "success";

            }
            catch (Exception ex)
            {
                reponse.status = 0;
                reponse.message = ex.Message;
            }
            return reponse;
        }



        public BaseReponse updateCategory(category category)
        {

            BaseReponse response = new BaseReponse();
            try
            {
                DBhelper helper = new DBhelper();
                string sql = "update Categories set categoryname='" + category.categoryname + "' where id=" + category.Id + " ";

                helper.Exexecutenonquery(sql);
                response.status = 1;
                response.message = "success";
            }
            catch (Exception ex)
            {
                response.status = 0;
                response.message = ex.Message;
            }
            return response;
        }
        public BaseReponse deletedcategory(category category)
        {

            BaseReponse reponse = new BaseReponse();

            try
            {
                DBhelper helper = new DBhelper();
                string sql = "delete from Categories where Id=" + category.Id + " ";

                helper.Exexecutenonquery(sql);
                reponse.status = 1;
                reponse.message = "success";
            }
            catch (Exception ex)
            {
                reponse.status = 0;
                reponse.message = ex.Message;
            }
            return reponse;
        }


        public BaseReponse DeleteLanguage(Language langu)
        {

            BaseReponse reponse = new BaseReponse();

            try
            {
                DBhelper helper = new DBhelper();
                string sql = "delete from languages where Id=" + langu.Id + " ";

                helper.Exexecutenonquery(sql);
                reponse.status = 1;
                reponse.message = "success";
            }
            catch (Exception ex)
            {
                reponse.status = 0;
                reponse.message = ex.Message;
            }
            return reponse;
        }




        public List<category> getcategorydata()
        {
            List<category> category_ = new List<category>();


            BaseReponse response = new BaseReponse();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {


                DBhelper helper = new DBhelper();
                string sql = "select * from Categories";

                dt = helper.ExecuteDataSet(sql).Tables[0];

                foreach (DataRow dr in dt.Rows)
                {

                    category_.Add(new category()
                    {
                        Id = Convert.ToInt32(dr[0]),

                        categoryname = dr[1].ToString()

                    });

                }




            }
            catch (Exception ex)
            {

            }
            return category_;
        }



        public List<Language> GetLanguage()
        {
            List<Language> language_ = new List<Language>();


            BaseReponse response = new BaseReponse();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {


                DBhelper helper = new DBhelper();
                string sql = "select * from languages";

                dt = helper.ExecuteDataSet(sql).Tables[0];

                foreach (DataRow dr in dt.Rows)
                {

                    language_.Add(new Language()
                    {
                        Id = Convert.ToInt32(dr[0]),

                        languageName = dr[1].ToString()

                    });

                }




            }
            catch (Exception ex)
            {

            }
            return language_;
        }


        public BaseReponse addproducts(SiteProduct product)
        {

            BaseReponse reponse = new BaseReponse();
            try
            {
                DBhelper helper = new DBhelper();

                byte[] docNull = new byte[200];

                string sql = "insert into MainProducts(Name,Description,Price,category,language,author,qnt,Doctype,doctypeDoc)values('" + product.Name + "','" + product.Description + "'," + product.Price + ",'" + product.category + "','" + product.language + "','" + product.author + "'," + product.qnt + ",'" + product.Doctype + "','" + product.doctypeDoc + "')";
                helper.Exexecutenonquery(sql);

                sql = "select max(id) from MainProducts";

                DataTable dt = new DataTable();
                dt = helper.ExecuteDataSet(sql).Tables[0];
                int id = Convert.ToInt32(dt.Rows[0][0]);
                sql = "update MainProducts set [img] = @ph  where id= " + id + "";

                UpdateBlob(product.img, sql);


                sql = "update MainProducts set [Doc] = @ph  where id= " + id + "";
                UpdateBlob(product.Doc, sql);

                reponse.status = 1;
                reponse.message = "success";
            }
            catch (Exception ex)
            {
                reponse.status = 0;
                reponse.message = ex.Message;
            }

            return reponse;
        }






        public void UpdateBlob(byte[] doc, string sql)
        {
            DBhelper helper = new DBhelper();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter();
            para[0].ParameterName = "ph";
            para[0].SqlDbType = SqlDbType.VarBinary;
            para[0].Direction = ParameterDirection.Input;
            para[0].Value = doc;
            helper.Exexecutenonquery(sql, para);
        }




        public List<ProductResponse> Getproductdata()
        {
            ProductResponse response = new ProductResponse();

            List<ProductResponse> product_ = new List<ProductResponse>();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {


                DBhelper helper = new DBhelper();
                string sql = "select * from MainProducts";

                dt = helper.ExecuteDataSet(sql).Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string ImageDataURI = ""; string ImageDataURI2 = "";
                    if (dr[6] != DBNull.Value)
                    {
                        byte[] data = (byte[])dr[6];
                        ImageDataURI = Convert.ToBase64String(data);
                    }

                    if (dr[6] != DBNull.Value)
                    {
                        byte[] data2 = (byte[])dr[10];
                        ImageDataURI2 = Convert.ToBase64String(data2);
                    }


                    product_.Add(new ProductResponse()
                    {

                        Id = Convert.ToInt32(dr[0]),
                        Name = dr[1].ToString(),
                        Description = dr[2].ToString(),
                        Price = Convert.ToInt32(dr[3]),
                        category = dr[4].ToString(),
                        author = dr[5].ToString(),
                        img = ImageDataURI,
                        language = dr[7].ToString(),
                        qnt = Convert.ToInt32(dr[8]),
                        doctype = dr[9].ToString(),
                        Doc = ImageDataURI2,
                        doctypeDoc = dr[11].ToString()
                    });

                }

            }
            catch (Exception ex)
            {
                string exMessage = ex.Message;
            }
            return product_;
        }
    }
}
