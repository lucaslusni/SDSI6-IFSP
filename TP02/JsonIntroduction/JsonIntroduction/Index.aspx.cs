using JsonIntroduction.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JsonIntroduction
{
    public partial class Index : System.Web.UI.Page
    {
        private const string JsonFilePath = ("C:\\Users\\Lusni\\Documents\\GitHub\\SDSI6-IFSP\\TP02\\voos.json");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadVoos();
            }
        }
        private void LoadVoos()
        {
            var json = File.ReadAllText(JsonFilePath);
            var voos = JsonConvert.DeserializeObject<List<Voo>>(json);

            ddlVoos.DataSource = voos;
            ddlVoos.DataTextField = "codigo";
            ddlVoos.DataValueField = "codigo";
            ddlVoos.DataBind();

            gvVoos.DataSource = voos;
            gvVoos.DataBind();
        }

        protected void ddlVoos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCodigo = ddlVoos.SelectedValue;
            var json = File.ReadAllText(JsonFilePath);
            var voos = JsonConvert.DeserializeObject<List<Voo>>(json);

            var selectedVoo = voos.FirstOrDefault(v => v.codigo == selectedCodigo);

            if (selectedVoo != null)
            {
                var selectedData = new List<Voo> { selectedVoo };
                var selectedJson = JsonConvert.SerializeObject(selectedData, Formatting.Indented);

                File.WriteAllText("C:\\Users\\Lusni\\Documents\\GitHub\\SDSI6-IFSP\\TP02\\selectedVoo.json", selectedJson); // Caminho para o arquivo JSON selecionado
            }
        }
    }
}