using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTC_Store
{
    public partial class BanHang : Form
    {
        public BanHang()
        {
            InitializeComponent();
        }

        private void Main_Click(object sender, EventArgs e)
        {
            HeThong frm = new HeThong();
            frm.Show();
            this.Hide();
        }

        private void lbSanPham_Click(object sender, EventArgs e)
        {
            SanPham frm = new SanPham();
            frm.Show();
            this.Hide();
        }

        private void lbNhanVien_Click(object sender, EventArgs e)
        {
            NhanVien frm = new NhanVien();
            frm.Show();
            this.Hide();
        }

        private void labelKH_Click(object sender, EventArgs e)
        {
            KhachHang frm = new KhachHang();
            frm.Show();
            this.Hide();
        }

        private void lbNhapHang_Click(object sender, EventArgs e)
        {
            NhapHang frm = new NhapHang();
            frm.Show();
            this.Hide();
        }

        private void lbThongKe_Click(object sender, EventArgs e)
        {
            ThongKe frm = new ThongKe();
            frm.Show();
            this.Hide();
        }

        private void lbBanHang_Click(object sender, EventArgs e)
        {
            BanHang frm = new BanHang();
            frm.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string mahd = txtmahd.Text;
            string masp = cbsp.Text;
            string makh = cbkh.Text;
            string tensp = txttensp.Text;
            string tenkh = txttenkh.Text;
            DateTime date = dtnb.Value;
            int soluong = Convert.ToInt32(num.Value.ToString());
            int giaban = Convert.ToInt32(txtgiaban.Text);
            string math = cbth.Text;
            string tenth = txttenth.Text;
            int total = soluong * giaban;
            txttongtien.Text = total.ToString();
            string sql = "insert into banhang ([Mã hóa đơn bán],[Mã sản phẩm],[Tên sản phẩm],[Mã khách hàng],[Tên khách hàng],[Ngày bán],[Số lượng],[Giá bán],[Mã thương hiệu],[Tên thương hiệu],[Tổng tiền])VALUES('" + mahd + "','" + masp + "',N'" + tensp + "','" + makh + "',N'" + tenkh + "','" + date + "','" + soluong + "','" + giaban + "','" + math + "',N'" + tenth + "','" +total+ "')";
            Ketnoi cn = new Ketnoi();
            bool kt = cn.thucthi(sql);
            if (kt == true)
            {
                MessageBox.Show("Thêm thành công !");
                Getdata();
            }
            else
            {
                MessageBox.Show("Lỗi ! ");
            }
        }

        private void BanHang_Load(object sender, EventArgs e)
        {
            Getdata();
            getMakh();
            getMasp();
            getMath();
        }
        public void Getdata()
        {
            string query = "select * from banhang";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "banhang");
            dgvhoadon.DataSource = ds.Tables["banhang"];
        }
        public void Gettongtien()
        {
            string query = "Select SUM([Tổng tiền]) from banhang";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "banhang");
            dgvhoadon.DataSource = ds.Tables["banhang"];
        }
        public void getMakh()
        {
            string query = "select * from khachhang";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "khachhang");
            cbkh.DataSource = ds.Tables["khachhang"];
            cbkh.DisplayMember = "Mã khách hàng";
            cbkh.ValueMember = "Tên khách hàng";
        }
        public void getMasp()
        {
            string query = "select * from sanpham";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "sanpham");
            cbsp.DataSource = ds.Tables["sanpham"];
            cbsp.DisplayMember = "Mã sản phẩm";
            cbsp.ValueMember = "Tên sản phẩm";
        }
        public void getgiasp()
        {
            string query = "select * from sanpham";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "sanpham");
            cbsp.DataSource = ds.Tables["sanpham"];
            cbsp.DisplayMember = "Tên sản phẩm";
            cbsp.ValueMember = "Giá bán";
        }
        public void getMath()
        {
            string query = "select * from thuonghieu";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "thuonghieu");
            cbth.DataSource = ds.Tables["thuonghieu"];
            cbth.DisplayMember = "Mã thương hiệu";
            cbth.ValueMember = "Tên thương hiệu";
        }
        private void btnupdate_Click(object sender, EventArgs e)
        {
            string mahd = txtmahd.Text;
            string masp = cbsp.Text;
            string makh = cbkh.Text;
            string tensp = txttensp.Text;
            string tenkh = txttenkh.Text;
            DateTime date = dtnb.Value;
            int soluong = Convert.ToInt32(num.Value.ToString());
            int giaban = Convert.ToInt32(txtgiaban.Text);
            string math = cbth.Text;
            string tenth = txttenth.Text;
            int total = soluong * giaban;
            txttongtien.Text = total.ToString();
            string sql = "update banhang set [Mã hóa đơn bán]='" + mahd + "',[Mã sản phẩm]='" + masp + "',[Tên sản phẩm]=N'" + tensp + "',[Mã khách hàng]='" + makh + "',[Tên khách hàng]=N'" + tenkh + "',[Ngày bán]='" + date + "',[Số lượng]='" + soluong + "',[Giá bán]='" + giaban + "',[Mã thương hiệu]='" + math + "',[Tên thương hiệu]=N'" + tenth + "',[Tổng tiền]='"+ total + "' where [Mã hóa đơn bán]='" + mahd + "'";
            Ketnoi cn = new Ketnoi();
            bool kt = cn.thucthi(sql);
            if (kt == true)
            {
                MessageBox.Show("Sửa thành công ! ");
                Getdata();
            }
            else
            {
                MessageBox.Show("Lỗi ! ");
            }
        }

        private void dgvhoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvhoadon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtmahd.Enabled = false;
                btnthem.Enabled = false;
                btnsearch.Enabled = false;
                btnupdate.Enabled = true;
                btndel.Enabled = true;
                DataGridViewRow row = this.dgvhoadon.Rows[e.RowIndex];
                txtmahd.Text = row.Cells[0].Value.ToString();
                cbsp.SelectedItem = row.Cells[1].Value.ToString();
                txttensp.Text = row.Cells[2].Value.ToString();
                cbkh.SelectedItem = row.Cells[3].Value.ToString();
                txttenkh.Text = row.Cells[4].Value.ToString();
                num.Value = int.Parse(row.Cells[6].Value.ToString());
                txtgiaban.Text = row.Cells[7].Value.ToString();
                cbth.SelectedItem = row.Cells[8].Value.ToString();
                txttenth.Text = row.Cells[9].Value.ToString();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txttenkh_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbkh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txttenkh.Text = cbkh.SelectedValue.ToString();
        }

        private void cbsp_SelectedIndexChanged(object sender, EventArgs e)
        {
            txttensp.Text = cbsp.SelectedValue.ToString();
        }

        private void cbth_SelectedIndexChanged(object sender, EventArgs e)
        {
            txttenth.Text = cbth.SelectedValue.ToString();
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            string sql = "delete from banhang where [Mã hóa đơn bán]='" + txtmahd.Text + "' ";
            Ketnoi cn = new Ketnoi();
            bool kt = cn.thucthi(sql);
            if (kt == true)
            {
                MessageBox.Show("Xóa thành công!");
                Getdata();
            }
            else
            {
                MessageBox.Show("Xóa thất bại !");
            }
        }

        private void btnrefesh_Click(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            btnupdate.Enabled = false;
            btndel.Enabled = false;
            btnsearch.Enabled = true;
            txtmahd.Text = "";
            txtmahd.Enabled = true;
            num.Value = default;
            txtgiaban.Text = "";
            txtsearch.Text = "";
            Getdata();
        }

        private void guna2HtmlLabel12_Click(object sender, EventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            btnthem.Enabled = false;
            string search = txtsearch.Text;
            string query = "select * from banhang where [Tên khách hàng] like N'%" + search + "%'";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "banhang");
            dgvhoadon.DataSource = ds.Tables["banhang"];
        }

        private void txttensp_TextChanged(object sender, EventArgs e)
        {

        }

        private void tongtien_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Gettongtien();
            int sc = dgvhoadon.Rows.Count;
            float thanhtien = 0;
            for (int i = 0; i < sc - 1; i++)
            {
                thanhtien += float.Parse(dgvhoadon.Rows[i].Cells["Tổng tiền"].Value.ToString());
            }
            tongtien.Text = thanhtien.ToString();
            
        }
    }
}
