using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace HTC_Store
{
    class Ketnoi
    {
        private string con_str = "";
        private SqlConnection conn = null;

        public Ketnoi()
        {
            con_str = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QLNT;Integrated Security=True";
            conn = new SqlConnection(con_str);
        }

        public bool thucthi(string sql)
        {
            try
            {
                // B1: Mở kết nối CSDL
                conn.Open();
                // B2: Tạo đối tượng thực thi
                SqlCommand cmd = new SqlCommand(sql, conn);
                // B3: Thực thi truy vấn
                cmd.ExecuteNonQuery();
                // B4: Đóng kết nối
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataSet laydulieu(string sql, string table_name)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, table_name);
            }
            catch
            {

            }
            return ds;
        }
    }
}
