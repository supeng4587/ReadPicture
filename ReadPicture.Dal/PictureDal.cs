using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadPicture.Common;
using ReadPicture.Model;
using System.Data;
using System.Data.SqlClient;

namespace ReadPicture.Dal
{
    public class PictureDal
    {
        public Picture GetPicture(string fastDfsFileName)
        {
            string sql = "SELECT Id,PictureBinary,MimeType,SeoFilename,AltAttribute,TitleAttribute,IsNew,FastDfsFileName FROM Picture WHERE FastDfsFileName = @FastDfsFileName";
            SqlParameter par = new SqlParameter("@FastDfsFileName", SqlDbType.VarChar, 200);
            par.Value = fastDfsFileName;

            Picture picture = new Picture();
            DataTable dt = SqlHelper.ExecuteDataTable_connSQLServer(sql, par);

            picture.Id = int.Parse(dt.Rows[0]["Id"].ToString());
            picture.PictureBinary = (byte[])dt.Rows[0]["PictureBinary"];
            picture.MimeType = dt.Rows[0]["MimeType"].ToString();
            picture.SeoFilename = dt.Rows[0]["SeoFilename"].ToString();
            picture.AltAttribute = dt.Rows[0]["AltAttribute"].ToString();
            picture.TitleAttribute = dt.Rows[0]["TitleAttribute"].ToString();
            picture.IsNew = Convert.ToBoolean(dt.Rows[0]["IsNew"]);
            picture.FastDfsFileName = dt.Rows[0]["FastDfsFileName"].ToString();

            return picture;
        }
    }
}
