using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using LTCSDL.BLL;
using LTCSDL.DAL.DTO;

namespace WebApplication1.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        public CategoriesDTO cate;
        public int CateID = 19;
        public string name = "Car";
        public string desciption = "Toyota, Honda, Mercedes, ...";
        public string name1 = "Eggs";
        public string desciption1 = "Eggs and protein";
        public List<CategoriesDTO> listall;
        public List<CategoriesDTO> listupdate;
        public List<CategoriesDTO> listdelete;
        public List<CategoriesDTO> listinsert;
        public string msg;
        CategoriesBLL srv;
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
            srv = new CategoriesBLL();
        }

        public void OnGet()
        {
            //cate = new CategoriesDTO();
            ////string msg = "";
            //cate = srv.getCategoryById(2, out msg);

            listall = new List<CategoriesDTO>();
            listall = srv.getCategories();

            listupdate = new List<CategoriesDTO>();
            srv.update(name, desciption);
            listupdate = srv.getCategories();

            listinsert = new List<CategoriesDTO>();
            srv.insert(name1, desciption1);
            listinsert = srv.getCategories();

            listdelete = new List<CategoriesDTO>();
            srv.delete(CateID);
            listdelete = srv.getCategories();
        }
    }
}
