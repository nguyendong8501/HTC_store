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
    public partial class NhapHang : Form
    {
        public NhapHang()
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

        private void labelKH_Click(object sender, EventArgs e)
        {
            KhachHang frm = new KhachHang();
            frm.Show();
            this.Hide();
        }

        private void lbBanHang_Click(object sender, EventArgs e)
        {
            BanHang frm = new BanHang();
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

        private void lbNhanVien_Click(object sender, EventArgs e)
        {
            NhanVien frm = new NhanVien();
            frm.Show();
            this.Hide();
        }
        public void Getdata()
        {
            string query = "select * from nhaphang";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "nhaphang");
            dgvnn.DataSource = ds.Tables["nhaphang"];
        }
        public void getManv()
        {
            string query = "select * from nhanvien";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "nhanvien");
            cbnv.DataSource = ds.Tables["nhanvien"];
            cbnv.DisplayMember = "Mã nhân viên";
            cbnv.ValueMember = "Tên nhân viên";
        }
        public void getMasp()
        {
            string query = "select * from sanpham";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "sanpham");
            cbmasp.DataSource = ds.Tables["sanpham"];
            cbmasp.DisplayMember = "Mã sản phẩm";
            cbmasp.ValueMember = "Tên sản phẩm";
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
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void NhapHang_Load(object sender, EventArgs e)
        {
            Getdata();
            getManv();
            getMasp();
            getMath();
        }

        private void cbmasp_SelectedIndexChanged(object sender, EventArgs e)
        {
            txttensp.Text = cbmasp.SelectedValue.ToString();
        }

        private void cbnv_SelectedIndexChanged(object sender, EventArgs e)
        {
            txttennv.Text = cbnv.SelectedValue.ToString();
        }

        private void cbth_SelectedIndexChanged(object sender, EventArgs e)
        {
            txttenth.Text = cbth.SelectedValue.ToString();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string mahdn = txtmahdn.Text;
            string masp = cbmasp.Text;
            string manv = cbnv.Text;
            string tensp = txttensp.Text;
            string tennv = txttennv.Text;
            DateTime date = dtnn.Value;
            int soluong = Convert.ToInt32(num2.Value.ToString());
            int gianhap = Convert.ToInt32(txtgianhap.Text);
            string math = cbth.Text;
            string tenth = txttenth.Text;
            int total = soluong * gianhap;
            txtotal.Text = total.ToString();
            string sql = "insert into nhaphang ([Mã hóa đơn nhập],[Mã sản phẩm],[Tên sản phẩm],[Mã nhân viên],[Tên nhân viên],[Ngày nhập],[Số lượng],[Giá nhập],[Mã thương hiệu],[Tên thương hiệu],[Tổng tiền])VALUES('" + mahdn + "','" + masp + "',N'" + tensp + "','" + manv + "',N'" + tennv + "','" + date + "','" + soluong + "','" + gianhap + "','" + math + "',N'" + tenth + "','" + total + "')";
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

        private void dgvnn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtmahdn.Enabled = false;
                btnthem.Enabled = false;
                btnsearch.Enabled = false;
                btnupdate.Enabled = true;
                btndel.Enabled = true;
                DataGridViewRow row = this.dgvnn.Rows[e.RowIndex];
                txtmahdn.Text = row.Cells[0].Value.ToString();
                cbmasp.SelectedItem = row.Cells[1].Value.ToString();
                txttensp.Text = row.Cells[2].Value.ToString();
                cbnv.SelectedItem = row.Cells[3].Value.ToString();
                txttennv.Text = row.Cells[4].Value.ToString();
                dtnn.Text= row.Cells[5].Value.ToString();
                num2.Value = int.Parse(row.Cells[6].Value.ToString());
                txtgianhap.Text = row.Cells[7].Value.ToString();
                cbth.SelectedItem = row.Cells[8].Value.ToString();
                txttenth.Text = row.Cells[9].Value.ToString();
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string mahdn = txtmahdn.Text;
            string masp = cbmasp.Text;
            string manv = cbnv.Text;
            string tensp = txttensp.Text;
            string tennv = txttennv.Text;
            DateTime date = dtnn.Value;
            int soluong = Convert.ToInt32(num2.Value.ToString());
            int gianhap = Convert.ToInt32(txtgianhap.Text);
            string math = cbth.Text;
            string tenth = txttenth.Text;
            int total = soluong * gianhap;
            txtotal.Text = total.ToString();
            string sql = "update nhaphang set [Mã hóa đơn nhập]='" + mahdn + "',[Mã sản phẩm]='" + masp + "',[Tên sản phẩm]=N'" + tensp + "',[Mã nhân viên]='" + manv + "',[Tên nhân viên]=N'" + tennv + "',[Ngày nhập]='" + date + "',[Số lượng]='" + soluong + "',[Giá nhập]='" + gianhap + "',[Mã thương hiệu]='" + math + "',[Tên thương hiệu]=N'" + tenth + "',[Tổng tiền]='" + total + "' where [Mã hóa đơn nhập]='"+mahdn+"'";
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

        private void btndel_Click(object sender, EventArgs e)
        {
            string sql = "delete from nhaphang where [Mã hóa đơn nhập]='" + txtmahdn.Text + "' ";
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
            txtmahdn.Text = "";
            txtmahdn.Enabled = true;
            num2.Value = default;
            txtgianhap.Text = "";
            txtsearch.Text = "";
            dgvsearch.DataSource = null;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            btnthem.Enabled = false;
            string search = txtsearch.Text;
            string query = "select * from nhaphang where [Tên sản phẩm] like N'%" + search + "%'";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "nhaphang");
            dgvsearch.DataSource = ds.Tables["nhaphang"];
        }
    }
}
