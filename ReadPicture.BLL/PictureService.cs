using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadPicture.Dal;
using ReadPicture.Model;

namespace ReadPicture.BLL
{
    public class PictureService
    {
        Dal.PictureDal pictureDal = new Dal.PictureDal();

        public Picture readSingle(string fastDfsFileName)
        {
            return pictureDal.GetPicture(fastDfsFileName);
        }
    }
}
