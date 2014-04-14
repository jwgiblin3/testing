using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GridExample3.App_Code;

namespace GridExample3
{
    public partial class Grid : System.Web.UI.Page
    {
        DataTable _content;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                GetContent();
                BindGridView();
            }
        }

        private void GetContent()
        {
            _content = new DataTable();
            SqlConnection connection = new SqlConnection(Settings.GetConnectionString());

            try
            {
                connection.Open();
                string sqlStatement = "SELECT * FROM Table_1";
                if (txtCategory.Text.Trim().Length > 0)
                    sqlStatement += " where Category like '%" + txtCategory.Text.Trim() + "%' ";
                SqlCommand sqlCmd = new SqlCommand(sqlStatement, connection);
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                sqlDa.Fill(_content);

                ViewState["content"] = _content;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void BindGridView()
        {
            if (_content != null &&_content.Rows.Count > 0)
                {
                    GridView1.DataSource = _content;
                    GridView1.DataBind();
                }
        }
        protected void onGridView_Sorting(object sender, GridViewSortEventArgs e)
        {

            //Retrieve the table from the session object.
            _content = ViewState["content"] as DataTable;

            if (_content != null)
            {

                //Sort the data.
                _content.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                GridView1.DataSource = _content;
                GridView1.DataBind();
            }

        }

        private string GetSortDirection(string column)
        {

            // By default, set the sort direction to ascending.
            string sortDirection = "ASC";

            // Retrieve the last column that was sorted.
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            // Save new values in ViewState.
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            GetContent();
            BindGridView();


        }

    }
}