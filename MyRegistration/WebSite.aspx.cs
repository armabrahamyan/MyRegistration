﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MyRegistration
{
    public partial class WebSite : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        public string Text_Name { get { return txtbox_Name.Text; } }
         protected void Page_Load(object sender, EventArgs e)
        {
            MyRegistration.AddItems.Additems(listbox_kirmex, listbox_matanal, listbox_matlab);
            
        }
        protected void Reset()
        {
            txtbox_Name.Text = "";
            txtbox_Surname.Text = "";
            listbox_kirmex.Text = "1";
            listbox_matanal.Text = "1";
            listbox_matlab.Text = "1";
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (txtbox_Name.Text != "" && txtbox_Surname.Text != "")
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("insert into Myregistre values('" + txtbox_Name.Text + "','" + txtbox_Surname.Text + "','" + listbox_matanal.Text + "','" + listbox_matlab.Text + "','" + listbox_kirmex.Text + "')", sqlcon);
                cmd.ExecuteNonQuery();
                sqlcon.Close();            
                Response.Write("Registration was succesfuul");
                Reset();
            }
            else Response.Write("Name and Surnamer are required");
        }

        protected void btn_showdata_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowData.aspx");
            
        }
    }
}