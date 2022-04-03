
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    public static DataTable dt = new DataTable();
    public static string ApiURL = "http://localhost:60742/api";
       
    public _Default()
    {
        try
        {
            dt.Columns.Add("OperationResult", typeof(string));
        }
        catch
        { }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            getTime();
           
        }
    }


    public string ApiEvet(string URL, Method method)
    {
        string Result = "";
        try
        {
            var client = new RestClient(URL);
            client.Timeout = -1;
            var request = new RestRequest(method);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            string json = response.Content;
            var objects = JObject.Parse(json);

            foreach (KeyValuePair<String, JToken> app in objects)
            {
                var appName = app.Key;
                if (app.Key == "message")
                {
                    Result = app.Value.ToString();
                    LogInsert(app.Value.ToString());
                }
            }
        }
        catch
        {

        }
        return Result;
    }
   


    protected void btnIncreaseHour_Click(object sender, EventArgs e)
    {
        try
        {          
            lblHour.Text = ApiEvet(ApiURL + "/Hour/increase_time?AddHour=" + txtHour.Text, Method.POST);  
        }
        catch
        {
           
        }
    }

    void getTime()
    {

        try
        {
            lblHour.Text = ApiEvet(ApiURL + "/Hour/get_time", Method.GET);

        }
        catch(Exception ex)
        {
           
        }
    }

    void LogInsert(string Value)
    {
        dt.Rows.Add(Value);
        rp.DataSource = dt;
        rp.DataBind();

    }


    protected void btnGetProduct_Click(object sender, EventArgs e)
    {
        try
        {          
            lblProductResult.Text = ApiEvet(ApiURL + "/Product/get_product_info?ProductCode=" + txtProductCode.Text, Method.GET);
        }
        catch (Exception ex)
        {

        }
    }

    protected void btncreate_product_Click(object sender, EventArgs e)
    {
        try
        {            
            lblProductResult.Text = ApiEvet(ApiURL + "/Product/create_product?ProductCode=" + txtProductCode.Text + "&Price=" + txtPrice.Text + "&Stock=" + txtStock.Text,Method.POST);
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnCampaignCreate_Click(object sender, EventArgs e)
    {
        try
        {
            lblCampaignResult.Text = ApiEvet(ApiURL + "/Campaign/create_campaign?Name=" + txtCampaignName.Text + "&ProductCode=" + txtCampaignProduct.Text + "&Duration=" + txtCampaignDuration.Text + "&PriceManipulationLimit=" + txtCampaignLimit.Text + "&TargetSalesCount=" + txtCampaignTargetSalesCount.Text,Method.POST);

        }
        catch (Exception ex)
        {

        }
    }

    protected void btnget_campaign_info_Click(object sender, EventArgs e)
    {
        try
        {            
            lblCampaignResult.Text = ApiEvet(ApiURL + "/Campaign/get_campaign_info?Name=" + txtCampaignName.Text, Method.GET);
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnOrderCreate_Click(object sender, EventArgs e)
    {
        try
        {
           lblOrderResult.Text = ApiEvet(ApiURL + "/Order/create_order?ProductCode=" + txtOrderProduct.Text + "&Quantity=" + txtOrderQuantity.Text,Method.POST);
        }
        catch (Exception ex)
        {

        }
    }
}