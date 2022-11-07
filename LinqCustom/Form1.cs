using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Data.Linq;

namespace LinqCustom
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            dm_khachhang dmkh = new dm_khachhang();
            DataDataContext dataContext = new DataDataContext();
            dmkh.id = Convert.ToInt32(txt_stt.Text);
            dmkh.khachhang_loai = radioButton1.Checked == true ? 0 : 1;
            dmkh.khachhang_ma = txt_mkh.Text;
            dmkh.khachhang_mst = txt_mst.Text;
            dmkh.khachhang_ten = txt_tenkh.Text;
            dmkh.khachhang_ghichu = txt_ghichu.Text;
            dmkh.doanhnghiep_mst = txt_mstdn.Text;
            dataContext.dm_khachhangs.InsertOnSubmit(dmkh);
            dataContext.SubmitChanges();
            Form1_Load(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dm_khachhang dmkh = new dm_khachhang();
            DataDataContext dataContext = new DataDataContext();
            var Lis = (from s in dataContext.dm_khachhangs select s).ToList();
            dataGridView1.DataSource = Lis;

            txt_stt.Text="";
            radioButton1.Checked= false;
            radioButton2.Checked = false;
            txt_mkh.Text = "";
            txt_mst.Text="";
            txt_tenkh.Text = "";
            txt_ghichu.Text = "";
            txt_mstdn.Text = "";

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            {
                dm_khachhang dmkh = new dm_khachhang();
                DataDataContext dataContext = new DataDataContext();
                dmkh = dataContext.dm_khachhangs.Where(s => s.id == Convert.ToInt32(txt_stt.Text)).Single();
                dmkh.khachhang_loai = radioButton1.Checked == true ? 0 : 1;
                dmkh.khachhang_ma = txt_mkh.Text;
                dmkh.khachhang_mst = txt_mst.Text;
                dmkh.khachhang_ten = txt_tenkh.Text;
                dmkh.khachhang_ghichu = txt_ghichu.Text;
                dmkh.doanhnghiep_mst = txt_mstdn.Text;
                dataContext.SubmitChanges();
                Form1_Load(sender, e);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
                return;
            txt_stt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "0")
            {
                radioButton1.Checked = true;
            }
            else
            if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "1")
            {
                radioButton2.Checked = true;
            }

            txt_mkh.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_mst.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_tenkh.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_ghichu.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_mstdn.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_stt.Text.Length == 0 || txt_mkh.Text.Length == 0 || txt_mst.Text.Length == 0 || txt_tenkh.Text.Length == 0 ||  txt_ghichu.Text.Length == 0 || txt_mstdn.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa chọn đối tượng xóa");
                    return;
                }
                if (radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    MessageBox.Show("Bạn chưa chọn loại khách hàng");
                    return;
                }
                dm_khachhang dmkh = new dm_khachhang();
                DataDataContext dataContext = new DataDataContext();
                dmkh = dataContext.dm_khachhangs.Where(s => s.id == Convert.ToInt32(txt_stt.Text)).Single();
                dmkh.khachhang_loai = radioButton1.Checked == true ? 0 : 1;
                dmkh.khachhang_ma = txt_mkh.Text;
                dmkh.khachhang_mst = txt_mst.Text;
                dmkh.khachhang_ten = txt_tenkh.Text;
                dmkh.khachhang_ghichu = txt_ghichu.Text;
                dmkh.doanhnghiep_mst = txt_mstdn.Text;
                dataContext.dm_khachhangs.DeleteOnSubmit(dmkh);
                dataContext.SubmitChanges();
                Form1_Load(sender, e);
            }
            catch
            {

            }
        }

        private void txt_search_KeyUp(object sender, KeyEventArgs e)
        {
            dm_khachhang dmkh = new dm_khachhang();
            DataDataContext dataContext = new DataDataContext();
            var Lis = (from s in dataContext.dm_khachhangs where s.id.ToString().Contains(txt_search.Text)
                       || s.khachhang_ma.ToString().Contains(txt_search.Text)
                       || s.khachhang_ten.ToString().Contains(txt_search.Text) select s).ToList() ;
            dataGridView1.DataSource = Lis;
            dmkh.khachhang_loai = radioButton1.Checked == true ? 0 : 1;
            dmkh.khachhang_ma = txt_mkh.Text;
            dmkh.khachhang_mst = txt_mst.Text;
            dmkh.khachhang_ten = txt_tenkh.Text;
            dmkh.khachhang_ghichu = txt_ghichu.Text;
            dmkh.doanhnghiep_mst = txt_mstdn.Text;
            
        }
    }
}
