using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BakeryManagment
{
    public partial class Bakery : Form
    {
        public Bakery()
        {
            InitializeComponent();
            DisplayElements("ProductTbl", ProductsDGV);
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\saimu\OneDrive\Documents\BakeryDb.mdf;Integrated Security=True;Connect Timeout=30");


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void label13_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(0);
            DisplayElements("ProductTbl", ProductsDGV);

        }

        private void label14_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(1);
            DisplayElements("CustomerTbl", CustomersDGV);

        }

        private void label15_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(2);
            DisplayElements("CategoryTbl", CategoryDVG);
        }

        private void label16_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(3);
            DisplayElements("ProductTbl", BProductDVG);
            DisplayElements("SalesTbl", BillingListDVG);
            GetCustomer();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(4);
            CountCustomer();
            CountProduct();
            SumAmount();
        }


        private void tabPage4_Click(object sender, EventArgs e)
        {

        }



        private void ProdNameTb_TextChanged(object sender, EventArgs e)
        {

        }
        private void DisplayElements(string TName, Bunifu.UI.WinForms.BunifuDataGridView DVG)
        {
            Con.Open();
            string Query = "select * from " + TName + "";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DVG.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (ProdNameTb.Text == "" || QuantityTb.Text == "" || PriceTb.Text == "" || CatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert Into ProductTbl(ProdName,ProdCat,ProdPrice,ProdQty) values(@PN,@PC,@PP,@PQ)", Con);
                    cmd.Parameters.AddWithValue("@PN", ProdNameTb.Text);
                    cmd.Parameters.AddWithValue("@PC", CatCb.SelectedIndex.ToString());
                    cmd.Parameters.AddWithValue("@PP", PriceTb.Text);
                    cmd.Parameters.AddWithValue("@PQ", QuantityTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Added !!!");
                    Con.Close();
                    DisplayElements("ProductTbl", ProductsDGV);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void ProductsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProdNameTb.Text = ProductsDGV.SelectedRows[0].Cells[1].Value.ToString();
            QuantityTb.Text = ProductsDGV.SelectedRows[0].Cells[2].Value.ToString();
            PriceTb.Text = ProductsDGV.SelectedRows[0].Cells[3].Value.ToString();
            CatCb.Text = ProductsDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (ProdNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ProductsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (ProdNameTb.Text == "" || QuantityTb.Text == "" || PriceTb.Text == "" || CatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update ProductTbl set ProdName=@PN,ProdCat=@PC,ProdPrice=@PP,ProdQty=@PQ where ProdId =@PKey", Con);
                    cmd.Parameters.AddWithValue("@PN", ProdNameTb.Text);
                    cmd.Parameters.AddWithValue("@PC", CatCb.SelectedIndex.ToString());
                    cmd.Parameters.AddWithValue("@PP", PriceTb.Text);
                    cmd.Parameters.AddWithValue("@PQ", QuantityTb.Text);
                    cmd.Parameters.AddWithValue("@PKey", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Updated !!!");
                    Con.Close();
                    DisplayElements("ProductTbl", ProductsDGV);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int CKey = 0;
        private void CustomersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CNameTb.Text = CustomersDGV.SelectedRows[0].Cells[1].Value.ToString();
            CPhoneTb.Text = CustomersDGV.SelectedRows[0].Cells[2].Value.ToString();
            CAddressTb.Text = CustomersDGV.SelectedRows[0].Cells[3].Value.ToString();
            if (CNameTb.Text == "")
            {
                CKey = 0;
            }
            else
            {
                CKey = Convert.ToInt32(CustomersDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void AddCustBtn_Click(object sender, EventArgs e)
        {
            if (CNameTb.Text == "" || CAddressTb.Text == "" || CPhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert Into CustomerTbl(CustName,CustPhone,CustAddress) values(@CN,@CP,@CA)", Con);
                    cmd.Parameters.AddWithValue("@CN", CNameTb.Text);
                    cmd.Parameters.AddWithValue("@CP", CPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@CA", CAddressTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Added !!!");
                    Con.Close();
                    DisplayElements("CustomerTbl", CustomersDGV);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from ProductTbl where ProdId=@PKey", Con);
                    cmd.Parameters.AddWithValue("@PKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Deleted !!!");
                    Con.Close();
                    DisplayElements("ProductTbl", ProductsDGV);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void DelCustBtn_Click(object sender, EventArgs e)
        {
            if (CKey == 0)
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from CustomerTbl where CustId=@CKey", Con);
                    cmd.Parameters.AddWithValue("@CKey", CKey);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Deleted !!!");
                    Con.Close();
                    DisplayElements("CustomerTbl", CustomersDGV);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void EditCustBtn_Click(object sender, EventArgs e)
        {
            if (CNameTb.Text == "" || CAddressTb.Text == "" || CPhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update CustomerTbl set CustName=@CN,,CustPhone=@CP,CustAddress=@CA where CustId=CKey", Con);
                    cmd.Parameters.AddWithValue("@CN", CNameTb.Text);
                    cmd.Parameters.AddWithValue("@CP", CPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@CA", CAddressTb.Text);
                    cmd.Parameters.AddWithValue("@CKey", CKey);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Updated !!!");
                    Con.Close();
                    DisplayElements("CustomerTbl", CustomersDGV);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void AddCatBtn_Click(object sender, EventArgs e)
        {
            if (CatNameTb.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert Into CategoryTbl(CatName) values(@CN)", Con);
                    cmd.Parameters.AddWithValue("@CN", CatNameTb.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Added !!!");
                    Con.Close();
                    DisplayElements("CategoryTbl", CategoryDVG);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteCatBtn_Click(object sender, EventArgs e)
        {
            if (CatKey == 0)
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from CategoryTbl where CatId=@CKey", Con);
                    cmd.Parameters.AddWithValue("@CKey", CatKey);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Deleted !!!");
                    Con.Close();
                    DisplayElements("CategoryTbl", CategoryDVG);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        int CatKey = 0;
        private void CategoryDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CatNameTb.Text = CategoryDVG.SelectedRows[0].Cells[1].Value.ToString();

            if (CatNameTb.Text == "")
            {
                CatKey = 0;
            }
            else
            {
                CatKey = Convert.ToInt32(CategoryDVG.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditCatBtn_Click(object sender, EventArgs e)
        {
            if (CatNameTb.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update CategoryTbl set CatName=@CN where CatId=@CKey", Con);
                    cmd.Parameters.AddWithValue("@CN", CatNameTb.Text);

                    cmd.Parameters.AddWithValue("@CKey", CatKey);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Updated !!!");
                    Con.Close();
                    DisplayElements("CategoryTbl", CategoryDVG);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void BillsDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int BPKey = 0;
        int stock = 0;
        private void BProductDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BProdNameTb.Text = BProductDVG.SelectedRows[0].Cells[1].Value.ToString();

            BPriceTb.Text =  ProductsDGV.SelectedRows[0].Cells[3].Value.ToString();

            if (BProdNameTb.Text == "")
            {
                Key = 0;
                stock = 0;
            }
            else
            {
                Key = Convert.ToInt32(BProductDVG.SelectedRows[0].Cells[0].Value.ToString());
                stock = Convert.ToInt32(BProductDVG.SelectedRows[0].Cells[2].Value.ToString());
            }
        }
        private void GetCustomer()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select CustId from CustomerTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustId", typeof(int));
            dt.Load(Rdr);
            CustomerCb.ValueMember = "CustId";
            CustomerCb.DataSource = dt;
            Con.Close();
        }
        private void bunifuButton11_Click(object sender, EventArgs e)
        {
            BPriceTb.Text = "";
            BQtyTb.Text = "";
            BProdNameTb.Text = "";
        }
        int n = 0;
        int GrandTotal = 0;
        private void AddBillBtn_Click(object sender, EventArgs e)
        {
            if (BQtyTb.Text == "")
            {
                MessageBox.Show("Enter the Quantity!!!");
            }
            else if (Convert.ToInt32(BQtyTb.Text) > stock)
            {
                MessageBox.Show("Not Enough Stock!!!");
            }
            else
            {
                int total = Convert.ToInt32(BQtyTb.Text) * Convert.ToInt32(BPriceTb.Text);
              int totals = total - Convert.ToInt32(QDiaquentTb.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(YourBillDVG);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = BProdNameTb.Text;
                newRow.Cells[2].Value = BQtyTb.Text;
                newRow.Cells[3].Value = BPriceTb.Text;
                newRow.Cells[4].Value = totals;
                YourBillDVG.Rows.Add(newRow);
                n++;
                GrandTotal +=  totals;
                GrdTotalLbl.Text = "Rs = " + GrandTotal;
            }
        }

        private void BQtyTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveBillBtn_Click(object sender, EventArgs e)
        {
            if (CustomerCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert Into SalesTbl(Customer,SAmount,SDate) values(@CN,@SA,@SD)", Con);
                    cmd.Parameters.AddWithValue("@CN", CustomerCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@SA", GrandTotal);
                    cmd.Parameters.AddWithValue("@SD", DateTime.Today.Date);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sales Added !!!");
                    Con.Close();
                    DisplayElements("SalesTbl", BillingListDVG);
                    BPriceTb.Text = "";
                    BQtyTb.Text = "";
                    BProdNameTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void CustomerCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CountCustomer()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(" select Count(*) from CustomerTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CustLbl.Text = dt.Rows[0][0].ToString() + " Customers";
            Con.Close();
        }
        private void CountProduct()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(" select Count(*) from ProductTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ProductLbl.Text = dt.Rows[0][0].ToString() + " Items";
            Con.Close();
        }
        private void SumAmount()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(" select  Sum(SAmount) from SalesTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            SalesLbl.Text = " Rs " + dt.Rows[0][0].ToString();
            Con.Close();
        }



        private void label18_Click_1(object sender, EventArgs e)
        {
            login Obj = new login();
            Obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void GrdTotalLbl_Click(object sender, EventArgs e)
        {

        }

        private void CustLbl_Click(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void PriceTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void QDiaquentTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Bakery_Load(object sender, EventArgs e)
        {

        }
    }


}
