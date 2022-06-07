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
    public partial class KhachHang : Form
    {
        public KhachHang()
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
        public void Getdata()
        {
            string query = "select * from khachhang";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "khachhang");
            dgvkh.DataSource = ds.Tables["khachhang"];
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            string makh = txtmakh.Text;
            string tenkh = txttenkh.Text;
            string sdt = txtsdt.Text;
            string gt = gioitinh.Text;
            string dc = diachi.Text;
            string sql = "insert into khachhang ([Mã khách hàng],[Tên khách hàng],[Số điện thoại],[Giới tính],[Địa chỉ])VALUES('" + makh + "',N'" + tenkh + "','" + sdt + "',N'" + gt + "',N'" + dc + "')";
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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            txtmakh.Enabled = false;
            string makh = txtmakh.Text;
            string tenkh = txttenkh.Text;
            string sdt = txtsdt.Text;
            string gt = gioitinh.Text;
            string dc = diachi.Text;
            string sql = "update khachhang set [Mã khách hàng]='" + makh + "', [Tên khách hàng]=N'" + tenkh + "',[Số điện thoại]='" + sdt + "',[Giới tính]=N'" + gt + "',[Địa chỉ]=N'" + dc + "' where [Mã khách hàng]='"+makh+"'";
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

        private void dgvkh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnthem.Enabled = false;
                btnsearch.Enabled = false;
                btnupdate.Enabled = true;
                btndel.Enabled = true;
                DataGridViewRow row = this.dgvkh.Rows[e.RowIndex];
                txtmakh.Text = row.Cells[0].Value.ToString();
                txttenkh.Text = row.Cells[1].Value.ToString();
                txtsdt.Text= row.Cells[2].Value.ToString();
                gioitinh.Text= row.Cells[3].Value.ToString();
                diachi.Text= row.Cells[4].Value.ToString();
            }
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            Getdata();
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            string sql = "delete from khachhang where [Mã khách hàng]='" + txtmakh.Text + "' ";
            Ketnoi cn = new Ketnoi();
            bool kt = cn.thucthi(sql);
            if (kt == true)
            {
                MessageBox.Show("Xóa thành công!");
                Getdata();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra!");
            }
        }

        private void btnrefesh_Click(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            btnupdate.Enabled = false;
            btndel.Enabled = false;
            btnsearch.Enabled = true;
            txtmakh.Text = "";
            txtmakh.Enabled = true;
            txtsdt.Text = "";
            txtsearch.Text = "";
            txttenkh.Text = "";
            diachi.Text = "";
            gioitinh.Text = "";
            Getdata();
            dgvsearch.DataSource=null;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            btnthem.Enabled = false;
            string search = txtsearch.Text;
            string query = "select * from khachhang where [Tên khách hàng] like N'%" + search + "%'";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "khachhang");
            dgvsearch.DataSource = ds.Tables["khachhang"];
        }

        private void dgvsearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvsearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnthem.Enabled = false;
                btnsearch.Enabled = false;
                btnupdate.Enabled = true;
                btndel.Enabled = true;
                DataGridViewRow row = this.dgvkh.Rows[e.RowIndex];
                txtmakh.Text = row.Cells[0].Value.ToString();
                txttenkh.Text = row.Cells[1].Value.ToString();
                txtsdt.Text = row.Cells[2].Value.ToString();
                gioitinh.Text = row.Cells[3].Value.ToString();
                diachi.Text = row.Cells[4].Value.ToString();
            }
        }
    }
}
