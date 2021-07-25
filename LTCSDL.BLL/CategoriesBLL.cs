using System;
using System.Collections.Generic;
using System.Text;
using LTCSDL.DAL.DTO;
using LTCSDL.DAL;

namespace LTCSDL.BLL
{
    public class CategoriesBLL
    {
        CategoriesDAL dal;
        public CategoriesBLL()
        {
            dal = new CategoriesDAL();
        }

        //public int insert(string name, string description, out string msg)
        //{
        //    int res = dal.insert(name, description, out msg);
        //    return res;
        //}

        public CategoriesDTO getCategoryById(int id, out string msg)
        {
            CategoriesDTO res = new CategoriesDTO();
            res = dal.getCategoryById(id, out msg);
            return res;
        }

        public List<CategoriesDTO> getCategories()
        {
            List<CategoriesDTO> res = new List<CategoriesDTO>();

            res = dal.getCategories();
            return res;
        }

        public void update(string name, string description)
        {
            dal.update(name, description);
        }

        public void insert(string name, string description)
        {
            dal.insert(name, description);
        }
        public void delete(int CateID)
        {
            dal.delete(CateID);
        }


    }
}
