using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using IIModel;

namespace GridExample
{
    public partial class Default : System.Web.UI.Page
    {

        private IEnumerable<Table_1> table1;
        Image sortImage = new Image();

        public Default()
        {

        }

    
        public string SortDireaction
        {
            get
            {
                if (ViewState["SortDireaction"] == null)
                    return string.Empty;
                else
                    return ViewState["SortDireaction"].ToString();
            }
            set
            {
                ViewState["SortDireaction"] = value;
            }
        }
        private string _sortDirection;
        private  OrderDirection _orderDirection;
        protected void Page_Load(object sender, EventArgs e)
        {
            IIEntities entities = new IIEntities();
            table1 = (entities.Table_1).ToList();
            Filter();
            BindGrid();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            SetSortDirection(SortDireaction);
            if (table1 != null)
            {
                //Sort the data.
                table1 = table1.OrderByDynamic(e.SortExpression, _orderDirection);

                BindGrid();
               // dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;

                GridView1.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in GridView1.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = GridView1.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                GridView1.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
            }
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        void BindGrid()
        {

            GridView1.DataSource = table1.ToList();
            GridView1.DataBind();
        }
        protected void SetSortDirection(string sortDirection)
        {
            if (sortDirection == "ASC")
            {
                _sortDirection = "DESC";
                _orderDirection = OrderDirection.Descending;

                sortImage.ImageUrl = "~/Content/Images/view_sort_ascending.png";

            }
            else
            {
                _sortDirection = "ASC";
                _orderDirection = OrderDirection.Ascending;
                sortImage.ImageUrl = "~/Content/Images/view_sort_descending.png";
            }
        }

        private void Filter()
        {
            if (txtCategory.Text.Trim().Length > 0)
            {
                table1 = from m in table1
                         where m.Category.ToLower().Contains(txtCategory.Text.Trim().ToLower())
                         select m;
            }

            BindGrid();
        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            Filter();
            
           
        }

    }

    public enum OrderDirection
    {
        Ascending,
        Descending
    }

    public static class LinqExtensions
    {
        public static IEnumerable<T> OrderByDynamic<T>(this IEnumerable<T> source, string propertyName, OrderDirection direction = OrderDirection.Ascending)
        {
            if (direction == OrderDirection.Ascending)
                return source.OrderBy(x => x.GetType().GetProperty(propertyName).GetValue(x, null));
            else
                return source.OrderByDescending(x => x.GetType().GetProperty(propertyName).GetValue(x, null));
        }
    }
}