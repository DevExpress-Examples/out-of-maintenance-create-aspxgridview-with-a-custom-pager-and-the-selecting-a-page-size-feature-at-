using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        CreateGridView();
    }

    private void CreateGridView()
    {
        ASPxGridView grid = new ASPxGridView { ID = "grid", DataSource = sds, KeyFieldName = "ProductID", ClientInstanceName = "grid", EnableRowsCache = false };
        grid.SettingsPager.AlwaysShowPager = true;
        grid.Load += grid_Load;
        grid.CustomCallback += grid_CustomCallback;
        grid.CustomJSProperties += grid_CustomJSProperties;
        grid.Templates.PagerBar = LoadTemplate("CustomPager.ascx");
        Page.Form.Controls.Add(grid);
        grid.DataBind();
    }
    protected void grid_Load(object sender, EventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        String position = String.Empty;
        if (cbPagerPosition.Value != null)
            position = cbPagerPosition.Value.ToString();
        switch (position)
        {
            case "PosTop":
                grid.SettingsPager.Position = PagerPosition.Top;
                break;
            case "PosBoth":
                grid.SettingsPager.Position = PagerPosition.TopAndBottom;
                break;
            case "PosBottom":
            default:
                grid.SettingsPager.Position = PagerPosition.Bottom;
                break;
        }
    }

    protected void grid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        int newPageSize;
        if (e != null)
        {
            if (!int.TryParse(e.Parameters, out newPageSize)) return;
            grid.SettingsPager.PageSize = newPageSize;
        }
    }
    protected void grid_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        e.Properties["cpPageSize"] = grid.SettingsPager.PageSize;
    }
}